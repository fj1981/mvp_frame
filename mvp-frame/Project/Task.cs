using HalconDotNet;
using MVPlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mvp_frame
{
  class Task
  {
    private NotifyImageReady notifyImageReady_; 
    public void SetShowDelegate(NotifyImageReady notifyImageReady)
    {
      notifyImageReady_ = notifyImageReady;
    }

    ToolObj toolObj_;
    public void Init(ToolObj tool)
    {
      toolObj_ = tool;
    }

    class RunData
    {
      public ToolObj toolObj;
      public RunEvent event_;
    }

    public bool Run()
    {
      if(toolObj_ == null)
      {
        return false;
      }
      ParameterizedThreadStart threadStart = new ParameterizedThreadStart(RunLive);
      Thread t = new Thread(threadStart);
      t.IsBackground = true;
      RunData rd = new RunData();
      rd.event_ = new RunEvent(notifyImageReady_, null);
      rd.toolObj = toolObj_;
      t.Start(rd);
      return true; 
    }

    static void RunLive(object data)
    {
      if (!(data is RunData))
      {
        return;
      }
      var wrap = data as RunData;
      if(null == wrap.toolObj || null == wrap.toolObj.children)
      {
        return;
      }
      var aa2 = Thread.CurrentThread.ManagedThreadId.ToString();
      //wrap.event_.NotifyLiveData(null);
      Ctx ctx = new Ctx();

      foreach (var aa in wrap.toolObj.children)
      {
        try
        {
          var plug = (aa.plug_ as IProcPlug);
    
          if (null != plug)
          {
            Ctx ctxIn, ctxOut, ctxOut1;
            if (!ctx.GetCopy(out ctxIn, plug.GetProperty()?.InputParams))
            {
              return;
            }

            plug.CallProcess(ctxIn, out ctxOut);
            if(ctxOut != null)
            {
              try {
                var show1 = ctxOut.GetDisplay()[0] as DataWapper;
                if (null != show1)
                {
                  wrap.event_.NotifyLiveData(show1.GetData<HObject>());
                  //rap.event_.NotifyCaptureData
                  //notifyImageReady_.Invoke()
                }
              }
              catch (Exception e)
              { }
              
            }

        
            if (!ctxOut.GetCopy(out ctxOut1, plug.GetProperty()?.OutputParams))
            {
              return;
            }
            ctx.Merge(ctxOut1);
          }
        }
        catch(Exception e)
        {
          break;
        }

      }
    }
  }
}
