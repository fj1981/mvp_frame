using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPlugIn
{
  [DisplayName("类型")]
  public class ParamDesc
  {
    public ParamDesc() { }
    public ParamDesc(DataType typeNew, string nameNew)
    {
      type = typeNew;
      name = nameNew;
    }
    [DisplayName("类型")]
    public DataType type {
      get;
      set;
    }
    [DisplayName("名称")]
    public string name {
      get;
      set;
    }
    public override string ToString()
    {
      return "新变量";
    }
  }


  public enum PlugType
  {
    PT_FLOW,
    PT_TRIGGER,
    PT_SRC,
    PT_PROC
  }

  public interface IPlugInfo
  {
    string GetPlugName();
    string GetDescription();
    string GetUUID();
    PlugType GetPlugType();
    Type GetPropType();
  }

  public class BaseProperty
  {
    protected BaseProperty()
    {
     
    }

    [DisplayName("名称")]
    public string name
    {
      get;
      set;
    }

    [DisplayName("描述")]
    public string description
    {
      get;
      set;
    }
    [DisplayName("输入"), Category("变量描述"), TypeConverter(typeof(MyTypeConverter))]
    public List<ParamDesc> InputParams { set; get; }

    [DisplayName("输出"), Category("变量描述"), TypeConverter(typeof(MyTypeConverter))]
    public List<ParamDesc> OutputParams { set; get; }
    private class MyTypeConverter : TypeConverter
    {
      public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
      {
        if (destinationType == typeof(string) && value is List<ParamDesc>)
        {
          var ret = "";
          foreach(var aa in (value as List<ParamDesc>))
          {
            ret += aa.name;
            ret += ";";
          }
          ret.TrimEnd(';');
          if(0 == ret.Length)
          {
            ret = "无";
          }
          return ret;
        }
        return base.ConvertTo(context, culture, value, destinationType);
      }
    }
    public void UpdateDefault()
    {
      if (InputParams == null)
      {
        InputParams = GetDefaultInputsDesc();
      }
      if (OutputParams == null)
      {
        OutputParams = GetDefaultOutputsDesc();
      }
    }
    protected virtual List<ParamDesc> GetDefaultInputsDesc()
    {
      return new List<ParamDesc>();
    }

    protected virtual List<ParamDesc> GetDefaultOutputsDesc()
    {
      return new List<ParamDesc>();
    }

    public string InputName(int index)
    {
      return InputParams[index].name;
    }

    public string OutputName(int index)
    {
      return OutputParams[index].name;
    }
  }

  public interface IPlugFactory
  {
    IPlugInfo GetPlugInfo();
    IPlugin NewPlug(); 
  }

 public class BasePlugFactory : IPlugFactory
  {
    public virtual IPlugInfo GetPlugInfo() { return null; }
    public virtual IPlugin NewPlug() { return null; }
    public override string ToString()
    {
      var info = GetPlugInfo();
      if(null == info)
      {
        return "不可用工具";
      }
      else
      {
        var text = info.GetPlugName() + "   < " + info.GetUUID() + " >    ";
        text += info.GetDescription();
        return text;
      }
    }
  }

  public interface IPlugin
  {
    IPlugInfo GetPlugInfo();
    BaseProperty GetProperty();
    void SetProperty(object BaseProperty);
  }

  public interface IProcPlug : IPlugin
  {
    bool CallProcess(Ctx ctxIn,out Ctx ctxOut);
  }

  public interface ISrcPlug: IProcPlug
  {
    bool SetRunEvent(RunEvent param);
    bool Run();
    List<String> GetSupplyVideoList();
    bool SetCurentDeviceID(String devId);
  }


}
