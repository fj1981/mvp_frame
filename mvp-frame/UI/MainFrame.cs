using DevExpress.XtraTreeList;
using HalconDotNet;
using mvp_frame.UI;
using System;
using System.Threading;
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
      ProjectMgr.Instance.onPrjLoadFininsh = tree_controlle_.OnFileloadFinish;
      ProjectSetting.Instance.Load();
    }

    private void OnFormClose(object sender, FormClosingEventArgs e)
    {
      ProjectSetting.Instance.Save();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      PlugMgr.Instance.Init();
      var setting = ProjectSetting.Instance.Val();
      if (setting != null && setting.lastSave_ != null)
      {
        ProjectMgr.Instance.OpenProject(setting.lastSave_);
      }
      HOperatorSet.OpenWindow(0, 0, 640, 480, pictureBox2.Handle, "visible", "", out handle_);
      TaskMgr.Instance.SetStateChangeNotify(OnTaskStateChanged);
      UpdateToolbarState();
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
        ProjectMgr.Instance.OpenProject(strFileName);
      }
    }

    private void SaveFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      if(!ProjectMgr.Instance.HasContent())
      {
        MessageBox.Show("没有需要保存的内容");
        return;
      }
      String path = null;
      if(ProjectMgr.Instance.IsNewProject())
      {
        SaveFileDialog ofd = new SaveFileDialog();
        ofd.Filter = "项目文件(*.json)|*.json|所有文件(*.*)|*.*";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          path = ofd.FileName;
        }
      }
      if(ProjectMgr.Instance.SaveProject(path))
      {
        ProjectSetting.Instance.Val().lastSave_ = ProjectMgr.Instance.Path();
        ProjectSetting.Instance.Save();
      }
    }

    private void SaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    HTuple handle_ = null;
    private void barButtonRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      var aa2 = Thread.CurrentThread.ManagedThreadId.ToString();
    
      TaskMgr.Instance.RunTasks(OnLiveImageReady);
    }
    private void UpdateToolbarState()
    {
      switch (TaskMgr.Instance.GetTaskState())
      {
        case RunState.RUNSTATE_INIT:
          {
            barButtonRun.Enabled = true;
            barButtonPause.Enabled = false;
            barButtonResume.Enabled = false;
            barButtonStop.Enabled = false;
            break;
          }
        case RunState.RUNSTATE_PAUSE:
          {
            barButtonRun.Enabled = false;
            barButtonPause.Enabled = false;
            barButtonResume.Enabled = true;
            barButtonStop.Enabled = true;
            break;
          }
        case RunState.RUNSTATE_RUNNING:
          {
            barButtonRun.Enabled = false;
            barButtonPause.Enabled = true;
            barButtonResume.Enabled = false;
            barButtonStop.Enabled = true;
            break;
          }
      }
    }
    private void OnTaskStateChanged(Task task2)
    {
      UpdateToolbarState();
    }
    private void barButtonStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      TaskMgr.Instance.StopAll();
    }

    private void barButtonResume_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      TaskMgr.Instance.ResumeAll();
    }

    private void barButtonPause_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      TaskMgr.Instance.PauseAll();
    }

    private void OnLiveImageReady(HObject ho_Image)
    {
      var aa2 = Thread.CurrentThread.ManagedThreadId.ToString();
      if (null != ho_Image)
      {
        HOperatorSet.DispObj(ho_Image, handle_);
      }
   
    }

    private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      DlgAddNewTool dlg = new DlgAddNewTool();
      dlg.ShowDialog();
    }

    private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      DlgAddNewFlow dlg = new DlgAddNewFlow();
      dlg.ShowDialog();
    }

    private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      DlgLiveShow dlg = new DlgLiveShow();
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

    private void treeList2_BeforeCheckNode(object sender, CheckNodeEventArgs e)
    {
      tree_controlle_.BeforeCheckNode(sender,e);
    }

    private void treeList2_AfterCheckNode(object sender, NodeEventArgs e)
    {
      tree_controlle_.AfterCheckNode(sender, e);
    }

  }
}
