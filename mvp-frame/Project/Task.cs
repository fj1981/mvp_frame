using Interface;
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

    public void Init(ToolObj tool)
    {

    }

    class RunData
    {
      public ISrcPlug plug;
      public RunEvent event_;
    }

    public void Run()
    {
      ISrcPlug plug = null;
      if (PlugMgr.Instance.GetSrcPlug<ISrcPlug>("", ref plug))
      {
        ParameterizedThreadStart threadStart = new ParameterizedThreadStart(RunLive);
        Thread t = new Thread(threadStart);
        t.IsBackground = true;
        RunData rd= new RunData();
        rd.event_ = new RunEvent(notifyImageReady_, null);
        rd.plug = plug;
        t.Start(rd);
        }
    }

    static void RunLive(object data)
    {
      if (data is RunData)
      {
        var wrap = data as RunData;
        wrap.plug.SetRunEvent(wrap.event_);
        wrap.plug.Run();
      }
    }
  }
}
