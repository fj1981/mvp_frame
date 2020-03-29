namespace mvp_frame.UI
{
  partial class DlgAddNewFlow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(32, 51);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(100, 14);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "请输入添加流程名:";
      // 
      // textEdit1
      // 
      this.textEdit1.Location = new System.Drawing.Point(148, 48);
      this.textEdit1.Name = "textEdit1";
      this.textEdit1.Size = new System.Drawing.Size(218, 20);
      this.textEdit1.TabIndex = 1;
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(284, 103);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(75, 23);
      this.simpleButton1.TabIndex = 2;
      this.simpleButton1.Text = "取消";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(187, 103);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(75, 23);
      this.simpleButton2.TabIndex = 2;
      this.simpleButton2.Text = "确认";
      this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
      // 
      // DlgAddNewFlow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(393, 152);
      this.Controls.Add(this.simpleButton2);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.textEdit1);
      this.Controls.Add(this.labelControl1);
      this.Name = "DlgAddNewFlow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "新建一个流程";
      ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.TextEdit textEdit1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
  }
}