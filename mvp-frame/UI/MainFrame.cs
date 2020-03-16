using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using HalconDotNet;
using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
using mvp_frame.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mvp_frame
{
  public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
  {
    ProjectTreeController tree_controlle_;
    PropertyController property_controller_;
    public MainFrame()
    {
      InitializeComponent();
      tree_controlle_ = new ProjectTreeController(treeList2);
      property_controller_ = new PropertyController(propertyGrid2);
    }

    void UpdateToolbarButtonState()
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      PlugMgr.Instance.Init();
    }

    private void NewFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void OpenFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      string strFileName = "";
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "项目文件(*.json)|*.json|所有文件(*.*)|*.*";
      ofd.ValidateNames = true;
      ofd.CheckFileExists = true;
      ofd.CheckPathExists = true;
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        strFileName = ofd.FileName;
        ProjectMgr.Instance.OpenProject(strFileName,
          tree_controlle_.OnFileloadFinish);
      }
    }

    private void SaveFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void SaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    HTuple handle_ = null;
    private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      HOperatorSet.OpenWindow(2, 2, 640, 480, pictureBox1.Handle, "visible", "", out handle_);
      TaskMgr.Instance.RunTasks(OnLiveImageReady);
    }



    private void OnLiveImageReady(HObject ho_Image)
    {
      HOperatorSet.DispObj(ho_Image, handle_);
    }

    private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      DlgAddNewTool dlg = new DlgAddNewTool();
      dlg.ShowDialog();
    }

    private void OnFocusItemChange(object sender, FocusedNodeChangedEventArgs e)
    {
      tree_controlle_.OnFocusChanged(e.Node);
    }

    private void OnPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      property_controller_.OnPropertyValueChanged();
    }
  }
}
