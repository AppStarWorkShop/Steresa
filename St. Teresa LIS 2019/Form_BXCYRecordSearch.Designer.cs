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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.casenoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rptdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patseqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patsexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctoricDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fzsectionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snopcodetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desctDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snopcodet2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desct2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snopcodet3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desct3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snopcodemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snopcodem2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descm2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.snopcodem3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descm3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cyreportDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signdrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inv_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.textBox_Data_From = new System.Windows.Forms.TextBox();
            this.textBox_Data_To = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bXCYSPECIMENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medlabDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.casenoDataGridViewTextBoxColumn,
            this.rptdateDataGridViewTextBoxColumn,
            this.patientDataGridViewTextBoxColumn,
            this.patseqDataGridViewTextBoxColumn,
            this.patageDataGridViewTextBoxColumn,
            this.patsexDataGridViewTextBoxColumn,
            this.pathkidDataGridViewTextBoxColumn,
            this.clientDataGridViewTextBoxColumn,
            this.doctoricDataGridViewTextBoxColumn,
            this.fzsectionDataGridViewTextBoxColumn,
            this.snopcodetDataGridViewTextBoxColumn,
            this.desctDataGridViewTextBoxColumn,
            this.snopcodet2DataGridViewTextBoxColumn,
            this.desct2DataGridViewTextBoxColumn,
            this.snopcodet3DataGridViewTextBoxColumn,
            this.desct3DataGridViewTextBoxColumn,
            this.snopcodemDataGridViewTextBoxColumn,
            this.descmDataGridViewTextBoxColumn,
            this.snopcodem2DataGridViewTextBoxColumn,
            this.descm2DataGridViewTextBoxColumn,
            this.snopcodem3DataGridViewTextBoxColumn,
            this.descm3DataGridViewTextBoxColumn,
            this.cyreportDataGridViewTextBoxColumn,
            this.signdrDataGridViewTextBoxColumn,
            this.erDataGridViewTextBoxColumn,
            this.emDataGridViewTextBoxColumn,
            this.inv_date});
            this.dataGridView1.DataSource = this.bXCYSPECIMENBindingSource;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(-16, 113);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 617);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // casenoDataGridViewTextBoxColumn
            // 
            this.casenoDataGridViewTextBoxColumn.DataPropertyName = "case_no";
            this.casenoDataGridViewTextBoxColumn.HeaderText = "Case No";
            this.casenoDataGridViewTextBoxColumn.Name = "casenoDataGridViewTextBoxColumn";
            this.casenoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rptdateDataGridViewTextBoxColumn
            // 
            this.rptdateDataGridViewTextBoxColumn.DataPropertyName = "rpt_date";
            this.rptdateDataGridViewTextBoxColumn.HeaderText = "Report Date";
            this.rptdateDataGridViewTextBoxColumn.Name = "rptdateDataGridViewTextBoxColumn";
            this.rptdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientDataGridViewTextBoxColumn
            // 
            this.patientDataGridViewTextBoxColumn.DataPropertyName = "patient";
            this.patientDataGridViewTextBoxColumn.HeaderText = "Patient";
            this.patientDataGridViewTextBoxColumn.Name = "patientDataGridViewTextBoxColumn";
            this.patientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patseqDataGridViewTextBoxColumn
            // 
            this.patseqDataGridViewTextBoxColumn.DataPropertyName = "pat_seq";
            this.patseqDataGridViewTextBoxColumn.HeaderText = " ";
            this.patseqDataGridViewTextBoxColumn.Name = "patseqDataGridViewTextBoxColumn";
            this.patseqDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patageDataGridViewTextBoxColumn
            // 
            this.patageDataGridViewTextBoxColumn.DataPropertyName = "pat_age";
            this.patageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.patageDataGridViewTextBoxColumn.Name = "patageDataGridViewTextBoxColumn";
            this.patageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patsexDataGridViewTextBoxColumn
            // 
            this.patsexDataGridViewTextBoxColumn.DataPropertyName = "pat_sex";
            this.patsexDataGridViewTextBoxColumn.HeaderText = "Sex";
            this.patsexDataGridViewTextBoxColumn.Name = "patsexDataGridViewTextBoxColumn";
            this.patsexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathkidDataGridViewTextBoxColumn
            // 
            this.pathkidDataGridViewTextBoxColumn.DataPropertyName = "pat_hkid";
            this.pathkidDataGridViewTextBoxColumn.HeaderText = "HKID No.";
            this.pathkidDataGridViewTextBoxColumn.Name = "pathkidDataGridViewTextBoxColumn";
            this.pathkidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Client";
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doctoricDataGridViewTextBoxColumn
            // 
            this.doctoricDataGridViewTextBoxColumn.DataPropertyName = "doctor_ic";
            this.doctoricDataGridViewTextBoxColumn.HeaderText = "Doctor In Charge";
            this.doctoricDataGridViewTextBoxColumn.Name = "doctoricDataGridViewTextBoxColumn";
            this.doctoricDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fzsectionDataGridViewTextBoxColumn
            // 
            this.fzsectionDataGridViewTextBoxColumn.DataPropertyName = "fz_section";
            this.fzsectionDataGridViewTextBoxColumn.HeaderText = "F.S.";
            this.fzsectionDataGridViewTextBoxColumn.Name = "fzsectionDataGridViewTextBoxColumn";
            this.fzsectionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snopcodetDataGridViewTextBoxColumn
            // 
            this.snopcodetDataGridViewTextBoxColumn.DataPropertyName = "snopcode_t";
            this.snopcodetDataGridViewTextBoxColumn.HeaderText = "Snop-T";
            this.snopcodetDataGridViewTextBoxColumn.Name = "snopcodetDataGridViewTextBoxColumn";
            this.snopcodetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desctDataGridViewTextBoxColumn
            // 
            this.desctDataGridViewTextBoxColumn.DataPropertyName = "desc_t";
            this.desctDataGridViewTextBoxColumn.HeaderText = "Desc-T";
            this.desctDataGridViewTextBoxColumn.Name = "desctDataGridViewTextBoxColumn";
            this.desctDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snopcodet2DataGridViewTextBoxColumn
            // 
            this.snopcodet2DataGridViewTextBoxColumn.DataPropertyName = "snopcode_t2";
            this.snopcodet2DataGridViewTextBoxColumn.HeaderText = "Snop-T2";
            this.snopcodet2DataGridViewTextBoxColumn.Name = "snopcodet2DataGridViewTextBoxColumn";
            this.snopcodet2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desct2DataGridViewTextBoxColumn
            // 
            this.desct2DataGridViewTextBoxColumn.DataPropertyName = "desc_t2";
            this.desct2DataGridViewTextBoxColumn.HeaderText = "Desc-T2";
            this.desct2DataGridViewTextBoxColumn.Name = "desct2DataGridViewTextBoxColumn";
            this.desct2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snopcodet3DataGridViewTextBoxColumn
            // 
            this.snopcodet3DataGridViewTextBoxColumn.DataPropertyName = "snopcode_t3";
            this.snopcodet3DataGridViewTextBoxColumn.HeaderText = "Snop-T3";
            this.snopcodet3DataGridViewTextBoxColumn.Name = "snopcodet3DataGridViewTextBoxColumn";
            this.snopcodet3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desct3DataGridViewTextBoxColumn
            // 
            this.desct3DataGridViewTextBoxColumn.DataPropertyName = "desc_t3";
            this.desct3DataGridViewTextBoxColumn.HeaderText = "Desc-T3";
            this.desct3DataGridViewTextBoxColumn.Name = "desct3DataGridViewTextBoxColumn";
            this.desct3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snopcodemDataGridViewTextBoxColumn
            // 
            this.snopcodemDataGridViewTextBoxColumn.DataPropertyName = "snopcode_m";
            this.snopcodemDataGridViewTextBoxColumn.HeaderText = "Snop-M";
            this.snopcodemDataGridViewTextBoxColumn.Name = "snopcodemDataGridViewTextBoxColumn";
            this.snopcodemDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descmDataGridViewTextBoxColumn
            // 
            this.descmDataGridViewTextBoxColumn.DataPropertyName = "desc_m";
            this.descmDataGridViewTextBoxColumn.HeaderText = "Desc-m";
            this.descmDataGridViewTextBoxColumn.Name = "descmDataGridViewTextBoxColumn";
            this.descmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snopcodem2DataGridViewTextBoxColumn
            // 
            this.snopcodem2DataGridViewTextBoxColumn.DataPropertyName = "snopcode_m2";
            this.snopcodem2DataGridViewTextBoxColumn.HeaderText = "Snop-M2";
            this.snopcodem2DataGridViewTextBoxColumn.Name = "snopcodem2DataGridViewTextBoxColumn";
            this.snopcodem2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descm2DataGridViewTextBoxColumn
            // 
            this.descm2DataGridViewTextBoxColumn.DataPropertyName = "desc_m2";
            this.descm2DataGridViewTextBoxColumn.HeaderText = "Desc-M2";
            this.descm2DataGridViewTextBoxColumn.Name = "descm2DataGridViewTextBoxColumn";
            this.descm2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // snopcodem3DataGridViewTextBoxColumn
            // 
            this.snopcodem3DataGridViewTextBoxColumn.DataPropertyName = "snopcode_m3";
            this.snopcodem3DataGridViewTextBoxColumn.HeaderText = "Snop-M3";
            this.snopcodem3DataGridViewTextBoxColumn.Name = "snopcodem3DataGridViewTextBoxColumn";
            this.snopcodem3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descm3DataGridViewTextBoxColumn
            // 
            this.descm3DataGridViewTextBoxColumn.DataPropertyName = "desc_m3";
            this.descm3DataGridViewTextBoxColumn.HeaderText = "Desc-M3";
            this.descm3DataGridViewTextBoxColumn.Name = "descm3DataGridViewTextBoxColumn";
            this.descm3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cyreportDataGridViewTextBoxColumn
            // 
            this.cyreportDataGridViewTextBoxColumn.DataPropertyName = "cy_report";
            this.cyreportDataGridViewTextBoxColumn.HeaderText = "CY Report";
            this.cyreportDataGridViewTextBoxColumn.Name = "cyreportDataGridViewTextBoxColumn";
            this.cyreportDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // signdrDataGridViewTextBoxColumn
            // 
            this.signdrDataGridViewTextBoxColumn.DataPropertyName = "sign_dr";
            this.signdrDataGridViewTextBoxColumn.HeaderText = "Sign By";
            this.signdrDataGridViewTextBoxColumn.Name = "signdrDataGridViewTextBoxColumn";
            this.signdrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // erDataGridViewTextBoxColumn
            // 
            this.erDataGridViewTextBoxColumn.DataPropertyName = "er";
            this.erDataGridViewTextBoxColumn.HeaderText = "E/R";
            this.erDataGridViewTextBoxColumn.Name = "erDataGridViewTextBoxColumn";
            this.erDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emDataGridViewTextBoxColumn
            // 
            this.emDataGridViewTextBoxColumn.DataPropertyName = "em";
            this.emDataGridViewTextBoxColumn.HeaderText = "E/M";
            this.emDataGridViewTextBoxColumn.Name = "emDataGridViewTextBoxColumn";
            this.emDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inv_date
            // 
            this.inv_date.DataPropertyName = "inv_date";
            this.inv_date.HeaderText = "inv_date";
            this.inv_date.Name = "inv_date";
            this.inv_date.ReadOnly = true;
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
            this.textBox_Search_Type.Location = new System.Drawing.Point(14, 28);
            this.textBox_Search_Type.Name = "textBox_Search_Type";
            this.textBox_Search_Type.Size = new System.Drawing.Size(254, 27);
            this.textBox_Search_Type.TabIndex = 50;
            this.textBox_Search_Type.TextChanged += new System.EventHandler(this.textBox_Search_Type_TextChanged);
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
            this.button_Exit.Location = new System.Drawing.Point(885, 48);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(109, 33);
            this.button_Exit.TabIndex = 52;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_BX
            // 
            this.button_BX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_BX.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_BX.Location = new System.Drawing.Point(14, 61);
            this.button_BX.Name = "button_BX";
            this.button_BX.Size = new System.Drawing.Size(48, 21);
            this.button_BX.TabIndex = 66;
            this.button_BX.Text = "BX";
            this.button_BX.UseVisualStyleBackColor = true;
            // 
            // button_F4_Daily_Report
            // 
            this.button_F4_Daily_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F4_Daily_Report.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_F4_Daily_Report.Location = new System.Drawing.Point(885, 8);
            this.button_F4_Daily_Report.Name = "button_F4_Daily_Report";
            this.button_F4_Daily_Report.Size = new System.Drawing.Size(109, 33);
            this.button_F4_Daily_Report.TabIndex = 67;
            this.button_F4_Daily_Report.Text = "F4. Daily Report";
            this.button_F4_Daily_Report.UseVisualStyleBackColor = true;
            this.button_F4_Daily_Report.Click += new System.EventHandler(this.button_F4_Daily_Report_Click);
            // 
            // buttonF3_Edit_Record
            // 
            this.buttonF3_Edit_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonF3_Edit_Record.ForeColor = System.Drawing.Color.Gray;
            this.buttonF3_Edit_Record.Location = new System.Drawing.Point(736, 8);
            this.buttonF3_Edit_Record.Name = "buttonF3_Edit_Record";
            this.buttonF3_Edit_Record.Size = new System.Drawing.Size(109, 33);
            this.buttonF3_Edit_Record.TabIndex = 69;
            this.buttonF3_Edit_Record.Text = "F3. Edit Record";
            this.buttonF3_Edit_Record.UseVisualStyleBackColor = true;
            this.buttonF3_Edit_Record.Click += new System.EventHandler(this.buttonF3_Edit_Record_Click);
            // 
            // button_F6_View_Record
            // 
            this.button_F6_View_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F6_View_Record.ForeColor = System.Drawing.Color.Gray;
            this.button_F6_View_Record.Location = new System.Drawing.Point(736, 47);
            this.button_F6_View_Record.Name = "button_F6_View_Record";
            this.button_F6_View_Record.Size = new System.Drawing.Size(109, 33);
            this.button_F6_View_Record.TabIndex = 68;
            this.button_F6_View_Record.Text = "F6. View Record";
            this.button_F6_View_Record.UseVisualStyleBackColor = true;
            this.button_F6_View_Record.Click += new System.EventHandler(this.button_F6_View_Record_Click);
            // 
            // button_F2_New_Record
            // 
            this.button_F2_New_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F2_New_Record.ForeColor = System.Drawing.Color.Gray;
            this.button_F2_New_Record.Location = new System.Drawing.Point(621, 8);
            this.button_F2_New_Record.Name = "button_F2_New_Record";
            this.button_F2_New_Record.Size = new System.Drawing.Size(109, 33);
            this.button_F2_New_Record.TabIndex = 71;
            this.button_F2_New_Record.Text = "F2. New Record";
            this.button_F2_New_Record.UseVisualStyleBackColor = true;
            this.button_F2_New_Record.Click += new System.EventHandler(this.button_F2_New_Record_Click);
            // 
            // button_F5_New_Patient
            // 
            this.button_F5_New_Patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F5_New_Patient.ForeColor = System.Drawing.Color.Gray;
            this.button_F5_New_Patient.Location = new System.Drawing.Point(621, 47);
            this.button_F5_New_Patient.Name = "button_F5_New_Patient";
            this.button_F5_New_Patient.Size = new System.Drawing.Size(109, 33);
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
            this.button_F7_Columns.Size = new System.Drawing.Size(101, 24);
            this.button_F7_Columns.TabIndex = 72;
            this.button_F7_Columns.Text = "F7. Columns";
            this.button_F7_Columns.UseVisualStyleBackColor = true;
            this.button_F7_Columns.Click += new System.EventHandler(this.button_F7_Columas_Click);
            // 
            // button_F8_Pic_Path
            // 
            this.button_F8_Pic_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F8_Pic_Path.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button_F8_Pic_Path.Location = new System.Drawing.Point(484, 31);
            this.button_F8_Pic_Path.Name = "button_F8_Pic_Path";
            this.button_F8_Pic_Path.Size = new System.Drawing.Size(101, 24);
            this.button_F8_Pic_Path.TabIndex = 73;
            this.button_F8_Pic_Path.Text = "F8. Pic. Path";
            this.button_F8_Pic_Path.UseVisualStyleBackColor = true;
            this.button_F8_Pic_Path.Click += new System.EventHandler(this.button_F8_Pic_Path_Click);
            // 
            // button_F9_Set_BX_CY
            // 
            this.button_F9_Set_BX_CY.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F9_Set_BX_CY.ForeColor = System.Drawing.Color.Purple;
            this.button_F9_Set_BX_CY.Location = new System.Drawing.Point(484, 56);
            this.button_F9_Set_BX_CY.Name = "button_F9_Set_BX_CY";
            this.button_F9_Set_BX_CY.Size = new System.Drawing.Size(101, 24);
            this.button_F9_Set_BX_CY.TabIndex = 74;
            this.button_F9_Set_BX_CY.Text = "F9. Set BX/CY";
            this.button_F9_Set_BX_CY.UseVisualStyleBackColor = true;
            this.button_F9_Set_BX_CY.Click += new System.EventHandler(this.button_F9_Set_BX_CY_Click);
            // 
            // button_BB
            // 
            this.button_BB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_BB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_BB.Location = new System.Drawing.Point(62, 61);
            this.button_BB.Name = "button_BB";
            this.button_BB.Size = new System.Drawing.Size(48, 21);
            this.button_BB.TabIndex = 77;
            this.button_BB.Text = "BB";
            this.button_BB.UseVisualStyleBackColor = true;
            // 
            // button_CC
            // 
            this.button_CC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_CC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_CC.Location = new System.Drawing.Point(158, 61);
            this.button_CC.Name = "button_CC";
            this.button_CC.Size = new System.Drawing.Size(48, 21);
            this.button_CC.TabIndex = 79;
            this.button_CC.Text = "CC";
            this.button_CC.UseVisualStyleBackColor = true;
            // 
            // button_CY
            // 
            this.button_CY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_CY.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_CY.Location = new System.Drawing.Point(110, 61);
            this.button_CY.Name = "button_CY";
            this.button_CY.Size = new System.Drawing.Size(48, 21);
            this.button_CY.TabIndex = 78;
            this.button_CY.Text = "CY";
            this.button_CY.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(208, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 21);
            this.button1.TabIndex = 80;
            this.button1.Text = "MP";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button_F1_Search
            // 
            this.button_F1_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F1_Search.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_F1_Search.Location = new System.Drawing.Point(220, 4);
            this.button_F1_Search.Name = "button_F1_Search";
            this.button_F1_Search.Size = new System.Drawing.Size(83, 21);
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
            this.button_Digital_Signature.Location = new System.Drawing.Point(351, 18);
            this.button_Digital_Signature.Name = "button_Digital_Signature";
            this.button_Digital_Signature.Size = new System.Drawing.Size(102, 47);
            this.button_Digital_Signature.TabIndex = 82;
            this.button_Digital_Signature.Text = "F10 Digital Signature";
            this.button_Digital_Signature.UseVisualStyleBackColor = true;
            this.button_Digital_Signature.Click += new System.EventHandler(this.button_Digital_Signature_Click);
            // 
            // radioButton_Data_All
            // 
            this.radioButton_Data_All.AutoSize = true;
            this.radioButton_Data_All.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_All.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_All.Location = new System.Drawing.Point(14, 88);
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
            this.radioButton_Data_Past_7.Location = new System.Drawing.Point(76, 88);
            this.radioButton_Data_Past_7.Name = "radioButton_Data_Past_7";
            this.radioButton_Data_Past_7.Size = new System.Drawing.Size(105, 20);
            this.radioButton_Data_Past_7.TabIndex = 216;
            this.radioButton_Data_Past_7.TabStop = true;
            this.radioButton_Data_Past_7.Text = "Past 7 Days";
            this.radioButton_Data_Past_7.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_14
            // 
            this.radioButton_Data_Past_14.AutoSize = true;
            this.radioButton_Data_Past_14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_14.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_14.Location = new System.Drawing.Point(208, 88);
            this.radioButton_Data_Past_14.Name = "radioButton_Data_Past_14";
            this.radioButton_Data_Past_14.Size = new System.Drawing.Size(113, 20);
            this.radioButton_Data_Past_14.TabIndex = 217;
            this.radioButton_Data_Past_14.TabStop = true;
            this.radioButton_Data_Past_14.Text = "Past 14 Days";
            this.radioButton_Data_Past_14.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_28
            // 
            this.radioButton_Data_Past_28.AutoSize = true;
            this.radioButton_Data_Past_28.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_28.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_28.Location = new System.Drawing.Point(351, 88);
            this.radioButton_Data_Past_28.Name = "radioButton_Data_Past_28";
            this.radioButton_Data_Past_28.Size = new System.Drawing.Size(113, 20);
            this.radioButton_Data_Past_28.TabIndex = 218;
            this.radioButton_Data_Past_28.TabStop = true;
            this.radioButton_Data_Past_28.Text = "Past 28 Days";
            this.radioButton_Data_Past_28.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_From
            // 
            this.radioButton_Data_From.AutoSize = true;
            this.radioButton_Data_From.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_From.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_From.Location = new System.Drawing.Point(497, 90);
            this.radioButton_Data_From.Name = "radioButton_Data_From";
            this.radioButton_Data_From.Size = new System.Drawing.Size(62, 20);
            this.radioButton_Data_From.TabIndex = 219;
            this.radioButton_Data_From.TabStop = true;
            this.radioButton_Data_From.Text = "From";
            this.radioButton_Data_From.UseVisualStyleBackColor = true;
            // 
            // label_Data_To
            // 
            this.label_Data_To.AutoSize = true;
            this.label_Data_To.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Data_To.ForeColor = System.Drawing.Color.Blue;
            this.label_Data_To.Location = new System.Drawing.Point(648, 91);
            this.label_Data_To.Name = "label_Data_To";
            this.label_Data_To.Size = new System.Drawing.Size(24, 16);
            this.label_Data_To.TabIndex = 220;
            this.label_Data_To.Text = "To";
            // 
            // textBox_Data_From
            // 
            this.textBox_Data_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Data_From.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox_Data_From.Location = new System.Drawing.Point(565, 87);
            this.textBox_Data_From.Name = "textBox_Data_From";
            this.textBox_Data_From.Size = new System.Drawing.Size(82, 23);
            this.textBox_Data_From.TabIndex = 242;
            this.textBox_Data_From.Text = "31/05/2019";
            // 
            // textBox_Data_To
            // 
            this.textBox_Data_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Data_To.ForeColor = System.Drawing.Color.DarkBlue;
            this.textBox_Data_To.Location = new System.Drawing.Point(673, 88);
            this.textBox_Data_To.Name = "textBox_Data_To";
            this.textBox_Data_To.Size = new System.Drawing.Size(82, 23);
            this.textBox_Data_To.TabIndex = 243;
            this.textBox_Data_To.Text = "31/05/2019";
            // 
            // Form_BXCYRecordSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(216)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_Data_To);
            this.Controls.Add(this.textBox_Data_From);
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
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox_Search_Type);
            this.Controls.Add(this.label_Search_Type);
            this.KeyPreview = true;
            this.Name = "Form_BXCYRecordSearch";
            this.Text = "BX/CY Record Search";
            this.Load += new System.EventHandler(this.Form_BXCYRecordSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_BXCYRecordSearch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bXCYSPECIMENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medlabDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn casenoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rptdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patseqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patsexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctoricDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fzsectionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snopcodetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desctDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snopcodet2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desct2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snopcodet3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desct3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snopcodemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snopcodem2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descm2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn snopcodem3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descm3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cyreportDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn signdrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn erDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inv_date;
        private System.Windows.Forms.Button button_Digital_Signature;
        private System.Windows.Forms.RadioButton radioButton_Data_All;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_7;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_14;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_28;
        private System.Windows.Forms.RadioButton radioButton_Data_From;
        private System.Windows.Forms.Label label_Data_To;
        private System.Windows.Forms.TextBox textBox_Data_From;
        private System.Windows.Forms.TextBox textBox_Data_To;
    }
}