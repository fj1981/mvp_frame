using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPlugIn
{
  public delegate bool TriggerNotify(object p);
  public class BaseTrigger : IPlugin
  {
    virtual public IPlugInfo GetPlugInfo()
    {
      throw new NotImplementedException();
    }

    virtual public BaseProperty GetProperty()
    {
      throw new NotImplementedException();
    }

    virtual public void SetProperty(object BaseProperty)
    {
      throw new NotImplementedException();
    }
    public TriggerNotify Notify_ { set; get; }
    public bool stopState_ { set; get; }
    public object data_ { set; get; }

    protected bool Trigger()
    {
      if(Notify_ != null)
      return Notify_(data_);
      return false;
    }

    public virtual bool RunTrigger()
    {
      throw new NotImplementedException();
    }
   

  }
}
