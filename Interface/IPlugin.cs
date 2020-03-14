using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
  public struct ParamDesc
  {
    ParamDesc(DataType type, string name) {
      type_ = type;
      name_ = name;
    }
    DataType type_;
    string name_;
  }

  public class IPropertyData
  {
     
  }

  public enum PlugType
  {
    PT_SRC,
    PT_PROC
  }

  public interface IPlugFactory
  {
    string GetPlugName();
    PlugType GetPlugType();
    IPlugin NewPlug();

  }

  public interface IPlugin
  {
    string Name();
    IPropertyData GetProperty();
    void SetProperty(IPropertyData prop);
 
  }

  public interface IProcPlug : IPlugin
  {
    Ctx CallProcess(Ctx ctx);
    List<ParamDesc> InputParamDesc();
    List<ParamDesc> OutputParamDesc();
  }

  public interface ISrcPlug:IPlugin
  {
    bool SetRunEvent(RunEvent param);
    bool Run();
  }
}
