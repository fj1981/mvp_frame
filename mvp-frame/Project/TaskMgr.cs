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
        task.Init(tool);
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
        break;
      }
      return true;
    }
  }
}
