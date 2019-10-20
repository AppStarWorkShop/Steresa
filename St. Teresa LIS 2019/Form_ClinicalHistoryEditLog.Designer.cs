namespace St.Teresa_LIS_2019
{
    partial class Form_ClinicalHistoryEditLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ClinicalHistoryEditLog));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_F8_Confirm_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, -2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(522, 292);
            this.dataGridView1.TabIndex = 1;
            // 
            // button_F8_Confirm_Exit
            // 
            this.button_F8_Confirm_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F8_Confirm_Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_F8_Confirm_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_F8_Confirm_Exit.Image")));
            this.button_F8_Confirm_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_F8_Confirm_Exit.Location = new System.Drawing.Point(187, 302);
            this.button_F8_Confirm_Exit.Name = "button_F8_Confirm_Exit";
            this.button_F8_Confirm_Exit.Size = new System.Drawing.Size(126, 39);
            this.button_F8_Confirm_Exit.TabIndex = 165;
            this.button_F8_Confirm_Exit.Text = "F8: Confirm Exit";
            this.button_F8_Confirm_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_F8_Confirm_Exit.UseVisualStyleBackColor = true;
            this.button_F8_Confirm_Exit.Click += new System.EventHandler(this.button_F8_Confirm_Exit_Click);
            // 
            // Form_ClinicalHistoryEditLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(221)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(518, 352);
            this.ControlBox = false;
            this.Controls.Add(this.button_F8_Confirm_Exit);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_ClinicalHistoryEditLog";
            this.Text = "Clinical History Edit Log";
            this.Load += new System.EventHandler(this.Form_ClinicalHistoryEditLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_F8_Confirm_Exit;
    }
}