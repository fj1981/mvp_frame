using HalconDotNet;
using MVPlugIn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvp_frame.UI
{
  partial class DlgLiveShow : DevExpress.XtraEditors.XtraForm
  {

    private List<ISrcPlug> srcPlugs_;
    private RunEvent runEvent_;
    public DlgLiveShow()
    {
      InitializeComponent();
      InitVideoSrc();
    }

    List<ISrcPlug> GetSrcPlugs()
    {
      if (srcPlugs_ == null)
      {
        srcPlugs_ = PlugMgr.Instance.GetSrcPlugs();
      }
      return srcPlugs_;

    }

    private void InitVideoSrc()
    {
      comboBoxEdit1.Properties.Items.Clear();
      foreach (var plug in GetSrcPlugs())
      {
        foreach(var name in plug.GetSupplyVideoList())
        {
          comboBoxEdit1.Properties.Items.Add($"{plug.GetPlugInfo().GetPlugName()}|{name}");
        }
      }
    }

    ISrcPlug GetSrcPlug(String name)
    {
      foreach (var plug in GetSrcPlugs())
      {
        if(plug.GetPlugInfo().GetPlugName() == name)
        {
          return plug;
        }
      }
      return null;
    }

    private void OnLiveDataReady(HObject ho_Image)
    {
      if (null != ho_Image)
      {
        HOperatorSet.DispObj(ho_Image, handle_);
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      String t = comboBoxEdit1.Text;
      Thread th;
      var info  = t.Split('|');
      if(info.Length == 2)
      {
        var plug = GetSrcPlug(info[0]);
        if(plug != null)
        {
          if(!plug.SetCurentDeviceID(info[1]))
          {
            MessageBox.Show("找不到视频源", "显示视频失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
          if(runEvent_ != null)
          {
            runEvent_.stop = true;
          }
          runEvent_ = new RunEvent(OnLiveDataReady, null);
          plug.SetRunEvent(runEvent_);
          th = new Thread(() =>{
                plug.Run();
          });
          th.IsBackground = true;
          th.Start();
        }
      }
      else
      {
        MessageBox.Show("找不到视频源", "显示视频失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void simpleButton2_Click(object sender, EventArgs e)
    {
      this.Dispose();
    }

    private void OnFormClose(object sender, FormClosedEventArgs e)
    {
      if (runEvent_ != null)
      {
        runEvent_.stop = true;
      }
    }
    HTuple handle_ = null;
    private void OnShow(object sender, EventArgs e)
    {
      HOperatorSet.OpenWindow(2, 2, 642, 482, pictureBox1.Handle, "visible", "", out handle_);
    }
  }
}
