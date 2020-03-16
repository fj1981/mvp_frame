namespace mvp_frame.UI
{
  partial class DlgAddNewTool
  {
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
      this.listView1 = new System.Windows.Forms.ListView();
      this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
      this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
      this.tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
      this.xtraTabControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.xtraTabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 1;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
      this.tableLayoutPanel.Controls.Add(this.xtraTabControl1, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.panelControl1, 0, 1);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(10, 9);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 2;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.29953F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.70047F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(938, 641);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // xtraTabControl1
      // 
      this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.xtraTabControl1.Location = new System.Drawing.Point(3, 3);
      this.xtraTabControl1.Name = "xtraTabControl1";
      this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
      this.xtraTabControl1.Size = new System.Drawing.Size(932, 559);
      this.xtraTabControl1.TabIndex = 0;
      this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage1,
            this.xtraTabPage3});
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.simpleButton2);
      this.panelControl1.Controls.Add(this.simpleButton1);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(3, 568);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(932, 70);
      this.panelControl1.TabIndex = 1;
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(715, 25);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(75, 23);
      this.simpleButton1.TabIndex = 0;
      this.simpleButton1.Text = "simpleButton1";
      // 
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(820, 25);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(75, 23);
      this.simpleButton2.TabIndex = 0;
      this.simpleButton2.Text = "simpleButton1";
      // 
      // xtraTabPage2
      // 
      this.xtraTabPage2.Controls.Add(this.listView1);
      this.xtraTabPage2.Name = "xtraTabPage2";
      this.xtraTabPage2.Size = new System.Drawing.Size(926, 530);
      this.xtraTabPage2.Text = "xtraTabPage2";
      // 
      // listView1
      // 
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.HideSelection = false;
      this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
      this.listView1.Location = new System.Drawing.Point(0, 0);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(926, 530);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      // 
      // xtraTabPage1
      // 
      this.xtraTabPage1.Name = "xtraTabPage1";
      this.xtraTabPage1.Size = new System.Drawing.Size(926, 530);
      this.xtraTabPage1.Text = "xtraTabPage1";
      // 
      // xtraTabPage3
      // 
      this.xtraTabPage3.Name = "xtraTabPage3";
      this.xtraTabPage3.Size = new System.Drawing.Size(926, 530);
      this.xtraTabPage3.Text = "xtraTabPage3";
      // 
      // DlgAddNewTool
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(958, 659);
      this.Controls.Add(this.tableLayoutPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DlgAddNewTool";
      this.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "DlgAddNewTool";
      this.tableLayoutPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
      this.xtraTabControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.xtraTabPage2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    private System.Windows.Forms.ListView listView1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
  }
}
