namespace St.Teresa_LIS_2019
{
    partial class Form_LabelPrinting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LabelPrinting));
            this.button_Print = new System.Windows.Forms.Button();
            this.textBox_Serch_For = new System.Windows.Forms.TextBox();
            this.label_Serch_For = new System.Windows.Forms.Label();
            this.comboBox_Serch_For = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Import_Label_Printing_Log = new System.Windows.Forms.Button();
            this.button_X = new System.Windows.Forms.Button();
            this.label_F1_Focus_On_Search_Key = new System.Windows.Forms.Label();
            this.label_Line = new System.Windows.Forms.Label();
            this.checkBox_Only_Display_Seleted_Label = new System.Windows.Forms.CheckBox();
            this.button_Preview = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Selected = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Selected_No = new System.Windows.Forms.Label();
            this.button_Label_Formats = new System.Windows.Forms.Button();
            this.comboBox_Print_Type = new System.Windows.Forms.ComboBox();
            this.label_Starting_Position = new System.Windows.Forms.Label();
            this.label_Starting_Position_No = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Print
            // 
            this.button_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Print.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Print.Image = ((System.Drawing.Image)(resources.GetObject("button_Print.Image")));
            this.button_Print.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Print.Location = new System.Drawing.Point(12, 501);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(99, 49);
            this.button_Print.TabIndex = 42;
            this.button_Print.Text = "Print";
            this.button_Print.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Print.UseVisualStyleBackColor = true;
            // 
            // textBox_Serch_For
            // 
            this.textBox_Serch_For.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Serch_For.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Serch_For.Location = new System.Drawing.Point(271, 14);
            this.textBox_Serch_For.Name = "textBox_Serch_For";
            this.textBox_Serch_For.Size = new System.Drawing.Size(306, 27);
            this.textBox_Serch_For.TabIndex = 41;
            // 
            // label_Serch_For
            // 
            this.label_Serch_For.AutoSize = true;
            this.label_Serch_For.BackColor = System.Drawing.Color.Transparent;
            this.label_Serch_For.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Serch_For.ForeColor = System.Drawing.Color.Blue;
            this.label_Serch_For.Location = new System.Drawing.Point(12, 17);
            this.label_Serch_For.Name = "label_Serch_For";
            this.label_Serch_For.Size = new System.Drawing.Size(98, 22);
            this.label_Serch_For.TabIndex = 40;
            this.label_Serch_For.Text = "Serch For";
            // 
            // comboBox_Serch_For
            // 
            this.comboBox_Serch_For.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Serch_For.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Serch_For.FormattingEnabled = true;
            this.comboBox_Serch_For.Items.AddRange(new object[] {
            "Client",
            "Name"});
            this.comboBox_Serch_For.Location = new System.Drawing.Point(116, 14);
            this.comboBox_Serch_For.Name = "comboBox_Serch_For";
            this.comboBox_Serch_For.Size = new System.Drawing.Size(121, 28);
            this.comboBox_Serch_For.TabIndex = 43;
            this.comboBox_Serch_For.Text = "Client";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(243, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 22);
            this.label1.TabIndex = 44;
            this.label1.Text = "=";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(760, 405);
            this.dataGridView1.TabIndex = 45;
            // 
            // button_Import_Label_Printing_Log
            // 
            this.button_Import_Label_Printing_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Import_Label_Printing_Log.ForeColor = System.Drawing.Color.Firebrick;
            this.button_Import_Label_Printing_Log.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Import_Label_Printing_Log.Location = new System.Drawing.Point(583, 19);
            this.button_Import_Label_Printing_Log.Name = "button_Import_Label_Printing_Log";
            this.button_Import_Label_Printing_Log.Size = new System.Drawing.Size(154, 23);
            this.button_Import_Label_Printing_Log.TabIndex = 46;
            this.button_Import_Label_Printing_Log.Text = "Import Label Printing Log";
            this.button_Import_Label_Printing_Log.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_Import_Label_Printing_Log.UseVisualStyleBackColor = true;
            // 
            // button_X
            // 
            this.button_X.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_X.ForeColor = System.Drawing.Color.Red;
            this.button_X.Location = new System.Drawing.Point(743, 20);
            this.button_X.Name = "button_X";
            this.button_X.Size = new System.Drawing.Size(29, 23);
            this.button_X.TabIndex = 47;
            this.button_X.Text = "X";
            this.button_X.UseVisualStyleBackColor = true;
            this.button_X.Click += new System.EventHandler(this.button_X_Click);
            // 
            // label_F1_Focus_On_Search_Key
            // 
            this.label_F1_Focus_On_Search_Key.AutoSize = true;
            this.label_F1_Focus_On_Search_Key.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_F1_Focus_On_Search_Key.Location = new System.Drawing.Point(586, 3);
            this.label_F1_Focus_On_Search_Key.Name = "label_F1_Focus_On_Search_Key";
            this.label_F1_Focus_On_Search_Key.Size = new System.Drawing.Size(138, 13);
            this.label_F1_Focus_On_Search_Key.TabIndex = 48;
            this.label_F1_Focus_On_Search_Key.Text = "(F1 : Focus On Search Key)";
            // 
            // label_Line
            // 
            this.label_Line.AutoSize = true;
            this.label_Line.BackColor = System.Drawing.Color.Transparent;
            this.label_Line.Font = new System.Drawing.Font("Palace Script MT", 35F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Line.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Line.Location = new System.Drawing.Point(8, 433);
            this.label_Line.Name = "label_Line";
            this.label_Line.Size = new System.Drawing.Size(779, 47);
            this.label_Line.TabIndex = 49;
            this.label_Line.Text = "_________________________________";
            // 
            // checkBox_Only_Display_Seleted_Label
            // 
            this.checkBox_Only_Display_Seleted_Label.AutoSize = true;
            this.checkBox_Only_Display_Seleted_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(233)))), ((int)(((byte)(158)))));
            this.checkBox_Only_Display_Seleted_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_Only_Display_Seleted_Label.ForeColor = System.Drawing.Color.DarkViolet;
            this.checkBox_Only_Display_Seleted_Label.Location = new System.Drawing.Point(34, 459);
            this.checkBox_Only_Display_Seleted_Label.Name = "checkBox_Only_Display_Seleted_Label";
            this.checkBox_Only_Display_Seleted_Label.Size = new System.Drawing.Size(178, 17);
            this.checkBox_Only_Display_Seleted_Label.TabIndex = 50;
            this.checkBox_Only_Display_Seleted_Label.Text = "Only Display Seleted Label";
            this.checkBox_Only_Display_Seleted_Label.UseVisualStyleBackColor = false;
            // 
            // button_Preview
            // 
            this.button_Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Preview.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Preview.Image = ((System.Drawing.Image)(resources.GetObject("button_Preview.Image")));
            this.button_Preview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Preview.Location = new System.Drawing.Point(117, 501);
            this.button_Preview.Name = "button_Preview";
            this.button_Preview.Size = new System.Drawing.Size(99, 49);
            this.button_Preview.TabIndex = 51;
            this.button_Preview.Text = "Preview";
            this.button_Preview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Preview.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Cancel.Location = new System.Drawing.Point(222, 501);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(99, 49);
            this.button_Cancel.TabIndex = 52;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label_Selected
            // 
            this.label_Selected.AutoSize = true;
            this.label_Selected.BackColor = System.Drawing.Color.Transparent;
            this.label_Selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Selected.ForeColor = System.Drawing.Color.Blue;
            this.label_Selected.Location = new System.Drawing.Point(13, 16);
            this.label_Selected.Name = "label_Selected";
            this.label_Selected.Size = new System.Drawing.Size(88, 18);
            this.label_Selected.TabIndex = 49;
            this.label_Selected.Text = "Selected : ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(232)))), ((int)(((byte)(180)))));
            this.panel1.Controls.Add(this.label_Selected_No);
            this.panel1.Controls.Add(this.label_Selected);
            this.panel1.Location = new System.Drawing.Point(628, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 49);
            this.panel1.TabIndex = 53;
            // 
            // label_Selected_No
            // 
            this.label_Selected_No.AutoSize = true;
            this.label_Selected_No.BackColor = System.Drawing.Color.Transparent;
            this.label_Selected_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Selected_No.ForeColor = System.Drawing.Color.Blue;
            this.label_Selected_No.Location = new System.Drawing.Point(107, 16);
            this.label_Selected_No.Name = "label_Selected_No";
            this.label_Selected_No.Size = new System.Drawing.Size(17, 18);
            this.label_Selected_No.TabIndex = 50;
            this.label_Selected_No.Text = "0";
            // 
            // button_Label_Formats
            // 
            this.button_Label_Formats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Label_Formats.ForeColor = System.Drawing.Color.Blue;
            this.button_Label_Formats.Image = ((System.Drawing.Image)(resources.GetObject("button_Label_Formats.Image")));
            this.button_Label_Formats.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Label_Formats.Location = new System.Drawing.Point(487, 501);
            this.button_Label_Formats.Name = "button_Label_Formats";
            this.button_Label_Formats.Size = new System.Drawing.Size(121, 49);
            this.button_Label_Formats.TabIndex = 54;
            this.button_Label_Formats.Text = "Label Formats";
            this.button_Label_Formats.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Label_Formats.UseVisualStyleBackColor = true;
            this.button_Label_Formats.Click += new System.EventHandler(this.button_Label_Formats_Click);
            // 
            // comboBox_Print_Type
            // 
            this.comboBox_Print_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Print_Type.ForeColor = System.Drawing.Color.DarkRed;
            this.comboBox_Print_Type.FormattingEnabled = true;
            this.comboBox_Print_Type.Items.AddRange(new object[] {
            "2 x 6 Labels(M)"});
            this.comboBox_Print_Type.Location = new System.Drawing.Point(339, 501);
            this.comboBox_Print_Type.Name = "comboBox_Print_Type";
            this.comboBox_Print_Type.Size = new System.Drawing.Size(142, 26);
            this.comboBox_Print_Type.TabIndex = 55;
            this.comboBox_Print_Type.Text = "2 x 6 Labels(M)";
            // 
            // label_Starting_Position
            // 
            this.label_Starting_Position.AutoSize = true;
            this.label_Starting_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Starting_Position.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Starting_Position.Location = new System.Drawing.Point(343, 532);
            this.label_Starting_Position.Name = "label_Starting_Position";
            this.label_Starting_Position.Size = new System.Drawing.Size(119, 17);
            this.label_Starting_Position.TabIndex = 56;
            this.label_Starting_Position.Text = "Starting Position :";
            // 
            // label_Starting_Position_No
            // 
            this.label_Starting_Position_No.AutoSize = true;
            this.label_Starting_Position_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Starting_Position_No.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Starting_Position_No.Location = new System.Drawing.Point(465, 532);
            this.label_Starting_Position_No.Name = "label_Starting_Position_No";
            this.label_Starting_Position_No.Size = new System.Drawing.Size(16, 17);
            this.label_Starting_Position_No.TabIndex = 57;
            this.label_Starting_Position_No.Text = "1";
            this.label_Starting_Position_No.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form_LabelPrinting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(228)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.ControlBox = false;
            this.Controls.Add(this.label_Starting_Position_No);
            this.Controls.Add(this.label_Starting_Position);
            this.Controls.Add(this.comboBox_Print_Type);
            this.Controls.Add(this.button_Label_Formats);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Preview);
            this.Controls.Add(this.checkBox_Only_Display_Seleted_Label);
            this.Controls.Add(this.label_F1_Focus_On_Search_Key);
            this.Controls.Add(this.button_X);
            this.Controls.Add(this.button_Import_Label_Printing_Log);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Serch_For);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.textBox_Serch_For);
            this.Controls.Add(this.label_Serch_For);
            this.Controls.Add(this.label_Line);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form_LabelPrinting";
            this.Text = "Label Printing";
            this.Load += new System.EventHandler(this.Form_LabelPrinting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.TextBox textBox_Serch_For;
        private System.Windows.Forms.Label label_Serch_For;
        private System.Windows.Forms.ComboBox comboBox_Serch_For;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Import_Label_Printing_Log;
        private System.Windows.Forms.Button button_X;
        private System.Windows.Forms.Label label_F1_Focus_On_Search_Key;
        private System.Windows.Forms.Label label_Line;
        private System.Windows.Forms.CheckBox checkBox_Only_Display_Seleted_Label;
        private System.Windows.Forms.Button button_Preview;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Selected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Selected_No;
        private System.Windows.Forms.Button button_Label_Formats;
        private System.Windows.Forms.ComboBox comboBox_Print_Type;
        private System.Windows.Forms.Label label_Starting_Position;
        private System.Windows.Forms.Label label_Starting_Position_No;
    }
}