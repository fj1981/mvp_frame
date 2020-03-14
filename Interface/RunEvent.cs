using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
  public delegate void NotifyImageReady(HObject ho_Image);
  public delegate HObject FuncGetImage();
  public class RunEvent
  {

    private event NotifyImageReady notifyLiveDataReady_;
    private event NotifyImageReady notifyCaptureDataReady_;
    public FuncGetImage funcGetImage_;
    public bool stop
    {
      set;
      get;
    }
    public RunEvent(NotifyImageReady notifyLiveDataReady, NotifyImageReady notifyCaptureDataReady)
    {
      notifyLiveDataReady_ = notifyLiveDataReady;
      notifyLiveDataReady_ += keepImageData;
      notifyCaptureDataReady_ = notifyCaptureDataReady;
    }
    public void NotifyLiveData(HObject ho_Image)
    {
      notifyLiveDataReady_?.Invoke(ho_Image);
    }
    public void NotifyCaptureData(HObject ho_Image)
    {
      notifyCaptureDataReady_?.Invoke(ho_Image);
    }

    public bool TriggerCapture()
    {
      if (funcGetImage_ != null)
      {
        var img = funcGetImage_();
        if (img != null)
        {
          NotifyCaptureData(img);
          return true;
        }
      }

      if (image_ != null)
      {
        NotifyCaptureData(image_);
        return true;
      }
      return false;
    }

    private void keepImageData(HObject ho_Image)
    {
      image_ = ho_Image;
    }
    private HObject image_;
  }
}
