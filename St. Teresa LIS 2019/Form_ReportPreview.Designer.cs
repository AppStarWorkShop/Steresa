namespace St.Teresa_LIS_2019
{
    partial class Form_ReportPreview
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
            this.comboBoxReportType = new System.Windows.Forms.ComboBox();
            this.textBoxCaseNo = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxReportNo = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.textBoxHKAS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxReportType
            // 
            this.comboBoxReportType.FormattingEnabled = true;
            this.comboBoxReportType.Location = new System.Drawing.Point(22, 29);
            this.comboBoxReportType.Name = "comboBoxReportType";
            this.comboBoxReportType.Size = new System.Drawing.Size(317, 21);
            this.comboBoxReportType.TabIndex = 0;
            // 
            // textBoxCaseNo
            // 
            this.textBoxCaseNo.Location = new System.Drawing.Point(365, 30);
            this.textBoxCaseNo.Name = "textBoxCaseNo";
            this.textBoxCaseNo.Size = new System.Drawing.Size(142, 20);
            this.textBoxCaseNo.TabIndex = 1;
            this.textBoxCaseNo.Text = "BX18/09463";
            this.textBoxCaseNo.TextChanged += new System.EventHandler(this.textBoxCaseNo_TextChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(624, 30);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(170, 22);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "Refresh";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxReportNo
            // 
            this.textBoxReportNo.Location = new System.Drawing.Point(527, 30);
            this.textBoxReportNo.Name = "textBoxReportNo";
            this.textBoxReportNo.Size = new System.Drawing.Size(28, 20);
            this.textBoxReportNo.TabIndex = 3;
            this.textBoxReportNo.Text = "1";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "ReportViewer";
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // textBoxHKAS
            // 
            this.textBoxHKAS.Location = new System.Drawing.Point(573, 30);
            this.textBoxHKAS.Name = "textBoxHKAS";
            this.textBoxHKAS.Size = new System.Drawing.Size(28, 20);
            this.textBoxHKAS.TabIndex = 4;
            this.textBoxHKAS.Text = "1";
            // 
            // Form_ReportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 629);
            this.Controls.Add(this.textBoxHKAS);
            this.Controls.Add(this.textBoxReportNo);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.textBoxCaseNo);
            this.Controls.Add(this.comboBoxReportType);
            this.Name = "Form_ReportPreview";
            this.Text = "Report Preview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxReportType;
        private System.Windows.Forms.TextBox textBoxCaseNo;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxReportNo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox textBoxHKAS;
    }
}