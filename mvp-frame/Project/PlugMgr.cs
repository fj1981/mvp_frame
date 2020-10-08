using MVPlugIn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace mvp_frame
{
  class PlugMgr  : Singleton<PlugMgr>
  {
    public List<BasePlugFactory> Plugins { get; set; } = new List<BasePlugFactory>();
    public void Init()
    {
      string[] files = Directory.GetFiles(Application.StartupPath + "\\Plugins");
      Plugins.Add(new FlowPlugFactory());
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
                var inst = ab.CreateInstance(t.FullName) as BasePlugFactory;
                if(null != inst)
                  Plugins.Add(inst);
              }
            }
          }                                               
        }
        catch(Exception e)
        {
          Console.WriteLine(e.ToString());
        }
      }
    }
    public BasePlugFactory GetFactory(String guid)
    {
       foreach(var e in Plugins)  {
        if(guid == e.GetPlugInfo().GetUUID())
        {
          return e;
        }
      }
      return null;
    }

    public List<ISrcPlug> GetSrcPlugs()
    {
      var ret = new List<ISrcPlug>();
      foreach (var e in Plugins)
      {
        if (PlugType.PT_SRC == e.GetPlugInfo().GetPlugType())
        {
          ret.Add(e.NewPlug() as ISrcPlug);
        }
      }
      return ret;
    }

    public bool GetSrcPlug<T>(String name, out T tool)
    {
      tool = default(T);
      if (Plugins.Count >= 1) {
        tool = (T)(Plugins[0] as BasePlugFactory).NewPlug();
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
