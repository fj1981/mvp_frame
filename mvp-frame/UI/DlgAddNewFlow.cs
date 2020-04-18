using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace mvp_frame.UI
{
  public partial class DlgAddNewFlow : DevExpress.XtraEditors.XtraForm
  {
    public DlgAddNewFlow()
    {
      InitializeComponent();
    }

    private void simpleButton2_Click(object sender, EventArgs e)
    {
      String name = textEdit1.Text;
      if (ProjectMgr.Instance.NewFlow(name))
      {
        this.Dispose();
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      this.Dispose();
    }
  }
}