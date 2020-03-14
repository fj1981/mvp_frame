using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;

namespace mvp_frame
{
  public partial class ProjectTree : UserControl
  {
    public ProjectTree()
    {
      InitializeComponent();
      InitTreeView(treeView);
    }

    public static void InitTreeView(DevExpress.XtraTreeList.TreeList treeView)
    {
      TreeListColumn column = treeView.Columns.Add();
      column.Visible = true;
      treeView.OptionsView.ShowColumns = false;
      treeView.OptionsView.ShowIndicator = false;
      treeView.OptionsView.ShowVertLines = false;
      treeView.OptionsView.ShowHorzLines = false;
      treeView.OptionsBehavior.Editable = false;
      treeView.OptionsSelection.EnableAppearanceFocusedCell = false;
    }

    private void AppendTree(ToolObj obj,int parent_id)
    {
      var node = treeView.AppendNode(new object[] { obj.name }, parent_id, -1, 0, obj.type); //0
      if (null != obj.children)
      {
        foreach (var a in obj.children)
        {
          AppendTree(a, node.Id);
        }
      }
    }

    public void OnFileloadFinish(ToolObj root)
    {
      treeView.Nodes.Clear();
      if(null != root.children)
      {
        foreach(var a in root.children) { 
          AppendTree(a, -1);
        }
      }
     
      
    }

  }
}
