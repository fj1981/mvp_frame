using Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvp_frame
{
  class PlugMgr  : Singleton<PlugMgr>
  {
    List<IPlugFactory> plugins_ = new List<IPlugFactory>();
    public void Init()
    {
      string[] files = Directory.GetFiles(Application.StartupPath + "\\Plugins");

      foreach (string file in files) {
        try
        {
          if (file.ToUpper().EndsWith(".DLL"))
          {
            Assembly ab = Assembly.LoadFile(file);
            Type[] types = ab.GetTypes();

            foreach (Type t in types)
            {
              if (t.GetInterface("IPlugFactory") != null)
              {
                plugins_.Add(ab.CreateInstance(t.FullName) as IPlugFactory);
              }
            }
          }
        }
        catch(Exception e)
        {

        }
      }
    }
    public IPlugFactory GetFactory(String guid)
    {
       foreach(var e in plugins_)  {
        if(guid == e.GetPlugInfo().GetUUID())
        {
          return e;
        }
      }
      return null;
    }

    public bool GetSrcPlug<T>(String name, ref T tool)
    {
      if(plugins_.Count >= 1) {
        tool = (T)(plugins_[0] as IPlugFactory).NewPlug();
        return true;
      }
      return false;
    }

    bool IsToolExist(String name)
    {

      return false;
    }

  }
}
