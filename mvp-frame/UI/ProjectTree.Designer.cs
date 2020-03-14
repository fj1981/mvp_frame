namespace mvp_frame
{
  partial class ProjectTree
  {
    /// <summary> 
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region 组件设计器生成的代码

    /// <summary> 
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.treeView = new DevExpress.XtraTreeList.TreeList();
      this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
      this.SuspendLayout();
      // 
      // treeView
      // 
      this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView.FixedLineWidth = 1;
      this.treeView.Location = new System.Drawing.Point(0, 0);
      this.treeView.Margin = new System.Windows.Forms.Padding(2);
      this.treeView.MinWidth = 16;
      this.treeView.Name = "treeView";
      this.treeView.Size = new System.Drawing.Size(302, 852);
      this.treeView.StateImageList = this.svgImageCollection1;
      this.treeView.TabIndex = 0;
      this.treeView.TreeLevelWidth = 12;
      // 
      // svgImageCollection1
      // 
      this.svgImageCollection1.Add("open", "image://svgimages/dashboards/open.svg");
      this.svgImageCollection1.Add("actions_list", "image://svgimages/icon builder/actions_list.svg");
      // 
      // ProjectTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.treeView);
      this.Margin = new System.Windows.Forms.Padding(2);
      this.Name = "ProjectTree";
      this.Size = new System.Drawing.Size(302, 852);
      ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraTreeList.TreeList treeView;
    private DevExpress.Utils.SvgImageCollection svgImageCollection1;
  }
}
