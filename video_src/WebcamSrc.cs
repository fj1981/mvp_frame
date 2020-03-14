﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HalconDotNet;
using Interface;

namespace video_src
{
  public class PlugFactory : IPlugFactory
  {
    public string GetPlugName()
    {
      return WebcamSrc.PLUG_NAME;
    }

    public PlugType GetPlugType()
    {
      return PlugType.PT_SRC;
    }

    public IPlugin NewPlug()
    {
      return new WebcamSrc();
    }
  }

  public class WebcamSrc : ISrcPlug
  {
    public static String PLUG_NAME = "DirectShowVideo";
    public WebcamSrc()
    {
     // FilterInfoCollection videoDevices;
     // videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
    }


    public string Name()
    {
      return PLUG_NAME;
    }
    RunEvent param_;
    public IPropertyData GetProperty()
    {
      throw new NotImplementedException();
    }

    public void SetProperty(IPropertyData prop)
    {
      throw new NotImplementedException();
    }


    public bool SetRunEvent(RunEvent param)
    {
      param_ = param;
      return true;
    }

    public bool Run()
    {
      if(null == param_)
      {
        return false;
      }
      HObject ho_Image = null;

      HTuple hv_AcqHandle = null;
      // Initialize local and output iconic variables
      HOperatorSet.GenEmptyObj(out ho_Image);
      //Image Acquisition 01: Code generated by Image Acquisition 01
      HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb",
                                    -1, "false", "default", "[1] Microsoft Camera Rear", 0, -1, out hv_AcqHandle);
      HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "grab_timeout", 5000);
      HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
      while (!param_.stop)
      {
        ho_Image.Dispose();
        HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
        param_.NotifyLiveData(ho_Image);
        //Image Acquisition 01: Do something
      }
      HOperatorSet.CloseFramegrabber(hv_AcqHandle);
      ho_Image.Dispose();
      return true;
    }
  }


}
