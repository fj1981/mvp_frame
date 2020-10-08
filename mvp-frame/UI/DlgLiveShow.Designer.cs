namespace mvp_frame.UI
{
  partial class DlgLiveShow
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgLiveShow));
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.dpiAwareImageCollection1 = new DevExpress.Utils.DPIAwareImageCollection(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dpiAwareImageCollection1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 1;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
      this.tableLayoutPanel.Controls.Add(this.panelControl1, 0, 1);
      this.tableLayoutPanel.Controls.Add(this.pictureBox1, 0, 0);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(9, 8);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 2;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.29953F));
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.70047F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(803, 596);
      this.tableLayoutPanel.TabIndex = 0;
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.labelControl1);
      this.panelControl1.Controls.Add(this.comboBoxEdit1);
      this.panelControl1.Controls.Add(this.simpleButton2);
      this.panelControl1.Controls.Add(this.simpleButton1);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelControl1.Location = new System.Drawing.Point(3, 529);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(797, 64);
      this.panelControl1.TabIndex = 1;
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(278, 27);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(88, 13);
      this.labelControl1.TabIndex = 2;
      this.labelControl1.Text = "选择一个视频源:";
      // 
      // comboBoxEdit1
      // 
      this.comboBoxEdit1.Location = new System.Drawing.Point(384, 24);
      this.comboBoxEdit1.Name = "comboBoxEdit1";
      this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.comboBoxEdit1.Size = new System.Drawing.Size(139, 20);
      this.comboBoxEdit1.TabIndex = 1;
      // 
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(703, 23);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(64, 21);
      this.simpleButton2.TabIndex = 0;
      this.simpleButton2.Text = "取消";
      this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(613, 23);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(64, 21);
      this.simpleButton1.TabIndex = 0;
      this.simpleButton1.Text = "运行";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // dpiAwareImageCollection1
      // 
      this.dpiAwareImageCollection1.Images.AddRange(new DevExpress.Utils.DefaultImage[] {
            new DevExpress.Utils.DefaultImage(new DevExpress.Utils.LocalImageLocator("build_32x32.png"))});
      this.dpiAwareImageCollection1.ImageSize = new System.Drawing.Size(32, 32);
      this.dpiAwareImageCollection1.Stream = ((DevExpress.Utils.DPIAwareImageCollectionStreamer)(resources.GetObject("dpiAwareImageCollection1.Stream")));
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(797, 520);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      // 
      // DlgLiveShow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(821, 612);
      this.Controls.Add(this.tableLayoutPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DlgLiveShow";
      this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "显示可用视频";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClose);
      this.Shown += new System.EventHandler(this.OnShow);
      this.tableLayoutPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dpiAwareImageCollection1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.Utils.DPIAwareImageCollection dpiAwareImageCollection1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}
