namespace St.Teresa_LIS_2019
{
    partial class Form_SelectDoctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SelectDoctor));
            this.textBox_Serch_Doctor = new System.Windows.Forms.TextBox();
            this.label_Serch_Doctor = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Serch_Doctor
            // 
            this.textBox_Serch_Doctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Serch_Doctor.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Serch_Doctor.Location = new System.Drawing.Point(260, 11);
            this.textBox_Serch_Doctor.Name = "textBox_Serch_Doctor";
            this.textBox_Serch_Doctor.Size = new System.Drawing.Size(401, 27);
            this.textBox_Serch_Doctor.TabIndex = 47;
            this.textBox_Serch_Doctor.TextChanged += new System.EventHandler(this.textBox_Serch_Doctor_TextChanged);
            // 
            // label_Serch_Doctor
            // 
            this.label_Serch_Doctor.AutoSize = true;
            this.label_Serch_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.label_Serch_Doctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Serch_Doctor.ForeColor = System.Drawing.Color.Blue;
            this.label_Serch_Doctor.Location = new System.Drawing.Point(115, 14);
            this.label_Serch_Doctor.Name = "label_Serch_Doctor";
            this.label_Serch_Doctor.Size = new System.Drawing.Size(147, 22);
            this.label_Serch_Doctor.TabIndex = 46;
            this.label_Serch_Doctor.Text = "Locate Doctor :";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Cancel.ForeColor = System.Drawing.Color.Red;
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Cancel.Location = new System.Drawing.Point(428, 384);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(119, 41);
            this.button_Cancel.TabIndex = 64;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_OK.ForeColor = System.Drawing.Color.Blue;
            this.button_OK.Image = ((System.Drawing.Image)(resources.GetObject("button_OK.Image")));
            this.button_OK.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_OK.Location = new System.Drawing.Point(236, 384);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(119, 41);
            this.button_OK.TabIndex = 63;
            this.button_OK.Text = "OK";
            this.button_OK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 326);
            this.dataGridView1.TabIndex = 68;
            // 
            // Form_SelectDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(220)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(784, 436);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Serch_Doctor);
            this.Controls.Add(this.label_Serch_Doctor);
            this.Name = "Form_SelectDoctor";
            this.Text = "Select Doctor";
            this.Load += new System.EventHandler(this.Form_SelectDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Serch_Doctor;
        private System.Windows.Forms.Label label_Serch_Doctor;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}