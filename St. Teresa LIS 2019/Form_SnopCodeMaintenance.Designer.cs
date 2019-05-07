namespace St.Teresa_LIS_2019
{
    partial class Form_SnopCodeMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SnopCodeMaintenance));
            this.textBox_Patient = new System.Windows.Forms.TextBox();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_End = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.button_Top = new System.Windows.Forms.Button();
            this.label_Description = new System.Windows.Forms.Label();
            this.comboBox_Report_Code = new System.Windows.Forms.ComboBox();
            this.label_Snop_Code = new System.Windows.Forms.Label();
            this.textBox_Sex = new System.Windows.Forms.TextBox();
            this.label_Snop_Type = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Patient
            // 
            this.textBox_Patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Patient.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Patient.Location = new System.Drawing.Point(209, 126);
            this.textBox_Patient.Name = "textBox_Patient";
            this.textBox_Patient.Size = new System.Drawing.Size(278, 24);
            this.textBox_Patient.TabIndex = 199;
            this.textBox_Patient.Text = "IgA anit EA:";
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Delete.Location = new System.Drawing.Point(405, 182);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(58, 40);
            this.button_Delete.TabIndex = 198;
            this.button_Delete.Text = "Delete";
            this.button_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Save.Location = new System.Drawing.Point(243, 182);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(48, 40);
            this.button_Save.TabIndex = 197;
            this.button_Save.Text = "Save";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // button_New
            // 
            this.button_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_New.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_New.Image = ((System.Drawing.Image)(resources.GetObject("button_New.Image")));
            this.button_New.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_New.Location = new System.Drawing.Point(297, 182);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(48, 40);
            this.button_New.TabIndex = 196;
            this.button_New.Text = "New";
            this.button_New.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_New.UseVisualStyleBackColor = true;
            // 
            // button_Edit
            // 
            this.button_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Edit.Image = ((System.Drawing.Image)(resources.GetObject("button_Edit.Image")));
            this.button_Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Edit.Location = new System.Drawing.Point(351, 182);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(48, 40);
            this.button_Edit.TabIndex = 195;
            this.button_Edit.Text = "Edit";
            this.button_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Edit.UseVisualStyleBackColor = true;
            // 
            // button_Undo
            // 
            this.button_Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Undo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_Undo.Image = ((System.Drawing.Image)(resources.GetObject("button_Undo.Image")));
            this.button_Undo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Undo.Location = new System.Drawing.Point(469, 182);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(52, 40);
            this.button_Undo.TabIndex = 194;
            this.button_Undo.Text = "Undo";
            this.button_Undo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Undo.UseVisualStyleBackColor = true;
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(527, 182);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(48, 40);
            this.button_Exit.TabIndex = 193;
            this.button_Exit.Text = "Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_End
            // 
            this.button_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_End.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_End.Image = ((System.Drawing.Image)(resources.GetObject("button_End.Image")));
            this.button_End.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_End.Location = new System.Drawing.Point(173, 182);
            this.button_End.Name = "button_End";
            this.button_End.Size = new System.Drawing.Size(48, 40);
            this.button_End.TabIndex = 192;
            this.button_End.Text = "End";
            this.button_End.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_End.UseVisualStyleBackColor = true;
            // 
            // button_Next
            // 
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Next.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Next.Image = ((System.Drawing.Image)(resources.GetObject("button_Next.Image")));
            this.button_Next.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Next.Location = new System.Drawing.Point(119, 182);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(48, 40);
            this.button_Next.TabIndex = 191;
            this.button_Next.Text = "Next";
            this.button_Next.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Next.UseVisualStyleBackColor = true;
            // 
            // button_Back
            // 
            this.button_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Back.Image = ((System.Drawing.Image)(resources.GetObject("button_Back.Image")));
            this.button_Back.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Back.Location = new System.Drawing.Point(65, 182);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(48, 40);
            this.button_Back.TabIndex = 190;
            this.button_Back.Text = "Back";
            this.button_Back.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Back.UseVisualStyleBackColor = true;
            // 
            // button_Top
            // 
            this.button_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Top.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Top.Image = ((System.Drawing.Image)(resources.GetObject("button_Top.Image")));
            this.button_Top.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Top.Location = new System.Drawing.Point(11, 182);
            this.button_Top.Name = "button_Top";
            this.button_Top.Size = new System.Drawing.Size(48, 40);
            this.button_Top.TabIndex = 189;
            this.button_Top.Text = "Top";
            this.button_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Top.UseVisualStyleBackColor = true;
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.BackColor = System.Drawing.Color.Transparent;
            this.label_Description.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Description.ForeColor = System.Drawing.Color.Black;
            this.label_Description.Location = new System.Drawing.Point(85, 129);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(122, 21);
            this.label_Description.TabIndex = 188;
            this.label_Description.Text = "Description :";
            // 
            // comboBox_Report_Code
            // 
            this.comboBox_Report_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Report_Code.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Report_Code.FormattingEnabled = true;
            this.comboBox_Report_Code.Location = new System.Drawing.Point(209, 36);
            this.comboBox_Report_Code.Name = "comboBox_Report_Code";
            this.comboBox_Report_Code.Size = new System.Drawing.Size(135, 26);
            this.comboBox_Report_Code.TabIndex = 187;
            this.comboBox_Report_Code.Text = "NPIGA";
            // 
            // label_Snop_Code
            // 
            this.label_Snop_Code.AutoSize = true;
            this.label_Snop_Code.BackColor = System.Drawing.Color.Transparent;
            this.label_Snop_Code.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Snop_Code.ForeColor = System.Drawing.Color.Black;
            this.label_Snop_Code.Location = new System.Drawing.Point(85, 39);
            this.label_Snop_Code.Name = "label_Snop_Code";
            this.label_Snop_Code.Size = new System.Drawing.Size(118, 21);
            this.label_Snop_Code.TabIndex = 186;
            this.label_Snop_Code.Text = "Snop Code :";
            // 
            // textBox_Sex
            // 
            this.textBox_Sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Sex.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Sex.Location = new System.Drawing.Point(209, 78);
            this.textBox_Sex.Name = "textBox_Sex";
            this.textBox_Sex.Size = new System.Drawing.Size(25, 26);
            this.textBox_Sex.TabIndex = 200;
            this.textBox_Sex.Text = "M";
            // 
            // label_Snop_Type
            // 
            this.label_Snop_Type.AutoSize = true;
            this.label_Snop_Type.BackColor = System.Drawing.Color.Transparent;
            this.label_Snop_Type.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Snop_Type.ForeColor = System.Drawing.Color.Black;
            this.label_Snop_Type.Location = new System.Drawing.Point(85, 82);
            this.label_Snop_Type.Name = "label_Snop_Type";
            this.label_Snop_Type.Size = new System.Drawing.Size(115, 21);
            this.label_Snop_Type.TabIndex = 201;
            this.label_Snop_Type.Text = "Snop Type :";
            // 
            // Form_SnopCodeMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(231)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(584, 248);
            this.ControlBox = false;
            this.Controls.Add(this.label_Snop_Type);
            this.Controls.Add(this.textBox_Sex);
            this.Controls.Add(this.textBox_Patient);
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
            this.Controls.Add(this.label_Snop_Code);
            this.Name = "Form_SnopCodeMaintenance";
            this.Text = "Snop Code Maintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Patient;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_End;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Top;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.ComboBox comboBox_Report_Code;
        private System.Windows.Forms.Label label_Snop_Code;
        private System.Windows.Forms.TextBox textBox_Sex;
        private System.Windows.Forms.Label label_Snop_Type;
    }
}