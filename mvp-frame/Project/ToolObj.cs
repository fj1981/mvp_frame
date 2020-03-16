using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_frame
{
  public enum TOOL_CHANGED_TYPE {
    TCT_MODIFY,
    TCT_DELLTE,
    TCT_FOCUS,
    TCT_ADD,
  }
  public delegate void ChangedNotify(TOOL_CHANGED_TYPE type, ToolObj cur, ToolObj parent);

  public class ToolObj
  {
    public string guid { get; set;}
    /// <summary>
    ///
    /// </summary>
    string name_;
    public string name {
      get {
        return name_;
      }
      set {
        if(name_ != value)
        {
          name_ = value;
          ModifyNoify();
        }
      }
    }
    /// <summary>
    ///
    /// </summary>
    int type_;
    public int type {
      get {
        return type_;
      }
      set {
        if (type_ != value)
        {
          type_ = value;
          ModifyNoify();
        }
      }
    }
    /// <summary>
    ///
    /// </summary>
    string property_;
    public string property {
      get {
        return property_;
      }
      set
      {
        if (property_ != value)
        {
          property_ = value;
          ModifyNoify();
        }
      }
    }
    /// <summary>
    ///
    /// </summary>
    List<ParamDesc> inputs_;
    public List<ParamDesc> inputs {
      get
      {
        return inputs_;
      }
      set
      {
        if (inputs_ != value)
        {
          inputs_ = value;
          ModifyNoify();
        }
      }
    }
    /// <summary>
    ///
    /// </summary>
    public List<ParamDesc> outputs_;
    public List<ParamDesc> outputs {
      get
      {
        return outputs_;
      }
      set
      {
        if (outputs_ != value)
        {
          outputs_ = value;
          ModifyNoify();
        }
      }
    }
    /// <summary>
    ///
    /// </summary>
    public List<ToolObj> children {
      get;
      set;
    }

    public bool DeleteObj(int id)
    {
      if(children == null)
      {
        return false;
      }
      bool ret = false;
      foreach(var e in children )
      {
        if (e != null && e.treeId_ == id)
        {
          children.Remove(e);
          changedNotify?.Invoke(TOOL_CHANGED_TYPE.TCT_MODIFY, e, this);
          ret = true;
          break;
        }
      }
      return ret;
    }

    public bool AddObj(int id, ToolObj newObj,bool insert )
    {
      if (children == null)
      {
        return false;
      }
      bool ret = false;
      int index = 0;
      foreach (var e in children)
      {
        ++index;
        if (e != null && e.treeId_ == id)
        {
          if(insert)
          {
            if(e.children == null)
            {
              e.children = new List<ToolObj>();
            }
            e.children.Add(newObj);
            changedNotify?.Invoke(TOOL_CHANGED_TYPE.TCT_MODIFY, newObj, e);
          }
          else
          {
            children.Insert(index, newObj);
            changedNotify?.Invoke(TOOL_CHANGED_TYPE.TCT_MODIFY, newObj, this);
          }
          ret = true;
          break;
        }
      }
      return ret;
    }

    void ModifyNoify()
    {
      changedNotify?.Invoke(TOOL_CHANGED_TYPE.TCT_MODIFY, this, null);
    }

    public ToolObj GetObjByTreeId(int treeId)
    {
      if (treeId == treeId_)
      {
        return this;
      }
      if (children != null)
      {
        foreach (var e in children)
        {
          var ret = e.GetObjByTreeId(treeId);
          if (ret != null)
          {
            return ret;
          }
        }
      }
      return null;
    }

    public int treeId_ = -1;
    public IPlugin plug_;
    static ToolObj focusTool_;
    public static ToolObj focusTool
    {
      set {
        if(value != focusTool_)
        {
          focusTool_ = value;
          changedNotify?.Invoke(TOOL_CHANGED_TYPE.TCT_FOCUS, focusTool_, null);
        }
      }
      get {
        return focusTool_;
      }
    }

    public static event ChangedNotify changedNotify;
  }

}
