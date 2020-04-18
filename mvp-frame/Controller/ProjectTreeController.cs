using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mvp_frame
{
  class ProjectTreeController
  {
    DevExpress.XtraTreeList.TreeList treeList_;
    public ProjectTreeController(DevExpress.XtraTreeList.TreeList tree)
    {
      treeList_ = tree;
      InitTreeView(treeList_);

    }

    private static void InitTreeView(DevExpress.XtraTreeList.TreeList treeView)
    {
      TreeListColumn column = treeView.Columns.Add();
      column.Visible = true;
      treeView.OptionsView.ShowColumns = false;
      treeView.OptionsView.ShowIndicator = false;
      treeView.OptionsView.ShowVertLines = false;
      treeView.OptionsView.ShowHorzLines = true;
      treeView.OptionsBehavior.Editable = false;
      treeView.OptionsSelection.EnableAppearanceFocusedCell = false;
      treeView.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
      treeView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Solid;
    }

    private TreeListNode AppendTree(ToolObj obj, int parent_id)
    {
      var node = treeList_.AppendNode(new object[] { obj.name }, parent_id, -1, 0,(int) obj.type);
      obj.tree_id_ = node.Id;
      if (null != obj.children)
      {
        foreach (var a in obj.children)
        {
          AppendTree(a, node.Id);
        }
      }
      return node;
    }

    ToolObj root_;
    public void OnFileloadFinish(ToolObj root)
    {
      treeList_.Nodes.Clear();
      if (null != root.children)
      {
        foreach (var a in root.children)
        {
          AppendTree(a, -1);
        }
      }
      root_ = root;
      ToolObj.changedNotify += OnToolChangedNotify;
    }

    public void OnFocusChanged(DevExpress.XtraTreeList.Nodes.TreeListNode node)
    {
      if(root_ != null && node != null)
      {
        ToolObj.focusTool = root_.GetObjByTreeId(node.Id);
      }
    }

    private void PRV_SetState(bool IN_State, TreeListNode IN_CheckedNode)
    {
      if (IN_CheckedNode.HasChildren)
      {
        foreach (TreeListNode Each_Node in IN_CheckedNode.Nodes)
        {
          PRV_SetState(IN_State, Each_Node);
        }
      }
      else
      {
        IN_CheckedNode.Checked = IN_State;
        PRV_SetParrent(IN_CheckedNode);

      }
    }

    public void BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
    {

      PRV_SetState(!e.Node.Checked, e.Node);
    }

    public void AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
    {
      if (e.Node.CheckState == CheckState.Indeterminate)
        e.Node.CheckState = CheckState.Checked;

    }

    private void PRV_SetParrent(TreeListNode IN_ChildNode)
    {
      if (IN_ChildNode.ParentNode == null)
      {
        return;
      }
      else
      {
        foreach (TreeListNode Each_BrotherNode in IN_ChildNode.ParentNode.Nodes)
        {
          if (Each_BrotherNode.Checked != IN_ChildNode.Checked)
          {
            IN_ChildNode.ParentNode.CheckState = CheckState.Indeterminate;
            return;
          }
        }
        IN_ChildNode.ParentNode.Checked = IN_ChildNode.Checked;
        PRV_SetParrent(IN_ChildNode.ParentNode);
      }
    }

    void OnToolChangedNotify(NotifyParam np)
    {
      if (root_ == null)
        return;
      TreeListNode tln = null;
      if(np.Type == TOOL_CHANGED_TYPE.TCT_ADD)
      {
        if (-1 == np.Current.tree_id_)
        {
          tln = AppendTree(np.Current, np.Parent.tree_id_);
          if(np.Index != -1)
          {
            treeList_.SetNodeIndex(tln, np.Index);
          }
        }

        if(null != tln)
        {
          treeList_.SetFocusedNode(tln);
        }

      }
    }
  }
}
