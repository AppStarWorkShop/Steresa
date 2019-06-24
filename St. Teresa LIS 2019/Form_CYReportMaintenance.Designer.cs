namespace St.Teresa_LIS_2019
{
    partial class Form_CYReportMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CYReportMaintenance));
            this.comboBox_Report_Code = new System.Windows.Forms.ComboBox();
            this.label_Report_Code = new System.Windows.Forms.Label();
            this.label_Description = new System.Windows.Forms.Label();
            this.button_End = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.button_Top = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_Update_At = new System.Windows.Forms.TextBox();
            this.label_Update_At = new System.Windows.Forms.Label();
            this.textBox_Last_Updated_By_No = new System.Windows.Forms.TextBox();
            this.textBox_Last_Updated_By = new System.Windows.Forms.TextBox();
            this.label_Last_Updated_By = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Report_Code
            // 
            this.comboBox_Report_Code.DisplayMember = "DESC";
            this.comboBox_Report_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Report_Code.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Report_Code.FormattingEnabled = true;
            this.comboBox_Report_Code.Location = new System.Drawing.Point(188, 21);
            this.comboBox_Report_Code.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_Report_Code.Name = "comboBox_Report_Code";
            this.comboBox_Report_Code.Size = new System.Drawing.Size(320, 30);
            this.comboBox_Report_Code.TabIndex = 159;
            this.comboBox_Report_Code.ValueMember = "REPORT";
            this.comboBox_Report_Code.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Report_Code_SelectionChangeCommitted);
            // 
            // label_Report_Code
            // 
            this.label_Report_Code.AutoSize = true;
            this.label_Report_Code.BackColor = System.Drawing.Color.Transparent;
            this.label_Report_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Report_Code.ForeColor = System.Drawing.Color.Black;
            this.label_Report_Code.Location = new System.Drawing.Point(28, 24);
            this.label_Report_Code.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Report_Code.Name = "label_Report_Code";
            this.label_Report_Code.Size = new System.Drawing.Size(140, 24);
            this.label_Report_Code.TabIndex = 158;
            this.label_Report_Code.Text = "Report Code :";
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.BackColor = System.Drawing.Color.Transparent;
            this.label_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Description.ForeColor = System.Drawing.Color.Black;
            this.label_Description.Location = new System.Drawing.Point(28, 58);
            this.label_Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(127, 24);
            this.label_Description.TabIndex = 160;
            this.label_Description.Text = "Description :";
            // 
            // button_End
            // 
            this.button_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_End.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_End.Image = ((System.Drawing.Image)(resources.GetObject("button_End.Image")));
            this.button_End.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_End.Location = new System.Drawing.Point(228, 305);
            this.button_End.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_End.Name = "button_End";
            this.button_End.Size = new System.Drawing.Size(64, 46);
            this.button_End.TabIndex = 164;
            this.button_End.Text = "End";
            this.button_End.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_End.UseVisualStyleBackColor = true;
            this.button_End.Click += new System.EventHandler(this.button_End_Click);
            // 
            // button_Next
            // 
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Next.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Next.Image = ((System.Drawing.Image)(resources.GetObject("button_Next.Image")));
            this.button_Next.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Next.Location = new System.Drawing.Point(156, 305);
            this.button_Next.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(64, 46);
            this.button_Next.TabIndex = 163;
            this.button_Next.Text = "Next";
            this.button_Next.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Back
            // 
            this.button_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Back.Image = ((System.Drawing.Image)(resources.GetObject("button_Back.Image")));
            this.button_Back.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Back.Location = new System.Drawing.Point(84, 305);
            this.button_Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(64, 46);
            this.button_Back.TabIndex = 162;
            this.button_Back.Text = "Back";
            this.button_Back.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // button_Top
            // 
            this.button_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Top.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Top.Image = ((System.Drawing.Image)(resources.GetObject("button_Top.Image")));
            this.button_Top.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Top.Location = new System.Drawing.Point(12, 305);
            this.button_Top.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Top.Name = "button_Top";
            this.button_Top.Size = new System.Drawing.Size(64, 46);
            this.button_Top.TabIndex = 161;
            this.button_Top.Text = "Top";
            this.button_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Top.UseVisualStyleBackColor = true;
            this.button_Top.Click += new System.EventHandler(this.button_Top_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Delete.Location = new System.Drawing.Point(537, 305);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(77, 46);
            this.button_Delete.TabIndex = 171;
            this.button_Delete.Text = "Delete";
            this.button_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Save.Location = new System.Drawing.Point(321, 305);
            this.button_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(64, 46);
            this.button_Save.TabIndex = 170;
            this.button_Save.Text = "Save";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_New
            // 
            this.button_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_New.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_New.Image = ((System.Drawing.Image)(resources.GetObject("button_New.Image")));
            this.button_New.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_New.Location = new System.Drawing.Point(393, 305);
            this.button_New.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(64, 46);
            this.button_New.TabIndex = 169;
            this.button_New.Text = "New";
            this.button_New.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_New.UseVisualStyleBackColor = true;
            this.button_New.Click += new System.EventHandler(this.button_New_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Edit.Image = ((System.Drawing.Image)(resources.GetObject("button_Edit.Image")));
            this.button_Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Edit.Location = new System.Drawing.Point(465, 305);
            this.button_Edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(64, 46);
            this.button_Edit.TabIndex = 168;
            this.button_Edit.Text = "Edit";
            this.button_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Undo
            // 
            this.button_Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Undo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_Undo.Image = ((System.Drawing.Image)(resources.GetObject("button_Undo.Image")));
            this.button_Undo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Undo.Location = new System.Drawing.Point(623, 305);
            this.button_Undo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(69, 46);
            this.button_Undo.TabIndex = 167;
            this.button_Undo.Text = "Undo";
            this.button_Undo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Undo.UseVisualStyleBackColor = true;
            this.button_Undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(700, 305);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(64, 46);
            this.button_Exit.TabIndex = 165;
            this.button_Exit.Text = "Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Desc.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Desc.Location = new System.Drawing.Point(188, 58);
            this.textBox_Desc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Desc.Size = new System.Drawing.Size(553, 200);
            this.textBox_Desc.TabIndex = 239;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Enabled = false;
            this.textBox_ID.Location = new System.Drawing.Point(884, 15);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(12, 25);
            this.textBox_ID.TabIndex = 240;
            // 
            // textBox_Update_At
            // 
            this.textBox_Update_At.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Update_At.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Update_At.Location = new System.Drawing.Point(503, 5);
            this.textBox_Update_At.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Update_At.Name = "textBox_Update_At";
            this.textBox_Update_At.ReadOnly = true;
            this.textBox_Update_At.Size = new System.Drawing.Size(239, 24);
            this.textBox_Update_At.TabIndex = 63;
            this.textBox_Update_At.Text = "02/03/2019 10:48:45 AM";
            // 
            // label_Update_At
            // 
            this.label_Update_At.AutoSize = true;
            this.label_Update_At.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label_Update_At.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Update_At.Location = new System.Drawing.Point(407, 8);
            this.label_Update_At.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Update_At.Name = "label_Update_At";
            this.label_Update_At.Size = new System.Drawing.Size(80, 18);
            this.label_Update_At.TabIndex = 64;
            this.label_Update_At.Text = "Update At :";
            // 
            // textBox_Last_Updated_By_No
            // 
            this.textBox_Last_Updated_By_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Last_Updated_By_No.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Last_Updated_By_No.Location = new System.Drawing.Point(336, 5);
            this.textBox_Last_Updated_By_No.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Last_Updated_By_No.Name = "textBox_Last_Updated_By_No";
            this.textBox_Last_Updated_By_No.ReadOnly = true;
            this.textBox_Last_Updated_By_No.Size = new System.Drawing.Size(41, 24);
            this.textBox_Last_Updated_By_No.TabIndex = 62;
            this.textBox_Last_Updated_By_No.Text = "19";
            this.textBox_Last_Updated_By_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_Last_Updated_By
            // 
            this.textBox_Last_Updated_By.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Last_Updated_By.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Last_Updated_By.Location = new System.Drawing.Point(145, 4);
            this.textBox_Last_Updated_By.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Last_Updated_By.Name = "textBox_Last_Updated_By";
            this.textBox_Last_Updated_By.ReadOnly = true;
            this.textBox_Last_Updated_By.Size = new System.Drawing.Size(181, 24);
            this.textBox_Last_Updated_By.TabIndex = 60;
            this.textBox_Last_Updated_By.Text = "Some one";
            // 
            // label_Last_Updated_By
            // 
            this.label_Last_Updated_By.AutoSize = true;
            this.label_Last_Updated_By.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label_Last_Updated_By.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Last_Updated_By.Location = new System.Drawing.Point(9, 8);
            this.label_Last_Updated_By.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Last_Updated_By.Name = "label_Last_Updated_By";
            this.label_Last_Updated_By.Size = new System.Drawing.Size(132, 18);
            this.label_Last_Updated_By.TabIndex = 61;
            this.label_Last_Updated_By.Text = "Last Updated By  : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.textBox_Update_At);
            this.panel2.Controls.Add(this.label_Update_At);
            this.panel2.Controls.Add(this.textBox_Last_Updated_By_No);
            this.panel2.Controls.Add(this.textBox_Last_Updated_By);
            this.panel2.Controls.Add(this.label_Last_Updated_By);
            this.panel2.Location = new System.Drawing.Point(15, 266);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 34);
            this.panel2.TabIndex = 241;
            // 
            // Form_CYReportMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(779, 360);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.textBox_Desc);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_New);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Undo);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_End);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Top);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.comboBox_Report_Code);
            this.Controls.Add(this.label_Report_Code);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_CYReportMaintenance";
            this.Text = "CY Report Maintenance";
            this.Load += new System.EventHandler(this.Form_CYReportMaintenance_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Report_Code;
        private System.Windows.Forms.Label label_Report_Code;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Button button_End;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Top;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_Update_At;
        private System.Windows.Forms.Label label_Update_At;
        private System.Windows.Forms.TextBox textBox_Last_Updated_By_No;
        private System.Windows.Forms.TextBox textBox_Last_Updated_By;
        private System.Windows.Forms.Label label_Last_Updated_By;
        private System.Windows.Forms.Panel panel2;
    }
}