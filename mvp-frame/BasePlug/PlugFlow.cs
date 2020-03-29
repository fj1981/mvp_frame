using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPlugIn
{
  public class PlugInfoImpl : IPlugInfo
  {
    public string GetDescription()
    {
      return "这是一个流程节点";
    }

    public string GetPlugName()
    {
      return "流程";
    }
    public PlugType GetPlugType()
    {
      return PlugType.PT_FLOW;
    }
    public Type GetPropType()
    {
      return typeof(FlowProperty);
    }

    public string GetUUID()
    {
      return FlowPlugFactory.Guid;
    }
  }

  public class FlowPlugFactory : BasePlugFactory
  {
    internal readonly static IPlugInfo pluginfo_ = new PlugInfoImpl();
    public static String Guid { get; } = "{098EFE13-A905-431F-8C07-36225CE835D8}";
    public override IPlugInfo GetPlugInfo()
    {
      return pluginfo_;
    }

    public override IPlugin NewPlug()
    {
      return new FlowPlug();
    }
  }

  public class FlowProperty : BaseProperty
  {
    [DisplayName("执行次数")]
    public int repeat_times
    {
      get;
      set;
    }
  }

  class FlowPlug : IProcPlug
  {
    FlowProperty flowProperty_ = new FlowProperty();
    public IPlugInfo GetPlugInfo()
    {
      return FlowPlugFactory.pluginfo_;
    }

    public BaseProperty GetProperty()
    {
      return flowProperty_;
    }

    public void SetProperty(object BaseProperty)
    {
      flowProperty_ = BaseProperty as FlowProperty;
    }

    public bool CallProcess(Ctx ctxIn, out Ctx ctxOut)
    {
      throw new NotImplementedException();
    }
  }
}
