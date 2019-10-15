namespace St.Teresa_LIS_2019
{
    partial class Form_DoctorsSignatureMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DoctorsSignatureMaintenance));
            this.label_Picture_Path = new System.Windows.Forms.Label();
            this.comboBox_Doctor = new System.Windows.Forms.ComboBox();
            this.button_Picture_File_4_Path = new System.Windows.Forms.Button();
            this.textBox_Sign_Img = new System.Windows.Forms.TextBox();
            this.button_Detail_2 = new System.Windows.Forms.Button();
            this.textBox_Doctor_No = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Picture_Path
            // 
            this.label_Picture_Path.AutoSize = true;
            this.label_Picture_Path.BackColor = System.Drawing.Color.Transparent;
            this.label_Picture_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Picture_Path.ForeColor = System.Drawing.Color.Black;
            this.label_Picture_Path.Location = new System.Drawing.Point(19, 32);
            this.label_Picture_Path.Name = "label_Picture_Path";
            this.label_Picture_Path.Size = new System.Drawing.Size(73, 20);
            this.label_Picture_Path.TabIndex = 197;
            this.label_Picture_Path.Text = "Doctor :";
            // 
            // comboBox_Doctor
            // 
            this.comboBox_Doctor.DisplayMember = "DOCTOR";
            this.comboBox_Doctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Doctor.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Doctor.FormattingEnabled = true;
            this.comboBox_Doctor.Location = new System.Drawing.Point(98, 30);
            this.comboBox_Doctor.Name = "comboBox_Doctor";
            this.comboBox_Doctor.Size = new System.Drawing.Size(379, 26);
            this.comboBox_Doctor.TabIndex = 198;
            this.comboBox_Doctor.ValueMember = "DOCTOR";
            this.comboBox_Doctor.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Doctor_SelectionChangeCommitted);
            // 
            // button_Picture_File_4_Path
            // 
            this.button_Picture_File_4_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Picture_File_4_Path.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Picture_File_4_Path.Location = new System.Drawing.Point(448, 86);
            this.button_Picture_File_4_Path.Name = "button_Picture_File_4_Path";
            this.button_Picture_File_4_Path.Size = new System.Drawing.Size(29, 24);
            this.button_Picture_File_4_Path.TabIndex = 201;
            this.button_Picture_File_4_Path.Text = "...";
            this.button_Picture_File_4_Path.UseVisualStyleBackColor = true;
            // 
            // textBox_Sign_Img
            // 
            this.textBox_Sign_Img.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Sign_Img.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Sign_Img.Location = new System.Drawing.Point(209, 88);
            this.textBox_Sign_Img.Name = "textBox_Sign_Img";
            this.textBox_Sign_Img.Size = new System.Drawing.Size(240, 24);
            this.textBox_Sign_Img.TabIndex = 200;
            // 
            // button_Detail_2
            // 
            this.button_Detail_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Detail_2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Detail_2.Location = new System.Drawing.Point(483, 32);
            this.button_Detail_2.Name = "button_Detail_2";
            this.button_Detail_2.Size = new System.Drawing.Size(97, 24);
            this.button_Detail_2.TabIndex = 202;
            this.button_Detail_2.Text = "Select";
            this.button_Detail_2.UseVisualStyleBackColor = true;
            this.button_Detail_2.Click += new System.EventHandler(this.button_Detail_2_Click);
            // 
            // textBox_Doctor_No
            // 
            this.textBox_Doctor_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Doctor_No.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Doctor_No.Location = new System.Drawing.Point(98, 60);
            this.textBox_Doctor_No.Name = "textBox_Doctor_No";
            this.textBox_Doctor_No.Size = new System.Drawing.Size(39, 24);
            this.textBox_Doctor_No.TabIndex = 203;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 204;
            this.label1.Text = "Index :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 20);
            this.label2.TabIndex = 205;
            this.label2.Text = "Signatory Image File :";
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Delete.Location = new System.Drawing.Point(410, 142);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(58, 37);
            this.button_Delete.TabIndex = 215;
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
            this.button_Save.Location = new System.Drawing.Point(248, 142);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(48, 37);
            this.button_Save.TabIndex = 214;
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
            this.button_New.Location = new System.Drawing.Point(302, 142);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(48, 37);
            this.button_New.TabIndex = 213;
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
            this.button_Edit.Location = new System.Drawing.Point(356, 142);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(48, 37);
            this.button_Edit.TabIndex = 212;
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
            this.button_Undo.Location = new System.Drawing.Point(474, 142);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(52, 37);
            this.button_Undo.TabIndex = 211;
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
            this.button_Exit.Location = new System.Drawing.Point(532, 142);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(48, 37);
            this.button_Exit.TabIndex = 210;
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
            this.button_End.Location = new System.Drawing.Point(178, 142);
            this.button_End.Name = "button_End";
            this.button_End.Size = new System.Drawing.Size(48, 37);
            this.button_End.TabIndex = 209;
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
            this.button_Next.Location = new System.Drawing.Point(124, 142);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(48, 37);
            this.button_Next.TabIndex = 208;
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
            this.button_Back.Location = new System.Drawing.Point(70, 142);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(48, 37);
            this.button_Back.TabIndex = 207;
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
            this.button_Top.Location = new System.Drawing.Point(16, 142);
            this.button_Top.Name = "button_Top";
            this.button_Top.Size = new System.Drawing.Size(48, 37);
            this.button_Top.TabIndex = 206;
            this.button_Top.Text = "Top";
            this.button_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Top.UseVisualStyleBackColor = true;
            this.button_Top.Click += new System.EventHandler(this.button_Top_Click);
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(596, 12);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(14, 21);
            this.textBox_ID.TabIndex = 216;
            // 
            // Form_DoctorsSignatureMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(224)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(587, 190);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_ID);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Doctor_No);
            this.Controls.Add(this.button_Detail_2);
            this.Controls.Add(this.button_Picture_File_4_Path);
            this.Controls.Add(this.textBox_Sign_Img);
            this.Controls.Add(this.comboBox_Doctor);
            this.Controls.Add(this.label_Picture_Path);
            this.Name = "Form_DoctorsSignatureMaintenance";
            this.Text = "Doctors Signature Maintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Picture_Path;
        private System.Windows.Forms.ComboBox comboBox_Doctor;
        private System.Windows.Forms.Button button_Picture_File_4_Path;
        private System.Windows.Forms.TextBox textBox_Sign_Img;
        private System.Windows.Forms.Button button_Detail_2;
        private System.Windows.Forms.TextBox textBox_Doctor_No;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TextBox textBox_ID;
    }
}