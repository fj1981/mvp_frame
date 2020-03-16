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

    void OnUpdateProperty(ToolObj tool)
    {
      if(null != tool)
      {
        property_.SelectedObject = tool.plug_.GetProperty();
      }
      //
    }

    public void OnPropertyValueChanged()
    {

   
    }

    void OnToolChangedNotify(TOOL_CHANGED_TYPE type, ToolObj cur, ToolObj parent)
    {
      if(type == TOOL_CHANGED_TYPE.TCT_FOCUS)
      {
        OnUpdateProperty(cur);
      }
     
    }
  }
}
