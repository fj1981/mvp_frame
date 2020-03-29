﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using HalconDotNet;
using MVPlugIn;

namespace MVPlugIn
{
  public class PlugInfoImpl :IPlugInfo {
    public string GetPlugName()
    {
      return "摄像头采集";
    }

    public string GetDescription()
    {
      return "使用电脑的摄像头采集";
    }

    public PlugType GetPlugType()
    {
      return PlugType.PT_SRC;
    }
    public Type GetPropType()
    {
      return typeof(WebcamProperty);
    }

    public string GetUUID()
    {
      return "{EB7C4F05-7341-45D1-94EF-2EDAC3F6C8EB}";
    }
  }

  public class PlugFactory : BasePlugFactory
  {
    internal readonly static IPlugInfo pluginfo_ = new PlugInfoImpl();
    public override IPlugInfo GetPlugInfo()
    {
      return pluginfo_;
    }

    public override IPlugin NewPlug()
    {
      return new WebcamSrc();
    }

  }

  public class WebcamProperty  :BaseProperty
  {
    private static int objCount = 1;
    public WebcamProperty()
    {
 
    }

    protected override List<ParamDesc> GetDefultInputsDesc()
    {
      var ret = new List<ParamDesc>();
      ret.Add(new ParamDesc(DataType.DT_BOOL, $"vi{objCount++}"));
      return ret;
    }

    protected override List<ParamDesc> GetDefultOutputsDesc()
    {
      var ret = new List<ParamDesc>();
      ret.Add(new ParamDesc(DataType.DT_IMAGEOBJ, $"vo{objCount++}"));
      return ret;
    }
  }


  public class WebcamSrc : ISrcPlug
  {
    WebcamProperty property_ = new WebcamProperty();
    public WebcamSrc()
    {
     // FilterInfoCollection videoDevices;
     // videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
    }

    RunEvent param_;
    public IPlugInfo GetPlugInfo()
    {
      return PlugFactory.pluginfo_;
    }

    BaseProperty IPlugin.GetProperty()
    {
      return property_;
    }

    public void SetProperty(object prop)
    {
      property_ = prop as WebcamProperty;
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

    public bool CallProcess(Ctx ctxIn,out Ctx ctxOut)
    {
      var b =  ctxIn.GetData<bool>(property_.InputName(0));
      ctxOut = null;
      if (b)
      {
        ctxOut = new Ctx();
        HObject ho_Image = null;

        HTuple hv_AcqHandle = null;
        // Initialize local and output iconic variables
        HOperatorSet.GenEmptyObj(out ho_Image);
        //Image Acquisition 01: Code generated by Image Acquisition 01
        HOperatorSet.OpenFramegrabber("DirectShow", 1, 1, 0, 0, 0, 0, "default", 8, "rgb",
                                      -1, "false", "default", "[1] Microsoft Camera Rear", 0, -1, out hv_AcqHandle);
        HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "grab_timeout", 5000);
        HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
          ho_Image.Dispose();
         HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
         HOperatorSet.CloseFramegrabber(hv_AcqHandle);
        ctxOut.SetData(property_.OutputName(0), ho_Image);
        ctxOut.SetDisplayImage(ho_Image);
      }
      return true;
    }

   

   
  }


}
