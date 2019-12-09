namespace St.Teresa_LIS_2019
{
    partial class Form_FrozenSectionDianosis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FrozenSectionDianosis));
            this.button_Copy_To_New = new System.Windows.Forms.Button();
            this.comboBox_FZ_Detail = new System.Windows.Forms.ComboBox();
            this.label_Frozen_Section_Diagnosis = new System.Windows.Forms.Label();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_End = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.button_Back = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_New = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Top = new System.Windows.Forms.Button();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Copy_To_New
            // 
            this.button_Copy_To_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Copy_To_New.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Copy_To_New.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Copy_To_New.Location = new System.Drawing.Point(583, 40);
            this.button_Copy_To_New.Name = "button_Copy_To_New";
            this.button_Copy_To_New.Size = new System.Drawing.Size(72, 22);
            this.button_Copy_To_New.TabIndex = 114;
            this.button_Copy_To_New.Text = "Select";
            this.button_Copy_To_New.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Copy_To_New.UseVisualStyleBackColor = true;
            this.button_Copy_To_New.Click += new System.EventHandler(this.button_Copy_To_New_Click);
            // 
            // comboBox_FZ_Detail
            // 
            this.comboBox_FZ_Detail.DisplayMember = "FZ_DETAIL";
            this.comboBox_FZ_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_FZ_Detail.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_FZ_Detail.FormattingEnabled = true;
            this.comboBox_FZ_Detail.Location = new System.Drawing.Point(26, 40);
            this.comboBox_FZ_Detail.Name = "comboBox_FZ_Detail";
            this.comboBox_FZ_Detail.Size = new System.Drawing.Size(519, 26);
            this.comboBox_FZ_Detail.TabIndex = 113;
            this.comboBox_FZ_Detail.ValueMember = "FZ_DETAIL";
            this.comboBox_FZ_Detail.TextChanged += new System.EventHandler(this.comboBox_FZ_Detail_TextChanged);
            this.comboBox_FZ_Detail.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBox_FZ_Detail_PreviewKeyDown);
            // 
            // label_Frozen_Section_Diagnosis
            // 
            this.label_Frozen_Section_Diagnosis.AutoSize = true;
            this.label_Frozen_Section_Diagnosis.BackColor = System.Drawing.Color.Transparent;
            this.label_Frozen_Section_Diagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label_Frozen_Section_Diagnosis.ForeColor = System.Drawing.Color.Black;
            this.label_Frozen_Section_Diagnosis.Location = new System.Drawing.Point(23, 20);
            this.label_Frozen_Section_Diagnosis.Name = "label_Frozen_Section_Diagnosis";
            this.label_Frozen_Section_Diagnosis.Size = new System.Drawing.Size(203, 18);
            this.label_Frozen_Section_Diagnosis.TabIndex = 112;
            this.label_Frozen_Section_Diagnosis.Text = "Frozen Section Diagnosis";
            // 
            // button_Delete
            // 
            this.button_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Delete.Location = new System.Drawing.Point(481, 106);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(64, 43);
            this.button_Delete.TabIndex = 111;
            this.button_Delete.Text = "Delete";
            this.button_Delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_End
            // 
            this.button_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_End.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_End.Image = ((System.Drawing.Image)(resources.GetObject("button_End.Image")));
            this.button_End.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_End.Location = new System.Drawing.Point(209, 109);
            this.button_End.Name = "button_End";
            this.button_End.Size = new System.Drawing.Size(58, 42);
            this.button_End.TabIndex = 110;
            this.button_End.Text = "End";
            this.button_End.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_End.UseVisualStyleBackColor = true;
            this.button_End.Click += new System.EventHandler(this.button_End_Click);
            // 
            // button_Next
            // 
            this.button_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Next.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Next.Image = ((System.Drawing.Image)(resources.GetObject("button_Next.Image")));
            this.button_Next.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Next.Location = new System.Drawing.Point(145, 109);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(58, 42);
            this.button_Next.TabIndex = 109;
            this.button_Next.Text = "Next";
            this.button_Next.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // button_Back
            // 
            this.button_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Back.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Back.Image = ((System.Drawing.Image)(resources.GetObject("button_Back.Image")));
            this.button_Back.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Back.Location = new System.Drawing.Point(17, 109);
            this.button_Back.Name = "button_Back";
            this.button_Back.Size = new System.Drawing.Size(58, 42);
            this.button_Back.TabIndex = 108;
            this.button_Back.Text = "Back";
            this.button_Back.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Back.UseVisualStyleBackColor = true;
            this.button_Back.Click += new System.EventHandler(this.button_Back_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Save.ForeColor = System.Drawing.Color.Gray;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Save.Location = new System.Drawing.Point(298, 106);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(55, 43);
            this.button_Save.TabIndex = 107;
            this.button_Save.Text = "Save";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_New
            // 
            this.button_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_New.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_New.Image = ((System.Drawing.Image)(resources.GetObject("button_New.Image")));
            this.button_New.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_New.Location = new System.Drawing.Point(359, 106);
            this.button_New.Name = "button_New";
            this.button_New.Size = new System.Drawing.Size(55, 43);
            this.button_New.TabIndex = 106;
            this.button_New.Text = "New";
            this.button_New.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_New.UseVisualStyleBackColor = true;
            this.button_New.Click += new System.EventHandler(this.button_New_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Edit.Image = ((System.Drawing.Image)(resources.GetObject("button_Edit.Image")));
            this.button_Edit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Edit.Location = new System.Drawing.Point(420, 106);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(55, 43);
            this.button_Edit.TabIndex = 105;
            this.button_Edit.Text = "Edit";
            this.button_Edit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Undo
            // 
            this.button_Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Undo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button_Undo.Image = ((System.Drawing.Image)(resources.GetObject("button_Undo.Image")));
            this.button_Undo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Undo.Location = new System.Drawing.Point(551, 106);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(60, 43);
            this.button_Undo.TabIndex = 104;
            this.button_Undo.Text = "Undo";
            this.button_Undo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Undo.UseVisualStyleBackColor = true;
            this.button_Undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(617, 106);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(55, 43);
            this.button_Exit.TabIndex = 103;
            this.button_Exit.Text = "Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Top
            // 
            this.button_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Top.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Top.Image = ((System.Drawing.Image)(resources.GetObject("button_Top.Image")));
            this.button_Top.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Top.Location = new System.Drawing.Point(81, 109);
            this.button_Top.Name = "button_Top";
            this.button_Top.Size = new System.Drawing.Size(58, 42);
            this.button_Top.TabIndex = 102;
            this.button_Top.Text = "Top";
            this.button_Top.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Top.UseVisualStyleBackColor = true;
            this.button_Top.Click += new System.EventHandler(this.button_Top_Click);
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(698, 13);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(15, 21);
            this.textBox_ID.TabIndex = 115;
            // 
            // Form_FrozenSectionDianosis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(228)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(684, 170);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.button_Copy_To_New);
            this.Controls.Add(this.comboBox_FZ_Detail);
            this.Controls.Add(this.label_Frozen_Section_Diagnosis);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_End);
            this.Controls.Add(this.button_Next);
            this.Controls.Add(this.button_Back);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_New);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Undo);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Top);
            this.Name = "Form_FrozenSectionDianosis";
            this.Text = "Frozen Section Dianosis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Copy_To_New;
        private System.Windows.Forms.ComboBox comboBox_FZ_Detail;
        private System.Windows.Forms.Label label_Frozen_Section_Diagnosis;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_End;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.Button button_Back;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_New;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Top;
        private System.Windows.Forms.TextBox textBox_ID;
    }
}