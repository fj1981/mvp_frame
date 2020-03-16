using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      treeView.OptionsView.ShowHorzLines = false;
      treeView.OptionsBehavior.Editable = false;
      treeView.OptionsSelection.EnableAppearanceFocusedCell = false;
    }

    private void AppendTree(ToolObj obj, int parent_id)
    {
      var node = treeList_.AppendNode(new object[] { obj.name }, parent_id, -1, 0, obj.type);
      obj.treeId_ = node.Id;
      var f = PlugMgr.Instance.GetFactory(obj.guid);
      if (f != null)
      {
        obj.plug_ = f.NewPlug();
      }

      if (null != obj.children)
      {
        foreach (var a in obj.children)
        {
          AppendTree(a, node.Id);
        }
      }
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
      if(root_ != null)
      {
        ToolObj.focusTool = root_.GetObjByTreeId(node.Id);
      }
    }

    void OnToolChangedNotify(TOOL_CHANGED_TYPE type, ToolObj cur, ToolObj parent)
    {
      if (root_ == null)
        return;
    }
  }
}
