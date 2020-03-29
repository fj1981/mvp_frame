using MVPlugIn;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_frame
{
  public enum TOOL_CHANGED_TYPE {
    TCT_MODIFY,
    TCT_DELETE,
    TCT_FOCUS,
    TCT_ADD,
  }
  public class NotifyParam
  {
    public NotifyParam()
    {

    }
    public NotifyParam(TOOL_CHANGED_TYPE type,
      ToolObj current, ToolObj parent, int index = -1)
    {
      Type = type;
      Current = current;
      Parent = parent;
      Index = index;
    }

    public TOOL_CHANGED_TYPE Type { get; set; }
    public ToolObj Current { get; set; }
    public ToolObj Parent { get; set; }
    public int Index { get; set; } = -1;
  }

  public delegate void ChangedNotify(NotifyParam p);

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
          ModifyNotify();
        }
      }
    }
    /// <summary>
    ///
    /// </summary>
    PlugType type_;
    public PlugType type {
      get {
        return type_;
      }
      set {
        if (type_ != value)
        {
          type_ = value;
          ModifyNotify();
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
          ModifyNotify();
        }
      }
    }
    
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
        if (e != null && e.tree_id_ == id)
        {
          children.Remove(e);
          changedNotify?.Invoke(new NotifyParam(TOOL_CHANGED_TYPE.TCT_DELETE, e, this));
          ret = true;
          break;
        }
      }
      return ret;
    }

    public bool AddObj(int id, ToolObj obj,bool insert )
    {
      if(id == -1 && insert )
      {
        if(null == children)
        {
          children = new List<ToolObj>();
        }
        obj.parent = new WeakReference(this);
        obj.UpdateProperty(false);
        children.Add(obj);
        changedNotify?.Invoke(new NotifyParam(TOOL_CHANGED_TYPE.TCT_ADD, obj, this));
        return true;
      }
      if (children == null)
      {
        return false;
      }
      bool ret = false;
      int index = 0;
      foreach (var e in children)
      {
        ++index;
        if (e != null && e.tree_id_ == id)
        {
          if(insert)
          {
            if(e.children == null)
            {
              e.children = new List<ToolObj>();
            }
            obj.parent = new WeakReference(e);
            e.children.Add(obj);
            changedNotify?.Invoke(new NotifyParam(TOOL_CHANGED_TYPE.TCT_ADD, obj, e));
          }
          else
          {
            obj.parent = new WeakReference(this);
            children.Insert(index, obj);
            changedNotify?.Invoke(new NotifyParam(TOOL_CHANGED_TYPE.TCT_ADD, obj, this,index));
          }
          ret = true;
          break;
        }
      }
      return ret;
    }

    void ModifyNotify()
    {
      ToolObj parent1 = null;
      if(null != parent)
      {
        parent1 = parent.IsAlive ? parent.Target as ToolObj : null;
      }
     changedNotify?.Invoke(new NotifyParam(TOOL_CHANGED_TYPE.TCT_MODIFY, this, parent1));
    }

    public ToolObj GetObjByTreeId(int tree_id)
    {
      if (tree_id == tree_id_)
      {
        return this;
      }
      if (children != null)
      {
        foreach (var e in children)
        {
          var ret = e.GetObjByTreeId(tree_id);
          if (ret != null)
          {
            return ret;
          }
        }
      }
      return null;
    }

    public void UpdateProperty(bool for_save)
    {
      if(!for_save && plug_ == null && guid != null)
      {
        var f = PlugMgr.Instance.GetFactory(guid);
        if(f != null)
        {
          plug_ = f.NewPlug();
        }
      }
      if(plug_ != null)
      {
        if(for_save)
        {
          property_ = JsonConvert.SerializeObject(plug_.GetProperty());
        }
        else
        {
          BaseProperty prop;
          if (null != property_)
          {
             prop = JsonConvert.DeserializeObject(property_, plug_.GetPlugInfo().GetPropType()) as BaseProperty;
            plug_.SetProperty(prop);
          }
          else
          {
            prop = plug_.GetProperty();
          }
            (prop as BaseProperty).UpdateDefault();
        }
      }

      if (children != null)
      {
        foreach (var e in children)
        {
          e.UpdateProperty(for_save);
        }
      }
    }

    public int tree_id_ = -1;
    [JsonIgnore]
    public IPlugin plug_;
    [JsonIgnore]
    public WeakReference parent { get; set; }
    static ToolObj focus_tool_;
    public static ToolObj focusTool
    {
      set {
        if(value != focus_tool_)
        {
          focus_tool_ = value;
          changedNotify?.Invoke(new NotifyParam(TOOL_CHANGED_TYPE.TCT_FOCUS, focus_tool_, null));
        }
      }
      get {
        return focus_tool_;
      }
    }

    public static event ChangedNotify changedNotify;
  }

}
