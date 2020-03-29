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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAddNewTool));
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
      this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
      this.imageListBoxControl1 = new DevExpress.XtraEditors.ImageListBoxControl();
      this.dpiAwareImageCollection1 = new DevExpress.Utils.DPIAwareImageCollection(this.components);
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
      this.xtraTabControl1.SuspendLayout();
      this.xtraTabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dpiAwareImageCollection1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
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
      this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
      this.xtraTabControl1.Size = new System.Drawing.Size(932, 559);
      this.xtraTabControl1.TabIndex = 0;
      this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
      // 
      // xtraTabPage1
      // 
      this.xtraTabPage1.Controls.Add(this.imageListBoxControl1);
      this.xtraTabPage1.Name = "xtraTabPage1";
      this.xtraTabPage1.Size = new System.Drawing.Size(926, 530);
      this.xtraTabPage1.Text = "所有工具";
      // 
      // imageListBoxControl1
      // 
      this.imageListBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.imageListBoxControl1.ImageList = this.dpiAwareImageCollection1;
      this.imageListBoxControl1.ItemHeight = 48;
      this.imageListBoxControl1.Location = new System.Drawing.Point(0, 0);
      this.imageListBoxControl1.Name = "imageListBoxControl1";
      this.imageListBoxControl1.Size = new System.Drawing.Size(926, 530);
      this.imageListBoxControl1.TabIndex = 0;
      // 
      // dpiAwareImageCollection1
      // 
      this.dpiAwareImageCollection1.Images.AddRange(new DevExpress.Utils.DefaultImage[] {
            new DevExpress.Utils.DefaultImage(new DevExpress.Utils.LocalImageLocator("build_32x32.png"))});
      this.dpiAwareImageCollection1.ImageSize = new System.Drawing.Size(32, 32);
      this.dpiAwareImageCollection1.Stream = ((DevExpress.Utils.DPIAwareImageCollectionStreamer)(resources.GetObject("dpiAwareImageCollection1.Stream")));
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
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(820, 25);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(75, 23);
      this.simpleButton2.TabIndex = 0;
      this.simpleButton2.Text = "取消";
      this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(715, 25);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(75, 23);
      this.simpleButton1.TabIndex = 0;
      this.simpleButton1.Text = "确认添加";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
      this.Text = "添加一个新工具";
      this.tableLayoutPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
      this.xtraTabControl1.ResumeLayout(false);
      this.xtraTabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dpiAwareImageCollection1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.Utils.DPIAwareImageCollection dpiAwareImageCollection1;
    private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    private DevExpress.XtraEditors.ImageListBoxControl imageListBoxControl1;
  }
}
