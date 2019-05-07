namespace St.Teresa_LIS_2019
{
    partial class Form_ImportExportDate
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
            this.button_Client_File = new System.Windows.Forms.Button();
            this.label_Line_2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Exit.Location = new System.Drawing.Point(24, 149);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(238, 29);
            this.button_Exit.TabIndex = 34;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Client_File
            // 
            this.button_Client_File.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Client_File.ForeColor = System.Drawing.Color.DarkBlue;
            this.button_Client_File.Location = new System.Drawing.Point(24, 27);
            this.button_Client_File.Name = "button_Client_File";
            this.button_Client_File.Size = new System.Drawing.Size(238, 29);
            this.button_Client_File.TabIndex = 35;
            this.button_Client_File.Text = "1. Import Data From BIO-TECH";
            this.button_Client_File.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Client_File.UseVisualStyleBackColor = true;
            // 
            // label_Line_2
            // 
            this.label_Line_2.AutoSize = true;
            this.label_Line_2.BackColor = System.Drawing.Color.Transparent;
            this.label_Line_2.Font = new System.Drawing.Font("Palace Script MT", 21F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Line_2.ForeColor = System.Drawing.Color.DarkGray;
            this.label_Line_2.Location = new System.Drawing.Point(8, 97);
            this.label_Line_2.Name = "label_Line_2";
            this.label_Line_2.Size = new System.Drawing.Size(264, 28);
            this.label_Line_2.TabIndex = 78;
            this.label_Line_2.Text = "__________________";
            // 
            // Form_ImportExportDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(224)))), ((int)(((byte)(156)))));
            this.ClientSize = new System.Drawing.Size(284, 201);
            this.ControlBox = false;
            this.Controls.Add(this.button_Client_File);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.label_Line_2);
            this.Name = "Form_ImportExportDate";
            this.Text = "Import / Export Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Client_File;
        private System.Windows.Forms.Label label_Line_2;
    }
}