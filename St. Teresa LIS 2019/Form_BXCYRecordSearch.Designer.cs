namespace St.Teresa_LIS_2019
{
    partial class Form_BXCYRecordSearch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BXCYRecordSearch));
            this.bXCYSPECIMENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medlabDataSet = new St.Teresa_LIS_2019.medlabDataSet();
            this.textBox_Search_Type = new System.Windows.Forms.TextBox();
            this.label_Search_Type = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_BX = new System.Windows.Forms.Button();
            this.button_F4_Daily_Report = new System.Windows.Forms.Button();
            this.buttonF3_Edit_Record = new System.Windows.Forms.Button();
            this.button_F6_View_Record = new System.Windows.Forms.Button();
            this.button_F2_New_Record = new System.Windows.Forms.Button();
            this.button_F5_New_Patient = new System.Windows.Forms.Button();
            this.button_F7_Columns = new System.Windows.Forms.Button();
            this.button_F8_Pic_Path = new System.Windows.Forms.Button();
            this.button_F9_Set_BX_CY = new System.Windows.Forms.Button();
            this.button_BB = new System.Windows.Forms.Button();
            this.button_CC = new System.Windows.Forms.Button();
            this.button_CY = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_F1_Search = new System.Windows.Forms.Button();
            this.bXCY_SPECIMENTableAdapter = new St.Teresa_LIS_2019.medlabDataSetTableAdapters.BXCY_SPECIMENTableAdapter();
            this.button_Digital_Signature = new System.Windows.Forms.Button();
            this.radioButton_Data_All = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_Past_7 = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_Past_14 = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_Past_28 = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_From = new System.Windows.Forms.RadioButton();
            this.label_Data_To = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BindingNavigate = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtCurrentPage = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lblPageCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.button_D = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.bXCYSPECIMENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medlabDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigate)).BeginInit();
            this.BindingNavigate.SuspendLayout();
            this.SuspendLayout();
            // 
            // bXCYSPECIMENBindingSource
            // 
            this.bXCYSPECIMENBindingSource.DataMember = "BXCY_SPECIMEN";
            this.bXCYSPECIMENBindingSource.DataSource = this.medlabDataSet;
            // 
            // medlabDataSet
            // 
            this.medlabDataSet.DataSetName = "medlabDataSet";
            this.medlabDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox_Search_Type
            // 
            this.textBox_Search_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Search_Type.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Search_Type.Location = new System.Drawing.Point(14, 26);
            this.textBox_Search_Type.Name = "textBox_Search_Type";
            this.textBox_Search_Type.Size = new System.Drawing.Size(254, 27);
            this.textBox_Search_Type.TabIndex = 50;
            this.textBox_Search_Type.TextChanged += new System.EventHandler(this.textBox_Search_Type_TextChanged);
            this.textBox_Search_Type.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_Search_Type_KeyUp);
            // 
            // label_Search_Type
            // 
            this.label_Search_Type.AutoSize = true;
            this.label_Search_Type.BackColor = System.Drawing.Color.Transparent;
            this.label_Search_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Search_Type.ForeColor = System.Drawing.Color.Blue;
            this.label_Search_Type.Location = new System.Drawing.Point(10, 3);
            this.label_Search_Type.Name = "label_Search_Type";
            this.label_Search_Type.Size = new System.Drawing.Size(171, 22);
            this.label_Search_Type.TabIndex = 49;
            this.label_Search_Type.Text = "Locate Case No. :";
            this.label_Search_Type.Click += new System.EventHandler(this.label_Search_Type_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.Color.Purple;
            this.button_Exit.Location = new System.Drawing.Point(885, 44);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(109, 30);
            this.button_Exit.TabIndex = 52;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_BX
            // 
            this.button_BX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_BX.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_BX.Location = new System.Drawing.Point(14, 56);
            this.button_BX.Name = "button_BX";
            this.button_BX.Size = new System.Drawing.Size(48, 19);
            this.button_BX.TabIndex = 66;
            this.button_BX.Text = "BX";
            this.button_BX.UseVisualStyleBackColor = true;
            this.button_BX.Click += new System.EventHandler(this.button_BX_Click);
            // 
            // button_F4_Daily_Report
            // 
            this.button_F4_Daily_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F4_Daily_Report.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_F4_Daily_Report.Location = new System.Drawing.Point(885, 7);
            this.button_F4_Daily_Report.Name = "button_F4_Daily_Report";
            this.button_F4_Daily_Report.Size = new System.Drawing.Size(109, 30);
            this.button_F4_Daily_Report.TabIndex = 67;
            this.button_F4_Daily_Report.Text = "F4. Daily Report";
            this.button_F4_Daily_Report.UseVisualStyleBackColor = true;
            this.button_F4_Daily_Report.Click += new System.EventHandler(this.button_F4_Daily_Report_Click);
            // 
            // buttonF3_Edit_Record
            // 
            this.buttonF3_Edit_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonF3_Edit_Record.ForeColor = System.Drawing.Color.Black;
            this.buttonF3_Edit_Record.Location = new System.Drawing.Point(736, 7);
            this.buttonF3_Edit_Record.Name = "buttonF3_Edit_Record";
            this.buttonF3_Edit_Record.Size = new System.Drawing.Size(109, 30);
            this.buttonF3_Edit_Record.TabIndex = 69;
            this.buttonF3_Edit_Record.Text = "F3. Edit Record";
            this.buttonF3_Edit_Record.UseVisualStyleBackColor = true;
            this.buttonF3_Edit_Record.Click += new System.EventHandler(this.buttonF3_Edit_Record_Click);
            // 
            // button_F6_View_Record
            // 
            this.button_F6_View_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F6_View_Record.ForeColor = System.Drawing.Color.Black;
            this.button_F6_View_Record.Location = new System.Drawing.Point(736, 43);
            this.button_F6_View_Record.Name = "button_F6_View_Record";
            this.button_F6_View_Record.Size = new System.Drawing.Size(109, 30);
            this.button_F6_View_Record.TabIndex = 68;
            this.button_F6_View_Record.Text = "F6. View Record";
            this.button_F6_View_Record.UseVisualStyleBackColor = true;
            this.button_F6_View_Record.Click += new System.EventHandler(this.button_F6_View_Record_Click);
            // 
            // button_F2_New_Record
            // 
            this.button_F2_New_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F2_New_Record.ForeColor = System.Drawing.Color.Black;
            this.button_F2_New_Record.Location = new System.Drawing.Point(621, 7);
            this.button_F2_New_Record.Name = "button_F2_New_Record";
            this.button_F2_New_Record.Size = new System.Drawing.Size(109, 30);
            this.button_F2_New_Record.TabIndex = 71;
            this.button_F2_New_Record.Text = "F2. New Record";
            this.button_F2_New_Record.UseVisualStyleBackColor = true;
            this.button_F2_New_Record.Click += new System.EventHandler(this.button_F2_New_Record_Click);
            // 
            // button_F5_New_Patient
            // 
            this.button_F5_New_Patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F5_New_Patient.ForeColor = System.Drawing.Color.Black;
            this.button_F5_New_Patient.Location = new System.Drawing.Point(621, 43);
            this.button_F5_New_Patient.Name = "button_F5_New_Patient";
            this.button_F5_New_Patient.Size = new System.Drawing.Size(109, 30);
            this.button_F5_New_Patient.TabIndex = 70;
            this.button_F5_New_Patient.Text = "F5. New Patient";
            this.button_F5_New_Patient.UseVisualStyleBackColor = true;
            this.button_F5_New_Patient.Click += new System.EventHandler(this.button_F5_New_Patient_Click);
            // 
            // button_F7_Columns
            // 
            this.button_F7_Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F7_Columns.ForeColor = System.Drawing.Color.Green;
            this.button_F7_Columns.Location = new System.Drawing.Point(484, 6);
            this.button_F7_Columns.Name = "button_F7_Columns";
            this.button_F7_Columns.Size = new System.Drawing.Size(101, 22);
            this.button_F7_Columns.TabIndex = 72;
            this.button_F7_Columns.Text = "F7. Columns";
            this.button_F7_Columns.UseVisualStyleBackColor = true;
            this.button_F7_Columns.Click += new System.EventHandler(this.button_F7_Columas_Click);
            // 
            // button_F8_Pic_Path
            // 
            this.button_F8_Pic_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F8_Pic_Path.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button_F8_Pic_Path.Location = new System.Drawing.Point(484, 29);
            this.button_F8_Pic_Path.Name = "button_F8_Pic_Path";
            this.button_F8_Pic_Path.Size = new System.Drawing.Size(101, 22);
            this.button_F8_Pic_Path.TabIndex = 73;
            this.button_F8_Pic_Path.Text = "F8. Pic. Path";
            this.button_F8_Pic_Path.UseVisualStyleBackColor = true;
            this.button_F8_Pic_Path.Click += new System.EventHandler(this.button_F8_Pic_Path_Click);
            // 
            // button_F9_Set_BX_CY
            // 
            this.button_F9_Set_BX_CY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F9_Set_BX_CY.ForeColor = System.Drawing.Color.Purple;
            this.button_F9_Set_BX_CY.Location = new System.Drawing.Point(484, 52);
            this.button_F9_Set_BX_CY.Name = "button_F9_Set_BX_CY";
            this.button_F9_Set_BX_CY.Size = new System.Drawing.Size(101, 22);
            this.button_F9_Set_BX_CY.TabIndex = 74;
            this.button_F9_Set_BX_CY.Text = "F9. Set BX/CY";
            this.button_F9_Set_BX_CY.UseVisualStyleBackColor = true;
            this.button_F9_Set_BX_CY.Click += new System.EventHandler(this.button_F9_Set_BX_CY_Click);
            // 
            // button_BB
            // 
            this.button_BB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_BB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_BB.Location = new System.Drawing.Point(62, 56);
            this.button_BB.Name = "button_BB";
            this.button_BB.Size = new System.Drawing.Size(48, 19);
            this.button_BB.TabIndex = 77;
            this.button_BB.Text = "BB";
            this.button_BB.UseVisualStyleBackColor = true;
            this.button_BB.Click += new System.EventHandler(this.button_BB_Click);
            // 
            // button_CC
            // 
            this.button_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_CC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_CC.Location = new System.Drawing.Point(158, 56);
            this.button_CC.Name = "button_CC";
            this.button_CC.Size = new System.Drawing.Size(48, 19);
            this.button_CC.TabIndex = 79;
            this.button_CC.Text = "CC";
            this.button_CC.UseVisualStyleBackColor = true;
            this.button_CC.Click += new System.EventHandler(this.button_CC_Click);
            // 
            // button_CY
            // 
            this.button_CY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_CY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_CY.Location = new System.Drawing.Point(110, 56);
            this.button_CY.Name = "button_CY";
            this.button_CY.Size = new System.Drawing.Size(48, 19);
            this.button_CY.TabIndex = 78;
            this.button_CY.Text = "CY";
            this.button_CY.UseVisualStyleBackColor = true;
            this.button_CY.Click += new System.EventHandler(this.button_CY_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(207, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 19);
            this.button1.TabIndex = 80;
            this.button1.Text = "MP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_F1_Search
            // 
            this.button_F1_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F1_Search.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_F1_Search.Location = new System.Drawing.Point(220, 4);
            this.button_F1_Search.Name = "button_F1_Search";
            this.button_F1_Search.Size = new System.Drawing.Size(83, 19);
            this.button_F1_Search.TabIndex = 81;
            this.button_F1_Search.Text = "F1. Search";
            this.button_F1_Search.UseVisualStyleBackColor = true;
            this.button_F1_Search.Click += new System.EventHandler(this.button_F1_Search_Click);
            // 
            // bXCY_SPECIMENTableAdapter
            // 
            this.bXCY_SPECIMENTableAdapter.ClearBeforeFill = true;
            // 
            // button_Digital_Signature
            // 
            this.button_Digital_Signature.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Digital_Signature.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Digital_Signature.Location = new System.Drawing.Point(351, 4);
            this.button_Digital_Signature.Name = "button_Digital_Signature";
            this.button_Digital_Signature.Size = new System.Drawing.Size(102, 43);
            this.button_Digital_Signature.TabIndex = 82;
            this.button_Digital_Signature.Text = "F10 Digital Signature";
            this.button_Digital_Signature.UseVisualStyleBackColor = true;
            this.button_Digital_Signature.Click += new System.EventHandler(this.button_Digital_Signature_Click);
            // 
            // radioButton_Data_All
            // 
            this.radioButton_Data_All.AutoSize = true;
            this.radioButton_Data_All.Checked = true;
            this.radioButton_Data_All.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_All.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_All.Location = new System.Drawing.Point(14, 81);
            this.radioButton_Data_All.Name = "radioButton_Data_All";
            this.radioButton_Data_All.Size = new System.Drawing.Size(43, 20);
            this.radioButton_Data_All.TabIndex = 215;
            this.radioButton_Data_All.TabStop = true;
            this.radioButton_Data_All.Text = "All";
            this.radioButton_Data_All.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_7
            // 
            this.radioButton_Data_Past_7.AutoSize = true;
            this.radioButton_Data_Past_7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_7.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_7.Location = new System.Drawing.Point(76, 81);
            this.radioButton_Data_Past_7.Name = "radioButton_Data_Past_7";
            this.radioButton_Data_Past_7.Size = new System.Drawing.Size(105, 20);
            this.radioButton_Data_Past_7.TabIndex = 216;
            this.radioButton_Data_Past_7.Text = "Past 7 Days";
            this.radioButton_Data_Past_7.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_14
            // 
            this.radioButton_Data_Past_14.AutoSize = true;
            this.radioButton_Data_Past_14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_14.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_14.Location = new System.Drawing.Point(208, 81);
            this.radioButton_Data_Past_14.Name = "radioButton_Data_Past_14";
            this.radioButton_Data_Past_14.Size = new System.Drawing.Size(113, 20);
            this.radioButton_Data_Past_14.TabIndex = 217;
            this.radioButton_Data_Past_14.Text = "Past 14 Days";
            this.radioButton_Data_Past_14.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_28
            // 
            this.radioButton_Data_Past_28.AutoSize = true;
            this.radioButton_Data_Past_28.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_28.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_28.Location = new System.Drawing.Point(351, 81);
            this.radioButton_Data_Past_28.Name = "radioButton_Data_Past_28";
            this.radioButton_Data_Past_28.Size = new System.Drawing.Size(113, 20);
            this.radioButton_Data_Past_28.TabIndex = 218;
            this.radioButton_Data_Past_28.Text = "Past 28 Days";
            this.radioButton_Data_Past_28.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_From
            // 
            this.radioButton_Data_From.AutoSize = true;
            this.radioButton_Data_From.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_From.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_From.Location = new System.Drawing.Point(497, 83);
            this.radioButton_Data_From.Name = "radioButton_Data_From";
            this.radioButton_Data_From.Size = new System.Drawing.Size(62, 20);
            this.radioButton_Data_From.TabIndex = 219;
            this.radioButton_Data_From.Text = "From";
            this.radioButton_Data_From.UseVisualStyleBackColor = true;
            this.radioButton_Data_From.CheckedChanged += new System.EventHandler(this.radioButton_Data_From_CheckedChanged);
            // 
            // label_Data_To
            // 
            this.label_Data_To.AutoSize = true;
            this.label_Data_To.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Data_To.ForeColor = System.Drawing.Color.Blue;
            this.label_Data_To.Location = new System.Drawing.Point(648, 84);
            this.label_Data_To.Name = "label_Data_To";
            this.label_Data_To.Size = new System.Drawing.Size(24, 16);
            this.label_Data_To.TabIndex = 220;
            this.label_Data_To.Text = "To";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 107);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1008, 539);
            this.dataGridView1.TabIndex = 244;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // BindingNavigate
            // 
            this.BindingNavigate.AddNewItem = null;
            this.BindingNavigate.CountItem = null;
            this.BindingNavigate.DeleteItem = null;
            this.BindingNavigate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BindingNavigate.ImeMode = System.Windows.Forms.ImeMode.On;
            this.BindingNavigate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.bindingNavigatorSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.txtCurrentPage,
            this.toolStripLabel1,
            this.lblPageCount,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.bindingNavigatorSeparator1,
            this.toolStripButton4});
            this.BindingNavigate.Location = new System.Drawing.Point(0, 649);
            this.BindingNavigate.MoveFirstItem = null;
            this.BindingNavigate.MoveLastItem = null;
            this.BindingNavigate.MoveNextItem = null;
            this.BindingNavigate.MovePreviousItem = null;
            this.BindingNavigate.Name = "BindingNavigate";
            this.BindingNavigate.PositionItem = null;
            this.BindingNavigate.Size = new System.Drawing.Size(1008, 25);
            this.BindingNavigate.TabIndex = 245;
            this.BindingNavigate.Text = "bindingNavigator1";
            this.BindingNavigate.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BindingNavigate_ItemClicked);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton3.Text = "Top";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton1.Text = "Previous";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.AutoSize = false;
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(40, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel1.Text = "/";
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = false;
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(40, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 22);
            this.toolStripButton2.Text = "Next";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(34, 22);
            this.toolStripButton4.Text = "End";
            // 
            // button_D
            // 
            this.button_D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_D.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_D.Location = new System.Drawing.Point(255, 56);
            this.button_D.Name = "button_D";
            this.button_D.Size = new System.Drawing.Size(48, 19);
            this.button_D.TabIndex = 246;
            this.button_D.Text = "D";
            this.button_D.UseVisualStyleBackColor = true;
            this.button_D.Click += new System.EventHandler(this.button_D_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.DarkViolet;
            this.label1.Location = new System.Drawing.Point(311, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 247;
            this.label1.Text = "Default =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.DarkViolet;
            this.label2.Location = new System.Drawing.Point(383, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 248;
            this.label2.Text = "BX/CY";
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_From.Location = new System.Drawing.Point(554, 81);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_From.TabIndex = 249;
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_To.Location = new System.Drawing.Point(668, 81);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_To.TabIndex = 250;
            // 
            // Form_BXCYRecordSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(1008, 674);
            this.ControlBox = false;
            this.Controls.Add(this.dateTimePicker_To);
            this.Controls.Add(this.dateTimePicker_From);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_D);
            this.Controls.Add(this.BindingNavigate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_Data_To);
            this.Controls.Add(this.radioButton_Data_From);
            this.Controls.Add(this.radioButton_Data_Past_28);
            this.Controls.Add(this.radioButton_Data_Past_14);
            this.Controls.Add(this.radioButton_Data_Past_7);
            this.Controls.Add(this.radioButton_Data_All);
            this.Controls.Add(this.button_Digital_Signature);
            this.Controls.Add(this.button_F1_Search);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_CC);
            this.Controls.Add(this.button_CY);
            this.Controls.Add(this.button_BB);
            this.Controls.Add(this.button_F9_Set_BX_CY);
            this.Controls.Add(this.button_F8_Pic_Path);
            this.Controls.Add(this.button_F7_Columns);
            this.Controls.Add(this.button_F2_New_Record);
            this.Controls.Add(this.button_F5_New_Patient);
            this.Controls.Add(this.buttonF3_Edit_Record);
            this.Controls.Add(this.button_F6_View_Record);
            this.Controls.Add(this.button_F4_Daily_Report);
            this.Controls.Add(this.button_BX);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.textBox_Search_Type);
            this.Controls.Add(this.label_Search_Type);
            this.KeyPreview = true;
            this.Name = "Form_BXCYRecordSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BX/CY Record Search";
            this.Load += new System.EventHandler(this.Form_BXCYRecordSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_BXCYRecordSearch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bXCYSPECIMENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medlabDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigate)).EndInit();
            this.BindingNavigate.ResumeLayout(false);
            this.BindingNavigate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Search_Type;
        private System.Windows.Forms.Label label_Search_Type;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_BX;
        private System.Windows.Forms.Button button_F4_Daily_Report;
        private System.Windows.Forms.Button buttonF3_Edit_Record;
        private System.Windows.Forms.Button button_F6_View_Record;
        private System.Windows.Forms.Button button_F2_New_Record;
        private System.Windows.Forms.Button button_F5_New_Patient;
        private System.Windows.Forms.Button button_F7_Columns;
        private System.Windows.Forms.Button button_F8_Pic_Path;
        private System.Windows.Forms.Button button_F9_Set_BX_CY;
        private System.Windows.Forms.Button button_BB;
        private System.Windows.Forms.Button button_CC;
        private System.Windows.Forms.Button button_CY;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_F1_Search;
        private medlabDataSet medlabDataSet;
        private System.Windows.Forms.BindingSource bXCYSPECIMENBindingSource;
        private medlabDataSetTableAdapters.BXCY_SPECIMENTableAdapter bXCY_SPECIMENTableAdapter;
        private System.Windows.Forms.Button button_Digital_Signature;
        private System.Windows.Forms.RadioButton radioButton_Data_All;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_7;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_14;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_28;
        private System.Windows.Forms.RadioButton radioButton_Data_From;
        private System.Windows.Forms.Label label_Data_To;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator BindingNavigate;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox txtCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblPageCount;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Button button_D;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
    }
}