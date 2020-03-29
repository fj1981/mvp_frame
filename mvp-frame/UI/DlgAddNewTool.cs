using MVPlugIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvp_frame.UI
{
  partial class DlgAddNewTool : DevExpress.XtraEditors.XtraForm
  {
    public DlgAddNewTool()
    {
      InitializeComponent();
      InitListView();
    }

    public void InitListView()
    {
      this.imageListBoxControl1.BeginUpdate();  

      foreach(var f in PlugMgr.Instance.Plugins)
      {
        var info = f.GetPlugInfo();
        if (info.GetPlugType() != MVPlugIn.PlugType.PT_FLOW)
        {
          var text = info.GetPlugName() + "   < " + info.GetUUID() +" >    ";
          text += info.GetDescription();
          this.imageListBoxControl1.Items.Add(f, 0);
        }
      }
      this.imageListBoxControl1.EndUpdate();
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      var factory = this.imageListBoxControl1.SelectedValue as BasePlugFactory;
      if(ProjectMgr.Instance.NewProcess(factory.NewPlug()))
      {
        this.Dispose();
      }
    }

    private void simpleButton2_Click(object sender, EventArgs e)
    {
      this.Dispose();
    }
  }
}
