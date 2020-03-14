using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interface;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace mvp_frame
{
public delegate void OnPrjLoadFininsh(ToolObj root);

public class ProjectMgr: Singleton<ProjectMgr>
{
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

  public void OpenProject(string path, OnPrjLoadFininsh finish)
  {
    using (FileStream fsRead = new FileStream(path, FileMode.Open)) {
      int fsLen = (int)fsRead.Length;
      byte[] heByte = new byte[fsLen];
      int r = fsRead.Read(heByte, 0, heByte.Length);
      string myStr = System.Text.Encoding.UTF8.GetString(heByte);
      var dynamicObject = JsonConvert.DeserializeObject< ToolObj>(myStr);
        TaskMgr.Instance.Init(dynamicObject);
        finish ? .Invoke(dynamicObject);
    }
  }
 }
}
