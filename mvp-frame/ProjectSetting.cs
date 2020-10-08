using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvp_frame
{
  class SettingVal
  {
    public String lastSave_ { get; set; }
  }
  class ProjectSetting : Singleton<ProjectSetting>
  {
    SettingVal settingVal_;
    public SettingVal Val()
    {
      if(settingVal_ == null)
      {
        settingVal_ = new SettingVal();
      }
      return settingVal_ ;
    }
    private String SavePath()
    {
      var p = Application.StartupPath;
      p.TrimEnd('\\');
      p += "\\config.json";
      return p;
    }
    public void Save()
    {
      var path = SavePath();
      if(settingVal_ != null)
      {
        System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding(false);
        var charData = JsonConvert.SerializeObject(settingVal_);
        File.WriteAllText(path, charData, utf8);
      }
    }
    public void Load()
    {
      var p = SavePath();
      string cfgStr = "";
      try
      {
        if (File.Exists(p))
        {
          cfgStr = File.ReadAllText(p);
          settingVal_ = JsonConvert.DeserializeObject<SettingVal>(cfgStr);
        }
        else
        {

        }
      }
      catch (Exception ex)
      {
      }
    }
  }
}
