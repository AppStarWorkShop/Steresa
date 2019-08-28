namespace St.Teresa_LIS_2019
{
    partial class Form_PictureCaptionMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_PictureCaptionMaintenance));
            this.comboBox_Caption = new System.Windows.Forms.ComboBox();
            this.label_Caption = new System.Windows.Forms.Label();
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
            this.Select = new System.Windows.Forms.Button();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox_Caption
            // 
            this.comboBox_Caption.DisplayMember = "CAPTION";
            this.comboBox_Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Caption.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Caption.FormattingEnabled = true;
            this.comboBox_Caption.Items.AddRange(new object[] {
            "Chinese"});
            this.comboBox_Caption.Location = new System.Drawing.Point(131, 40);
            this.comboBox_Caption.Name = "comboBox_Caption";
            this.comboBox_Caption.Size = new System.Drawing.Size(356, 26);
            this.comboBox_Caption.TabIndex = 277;
            this.comboBox_Caption.Text = "Figrue01";
            this.comboBox_Caption.ValueMember = "CAPTION";
            this.comboBox_Caption.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Caption_SelectionChangeCommitted);
            // 
            // label_Caption
            // 
            this.label_Caption.AutoSize = true;
            this.label_Caption.BackColor = System.Drawing.Color.Transparent;
            this.label_Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Caption.ForeColor = System.Drawing.Color.Black;
            this.label_Caption.Location = new System.Drawing.Point(49, 42);
            this.label_Caption.Name = "label_Caption";
            this.label_Caption.Size = new System.Drawing.Size(76, 18);
            this.label_Caption.TabIndex = 276;
            this.label_Caption.Text = "Caption :";
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Delete.Location = new System.Drawing.Point(405, 108);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(58, 37);
            this.button_Delete.TabIndex = 287;
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
            this.button_Save.Location = new System.Drawing.Point(243, 108);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(48, 37);
            this.button_Save.TabIndex = 286;
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
            this.button_New.Location = new System.Drawing.Point(297, 108);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(48, 37);
            this.button_New.TabIndex = 285;
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
            this.button_Edit.Location = new System.Drawing.Point(351, 108);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(48, 37);
            this.button_Edit.TabIndex = 284;
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
            this.button_Undo.Location = new System.Drawing.Point(469, 108);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(52, 37);
            this.button_Undo.TabIndex = 283;
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
            this.button_Exit.Location = new System.Drawing.Point(527, 108);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(48, 37);
            this.button_Exit.TabIndex = 282;
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
            this.button_End.Location = new System.Drawing.Point(173, 108);
            this.button_End.Name = "button_End";
            this.button_End.Size = new System.Drawing.Size(48, 37);
            this.button_End.TabIndex = 281;
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
            this.button_Next.Location = new System.Drawing.Point(119, 108);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(48, 37);
            this.button_Next.TabIndex = 280;
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
            this.button_Back.Location = new System.Drawing.Point(65, 108);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(48, 37);
            this.button_Back.TabIndex = 279;
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
            this.button_Top.Location = new System.Drawing.Point(11, 108);
            this.button_Top.Name = "button_Top";
            this.button_Top.Size = new System.Drawing.Size(48, 37);
            this.button_Top.TabIndex = 278;
            this.button_Top.Text = "Top";
            this.button_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Top.UseVisualStyleBackColor = true;
            this.button_Top.Click += new System.EventHandler(this.button_Top_Click);
            // 
            // Select
            // 
            this.Select.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select.ForeColor = System.Drawing.Color.Black;
            this.Select.Location = new System.Drawing.Point(508, 42);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(67, 20);
            this.Select.TabIndex = 288;
            this.Select.Text = "Select";
            this.Select.UseVisualStyleBackColor = true;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(634, 12);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(12, 21);
            this.textBox_ID.TabIndex = 289;
            // 
            // Form_PictureCaptionMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(220)))), ((int)(((byte)(131)))));
            this.ClientSize = new System.Drawing.Size(584, 161);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.Select);
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
            this.Controls.Add(this.comboBox_Caption);
            this.Controls.Add(this.label_Caption);
            this.Name = "Form_PictureCaptionMaintenance";
            this.Text = "Picture Caption Maintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Caption;
        private System.Windows.Forms.Label label_Caption;
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
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.TextBox textBox_ID;
    }
}