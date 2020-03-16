using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
  public class ParamDesc
  {
    DataType type { get; set; }
    string name { get; set; }
  }


  public enum PlugType
  {
    PT_SRC,
    PT_PROC
  }

  public interface IPlugInfo
  {
    string GetPlugName();
    string GetUUID();
    PlugType GetPlugType();
    Type GetPropType();
  }

  public class BaseProperty
  {
    public string name {
      get;
      set;
    }

    [DisplayName("1 输入") ,Category("变量描述")]
    public List<ParamDesc> InputParam
    {
      get;
      set;
    }

    [DisplayName("2 输出"), Category("变量描述")]
    public List<ParamDesc> OutputParam
    {
      get;
      set;
    }
  }

  public interface IPlugFactory
  {
    IPlugInfo GetPlugInfo();
    IPlugin NewPlug();
  }

  //
  public interface IPlugin
  {
    IPlugInfo GetPlugInfo();
    BaseProperty GetProperty();
    void SetProperty(object BaseProperty);
  }

  public interface IProcPlug : IPlugin
  {
    Ctx CallProcess(Ctx ctx);
   }

  public interface ISrcPlug: IProcPlug
  {
    bool SetRunEvent(RunEvent param);
    bool Run();
  }


}
