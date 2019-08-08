namespace St.Teresa_LIS_2019
{
    partial class Form_DailyLogReportForEBV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DailyLogReportForEBV));
            this.button_Preview = new System.Windows.Forms.Button();
            this.radioButton_Screen = new System.Windows.Forms.RadioButton();
            this.radioButton_Excel = new System.Windows.Forms.RadioButton();
            this.radioButton_Report = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton_With_Snop_Code_Columns = new System.Windows.Forms.RadioButton();
            this.radioButton_Without_Snop_Code_Columns = new System.Windows.Forms.RadioButton();
            this.label_Report_Format = new System.Windows.Forms.Label();
            this.button_Print = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddl_diagnosis = new System.Windows.Forms.ComboBox();
            this.textBox_Group = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Remind = new System.Windows.Forms.TextBox();
            this.lbl_remind = new System.Windows.Forms.Label();
            this.checkBox_Only_No_Snop_T_Or_Snop_M = new System.Windows.Forms.CheckBox();
            this.checkBox_All_Records_In_Selected_Range = new System.Windows.Forms.CheckBox();
            this.label_Keyword_in_diagnosis = new System.Windows.Forms.Label();
            this.label_Additional_Filters = new System.Windows.Forms.Label();
            this.label_Doctor = new System.Windows.Forms.Label();
            this.textBox_Case_Date_From = new System.Windows.Forms.TextBox();
            this.radioButton_By_Case_Date_Range = new System.Windows.Forms.RadioButton();
            this.label_To_4 = new System.Windows.Forms.Label();
            this.label_From_1 = new System.Windows.Forms.Label();
            this.textBox_Case_No_To = new System.Windows.Forms.TextBox();
            this.textBox_Case_Date_To = new System.Windows.Forms.TextBox();
            this.label_From_4 = new System.Windows.Forms.Label();
            this.label_To_1 = new System.Windows.Forms.Label();
            this.radioButton_By_Case_No_Range = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Case_No_From = new System.Windows.Forms.TextBox();
            this.textBox_Report_Date_From = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton_By_Report_Date_Range = new System.Windows.Forms.RadioButton();
            this.radioButton_Over_due_For_One_Day = new System.Windows.Forms.RadioButton();
            this.label_From_2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Report_Date_To = new System.Windows.Forms.TextBox();
            this.label_To_2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Preview
            // 
            this.button_Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Preview.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Preview.Image = ((System.Drawing.Image)(resources.GetObject("button_Preview.Image")));
            this.button_Preview.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Preview.Location = new System.Drawing.Point(241, 399);
            this.button_Preview.Name = "button_Preview";
            this.button_Preview.Size = new System.Drawing.Size(99, 39);
            this.button_Preview.TabIndex = 216;
            this.button_Preview.Text = "Export";
            this.button_Preview.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Preview.UseVisualStyleBackColor = true;
            this.button_Preview.Click += new System.EventHandler(this.button_Preview_Click);
            // 
            // radioButton_Screen
            // 
            this.radioButton_Screen.AutoSize = true;
            this.radioButton_Screen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Screen.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Screen.Location = new System.Drawing.Point(21, 52);
            this.radioButton_Screen.Name = "radioButton_Screen";
            this.radioButton_Screen.Size = new System.Drawing.Size(81, 23);
            this.radioButton_Screen.TabIndex = 216;
            this.radioButton_Screen.Text = "Screen";
            this.radioButton_Screen.UseVisualStyleBackColor = true;
            // 
            // radioButton_Excel
            // 
            this.radioButton_Excel.AutoSize = true;
            this.radioButton_Excel.Checked = true;
            this.radioButton_Excel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Excel.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Excel.Location = new System.Drawing.Point(21, 28);
            this.radioButton_Excel.Name = "radioButton_Excel";
            this.radioButton_Excel.Size = new System.Drawing.Size(69, 23);
            this.radioButton_Excel.TabIndex = 215;
            this.radioButton_Excel.TabStop = true;
            this.radioButton_Excel.Text = "Excel";
            this.radioButton_Excel.UseVisualStyleBackColor = true;
            // 
            // radioButton_Report
            // 
            this.radioButton_Report.AutoSize = true;
            this.radioButton_Report.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Report.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Report.Location = new System.Drawing.Point(21, 4);
            this.radioButton_Report.Name = "radioButton_Report";
            this.radioButton_Report.Size = new System.Drawing.Size(79, 23);
            this.radioButton_Report.TabIndex = 214;
            this.radioButton_Report.Text = "Report";
            this.radioButton_Report.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.radioButton_Screen);
            this.panel3.Controls.Add(this.radioButton_Excel);
            this.panel3.Controls.Add(this.radioButton_Report);
            this.panel3.Location = new System.Drawing.Point(416, 293);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(127, 80);
            this.panel3.TabIndex = 213;
            // 
            // radioButton_With_Snop_Code_Columns
            // 
            this.radioButton_With_Snop_Code_Columns.AutoSize = true;
            this.radioButton_With_Snop_Code_Columns.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_With_Snop_Code_Columns.ForeColor = System.Drawing.Color.DarkRed;
            this.radioButton_With_Snop_Code_Columns.Location = new System.Drawing.Point(141, 40);
            this.radioButton_With_Snop_Code_Columns.Name = "radioButton_With_Snop_Code_Columns";
            this.radioButton_With_Snop_Code_Columns.Size = new System.Drawing.Size(224, 23);
            this.radioButton_With_Snop_Code_Columns.TabIndex = 215;
            this.radioButton_With_Snop_Code_Columns.TabStop = true;
            this.radioButton_With_Snop_Code_Columns.Text = "With Snop Code Columns";
            this.radioButton_With_Snop_Code_Columns.UseVisualStyleBackColor = true;
            // 
            // radioButton_Without_Snop_Code_Columns
            // 
            this.radioButton_Without_Snop_Code_Columns.AutoSize = true;
            this.radioButton_Without_Snop_Code_Columns.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Without_Snop_Code_Columns.ForeColor = System.Drawing.Color.DarkRed;
            this.radioButton_Without_Snop_Code_Columns.Location = new System.Drawing.Point(141, 13);
            this.radioButton_Without_Snop_Code_Columns.Name = "radioButton_Without_Snop_Code_Columns";
            this.radioButton_Without_Snop_Code_Columns.Size = new System.Drawing.Size(249, 23);
            this.radioButton_Without_Snop_Code_Columns.TabIndex = 214;
            this.radioButton_Without_Snop_Code_Columns.TabStop = true;
            this.radioButton_Without_Snop_Code_Columns.Text = "Without Snop Code Columns";
            this.radioButton_Without_Snop_Code_Columns.UseVisualStyleBackColor = true;
            // 
            // label_Report_Format
            // 
            this.label_Report_Format.AutoSize = true;
            this.label_Report_Format.BackColor = System.Drawing.Color.Transparent;
            this.label_Report_Format.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Report_Format.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Report_Format.Location = new System.Drawing.Point(12, 15);
            this.label_Report_Format.Name = "label_Report_Format";
            this.label_Report_Format.Size = new System.Drawing.Size(129, 19);
            this.label_Report_Format.TabIndex = 214;
            this.label_Report_Format.Text = "Report Format :";
            // 
            // button_Print
            // 
            this.button_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Print.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Print.Image = ((System.Drawing.Image)(resources.GetObject("button_Print.Image")));
            this.button_Print.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Print.Location = new System.Drawing.Point(97, 399);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(99, 39);
            this.button_Print.TabIndex = 214;
            this.button_Print.Text = "Print";
            this.button_Print.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.radioButton_With_Snop_Code_Columns);
            this.panel2.Controls.Add(this.radioButton_Without_Snop_Code_Columns);
            this.panel2.Controls.Add(this.label_Report_Format);
            this.panel2.Location = new System.Drawing.Point(12, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 80);
            this.panel2.TabIndex = 212;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ddl_diagnosis);
            this.panel1.Controls.Add(this.textBox_Group);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_Remind);
            this.panel1.Controls.Add(this.lbl_remind);
            this.panel1.Controls.Add(this.checkBox_Only_No_Snop_T_Or_Snop_M);
            this.panel1.Controls.Add(this.checkBox_All_Records_In_Selected_Range);
            this.panel1.Controls.Add(this.label_Keyword_in_diagnosis);
            this.panel1.Controls.Add(this.label_Additional_Filters);
            this.panel1.Controls.Add(this.label_Doctor);
            this.panel1.Controls.Add(this.textBox_Case_Date_From);
            this.panel1.Controls.Add(this.radioButton_By_Case_Date_Range);
            this.panel1.Controls.Add(this.label_To_4);
            this.panel1.Controls.Add(this.label_From_1);
            this.panel1.Controls.Add(this.textBox_Case_No_To);
            this.panel1.Controls.Add(this.textBox_Case_Date_To);
            this.panel1.Controls.Add(this.label_From_4);
            this.panel1.Controls.Add(this.label_To_1);
            this.panel1.Controls.Add(this.radioButton_By_Case_No_Range);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_Case_No_From);
            this.panel1.Controls.Add(this.textBox_Report_Date_From);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.radioButton_By_Report_Date_Range);
            this.panel1.Controls.Add(this.radioButton_Over_due_For_One_Day);
            this.panel1.Controls.Add(this.label_From_2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_Report_Date_To);
            this.panel1.Controls.Add(this.label_To_2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 276);
            this.panel1.TabIndex = 211;
            // 
            // ddl_diagnosis
            // 
            this.ddl_diagnosis.DisplayMember = "DIAGNOSIS";
            this.ddl_diagnosis.FormattingEnabled = true;
            this.ddl_diagnosis.Location = new System.Drawing.Point(357, 109);
            this.ddl_diagnosis.Name = "ddl_diagnosis";
            this.ddl_diagnosis.Size = new System.Drawing.Size(159, 20);
            this.ddl_diagnosis.TabIndex = 221;
            this.ddl_diagnosis.ValueMember = "DIAGNOSIS";
            // 
            // textBox_Group
            // 
            this.textBox_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Group.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox_Group.Location = new System.Drawing.Point(356, 168);
            this.textBox_Group.Name = "textBox_Group";
            this.textBox_Group.Size = new System.Drawing.Size(160, 23);
            this.textBox_Group.TabIndex = 220;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(275, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 219;
            this.label3.Text = "Group :";
            // 
            // textBox_Remind
            // 
            this.textBox_Remind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Remind.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox_Remind.Location = new System.Drawing.Point(357, 63);
            this.textBox_Remind.Name = "textBox_Remind";
            this.textBox_Remind.Size = new System.Drawing.Size(159, 23);
            this.textBox_Remind.TabIndex = 215;
            // 
            // lbl_remind
            // 
            this.lbl_remind.AutoSize = true;
            this.lbl_remind.BackColor = System.Drawing.Color.Transparent;
            this.lbl_remind.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remind.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_remind.Location = new System.Drawing.Point(286, 66);
            this.lbl_remind.Name = "lbl_remind";
            this.lbl_remind.Size = new System.Drawing.Size(65, 16);
            this.lbl_remind.TabIndex = 214;
            this.lbl_remind.Text = "Remind:";
            // 
            // checkBox_Only_No_Snop_T_Or_Snop_M
            // 
            this.checkBox_Only_No_Snop_T_Or_Snop_M.AutoSize = true;
            this.checkBox_Only_No_Snop_T_Or_Snop_M.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Only_No_Snop_T_Or_Snop_M.ForeColor = System.Drawing.Color.DarkRed;
            this.checkBox_Only_No_Snop_T_Or_Snop_M.Location = new System.Drawing.Point(278, 243);
            this.checkBox_Only_No_Snop_T_Or_Snop_M.Name = "checkBox_Only_No_Snop_T_Or_Snop_M";
            this.checkBox_Only_No_Snop_T_Or_Snop_M.Size = new System.Drawing.Size(191, 19);
            this.checkBox_Only_No_Snop_T_Or_Snop_M.TabIndex = 213;
            this.checkBox_Only_No_Snop_T_Or_Snop_M.Text = "Only No \"Snop-T\" Or \"Snop-M\"";
            this.checkBox_Only_No_Snop_T_Or_Snop_M.UseVisualStyleBackColor = true;
            // 
            // checkBox_All_Records_In_Selected_Range
            // 
            this.checkBox_All_Records_In_Selected_Range.AutoSize = true;
            this.checkBox_All_Records_In_Selected_Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_All_Records_In_Selected_Range.ForeColor = System.Drawing.Color.DarkRed;
            this.checkBox_All_Records_In_Selected_Range.Location = new System.Drawing.Point(278, 223);
            this.checkBox_All_Records_In_Selected_Range.Name = "checkBox_All_Records_In_Selected_Range";
            this.checkBox_All_Records_In_Selected_Range.Size = new System.Drawing.Size(192, 19);
            this.checkBox_All_Records_In_Selected_Range.TabIndex = 212;
            this.checkBox_All_Records_In_Selected_Range.Text = "All Records In Selected Range";
            this.checkBox_All_Records_In_Selected_Range.UseVisualStyleBackColor = true;
            // 
            // label_Keyword_in_diagnosis
            // 
            this.label_Keyword_in_diagnosis.AutoSize = true;
            this.label_Keyword_in_diagnosis.BackColor = System.Drawing.Color.Transparent;
            this.label_Keyword_in_diagnosis.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Keyword_in_diagnosis.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Keyword_in_diagnosis.Location = new System.Drawing.Point(275, 109);
            this.label_Keyword_in_diagnosis.Name = "label_Keyword_in_diagnosis";
            this.label_Keyword_in_diagnosis.Size = new System.Drawing.Size(81, 16);
            this.label_Keyword_in_diagnosis.TabIndex = 210;
            this.label_Keyword_in_diagnosis.Text = "Diagnosis:";
            // 
            // label_Additional_Filters
            // 
            this.label_Additional_Filters.AutoSize = true;
            this.label_Additional_Filters.BackColor = System.Drawing.Color.Transparent;
            this.label_Additional_Filters.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Additional_Filters.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Additional_Filters.Location = new System.Drawing.Point(334, 34);
            this.label_Additional_Filters.Name = "label_Additional_Filters";
            this.label_Additional_Filters.Size = new System.Drawing.Size(135, 16);
            this.label_Additional_Filters.TabIndex = 209;
            this.label_Additional_Filters.Text = "Additional Filters :";
            // 
            // label_Doctor
            // 
            this.label_Doctor.AutoSize = true;
            this.label_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.label_Doctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Doctor.ForeColor = System.Drawing.Color.Purple;
            this.label_Doctor.Location = new System.Drawing.Point(4, 8);
            this.label_Doctor.Name = "label_Doctor";
            this.label_Doctor.Size = new System.Drawing.Size(25, 20);
            this.label_Doctor.TabIndex = 64;
            this.label_Doctor.Text = "1)";
            // 
            // textBox_Case_Date_From
            // 
            this.textBox_Case_Date_From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox_Case_Date_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Case_Date_From.ForeColor = System.Drawing.Color.Black;
            this.textBox_Case_Date_From.Location = new System.Drawing.Point(118, 34);
            this.textBox_Case_Date_From.Name = "textBox_Case_Date_From";
            this.textBox_Case_Date_From.Size = new System.Drawing.Size(90, 21);
            this.textBox_Case_Date_From.TabIndex = 4;
            // 
            // radioButton_By_Case_Date_Range
            // 
            this.radioButton_By_Case_Date_Range.AutoSize = true;
            this.radioButton_By_Case_Date_Range.Checked = true;
            this.radioButton_By_Case_Date_Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_By_Case_Date_Range.ForeColor = System.Drawing.Color.Purple;
            this.radioButton_By_Case_Date_Range.Location = new System.Drawing.Point(35, 6);
            this.radioButton_By_Case_Date_Range.Name = "radioButton_By_Case_Date_Range";
            this.radioButton_By_Case_Date_Range.Size = new System.Drawing.Size(195, 24);
            this.radioButton_By_Case_Date_Range.TabIndex = 184;
            this.radioButton_By_Case_Date_Range.TabStop = true;
            this.radioButton_By_Case_Date_Range.Text = "By Case Date Range";
            this.radioButton_By_Case_Date_Range.UseVisualStyleBackColor = true;
            this.radioButton_By_Case_Date_Range.CheckedChanged += new System.EventHandler(this.radioButton_By_Case_Date_Range_CheckedChanged);
            // 
            // label_To_4
            // 
            this.label_To_4.AutoSize = true;
            this.label_To_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_To_4.ForeColor = System.Drawing.Color.DimGray;
            this.label_To_4.Location = new System.Drawing.Point(70, 244);
            this.label_To_4.Name = "label_To_4";
            this.label_To_4.Size = new System.Drawing.Size(27, 15);
            this.label_To_4.TabIndex = 201;
            this.label_To_4.Text = "To :";
            // 
            // label_From_1
            // 
            this.label_From_1.AutoSize = true;
            this.label_From_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_From_1.ForeColor = System.Drawing.Color.DimGray;
            this.label_From_1.Location = new System.Drawing.Point(70, 37);
            this.label_From_1.Name = "label_From_1";
            this.label_From_1.Size = new System.Drawing.Size(42, 15);
            this.label_From_1.TabIndex = 185;
            this.label_From_1.Text = "From :";
            // 
            // textBox_Case_No_To
            // 
            this.textBox_Case_No_To.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox_Case_No_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Case_No_To.ForeColor = System.Drawing.Color.Black;
            this.textBox_Case_No_To.Location = new System.Drawing.Point(118, 241);
            this.textBox_Case_No_To.Name = "textBox_Case_No_To";
            this.textBox_Case_No_To.Size = new System.Drawing.Size(138, 21);
            this.textBox_Case_No_To.TabIndex = 200;
            // 
            // textBox_Case_Date_To
            // 
            this.textBox_Case_Date_To.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox_Case_Date_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Case_Date_To.ForeColor = System.Drawing.Color.Black;
            this.textBox_Case_Date_To.Location = new System.Drawing.Point(118, 54);
            this.textBox_Case_Date_To.Name = "textBox_Case_Date_To";
            this.textBox_Case_Date_To.Size = new System.Drawing.Size(90, 21);
            this.textBox_Case_Date_To.TabIndex = 186;
            // 
            // label_From_4
            // 
            this.label_From_4.AutoSize = true;
            this.label_From_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_From_4.ForeColor = System.Drawing.Color.DimGray;
            this.label_From_4.Location = new System.Drawing.Point(70, 224);
            this.label_From_4.Name = "label_From_4";
            this.label_From_4.Size = new System.Drawing.Size(42, 15);
            this.label_From_4.TabIndex = 199;
            this.label_From_4.Text = "From :";
            // 
            // label_To_1
            // 
            this.label_To_1.AutoSize = true;
            this.label_To_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_To_1.ForeColor = System.Drawing.Color.DimGray;
            this.label_To_1.Location = new System.Drawing.Point(70, 56);
            this.label_To_1.Name = "label_To_1";
            this.label_To_1.Size = new System.Drawing.Size(27, 15);
            this.label_To_1.TabIndex = 187;
            this.label_To_1.Text = "To :";
            // 
            // radioButton_By_Case_No_Range
            // 
            this.radioButton_By_Case_No_Range.AutoSize = true;
            this.radioButton_By_Case_No_Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_By_Case_No_Range.ForeColor = System.Drawing.Color.Purple;
            this.radioButton_By_Case_No_Range.Location = new System.Drawing.Point(35, 194);
            this.radioButton_By_Case_No_Range.Name = "radioButton_By_Case_No_Range";
            this.radioButton_By_Case_No_Range.Size = new System.Drawing.Size(198, 24);
            this.radioButton_By_Case_No_Range.TabIndex = 198;
            this.radioButton_By_Case_No_Range.Text = "By Case No. # Range";
            this.radioButton_By_Case_No_Range.UseVisualStyleBackColor = true;
            this.radioButton_By_Case_No_Range.CheckedChanged += new System.EventHandler(this.radioButton_By_Case_No_Range_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Purple;
            this.label5.Location = new System.Drawing.Point(4, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 20);
            this.label5.TabIndex = 189;
            this.label5.Text = "2)";
            // 
            // textBox_Case_No_From
            // 
            this.textBox_Case_No_From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox_Case_No_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Case_No_From.ForeColor = System.Drawing.Color.Black;
            this.textBox_Case_No_From.Location = new System.Drawing.Point(118, 222);
            this.textBox_Case_No_From.Name = "textBox_Case_No_From";
            this.textBox_Case_No_From.Size = new System.Drawing.Size(138, 21);
            this.textBox_Case_No_From.TabIndex = 196;
            // 
            // textBox_Report_Date_From
            // 
            this.textBox_Report_Date_From.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox_Report_Date_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Report_Date_From.ForeColor = System.Drawing.Color.Black;
            this.textBox_Report_Date_From.Location = new System.Drawing.Point(118, 111);
            this.textBox_Report_Date_From.Name = "textBox_Report_Date_From";
            this.textBox_Report_Date_From.Size = new System.Drawing.Size(90, 21);
            this.textBox_Report_Date_From.TabIndex = 188;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Purple;
            this.label9.Location = new System.Drawing.Point(4, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.TabIndex = 197;
            this.label9.Text = "4)";
            // 
            // radioButton_By_Report_Date_Range
            // 
            this.radioButton_By_Report_Date_Range.AutoSize = true;
            this.radioButton_By_Report_Date_Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_By_Report_Date_Range.ForeColor = System.Drawing.Color.Purple;
            this.radioButton_By_Report_Date_Range.Location = new System.Drawing.Point(35, 83);
            this.radioButton_By_Report_Date_Range.Name = "radioButton_By_Report_Date_Range";
            this.radioButton_By_Report_Date_Range.Size = new System.Drawing.Size(209, 24);
            this.radioButton_By_Report_Date_Range.TabIndex = 190;
            this.radioButton_By_Report_Date_Range.Text = "By Report Date Range";
            this.radioButton_By_Report_Date_Range.UseVisualStyleBackColor = true;
            this.radioButton_By_Report_Date_Range.CheckedChanged += new System.EventHandler(this.radioButton_By_Report_Date_Range_CheckedChanged);
            // 
            // radioButton_Over_due_For_One_Day
            // 
            this.radioButton_Over_due_For_One_Day.AutoSize = true;
            this.radioButton_Over_due_For_One_Day.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_Over_due_For_One_Day.ForeColor = System.Drawing.Color.Purple;
            this.radioButton_Over_due_For_One_Day.Location = new System.Drawing.Point(35, 166);
            this.radioButton_Over_due_For_One_Day.Name = "radioButton_Over_due_For_One_Day";
            this.radioButton_Over_due_For_One_Day.Size = new System.Drawing.Size(206, 24);
            this.radioButton_Over_due_For_One_Day.TabIndex = 195;
            this.radioButton_Over_due_For_One_Day.Text = "Over-due For One Day";
            this.radioButton_Over_due_For_One_Day.UseVisualStyleBackColor = true;
            this.radioButton_Over_due_For_One_Day.CheckedChanged += new System.EventHandler(this.radioButton_Over_due_For_One_Day_CheckedChanged);
            // 
            // label_From_2
            // 
            this.label_From_2.AutoSize = true;
            this.label_From_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_From_2.ForeColor = System.Drawing.Color.DimGray;
            this.label_From_2.Location = new System.Drawing.Point(70, 114);
            this.label_From_2.Name = "label_From_2";
            this.label_From_2.Size = new System.Drawing.Size(42, 15);
            this.label_From_2.TabIndex = 191;
            this.label_From_2.Text = "From :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Purple;
            this.label6.Location = new System.Drawing.Point(4, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 20);
            this.label6.TabIndex = 194;
            this.label6.Text = "3)";
            // 
            // textBox_Report_Date_To
            // 
            this.textBox_Report_Date_To.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textBox_Report_Date_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Report_Date_To.ForeColor = System.Drawing.Color.Black;
            this.textBox_Report_Date_To.Location = new System.Drawing.Point(118, 130);
            this.textBox_Report_Date_To.Name = "textBox_Report_Date_To";
            this.textBox_Report_Date_To.Size = new System.Drawing.Size(90, 21);
            this.textBox_Report_Date_To.TabIndex = 192;
            // 
            // label_To_2
            // 
            this.label_To_2.AutoSize = true;
            this.label_To_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_To_2.ForeColor = System.Drawing.Color.DimGray;
            this.label_To_2.Location = new System.Drawing.Point(70, 133);
            this.label_To_2.Name = "label_To_2";
            this.label_To_2.Size = new System.Drawing.Size(27, 15);
            this.label_To_2.TabIndex = 193;
            this.label_To_2.Text = "To :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(236, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 205;
            this.pictureBox1.TabStop = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Cancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Cancel.Location = new System.Drawing.Point(385, 398);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(99, 40);
            this.button_Cancel.TabIndex = 215;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // Form_DailyLogReportForEBV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(206)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(562, 450);
            this.Controls.Add(this.button_Preview);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Cancel);
            this.Name = "Form_DailyLogReportForEBV";
            this.Text = "Daily Log Report For EBV";
            this.Load += new System.EventHandler(this.Form_DailyLogReportForEBV_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Preview;
        private System.Windows.Forms.RadioButton radioButton_Screen;
        private System.Windows.Forms.RadioButton radioButton_Excel;
        private System.Windows.Forms.RadioButton radioButton_Report;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton_With_Snop_Code_Columns;
        private System.Windows.Forms.RadioButton radioButton_Without_Snop_Code_Columns;
        private System.Windows.Forms.Label label_Report_Format;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Remind;
        private System.Windows.Forms.Label lbl_remind;
        private System.Windows.Forms.CheckBox checkBox_Only_No_Snop_T_Or_Snop_M;
        private System.Windows.Forms.CheckBox checkBox_All_Records_In_Selected_Range;
        private System.Windows.Forms.Label label_Keyword_in_diagnosis;
        private System.Windows.Forms.Label label_Additional_Filters;
        private System.Windows.Forms.Label label_Doctor;
        private System.Windows.Forms.TextBox textBox_Case_Date_From;
        private System.Windows.Forms.RadioButton radioButton_By_Case_Date_Range;
        private System.Windows.Forms.Label label_To_4;
        private System.Windows.Forms.Label label_From_1;
        private System.Windows.Forms.TextBox textBox_Case_No_To;
        private System.Windows.Forms.TextBox textBox_Case_Date_To;
        private System.Windows.Forms.Label label_From_4;
        private System.Windows.Forms.Label label_To_1;
        private System.Windows.Forms.RadioButton radioButton_By_Case_No_Range;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Case_No_From;
        private System.Windows.Forms.TextBox textBox_Report_Date_From;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton_By_Report_Date_Range;
        private System.Windows.Forms.RadioButton radioButton_Over_due_For_One_Day;
        private System.Windows.Forms.Label label_From_2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Report_Date_To;
        private System.Windows.Forms.Label label_To_2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox ddl_diagnosis;
    }
}