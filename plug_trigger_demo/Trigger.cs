using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MVPlugIn
{
  public class PlugInfoImpl : IPlugInfo
  {
    public string GetDescription()
    {
      return "默认每隔1s触发一次";
    }

    public string GetPlugName()
    {
      return "软触发Demo";
    }
    public PlugType GetPlugType()
    {
      return PlugType.PT_TRIGGER;
    }
    public Type GetPropType()
    {
      return typeof(Property);
    }

    public string GetUUID()
    {
      return "{FFC916FC-624E-4EC9-8661-9A2F1BD81994}";
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
      return new Trigger();
    }

  }

  public class Property : BaseProperty
  {
    private static int objCount = 1;
    protected override List<ParamDesc> GetDefultOutputsDesc()
    {
      var ret = new List<ParamDesc>();
      ret.Add(new ParamDesc(DataType.DT_BOOL, $"Trigger{objCount++}"));
      return ret;
    }
  }

  public class Trigger : IProcPlug
  {
    IPlugInfo IPlugin.GetPlugInfo()
    {
      return PlugFactory.pluginfo_;
    }
    Property property_ = new Property();
    BaseProperty IPlugin.GetProperty()
    {
      return property_;
    }

    void IPlugin.SetProperty(object BaseProperty)
    {
      property_ = BaseProperty as Property;
    }

    public bool CallProcess(Ctx ctxIn, out Ctx ctxOut)
    {
      ctxOut = new Ctx();
      Thread.Sleep(1000);

      ctxOut.SetData<bool>(property_.OutputName(0), true);
      return true;
    }
  }
}
