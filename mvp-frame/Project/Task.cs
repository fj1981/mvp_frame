using HalconDotNet;
using MVPlugIn;
using System;
using System.Collections.Generic;
using System.Threading;

namespace mvp_frame
{
  public enum RunState
  {
    RUNSTATE_INIT,
    RUNSTATE_RUNNING,
    RUNSTATE_PAUSE,
    RUNSTATE_STOP,
  }
  public delegate void NotifyTaskStateChanged(Task task);
  public class Task
  {
    private NotifyImageReady notifyImageReady_;
    private NotifyTaskStateChanged notifyTaskStateChanged_;
    public void SetShowDelegate(NotifyImageReady notifyImageReady)
    {
      notifyImageReady_ = notifyImageReady;
    }

    ToolObj toolObj_;
    public void Init(ToolObj tool, NotifyTaskStateChanged notify)
    {
      toolObj_ = tool;
      notifyTaskStateChanged_ = notify;
    }
    RunState runState = RunState.RUNSTATE_INIT;
    public RunState runState_ {
      get
      {
        return runState;
      } set {
        if(runState != value)
        {
          runState = value;
          notifyTaskStateChanged_?.Invoke(this);
        }
      } 
    }
    BaseTrigger trigger_;
    Thread t_;
    ManualResetEvent event_;

    bool TriggerNotify(object p)
    {
      if(p == null)
      {
        return false;
      }
      var l = p as List<ToolObj>;
      Ctx ctx = new Ctx();
      Dictionary<int, DataWapper> dataWrap;
      foreach (var aa in l)
      {
        if (runState_ == RunState.RUNSTATE_PAUSE)
        {
          event_ = new ManualResetEvent(false);
          event_.WaitOne();
          event_ = null;
        }
        if(runState_ == RunState.RUNSTATE_STOP)
        {
          return false;
        }
        if (aa.type == PlugType.PT_TRIGGER)
        {
          continue;
        }
        try
        {
          var plug = (aa.plug_ as IProcPlug);

          if (null != plug)
          {
            Ctx ctxIn, ctxOut, ctxOut1;
            if (!ctx.GetCopy(out ctxIn, plug.GetProperty()?.InputParams))
            {
              return false;
            }

            plug.CallProcess(ctxIn, out ctxOut);
            if (ctxOut != null)
            {
              try
              {
                dataWrap = ctxOut.GetDisplay();
                if (dataWrap != null && dataWrap.ContainsKey(0))
                {
                  var show1 = dataWrap[0] as DataWapper;
                  if (null != show1)
                  {
                    notifyImageReady_(show1.GetData<HObject>());
                    //rap.event_.NotifyCaptureData
                    //notifyImageReady_.Invoke()
                  }
                }

              }
              catch (Exception e)
              { }

            }
            if (!ctxOut.GetCopy(out ctxOut1, plug.GetProperty()?.OutputParams))
            {
              return false;
            }
            ctx.Merge(ctxOut1);
          }
        }
        catch (Exception e)
        {
          break;
        }

      }

      return true;
    }

    public bool Run()
    {
      if(runState_ != RunState.RUNSTATE_INIT)
      {
        return false;
      }
      if(toolObj_ == null)
      {
        return false;
      }
      if(toolObj_.children == null)
      {
        return false;
      }
      var l = toolObj_.children;
      
      foreach (ToolObj p in l)
      {
        if(p.type == PlugType.PT_TRIGGER)
        {
          trigger_ = p.plug_ as BaseTrigger;
          break;
        }
      }
      if(trigger_ != null)
      {
        trigger_.Notify_ = TriggerNotify;
        trigger_.data_ = l;
        trigger_.stopState_ = false;
      }

      runState_ = RunState.RUNSTATE_RUNNING;
      t_ = new Thread(() => {
        if(trigger_ == null)
        {
          TriggerNotify(l);
        }
        else
        {
          trigger_.RunTrigger();
        }
        Stop();
        runState_ = RunState.RUNSTATE_INIT;
      });
      t_.IsBackground = true;
      t_.Start();
      return true;
    }

    public void Stop()
    {
      if(event_ != null)
      {
        event_.Set();
      }
      runState_ = RunState.RUNSTATE_STOP;
      if(trigger_ != null) 
      {
        trigger_.stopState_ = true;
        trigger_ = null;
      }
      t_ = null;
    }

    public void Pause()
    {
      if(runState_ == RunState.RUNSTATE_RUNNING)
      {
        runState_ = RunState.RUNSTATE_PAUSE;
      }
    }

    public void Resume()
    {
      if(runState_ == RunState.RUNSTATE_PAUSE)
      {
        runState_ = RunState.RUNSTATE_RUNNING;
        event_.Set();
      }

    }
  }
}
