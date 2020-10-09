using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPlugIn
{
  class PlugInfoImpl : IPlugInfo
  {
    public string GetDescription()
    {
      return "图像二值化";
    }

    public string GetPlugName()
    {
      return "二值化处理";
    }
    public PlugType GetPlugType()
    {
      return PlugType.PT_PROC;
    }
    public Type GetPropType()
    {
      return typeof(Property);
    }

    public string GetUUID()
    {
      return "{8C5FC210-E145-4340-9E20-5F9675DEB2EE}";
    }
  }

  class PlugFactory : BasePlugFactory
  {
    internal readonly static IPlugInfo pluginfo_ = new PlugInfoImpl();
    public override IPlugInfo GetPlugInfo()
    {
      return pluginfo_;
    }

    public override IPlugin NewPlug()
    {
      return new ThresholdImpl();
    }

  }

  class Property : BaseProperty
  {
    private static int objCount = 1;
    protected override List<ParamDesc> GetDefaultInputsDesc()
    {
      var ret = new List<ParamDesc>();
      ret.Add(new ParamDesc(DataType.DT_IMAGEOBJ, $"Image{objCount++}"));
      ret.Add(new ParamDesc(DataType.DT_INT, $"Threshold{objCount++}"));
      return ret;
    }
    protected override List<ParamDesc> GetDefaultOutputsDesc()
    {
      var ret = new List<ParamDesc>();
      ret.Add(new ParamDesc(DataType.DT_IMAGEOBJ, $"Image{objCount++}"));
      return ret;
    }
  }

  public class ThresholdImpl : IProcPlug
  {
    Property property_ = new Property();
    public bool CallProcess(Ctx ctxIn, out Ctx ctxOut)
    {
      ctxOut = new Ctx();
      HObject image =  ctxIn.GetData<HObject>(property_.InputName(0));
      int threshold = ctxIn.GetData<int>(property_.InputName(1));
      if(threshold == 0)
      {
        threshold = 64;
      }
      HObject grayimage = null;
      HOperatorSet.GenEmptyObj(out grayimage);
      HOperatorSet.Rgb1ToGray(image, out grayimage);
      HObject result = null;
      HOperatorSet.GenEmptyObj(out result);
      HOperatorSet.Threshold(grayimage,out result, 0, threshold);
      ctxOut.SetData(property_.OutputName(0), result);
      ctxOut.SetDisplayImage(result);
      return true;
    }

    public IPlugInfo GetPlugInfo()
    {
      return PlugFactory.pluginfo_;
    }

    public BaseProperty GetProperty()
    {
      return property_;
    }

    public void SetProperty(object prop)
    {
      property_ = prop as Property;
    }
  }
}