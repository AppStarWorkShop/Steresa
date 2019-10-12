namespace St.Teresa_LIS_2019
{
    partial class Form_STHDiagnosticAmount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_STHDiagnosticAmount));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.label_ST_TERESAS_HOSPITAL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_EBV = new System.Windows.Forms.TextBox();
            this.label_EBV = new System.Windows.Forms.Label();
            this.textBox_CYG = new System.Windows.Forms.TextBox();
            this.label_CYG = new System.Windows.Forms.Label();
            this.textBox_CY = new System.Windows.Forms.TextBox();
            this.label_CY = new System.Windows.Forms.Label();
            this.label_diagnostic = new System.Windows.Forms.Label();
            this.label_Amount_auto_fill_in_setting = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Cancel.ForeColor = System.Drawing.Color.Red;
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Cancel.Location = new System.Drawing.Point(152, 210);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(84, 41);
            this.button_Cancel.TabIndex = 244;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click_1);
            // 
            // button_Confirm
            // 
            this.button_Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Confirm.ForeColor = System.Drawing.Color.Blue;
            this.button_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("button_Confirm.Image")));
            this.button_Confirm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Confirm.Location = new System.Drawing.Point(40, 210);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(84, 41);
            this.button_Confirm.TabIndex = 243;
            this.button_Confirm.Text = "Confirm";
            this.button_Confirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // label_ST_TERESAS_HOSPITAL
            // 
            this.label_ST_TERESAS_HOSPITAL.AutoSize = true;
            this.label_ST_TERESAS_HOSPITAL.BackColor = System.Drawing.Color.Transparent;
            this.label_ST_TERESAS_HOSPITAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_ST_TERESAS_HOSPITAL.ForeColor = System.Drawing.Color.Blue;
            this.label_ST_TERESAS_HOSPITAL.Location = new System.Drawing.Point(16, 8);
            this.label_ST_TERESAS_HOSPITAL.Name = "label_ST_TERESAS_HOSPITAL";
            this.label_ST_TERESAS_HOSPITAL.Size = new System.Drawing.Size(254, 24);
            this.label_ST_TERESAS_HOSPITAL.TabIndex = 242;
            this.label_ST_TERESAS_HOSPITAL.Text = "ST. TERESA\'S HOSPITAL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            this.panel1.Controls.Add(this.textBox_EBV);
            this.panel1.Controls.Add(this.label_EBV);
            this.panel1.Controls.Add(this.textBox_CYG);
            this.panel1.Controls.Add(this.label_CYG);
            this.panel1.Controls.Add(this.textBox_CY);
            this.panel1.Controls.Add(this.label_CY);
            this.panel1.Location = new System.Drawing.Point(38, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 90);
            this.panel1.TabIndex = 241;
            // 
            // textBox_EBV
            // 
            this.textBox_EBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_EBV.ForeColor = System.Drawing.Color.Blue;
            this.textBox_EBV.Location = new System.Drawing.Point(77, 55);
            this.textBox_EBV.Name = "textBox_EBV";
            this.textBox_EBV.Size = new System.Drawing.Size(88, 24);
            this.textBox_EBV.TabIndex = 58;
            // 
            // label_EBV
            // 
            this.label_EBV.AutoSize = true;
            this.label_EBV.BackColor = System.Drawing.Color.Transparent;
            this.label_EBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_EBV.ForeColor = System.Drawing.Color.Black;
            this.label_EBV.Location = new System.Drawing.Point(14, 58);
            this.label_EBV.Name = "label_EBV";
            this.label_EBV.Size = new System.Drawing.Size(54, 18);
            this.label_EBV.TabIndex = 59;
            this.label_EBV.Text = "EBV $";
            // 
            // textBox_CYG
            // 
            this.textBox_CYG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_CYG.ForeColor = System.Drawing.Color.Blue;
            this.textBox_CYG.Location = new System.Drawing.Point(77, 33);
            this.textBox_CYG.Name = "textBox_CYG";
            this.textBox_CYG.Size = new System.Drawing.Size(88, 24);
            this.textBox_CYG.TabIndex = 56;
            // 
            // label_CYG
            // 
            this.label_CYG.AutoSize = true;
            this.label_CYG.BackColor = System.Drawing.Color.Transparent;
            this.label_CYG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_CYG.ForeColor = System.Drawing.Color.Black;
            this.label_CYG.Location = new System.Drawing.Point(14, 36);
            this.label_CYG.Name = "label_CYG";
            this.label_CYG.Size = new System.Drawing.Size(57, 18);
            this.label_CYG.TabIndex = 57;
            this.label_CYG.Text = "CYG $";
            // 
            // textBox_CY
            // 
            this.textBox_CY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_CY.ForeColor = System.Drawing.Color.Blue;
            this.textBox_CY.Location = new System.Drawing.Point(77, 11);
            this.textBox_CY.Name = "textBox_CY";
            this.textBox_CY.Size = new System.Drawing.Size(88, 24);
            this.textBox_CY.TabIndex = 54;
            // 
            // label_CY
            // 
            this.label_CY.AutoSize = true;
            this.label_CY.BackColor = System.Drawing.Color.Transparent;
            this.label_CY.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_CY.ForeColor = System.Drawing.Color.Black;
            this.label_CY.Location = new System.Drawing.Point(14, 14);
            this.label_CY.Name = "label_CY";
            this.label_CY.Size = new System.Drawing.Size(44, 18);
            this.label_CY.TabIndex = 55;
            this.label_CY.Text = "CY $";
            // 
            // label_diagnostic
            // 
            this.label_diagnostic.AutoSize = true;
            this.label_diagnostic.BackColor = System.Drawing.Color.Transparent;
            this.label_diagnostic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_diagnostic.ForeColor = System.Drawing.Color.Blue;
            this.label_diagnostic.Location = new System.Drawing.Point(85, 36);
            this.label_diagnostic.Name = "label_diagnostic";
            this.label_diagnostic.Size = new System.Drawing.Size(105, 24);
            this.label_diagnostic.TabIndex = 245;
            this.label_diagnostic.Text = "diagnostic";
            // 
            // label_Amount_auto_fill_in_setting
            // 
            this.label_Amount_auto_fill_in_setting.AutoSize = true;
            this.label_Amount_auto_fill_in_setting.BackColor = System.Drawing.Color.Transparent;
            this.label_Amount_auto_fill_in_setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Amount_auto_fill_in_setting.ForeColor = System.Drawing.Color.Blue;
            this.label_Amount_auto_fill_in_setting.Location = new System.Drawing.Point(16, 67);
            this.label_Amount_auto_fill_in_setting.Name = "label_Amount_auto_fill_in_setting";
            this.label_Amount_auto_fill_in_setting.Size = new System.Drawing.Size(244, 24);
            this.label_Amount_auto_fill_in_setting.TabIndex = 246;
            this.label_Amount_auto_fill_in_setting.Text = "Amount auto fill in setting";
            // 
            // Form_STHDiagnosticAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(282, 315);
            this.ControlBox = false;
            this.Controls.Add(this.label_Amount_auto_fill_in_setting);
            this.Controls.Add(this.label_diagnostic);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.label_ST_TERESAS_HOSPITAL);
            this.Controls.Add(this.panel1);
            this.Name = "Form_STHDiagnosticAmount";
            this.Text = "STH Diagnostic Amount";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Label label_ST_TERESAS_HOSPITAL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_EBV;
        private System.Windows.Forms.Label label_EBV;
        private System.Windows.Forms.TextBox textBox_CYG;
        private System.Windows.Forms.Label label_CYG;
        private System.Windows.Forms.TextBox textBox_CY;
        private System.Windows.Forms.Label label_CY;
        private System.Windows.Forms.Label label_diagnostic;
        private System.Windows.Forms.Label label_Amount_auto_fill_in_setting;
    }
}