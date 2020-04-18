using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPlugIn
{
  public enum DataType
  {
    DT_UNKNOWN,
    DT_BOOL,
    DT_INT,
    DT_DOUBLE,
    DT_STRING,
    DT_IMAGEOBJ,
    DT_POINT,
    DT_SIZE,
    DT_RECT,
    DT_ARRAY,
  }

  public class DataWapper
  {
    static DataType TypeFromData<T>(T data)
    {
      if (data is bool)
      {
        return DataType.DT_BOOL;
      }
      if (data is int)
      {
        return DataType.DT_INT;
      }
      if (data is double)
      {
        return DataType.DT_DOUBLE;
      }
      if (data is string)
      {
        return DataType.DT_STRING;
      }
      if (data is HObject)
      {
        return DataType.DT_IMAGEOBJ;
      }
      if (data is Point)
      {
        return DataType.DT_POINT;
      }
      if (data is Size)
      {
        return DataType.DT_SIZE;
      }
      if (data is Rectangle)
      {
        return DataType.DT_RECT;
      }
      if (data is ArrayList)
      {
        return DataType.DT_ARRAY;
      }
      return DataType.DT_UNKNOWN;
    }

    public bool SetData<T>(T data)
    {
      dt_ = TypeFromData(data);
      if(dt_ == DataType.DT_UNKNOWN)
      {
        return false;
      }
      arr_val_ = new ArrayList();
      arr_val_.Add(data);

      return true;
    }

    public T GetData<T>()
    {
      if(arr_val_ != null && arr_val_.Count == 1)
      {
        return (T)arr_val_[0];
      }
      return default(T);
    }

    private T CovertData<T,T2>(T2 data) {
      return (T)Convert.ChangeType(data, typeof(T));
    }

    private DataType dt_;
    private ArrayList arr_val_;
  }
}
