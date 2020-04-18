using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvp_frame
{

  class PropertyController
  {
    System.Windows.Forms.PropertyGrid property_;
    public PropertyController(System.Windows.Forms.PropertyGrid property)
    {
      property_ = property;
      ToolObj.changedNotify += OnToolChangedNotify;
    }
    ToolObj curTool_;
    void OnUpdateProperty(ToolObj tool)
    {
      curTool_ = tool;
      if (null != tool && null != tool.plug_)
      {
        property_.SelectedObject = tool.plug_.GetProperty();
      }
      else
      {
        property_.SelectedObject = null;
      }
    }

    public void OnPropertyValueChanged()
    {
       if(curTool_ != null )
      {
        if(property_.SelectedObject != null)
        {
          curTool_.property = JsonConvert.SerializeObject(property_.SelectedObject);
        }
        else
        {
          curTool_.property = "";
        }
      
      }
   
    }

    void OnToolChangedNotify(NotifyParam np)
    {
      if(np.Type == TOOL_CHANGED_TYPE.TCT_FOCUS)
      {
        OnUpdateProperty(np.Current);
      }
     
    }
  }
}
