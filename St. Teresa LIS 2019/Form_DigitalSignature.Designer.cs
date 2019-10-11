namespace St.Teresa_LIS_2019
{
    partial class Form_DigitalSignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DigitalSignature));
            this.button_Import_ready_cases = new System.Windows.Forms.Button();
            this.textBox_Case_No = new System.Windows.Forms.TextBox();
            this.label_Case_No = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Clear_all = new System.Windows.Forms.Button();
            this.button_Sign_Selected_Cases = new System.Windows.Forms.Button();
            this.button_Select_all = new System.Windows.Forms.Button();
            this.button_Unselect_all = new System.Windows.Forms.Button();
            this.button_Clear_cases = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_Selected = new System.Windows.Forms.Label();
            this.label_Pending = new System.Windows.Forms.Label();
            this.label_Total_No = new System.Windows.Forms.Label();
            this.label_Selected_No = new System.Windows.Forms.Label();
            this.label_Pending_No = new System.Windows.Forms.Label();
            this.button_F6_View_Record = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Import_ready_cases
            // 
            this.button_Import_ready_cases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Import_ready_cases.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Import_ready_cases.Location = new System.Drawing.Point(684, 8);
            this.button_Import_ready_cases.Name = "button_Import_ready_cases";
            this.button_Import_ready_cases.Size = new System.Drawing.Size(187, 31);
            this.button_Import_ready_cases.TabIndex = 85;
            this.button_Import_ready_cases.Text = "Import ready cases";
            this.button_Import_ready_cases.UseVisualStyleBackColor = true;
            // 
            // textBox_Case_No
            // 
            this.textBox_Case_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Case_No.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Case_No.Location = new System.Drawing.Point(12, 31);
            this.textBox_Case_No.Name = "textBox_Case_No";
            this.textBox_Case_No.Size = new System.Drawing.Size(254, 27);
            this.textBox_Case_No.TabIndex = 84;
            // 
            // label_Case_No
            // 
            this.label_Case_No.AutoSize = true;
            this.label_Case_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Case_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Case_No.ForeColor = System.Drawing.Color.Blue;
            this.label_Case_No.Location = new System.Drawing.Point(8, 8);
            this.label_Case_No.Name = "label_Case_No";
            this.label_Case_No.Size = new System.Drawing.Size(105, 22);
            this.label_Case_No.TabIndex = 83;
            this.label_Case_No.Text = "Case No. :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-4, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(891, 366);
            this.dataGridView1.TabIndex = 86;
            // 
            // button_Clear_all
            // 
            this.button_Clear_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Clear_all.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Clear_all.Location = new System.Drawing.Point(743, 41);
            this.button_Clear_all.Name = "button_Clear_all";
            this.button_Clear_all.Size = new System.Drawing.Size(129, 31);
            this.button_Clear_all.TabIndex = 87;
            this.button_Clear_all.Text = "Clear all";
            this.button_Clear_all.UseVisualStyleBackColor = true;
            // 
            // button_Sign_Selected_Cases
            // 
            this.button_Sign_Selected_Cases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Sign_Selected_Cases.ForeColor = System.Drawing.Color.DarkBlue;
            this.button_Sign_Selected_Cases.Location = new System.Drawing.Point(11, 454);
            this.button_Sign_Selected_Cases.Name = "button_Sign_Selected_Cases";
            this.button_Sign_Selected_Cases.Size = new System.Drawing.Size(228, 39);
            this.button_Sign_Selected_Cases.TabIndex = 88;
            this.button_Sign_Selected_Cases.Text = "Sign Selected cases";
            this.button_Sign_Selected_Cases.UseVisualStyleBackColor = true;
            this.button_Sign_Selected_Cases.Click += new System.EventHandler(this.button_Sign_Selected_Cases_Click);
            // 
            // button_Select_all
            // 
            this.button_Select_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Select_all.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Select_all.Location = new System.Drawing.Point(245, 454);
            this.button_Select_all.Name = "button_Select_all";
            this.button_Select_all.Size = new System.Drawing.Size(133, 39);
            this.button_Select_all.TabIndex = 89;
            this.button_Select_all.Text = "Select all";
            this.button_Select_all.UseVisualStyleBackColor = true;
            this.button_Select_all.Click += new System.EventHandler(this.button_Select_all_Click);
            // 
            // button_Unselect_all
            // 
            this.button_Unselect_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Unselect_all.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Unselect_all.Location = new System.Drawing.Point(384, 454);
            this.button_Unselect_all.Name = "button_Unselect_all";
            this.button_Unselect_all.Size = new System.Drawing.Size(133, 39);
            this.button_Unselect_all.TabIndex = 90;
            this.button_Unselect_all.Text = "Unselect all";
            this.button_Unselect_all.UseVisualStyleBackColor = true;
            this.button_Unselect_all.Click += new System.EventHandler(this.button_Unselect_all_Click);
            // 
            // button_Clear_cases
            // 
            this.button_Clear_cases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Clear_cases.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Clear_cases.Image = ((System.Drawing.Image)(resources.GetObject("button_Clear_cases.Image")));
            this.button_Clear_cases.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Clear_cases.Location = new System.Drawing.Point(523, 454);
            this.button_Clear_cases.Name = "button_Clear_cases";
            this.button_Clear_cases.Size = new System.Drawing.Size(133, 39);
            this.button_Clear_cases.TabIndex = 91;
            this.button_Clear_cases.Text = "Clear cases";
            this.button_Clear_cases.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Clear_cases.UseVisualStyleBackColor = true;
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(771, 454);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(100, 39);
            this.button_Exit.TabIndex = 219;
            this.button_Exit.Text = "Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.BackColor = System.Drawing.Color.Transparent;
            this.label_Total.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total.ForeColor = System.Drawing.Color.Black;
            this.label_Total.Location = new System.Drawing.Point(329, 11);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(49, 16);
            this.label_Total.TabIndex = 220;
            this.label_Total.Text = "Total :";
            // 
            // label_Selected
            // 
            this.label_Selected.AutoSize = true;
            this.label_Selected.BackColor = System.Drawing.Color.Transparent;
            this.label_Selected.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Selected.ForeColor = System.Drawing.Color.Black;
            this.label_Selected.Location = new System.Drawing.Point(300, 31);
            this.label_Selected.Name = "label_Selected";
            this.label_Selected.Size = new System.Drawing.Size(78, 16);
            this.label_Selected.TabIndex = 221;
            this.label_Selected.Text = "Selected :";
            // 
            // label_Pending
            // 
            this.label_Pending.AutoSize = true;
            this.label_Pending.BackColor = System.Drawing.Color.Transparent;
            this.label_Pending.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Pending.ForeColor = System.Drawing.Color.Black;
            this.label_Pending.Location = new System.Drawing.Point(304, 51);
            this.label_Pending.Name = "label_Pending";
            this.label_Pending.Size = new System.Drawing.Size(74, 16);
            this.label_Pending.TabIndex = 222;
            this.label_Pending.Text = "Pending :";
            // 
            // label_Total_No
            // 
            this.label_Total_No.AutoSize = true;
            this.label_Total_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Total_No.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total_No.ForeColor = System.Drawing.Color.Black;
            this.label_Total_No.Location = new System.Drawing.Point(384, 11);
            this.label_Total_No.Name = "label_Total_No";
            this.label_Total_No.Size = new System.Drawing.Size(16, 16);
            this.label_Total_No.TabIndex = 223;
            this.label_Total_No.Text = "2";
            // 
            // label_Selected_No
            // 
            this.label_Selected_No.AutoSize = true;
            this.label_Selected_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Selected_No.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Selected_No.ForeColor = System.Drawing.Color.Black;
            this.label_Selected_No.Location = new System.Drawing.Point(384, 31);
            this.label_Selected_No.Name = "label_Selected_No";
            this.label_Selected_No.Size = new System.Drawing.Size(16, 16);
            this.label_Selected_No.TabIndex = 224;
            this.label_Selected_No.Text = "1";
            // 
            // label_Pending_No
            // 
            this.label_Pending_No.AutoSize = true;
            this.label_Pending_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Pending_No.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Pending_No.ForeColor = System.Drawing.Color.Black;
            this.label_Pending_No.Location = new System.Drawing.Point(384, 51);
            this.label_Pending_No.Name = "label_Pending_No";
            this.label_Pending_No.Size = new System.Drawing.Size(16, 16);
            this.label_Pending_No.TabIndex = 225;
            this.label_Pending_No.Text = "1";
            // 
            // button_F6_View_Record
            // 
            this.button_F6_View_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F6_View_Record.ForeColor = System.Drawing.Color.Black;
            this.button_F6_View_Record.Location = new System.Drawing.Point(537, 42);
            this.button_F6_View_Record.Name = "button_F6_View_Record";
            this.button_F6_View_Record.Size = new System.Drawing.Size(109, 30);
            this.button_F6_View_Record.TabIndex = 226;
            this.button_F6_View_Record.Text = "F6. View Record";
            this.button_F6_View_Record.UseVisualStyleBackColor = true;
            this.button_F6_View_Record.Click += new System.EventHandler(this.button_F6_View_Record_Click);
            // 
            // Form_DigitalSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(189)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(884, 506);
            this.ControlBox = false;
            this.Controls.Add(this.button_F6_View_Record);
            this.Controls.Add(this.label_Pending_No);
            this.Controls.Add(this.label_Selected_No);
            this.Controls.Add(this.label_Total_No);
            this.Controls.Add(this.label_Pending);
            this.Controls.Add(this.label_Selected);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Clear_cases);
            this.Controls.Add(this.button_Unselect_all);
            this.Controls.Add(this.button_Select_all);
            this.Controls.Add(this.button_Sign_Selected_Cases);
            this.Controls.Add(this.button_Clear_all);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Import_ready_cases);
            this.Controls.Add(this.textBox_Case_No);
            this.Controls.Add(this.label_Case_No);
            this.Name = "Form_DigitalSignature";
            this.Text = "Digital Signature";
            this.Load += new System.EventHandler(this.Form_DigitalSignature_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Import_ready_cases;
        private System.Windows.Forms.TextBox textBox_Case_No;
        private System.Windows.Forms.Label label_Case_No;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Clear_all;
        private System.Windows.Forms.Button button_Sign_Selected_Cases;
        private System.Windows.Forms.Button button_Select_all;
        private System.Windows.Forms.Button button_Unselect_all;
        private System.Windows.Forms.Button button_Clear_cases;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label_Selected;
        private System.Windows.Forms.Label label_Pending;
        private System.Windows.Forms.Label label_Total_No;
        private System.Windows.Forms.Label label_Selected_No;
        private System.Windows.Forms.Label label_Pending_No;
        private System.Windows.Forms.Button button_F6_View_Record;
    }
}