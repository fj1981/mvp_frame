using MVPlugIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_frame
{
  class TaskMgr : Singleton<TaskMgr>
  {
    private List<Task> tasks_;
    private NotifyTaskStateChanged notifyTaskStateChanged_;

    private void OnTaskStateChanged(Task task2)
    {
      if(notifyTaskStateChanged_ != null)
      {
        notifyTaskStateChanged_(task2);
      }
    }

    public void SetStateChangeNotify(NotifyTaskStateChanged notify)
    {
      notifyTaskStateChanged_ = notify;
    }

    public void Init(ToolObj tools)
    {
      if(tools != null)
      {
        tools.UpdateProperty(false);
      }

      tasks_ = new List<Task>();
      foreach (var tool in tools.children)
      {
        var task = new Task();
        task.Init(tool, OnTaskStateChanged);
        tasks_.Add(task);
      }
    }


    public bool RunTasks(NotifyImageReady liveImageArrived)
    {
      if(tasks_ == null)
      {
        return false;
      }
      foreach(var task in tasks_)
      {
        task.SetShowDelegate(liveImageArrived);
        task.Run();
      }
      return true;
    }

    public bool StopAll()
    {
      if (tasks_ == null)
      {
        return false;
      }
      foreach (var task in tasks_)
      {
        task.Stop();
      }
      return true;
    }


    public bool PauseAll()
    {
      if (tasks_ == null)
      {
        return false;
      }
      foreach (var task in tasks_)
      {
        task.Pause();
      }
      return true;
    }


    public bool ResumeAll()
    {
      if (tasks_ == null)
      {
        return false;
      }
      foreach (var task in tasks_)
      {
        task.Resume();
      }
      return true;
    }


    public RunState GetTaskState()
    {
      Dictionary<RunState, int> d = new Dictionary<RunState, int>();
      foreach (var task in tasks_)
      {
        if(!d.ContainsKey(task.runState_))
        {
          d.Add(task.runState_, 1);
        }
        else
        {
          d[task.runState_]++;
        }
      }
      if (d.ContainsKey(RunState.RUNSTATE_PAUSE))
      {
        return RunState.RUNSTATE_PAUSE;
      }
      if (d.ContainsKey(RunState.RUNSTATE_RUNNING))
      {
        return RunState.RUNSTATE_RUNNING;
      }
      return RunState.RUNSTATE_INIT;
    }
  }
}
