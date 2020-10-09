using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using MVPlugIn;
using Newtonsoft.Json;

namespace mvp_frame
{
  public delegate void OnPrjLoadFininsh(ToolObj root);

  public class ProjectMgr: Singleton<ProjectMgr>
  {
    public OnPrjLoadFininsh onPrjLoadFininsh;
    private string OpenFile()
    {
      //       string strFileName = "";
      //       OpenFileDialog ofd = new OpenFileDialog();
      //       ofd.Filter = "项目文件文件(*.mvp;*.mvp)|所有文件|*.*";
      //       ofd.ValidateNames = true;
      //       ofd.CheckFileExists = true;
      //       ofd.CheckPathExists = true;
      //       if (ofd.ShowDialog() == true)
      //       {
      //         strFileName = ofd.FileName;
      //       }
      //       return strFileName;
      return "";
    }

    ToolObj root_obj_;
    string path_;
    public void OpenProject(string path)
    {
      path_ = path;
      using (FileStream fsRead = new FileStream(path, FileMode.Open)) {
        int fsLen = (int)fsRead.Length;
        byte[] heByte = new byte[fsLen];
        int r = fsRead.Read(heByte, 0, heByte.Length);
        string myStr = System.Text.Encoding.UTF8.GetString(heByte);
        root_obj_ = JsonConvert.DeserializeObject< ToolObj>(myStr);
        if(root_obj_ != null)
        {
         // root_obj_.UpdateProperty()
        }
        TaskMgr.Instance.Init(root_obj_);
        onPrjLoadFininsh? .Invoke(root_obj_);

      }
    }

    public bool NewFlow(String flow_name)
    {
      if(null == flow_name || 0 == flow_name.Length )
      {
        MessageBox.Show("流程名不能为空");
        return false;
      }
      var flow_obj = new ToolObj();
      flow_obj.guid = FlowPlugFactory.Guid;
      flow_obj.name = flow_name;
      if (null == root_obj_)
      {
        root_obj_ = new ToolObj();
        root_obj_.type = PlugType.PT_FLOW;
        root_obj_.AddObj(-1, flow_obj, true);
        TaskMgr.Instance.Init(root_obj_);
        onPrjLoadFininsh?.Invoke(root_obj_);
        ToolObj.focusTool = flow_obj;
        return true;
      }
      else
      {
        root_obj_.AddObj(-1, flow_obj, true);
        return true;
      }
    }

    public bool NewProcess(IPlugin plug)
    {
      if(null == root_obj_)
      {
        MessageBox.Show("请先创建一个流程");
        return false;
      }
      var focus = ToolObj.focusTool;
      if (null == focus)
      {
        MessageBox.Show("请选择插入的位置");
        return false;
      }
      var prop = plug.GetProperty();
      prop.name = plug.GetPlugInfo().GetPlugName();
      prop.description = plug.GetPlugInfo().GetDescription();
      prop.UpdateDefault();

      var proc_obj = new ToolObj();
      proc_obj.guid = plug.GetPlugInfo().GetUUID();
      proc_obj.name = prop.name;
      proc_obj.plug_ = plug;
      proc_obj.type = plug.GetPlugInfo().GetPlugType();
      if (focus.type == PlugType.PT_FLOW)
      {
        focus.AddObj(-1, proc_obj, true);
        return true;
      }

      var flow = focus;
      flow = flow.parent.Target as ToolObj;
      if(null != flow)
      {
        flow.AddObj(focus.tree_id_, proc_obj, false);
      }
      return true;
    }

    public bool IsNewProject()
    {
      return path_ == null;
    }

    public String Path()
    {
      return path_;
    }

    public bool HasContent()
    {
      return root_obj_ != null;
    }

    public bool SaveProject(String path)
    {
      if(null != path)
      {
        path_ = path;
      }
      if(null == path_)
      {
        return false;
      }
      try
      {
        if (path_.Length != 0 && root_obj_ != null)
        {
          System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding(false);
          root_obj_.UpdateProperty(true);
          var charData = JsonConvert.SerializeObject(root_obj_);
          File.WriteAllText(path_, charData, utf8);
        }
      }
      catch(Exception e)
      {
        Console.Write(e.ToString());
        return false;
      }

      return true;

    }
  }
}
