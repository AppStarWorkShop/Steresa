namespace St.Teresa_LIS_2019
{
    partial class Form_EBVRecordSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EBVRecordSearch));
            this.label_F1 = new System.Windows.Forms.Label();
            this.button_F7_Columas = new System.Windows.Forms.Button();
            this.button_F2_New_Record = new System.Windows.Forms.Button();
            this.button_F5_New_Patient = new System.Windows.Forms.Button();
            this.buttonF3_Edit_Record = new System.Windows.Forms.Button();
            this.button_F6_View_Record = new System.Windows.Forms.Button();
            this.button_F4_Daily_Report = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_Search_Type = new System.Windows.Forms.TextBox();
            this.label_Search_Type = new System.Windows.Forms.Label();
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
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.label_Data_To = new System.Windows.Forms.Label();
            this.radioButton_Data_From = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_Past_28 = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_Past_14 = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_Past_7 = new System.Windows.Forms.RadioButton();
            this.radioButton_Data_All = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigate)).BeginInit();
            this.BindingNavigate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_F1
            // 
            this.label_F1.AutoSize = true;
            this.label_F1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_F1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_F1.Location = new System.Drawing.Point(244, 19);
            this.label_F1.Name = "label_F1";
            this.label_F1.Size = new System.Drawing.Size(35, 13);
            this.label_F1.TabIndex = 87;
            this.label_F1.Text = "<F1>";
            // 
            // button_F7_Columas
            // 
            this.button_F7_Columas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F7_Columas.ForeColor = System.Drawing.Color.Green;
            this.button_F7_Columas.Location = new System.Drawing.Point(469, 13);
            this.button_F7_Columas.Name = "button_F7_Columas";
            this.button_F7_Columas.Size = new System.Drawing.Size(101, 22);
            this.button_F7_Columas.TabIndex = 86;
            this.button_F7_Columas.Text = "F7. Columas";
            this.button_F7_Columas.UseVisualStyleBackColor = true;
            this.button_F7_Columas.Click += new System.EventHandler(this.button_F7_Columas_Click);
            // 
            // button_F2_New_Record
            // 
            this.button_F2_New_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F2_New_Record.ForeColor = System.Drawing.Color.Black;
            this.button_F2_New_Record.Location = new System.Drawing.Point(626, 10);
            this.button_F2_New_Record.Name = "button_F2_New_Record";
            this.button_F2_New_Record.Size = new System.Drawing.Size(109, 30);
            this.button_F2_New_Record.TabIndex = 85;
            this.button_F2_New_Record.Text = "F2. New Record";
            this.button_F2_New_Record.UseVisualStyleBackColor = true;
            this.button_F2_New_Record.Click += new System.EventHandler(this.button_F2_New_Record_Click);
            // 
            // button_F5_New_Patient
            // 
            this.button_F5_New_Patient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F5_New_Patient.ForeColor = System.Drawing.Color.Black;
            this.button_F5_New_Patient.Location = new System.Drawing.Point(626, 46);
            this.button_F5_New_Patient.Name = "button_F5_New_Patient";
            this.button_F5_New_Patient.Size = new System.Drawing.Size(109, 30);
            this.button_F5_New_Patient.TabIndex = 84;
            this.button_F5_New_Patient.Text = "F5. New Patient";
            this.button_F5_New_Patient.UseVisualStyleBackColor = true;
            this.button_F5_New_Patient.Click += new System.EventHandler(this.button_F5_New_Patient_Click);
            // 
            // buttonF3_Edit_Record
            // 
            this.buttonF3_Edit_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.buttonF3_Edit_Record.ForeColor = System.Drawing.Color.Black;
            this.buttonF3_Edit_Record.Location = new System.Drawing.Point(741, 10);
            this.buttonF3_Edit_Record.Name = "buttonF3_Edit_Record";
            this.buttonF3_Edit_Record.Size = new System.Drawing.Size(109, 30);
            this.buttonF3_Edit_Record.TabIndex = 83;
            this.buttonF3_Edit_Record.Text = "F3. Edit Record";
            this.buttonF3_Edit_Record.UseVisualStyleBackColor = true;
            this.buttonF3_Edit_Record.Click += new System.EventHandler(this.buttonF3_Edit_Record_Click);
            // 
            // button_F6_View_Record
            // 
            this.button_F6_View_Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F6_View_Record.ForeColor = System.Drawing.Color.Black;
            this.button_F6_View_Record.Location = new System.Drawing.Point(741, 46);
            this.button_F6_View_Record.Name = "button_F6_View_Record";
            this.button_F6_View_Record.Size = new System.Drawing.Size(109, 30);
            this.button_F6_View_Record.TabIndex = 82;
            this.button_F6_View_Record.Text = "F6. View Record";
            this.button_F6_View_Record.UseVisualStyleBackColor = true;
            this.button_F6_View_Record.Click += new System.EventHandler(this.button_F6_View_Record_Click);
            // 
            // button_F4_Daily_Report
            // 
            this.button_F4_Daily_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F4_Daily_Report.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_F4_Daily_Report.Location = new System.Drawing.Point(887, 10);
            this.button_F4_Daily_Report.Name = "button_F4_Daily_Report";
            this.button_F4_Daily_Report.Size = new System.Drawing.Size(109, 30);
            this.button_F4_Daily_Report.TabIndex = 81;
            this.button_F4_Daily_Report.Text = "F4. Daily Report";
            this.button_F4_Daily_Report.UseVisualStyleBackColor = true;
            this.button_F4_Daily_Report.Click += new System.EventHandler(this.button_F4_Daily_Report_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.Color.Purple;
            this.button_Exit.Location = new System.Drawing.Point(887, 47);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(109, 30);
            this.button_Exit.TabIndex = 80;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // textBox_Search_Type
            // 
            this.textBox_Search_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Search_Type.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Search_Type.Location = new System.Drawing.Point(16, 38);
            this.textBox_Search_Type.Name = "textBox_Search_Type";
            this.textBox_Search_Type.Size = new System.Drawing.Size(254, 27);
            this.textBox_Search_Type.TabIndex = 78;
            this.textBox_Search_Type.TextChanged += new System.EventHandler(this.textBox_Search_Type_TextChanged);
            // 
            // label_Search_Type
            // 
            this.label_Search_Type.AutoSize = true;
            this.label_Search_Type.BackColor = System.Drawing.Color.Transparent;
            this.label_Search_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Search_Type.ForeColor = System.Drawing.Color.Blue;
            this.label_Search_Type.Location = new System.Drawing.Point(12, 15);
            this.label_Search_Type.Name = "label_Search_Type";
            this.label_Search_Type.Size = new System.Drawing.Size(171, 22);
            this.label_Search_Type.TabIndex = 77;
            this.label_Search_Type.Text = "Locate Case No. :";
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
            this.BindingNavigate.TabIndex = 246;
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
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_To.Location = new System.Drawing.Point(671, 79);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_To.TabIndex = 258;
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_From.Location = new System.Drawing.Point(557, 79);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(97, 21);
            this.dateTimePicker_From.TabIndex = 257;
            // 
            // label_Data_To
            // 
            this.label_Data_To.AutoSize = true;
            this.label_Data_To.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Data_To.ForeColor = System.Drawing.Color.Blue;
            this.label_Data_To.Location = new System.Drawing.Point(651, 82);
            this.label_Data_To.Name = "label_Data_To";
            this.label_Data_To.Size = new System.Drawing.Size(24, 16);
            this.label_Data_To.TabIndex = 256;
            this.label_Data_To.Text = "To";
            // 
            // radioButton_Data_From
            // 
            this.radioButton_Data_From.AutoSize = true;
            this.radioButton_Data_From.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_From.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_From.Location = new System.Drawing.Point(500, 81);
            this.radioButton_Data_From.Name = "radioButton_Data_From";
            this.radioButton_Data_From.Size = new System.Drawing.Size(62, 20);
            this.radioButton_Data_From.TabIndex = 255;
            this.radioButton_Data_From.Text = "From";
            this.radioButton_Data_From.UseVisualStyleBackColor = true;
            this.radioButton_Data_From.CheckedChanged += new System.EventHandler(this.radioButton_Data_From_CheckedChanged);
            // 
            // radioButton_Data_Past_28
            // 
            this.radioButton_Data_Past_28.AutoSize = true;
            this.radioButton_Data_Past_28.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_28.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_28.Location = new System.Drawing.Point(354, 79);
            this.radioButton_Data_Past_28.Name = "radioButton_Data_Past_28";
            this.radioButton_Data_Past_28.Size = new System.Drawing.Size(113, 20);
            this.radioButton_Data_Past_28.TabIndex = 254;
            this.radioButton_Data_Past_28.Text = "Past 28 Days";
            this.radioButton_Data_Past_28.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_14
            // 
            this.radioButton_Data_Past_14.AutoSize = true;
            this.radioButton_Data_Past_14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_14.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_14.Location = new System.Drawing.Point(211, 79);
            this.radioButton_Data_Past_14.Name = "radioButton_Data_Past_14";
            this.radioButton_Data_Past_14.Size = new System.Drawing.Size(113, 20);
            this.radioButton_Data_Past_14.TabIndex = 253;
            this.radioButton_Data_Past_14.Text = "Past 14 Days";
            this.radioButton_Data_Past_14.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_Past_7
            // 
            this.radioButton_Data_Past_7.AutoSize = true;
            this.radioButton_Data_Past_7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_Past_7.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_Past_7.Location = new System.Drawing.Point(79, 79);
            this.radioButton_Data_Past_7.Name = "radioButton_Data_Past_7";
            this.radioButton_Data_Past_7.Size = new System.Drawing.Size(105, 20);
            this.radioButton_Data_Past_7.TabIndex = 252;
            this.radioButton_Data_Past_7.Text = "Past 7 Days";
            this.radioButton_Data_Past_7.UseVisualStyleBackColor = true;
            // 
            // radioButton_Data_All
            // 
            this.radioButton_Data_All.AutoSize = true;
            this.radioButton_Data_All.Checked = true;
            this.radioButton_Data_All.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.radioButton_Data_All.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_Data_All.Location = new System.Drawing.Point(17, 79);
            this.radioButton_Data_All.Name = "radioButton_Data_All";
            this.radioButton_Data_All.Size = new System.Drawing.Size(43, 20);
            this.radioButton_Data_All.TabIndex = 251;
            this.radioButton_Data_All.TabStop = true;
            this.radioButton_Data_All.Text = "All";
            this.radioButton_Data_All.UseVisualStyleBackColor = true;
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
            this.dataGridView1.TabIndex = 259;
            this.dataGridView1.VirtualMode = true;
            // 
            // Form_EBVRecordSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(200)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1008, 674);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePicker_To);
            this.Controls.Add(this.dateTimePicker_From);
            this.Controls.Add(this.label_Data_To);
            this.Controls.Add(this.radioButton_Data_From);
            this.Controls.Add(this.radioButton_Data_Past_28);
            this.Controls.Add(this.radioButton_Data_Past_14);
            this.Controls.Add(this.radioButton_Data_Past_7);
            this.Controls.Add(this.radioButton_Data_All);
            this.Controls.Add(this.BindingNavigate);
            this.Controls.Add(this.label_F1);
            this.Controls.Add(this.button_F7_Columas);
            this.Controls.Add(this.button_F2_New_Record);
            this.Controls.Add(this.button_F5_New_Patient);
            this.Controls.Add(this.buttonF3_Edit_Record);
            this.Controls.Add(this.button_F6_View_Record);
            this.Controls.Add(this.button_F4_Daily_Report);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.textBox_Search_Type);
            this.Controls.Add(this.label_Search_Type);
            this.Name = "Form_EBVRecordSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Locate Case No";
            this.Load += new System.EventHandler(this.Form_LocateCaseNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavigate)).EndInit();
            this.BindingNavigate.ResumeLayout(false);
            this.BindingNavigate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_F1;
        private System.Windows.Forms.Button button_F7_Columas;
        private System.Windows.Forms.Button button_F2_New_Record;
        private System.Windows.Forms.Button button_F5_New_Patient;
        private System.Windows.Forms.Button buttonF3_Edit_Record;
        private System.Windows.Forms.Button button_F6_View_Record;
        private System.Windows.Forms.Button button_F4_Daily_Report;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_Search_Type;
        private System.Windows.Forms.Label label_Search_Type;
        private System.Windows.Forms.BindingNavigator BindingNavigate;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtCurrentPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel lblPageCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.Label label_Data_To;
        private System.Windows.Forms.RadioButton radioButton_Data_From;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_28;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_14;
        private System.Windows.Forms.RadioButton radioButton_Data_Past_7;
        private System.Windows.Forms.RadioButton radioButton_Data_All;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}