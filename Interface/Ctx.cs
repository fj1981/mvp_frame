using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
public class Ctx
{
  private Dictionary<string, DataWapper> datas_ = new Dictionary<string, DataWapper>();
  public bool SetData<T>(string val_name, T data) {
    DataWapper data2 = new DataWapper();
    if (!data2.SetData(data))
    {
      return false;
    }
    datas_[val_name] = data2;
    return true;
  }

  public T GetData<T>(string val_name) {
    if( datas_.ContainsKey(val_name)) {
      return datas_[val_name].GetData<T>();
    }
    return default ( T );
  }

  public bool Merge(Ctx ctx)
  {
    var first = datas_;
    var second = ctx.datas_;
    if (first == null) first = new Dictionary<string, DataWapper>();
    if (second == null) return false;

    foreach (var item in second)
    {
      first[item.Key] = item.Value;
    }
    return true;
  }

  public  Ctx GetCopy()
  {
      Ctx ret = new Ctx();
      var first = new Dictionary<string, DataWapper>();
      ret.datas_ = first;
      foreach (var item in datas_)
      {
        first[item.Key] = item.Value;
      }
      return ret;
    }
}
}
