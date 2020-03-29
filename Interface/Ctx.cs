using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPlugIn
{
public class Ctx
{
  private Dictionary<string, DataWapper> datas_ = new Dictionary<string, DataWapper>();
  private Dictionary<int, DataWapper>  displays_ = new Dictionary<int, DataWapper>();
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
    public bool SetDisplayImage<T>(T img, int index = 0)
    {
      DataWapper data2 = new DataWapper();
      if (!data2.SetData(img))
      {
        return false;
      }
      displays_[index] = data2;
      return true;
    }
    public Dictionary<int, DataWapper> GetDisplay()
    {
      return displays_;
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

  public bool GetCopy(out Ctx copyCtx,List<ParamDesc> desc = null)
  {
      copyCtx = new Ctx();
      var data2 = new Dictionary<string, DataWapper>();
      copyCtx.datas_ = data2;
      if(null == desc)
      {
        foreach (var item in datas_)
        {
          data2[item.Key] = item.Value;
        }
        return true;
      }
      else
      {
        foreach(var item in desc)
        {
          if (datas_.ContainsKey(item.name))
          {
            data2[item.name] = datas_[item.name];
          }
        }
        return true;
      }
      return false;
    }
}
}
