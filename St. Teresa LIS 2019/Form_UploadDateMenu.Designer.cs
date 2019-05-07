namespace St.Teresa_LIS_2019
{
    partial class Form_UploadDateMenu
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
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_2_Upload_PDF_Report = new System.Windows.Forms.Button();
            this.button_1_Upload_Date_To_STH_WS = new System.Windows.Forms.Button();
            this.label_Line_2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Exit.Location = new System.Drawing.Point(56, 241);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(238, 29);
            this.button_Exit.TabIndex = 83;
            this.button_Exit.Text = "0. Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_2_Upload_PDF_Report
            // 
            this.button_2_Upload_PDF_Report.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_2_Upload_PDF_Report.ForeColor = System.Drawing.Color.DarkViolet;
            this.button_2_Upload_PDF_Report.Location = new System.Drawing.Point(56, 140);
            this.button_2_Upload_PDF_Report.Name = "button_2_Upload_PDF_Report";
            this.button_2_Upload_PDF_Report.Size = new System.Drawing.Size(238, 29);
            this.button_2_Upload_PDF_Report.TabIndex = 85;
            this.button_2_Upload_PDF_Report.Text = "2. Upload PDF Report";
            this.button_2_Upload_PDF_Report.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_2_Upload_PDF_Report.UseVisualStyleBackColor = true;
            // 
            // button_1_Upload_Date_To_STH_WS
            // 
            this.button_1_Upload_Date_To_STH_WS.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_1_Upload_Date_To_STH_WS.ForeColor = System.Drawing.Color.Blue;
            this.button_1_Upload_Date_To_STH_WS.Location = new System.Drawing.Point(56, 65);
            this.button_1_Upload_Date_To_STH_WS.Name = "button_1_Upload_Date_To_STH_WS";
            this.button_1_Upload_Date_To_STH_WS.Size = new System.Drawing.Size(238, 29);
            this.button_1_Upload_Date_To_STH_WS.TabIndex = 84;
            this.button_1_Upload_Date_To_STH_WS.Text = "1. Upload Date To STH - by WS";
            this.button_1_Upload_Date_To_STH_WS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_1_Upload_Date_To_STH_WS.UseVisualStyleBackColor = true;
            this.button_1_Upload_Date_To_STH_WS.Click += new System.EventHandler(this.button_1_Upload_Date_To_STH_WS_Click);
            // 
            // label_Line_2
            // 
            this.label_Line_2.AutoSize = true;
            this.label_Line_2.BackColor = System.Drawing.Color.Transparent;
            this.label_Line_2.Font = new System.Drawing.Font("Palace Script MT", 21F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Line_2.ForeColor = System.Drawing.Color.DarkGray;
            this.label_Line_2.Location = new System.Drawing.Point(-12, 188);
            this.label_Line_2.Name = "label_Line_2";
            this.label_Line_2.Size = new System.Drawing.Size(376, 28);
            this.label_Line_2.TabIndex = 86;
            this.label_Line_2.Text = "__________________________";
            // 
            // Form_UploadDateMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(224)))), ((int)(((byte)(183)))));
            this.ClientSize = new System.Drawing.Size(352, 317);
            this.ControlBox = false;
            this.Controls.Add(this.label_Line_2);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_2_Upload_PDF_Report);
            this.Controls.Add(this.button_1_Upload_Date_To_STH_WS);
            this.Name = "Form_UploadDateMenu";
            this.Text = "Upload Date Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_2_Upload_PDF_Report;
        private System.Windows.Forms.Button button_1_Upload_Date_To_STH_WS;
        private System.Windows.Forms.Label label_Line_2;
    }
}