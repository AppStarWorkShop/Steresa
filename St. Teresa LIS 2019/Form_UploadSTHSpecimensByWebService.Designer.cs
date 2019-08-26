﻿namespace St.Teresa_LIS_2019
{
    partial class Form_UploadSTHSpecimensByWebService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_UploadSTHSpecimensByWebService));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Barcode_No = new System.Windows.Forms.TextBox();
            this.label_Barcode_No = new System.Windows.Forms.Label();
            this.panel_BX_CY_SPECIMEN = new System.Windows.Forms.Panel();
            this.label_Upload_info = new System.Windows.Forms.Label();
            this.button_Upload_To_Server = new System.Windows.Forms.Button();
            this.label_Or = new System.Windows.Forms.Label();
            this.textBox_Case_No = new System.Windows.Forms.TextBox();
            this.label_Case_No = new System.Windows.Forms.Label();
            this.label_Upload_To_Server = new System.Windows.Forms.Label();
            this.textBox_Upload_To_Server_Path = new System.Windows.Forms.TextBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Upload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Uploaded_no = new System.Windows.Forms.Label();
            this.label_Uploaded = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_Failure_PDF_no = new System.Windows.Forms.Label();
            this.label_Failure_PDF = new System.Windows.Forms.Label();
            this.label_Total_Rec_no = new System.Windows.Forms.Label();
            this.label_Total_Rec = new System.Windows.Forms.Label();
            this.button_Autogen_Barcodres = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_BX_CY_SPECIMEN.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(781, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox_Barcode_No
            // 
            this.textBox_Barcode_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Barcode_No.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Barcode_No.Location = new System.Drawing.Point(136, 64);
            this.textBox_Barcode_No.Name = "textBox_Barcode_No";
            this.textBox_Barcode_No.Size = new System.Drawing.Size(190, 26);
            this.textBox_Barcode_No.TabIndex = 158;
            this.textBox_Barcode_No.Text = "BX19/123456";
            // 
            // label_Barcode_No
            // 
            this.label_Barcode_No.AutoSize = true;
            this.label_Barcode_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Barcode_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Barcode_No.ForeColor = System.Drawing.Color.Black;
            this.label_Barcode_No.Location = new System.Drawing.Point(12, 67);
            this.label_Barcode_No.Name = "label_Barcode_No";
            this.label_Barcode_No.Size = new System.Drawing.Size(118, 20);
            this.label_Barcode_No.TabIndex = 157;
            this.label_Barcode_No.Text = "Barcode No. :";
            // 
            // panel_BX_CY_SPECIMEN
            // 
            this.panel_BX_CY_SPECIMEN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(231)))), ((int)(((byte)(166)))));
            this.panel_BX_CY_SPECIMEN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_BX_CY_SPECIMEN.Controls.Add(this.label_Upload_info);
            this.panel_BX_CY_SPECIMEN.Location = new System.Drawing.Point(12, 12);
            this.panel_BX_CY_SPECIMEN.Name = "panel_BX_CY_SPECIMEN";
            this.panel_BX_CY_SPECIMEN.Size = new System.Drawing.Size(760, 44);
            this.panel_BX_CY_SPECIMEN.TabIndex = 156;
            // 
            // label_Upload_info
            // 
            this.label_Upload_info.AutoSize = true;
            this.label_Upload_info.BackColor = System.Drawing.Color.Transparent;
            this.label_Upload_info.Font = new System.Drawing.Font("Perpetua", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Upload_info.ForeColor = System.Drawing.Color.Blue;
            this.label_Upload_info.Location = new System.Drawing.Point(37, 8);
            this.label_Upload_info.Name = "label_Upload_info";
            this.label_Upload_info.Size = new System.Drawing.Size(664, 25);
            this.label_Upload_info.TabIndex = 6;
            this.label_Upload_info.Text = "Upload Specimen Records To STH\'s Database Server -- by Web Service";
            // 
            // button_Upload_To_Server
            // 
            this.button_Upload_To_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Upload_To_Server.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Upload_To_Server.Location = new System.Drawing.Point(697, 462);
            this.button_Upload_To_Server.Name = "button_Upload_To_Server";
            this.button_Upload_To_Server.Size = new System.Drawing.Size(33, 27);
            this.button_Upload_To_Server.TabIndex = 160;
            this.button_Upload_To_Server.Text = "...";
            this.button_Upload_To_Server.UseVisualStyleBackColor = true;
            // 
            // label_Or
            // 
            this.label_Or.AutoSize = true;
            this.label_Or.BackColor = System.Drawing.Color.Transparent;
            this.label_Or.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Or.ForeColor = System.Drawing.Color.Black;
            this.label_Or.Location = new System.Drawing.Point(332, 69);
            this.label_Or.Name = "label_Or";
            this.label_Or.Size = new System.Drawing.Size(50, 18);
            this.label_Or.TabIndex = 161;
            this.label_Or.Text = "-- or --";
            // 
            // textBox_Case_No
            // 
            this.textBox_Case_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Case_No.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Case_No.Location = new System.Drawing.Point(486, 65);
            this.textBox_Case_No.Name = "textBox_Case_No";
            this.textBox_Case_No.Size = new System.Drawing.Size(156, 26);
            this.textBox_Case_No.TabIndex = 163;
            // 
            // label_Case_No
            // 
            this.label_Case_No.AutoSize = true;
            this.label_Case_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Case_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Case_No.ForeColor = System.Drawing.Color.Black;
            this.label_Case_No.Location = new System.Drawing.Point(388, 67);
            this.label_Case_No.Name = "label_Case_No";
            this.label_Case_No.Size = new System.Drawing.Size(92, 20);
            this.label_Case_No.TabIndex = 162;
            this.label_Case_No.Text = "Case No. :";
            this.label_Case_No.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_Upload_To_Server
            // 
            this.label_Upload_To_Server.AutoSize = true;
            this.label_Upload_To_Server.BackColor = System.Drawing.Color.Transparent;
            this.label_Upload_To_Server.Font = new System.Drawing.Font("Perpetua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Upload_To_Server.ForeColor = System.Drawing.Color.Black;
            this.label_Upload_To_Server.Location = new System.Drawing.Point(19, 465);
            this.label_Upload_To_Server.Name = "label_Upload_To_Server";
            this.label_Upload_To_Server.Size = new System.Drawing.Size(120, 18);
            this.label_Upload_To_Server.TabIndex = 7;
            this.label_Upload_To_Server.Text = "Upload To Server";
            // 
            // textBox_Upload_To_Server_Path
            // 
            this.textBox_Upload_To_Server_Path.BackColor = System.Drawing.Color.LightGray;
            this.textBox_Upload_To_Server_Path.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Upload_To_Server_Path.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Upload_To_Server_Path.Location = new System.Drawing.Point(153, 462);
            this.textBox_Upload_To_Server_Path.Name = "textBox_Upload_To_Server_Path";
            this.textBox_Upload_To_Server_Path.Size = new System.Drawing.Size(538, 24);
            this.textBox_Upload_To_Server_Path.TabIndex = 164;
            this.textBox_Upload_To_Server_Path.Text = "http://sthwebservice.sth.com";
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(392, 500);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(100, 42);
            this.button_Exit.TabIndex = 182;
            this.button_Exit.Text = "Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Palace Script MT", 21F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(-3, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(838, 28);
            this.label8.TabIndex = 216;
            this.label8.Text = "___________________________________________________________";
            // 
            // button_Upload
            // 
            this.button_Upload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Upload.ForeColor = System.Drawing.Color.Blue;
            this.button_Upload.Image = ((System.Drawing.Image)(resources.GetObject("button_Upload.Image")));
            this.button_Upload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Upload.Location = new System.Drawing.Point(260, 500);
            this.button_Upload.Name = "button_Upload";
            this.button_Upload.Size = new System.Drawing.Size(100, 42);
            this.button_Upload.TabIndex = 217;
            this.button_Upload.Text = "Upload";
            this.button_Upload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Upload.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(238)))), ((int)(((byte)(184)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_Uploaded_no);
            this.panel1.Controls.Add(this.label_Uploaded);
            this.panel1.Location = new System.Drawing.Point(12, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 42);
            this.panel1.TabIndex = 157;
            // 
            // label_Uploaded_no
            // 
            this.label_Uploaded_no.AutoSize = true;
            this.label_Uploaded_no.BackColor = System.Drawing.Color.Transparent;
            this.label_Uploaded_no.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Uploaded_no.ForeColor = System.Drawing.Color.Blue;
            this.label_Uploaded_no.Location = new System.Drawing.Point(98, 12);
            this.label_Uploaded_no.Name = "label_Uploaded_no";
            this.label_Uploaded_no.Size = new System.Drawing.Size(18, 19);
            this.label_Uploaded_no.TabIndex = 219;
            this.label_Uploaded_no.Text = "0";
            // 
            // label_Uploaded
            // 
            this.label_Uploaded.AutoSize = true;
            this.label_Uploaded.BackColor = System.Drawing.Color.Transparent;
            this.label_Uploaded.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Uploaded.ForeColor = System.Drawing.Color.Blue;
            this.label_Uploaded.Location = new System.Drawing.Point(6, 12);
            this.label_Uploaded.Name = "label_Uploaded";
            this.label_Uploaded.Size = new System.Drawing.Size(93, 19);
            this.label_Uploaded.TabIndex = 218;
            this.label_Uploaded.Text = "Uploaded :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(238)))), ((int)(((byte)(184)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_Failure_PDF_no);
            this.panel2.Controls.Add(this.label_Failure_PDF);
            this.panel2.Controls.Add(this.label_Total_Rec_no);
            this.panel2.Controls.Add(this.label_Total_Rec);
            this.panel2.Location = new System.Drawing.Point(634, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 48);
            this.panel2.TabIndex = 220;
            // 
            // label_Failure_PDF_no
            // 
            this.label_Failure_PDF_no.AutoSize = true;
            this.label_Failure_PDF_no.BackColor = System.Drawing.Color.Transparent;
            this.label_Failure_PDF_no.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Failure_PDF_no.ForeColor = System.Drawing.Color.Red;
            this.label_Failure_PDF_no.Location = new System.Drawing.Point(99, 22);
            this.label_Failure_PDF_no.Name = "label_Failure_PDF_no";
            this.label_Failure_PDF_no.Size = new System.Drawing.Size(16, 16);
            this.label_Failure_PDF_no.TabIndex = 221;
            this.label_Failure_PDF_no.Text = "0";
            // 
            // label_Failure_PDF
            // 
            this.label_Failure_PDF.AutoSize = true;
            this.label_Failure_PDF.BackColor = System.Drawing.Color.Transparent;
            this.label_Failure_PDF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Failure_PDF.ForeColor = System.Drawing.Color.Red;
            this.label_Failure_PDF.Location = new System.Drawing.Point(7, 22);
            this.label_Failure_PDF.Name = "label_Failure_PDF";
            this.label_Failure_PDF.Size = new System.Drawing.Size(92, 16);
            this.label_Failure_PDF.TabIndex = 220;
            this.label_Failure_PDF.Text = "Failure PDF :";
            // 
            // label_Total_Rec_no
            // 
            this.label_Total_Rec_no.AutoSize = true;
            this.label_Total_Rec_no.BackColor = System.Drawing.Color.Transparent;
            this.label_Total_Rec_no.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total_Rec_no.ForeColor = System.Drawing.Color.Blue;
            this.label_Total_Rec_no.Location = new System.Drawing.Point(99, 3);
            this.label_Total_Rec_no.Name = "label_Total_Rec_no";
            this.label_Total_Rec_no.Size = new System.Drawing.Size(16, 16);
            this.label_Total_Rec_no.TabIndex = 219;
            this.label_Total_Rec_no.Text = "0";
            // 
            // label_Total_Rec
            // 
            this.label_Total_Rec.AutoSize = true;
            this.label_Total_Rec.BackColor = System.Drawing.Color.Transparent;
            this.label_Total_Rec.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Total_Rec.ForeColor = System.Drawing.Color.Blue;
            this.label_Total_Rec.Location = new System.Drawing.Point(7, 3);
            this.label_Total_Rec.Name = "label_Total_Rec";
            this.label_Total_Rec.Size = new System.Drawing.Size(84, 16);
            this.label_Total_Rec.TabIndex = 218;
            this.label_Total_Rec.Text = "Total Rec. :";
            // 
            // button_Autogen_Barcodres
            // 
            this.button_Autogen_Barcodres.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Autogen_Barcodres.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Autogen_Barcodres.Location = new System.Drawing.Point(649, 69);
            this.button_Autogen_Barcodres.Name = "button_Autogen_Barcodres";
            this.button_Autogen_Barcodres.Size = new System.Drawing.Size(123, 22);
            this.button_Autogen_Barcodres.TabIndex = 159;
            this.button_Autogen_Barcodres.Text = "Autogen Barcodres";
            this.button_Autogen_Barcodres.UseVisualStyleBackColor = true;
            // 
            // Form_UploadSTHSpecimensByWebService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(213)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Upload);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.textBox_Upload_To_Server_Path);
            this.Controls.Add(this.label_Upload_To_Server);
            this.Controls.Add(this.textBox_Case_No);
            this.Controls.Add(this.label_Case_No);
            this.Controls.Add(this.label_Or);
            this.Controls.Add(this.textBox_Barcode_No);
            this.Controls.Add(this.label_Barcode_No);
            this.Controls.Add(this.panel_BX_CY_SPECIMEN);
            this.Controls.Add(this.button_Upload_To_Server);
            this.Controls.Add(this.button_Autogen_Barcodres);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Name = "Form_UploadSTHSpecimensByWebService";
            this.Text = "Upload S.T.H. Specimens by Web Service";
            this.Load += new System.EventHandler(this.Form_UploadSTHSpecimensByWebService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_BX_CY_SPECIMEN.ResumeLayout(false);
            this.panel_BX_CY_SPECIMEN.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Barcode_No;
        private System.Windows.Forms.Label label_Barcode_No;
        private System.Windows.Forms.Panel panel_BX_CY_SPECIMEN;
        private System.Windows.Forms.Label label_Upload_info;
        private System.Windows.Forms.Button button_Upload_To_Server;
        private System.Windows.Forms.Label label_Or;
        private System.Windows.Forms.TextBox textBox_Case_No;
        private System.Windows.Forms.Label label_Case_No;
        private System.Windows.Forms.Label label_Upload_To_Server;
        private System.Windows.Forms.TextBox textBox_Upload_To_Server_Path;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Upload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Uploaded_no;
        private System.Windows.Forms.Label label_Uploaded;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_Failure_PDF_no;
        private System.Windows.Forms.Label label_Failure_PDF;
        private System.Windows.Forms.Label label_Total_Rec_no;
        private System.Windows.Forms.Label label_Total_Rec;
        private System.Windows.Forms.Button button_Autogen_Barcodres;
    }
}