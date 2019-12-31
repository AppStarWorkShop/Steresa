namespace St.Teresa_LIS_2019
{
    partial class Form_FeeCalculationSTH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FeeCalculationSTH));
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.label_Code = new System.Windows.Forms.Label();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.label_Class = new System.Windows.Forms.Label();
            this.label_Fee_Calculation_STH = new System.Windows.Forms.Label();
            this.comboBox_Code_1 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_1 = new System.Windows.Forms.TextBox();
            this.textBox_Price_2 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_2 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_3 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_3 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_4 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_4 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_5 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_5 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_10 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_10 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_9 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_9 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_8 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_8 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_7 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_7 = new System.Windows.Forms.ComboBox();
            this.textBox_Price_6 = new System.Windows.Forms.TextBox();
            this.comboBox_Code_6 = new System.Windows.Forms.ComboBox();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            this.label_Price = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.textBox_Other = new System.Windows.Forms.TextBox();
            this.label_Other = new System.Windows.Forms.Label();
            this.label_Line_2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Cancel.ForeColor = System.Drawing.Color.Red;
            this.button_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("button_Cancel.Image")));
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Cancel.Location = new System.Drawing.Point(165, 580);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(112, 51);
            this.button_Cancel.TabIndex = 71;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Confirm
            // 
            this.button_Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Confirm.ForeColor = System.Drawing.Color.Blue;
            this.button_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("button_Confirm.Image")));
            this.button_Confirm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Confirm.Location = new System.Drawing.Point(16, 580);
            this.button_Confirm.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(112, 51);
            this.button_Confirm.TabIndex = 70;
            this.button_Confirm.Text = "Confirm";
            this.button_Confirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // label_Code
            // 
            this.label_Code.AutoSize = true;
            this.label_Code.BackColor = System.Drawing.Color.Transparent;
            this.label_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Code.ForeColor = System.Drawing.Color.Black;
            this.label_Code.Location = new System.Drawing.Point(16, 88);
            this.label_Code.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Code.Name = "label_Code";
            this.label_Code.Size = new System.Drawing.Size(77, 25);
            this.label_Code.TabIndex = 68;
            this.label_Code.Text = "Code :";
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.DisplayMember = "className";
            this.comboBox_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Class.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Items.AddRange(new object[] {
            "Class 1",
            "Class 2",
            "Class 3",
            "Class 4"});
            this.comboBox_Class.Location = new System.Drawing.Point(107, 47);
            this.comboBox_Class.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(169, 30);
            this.comboBox_Class.TabIndex = 198;
            this.comboBox_Class.ValueMember = "classId";
            this.comboBox_Class.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Class_SelectionChangeCommitted);
            // 
            // label_Class
            // 
            this.label_Class.AutoSize = true;
            this.label_Class.BackColor = System.Drawing.Color.Transparent;
            this.label_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Class.ForeColor = System.Drawing.Color.Black;
            this.label_Class.Location = new System.Drawing.Point(17, 51);
            this.label_Class.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Class.Name = "label_Class";
            this.label_Class.Size = new System.Drawing.Size(72, 24);
            this.label_Class.TabIndex = 197;
            this.label_Class.Text = "Class :";
            // 
            // label_Fee_Calculation_STH
            // 
            this.label_Fee_Calculation_STH.AutoSize = true;
            this.label_Fee_Calculation_STH.BackColor = System.Drawing.Color.Transparent;
            this.label_Fee_Calculation_STH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Fee_Calculation_STH.ForeColor = System.Drawing.Color.Blue;
            this.label_Fee_Calculation_STH.Location = new System.Drawing.Point(16, 10);
            this.label_Fee_Calculation_STH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Fee_Calculation_STH.Name = "label_Fee_Calculation_STH";
            this.label_Fee_Calculation_STH.Size = new System.Drawing.Size(255, 29);
            this.label_Fee_Calculation_STH.TabIndex = 67;
            this.label_Fee_Calculation_STH.Text = "Fee Calculation STH";
            // 
            // comboBox_Code_1
            // 
            this.comboBox_Code_1.DisplayMember = "code";
            this.comboBox_Code_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_1.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_1.FormattingEnabled = true;
            this.comboBox_Code_1.Location = new System.Drawing.Point(16, 113);
            this.comboBox_Code_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_1.Name = "comboBox_Code_1";
            this.comboBox_Code_1.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_1.TabIndex = 199;
            this.comboBox_Code_1.ValueMember = "codeId";
            this.comboBox_Code_1.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_1_SelectionChangeCommitted);
            // 
            // textBox_Price_1
            // 
            this.textBox_Price_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_1.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_1.Location = new System.Drawing.Point(151, 115);
            this.textBox_Price_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_1.Name = "textBox_Price_1";
            this.textBox_Price_1.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_1.TabIndex = 209;
            this.textBox_Price_1.Text = "0";
            this.textBox_Price_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_1.TextChanged += new System.EventHandler(this.textBox_Price_1_TextChanged);
            this.textBox_Price_1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_1_PreviewKeyDown);
            // 
            // textBox_Price_2
            // 
            this.textBox_Price_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_2.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_2.Location = new System.Drawing.Point(151, 150);
            this.textBox_Price_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_2.Name = "textBox_Price_2";
            this.textBox_Price_2.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_2.TabIndex = 211;
            this.textBox_Price_2.Text = "0";
            this.textBox_Price_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_2.TextChanged += new System.EventHandler(this.textBox_Price_2_TextChanged);
            this.textBox_Price_2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_2_PreviewKeyDown);
            // 
            // comboBox_Code_2
            // 
            this.comboBox_Code_2.DisplayMember = "code";
            this.comboBox_Code_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_2.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_2.FormattingEnabled = true;
            this.comboBox_Code_2.Location = new System.Drawing.Point(16, 148);
            this.comboBox_Code_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_2.Name = "comboBox_Code_2";
            this.comboBox_Code_2.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_2.TabIndex = 210;
            this.comboBox_Code_2.ValueMember = "codeId";
            this.comboBox_Code_2.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_2_SelectionChangeCommitted);
            // 
            // textBox_Price_3
            // 
            this.textBox_Price_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_3.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_3.Location = new System.Drawing.Point(151, 185);
            this.textBox_Price_3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_3.Name = "textBox_Price_3";
            this.textBox_Price_3.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_3.TabIndex = 213;
            this.textBox_Price_3.Text = "0";
            this.textBox_Price_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_3.TextChanged += new System.EventHandler(this.textBox_Price_3_TextChanged);
            this.textBox_Price_3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_3_PreviewKeyDown);
            // 
            // comboBox_Code_3
            // 
            this.comboBox_Code_3.DisplayMember = "code";
            this.comboBox_Code_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_3.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_3.FormattingEnabled = true;
            this.comboBox_Code_3.Location = new System.Drawing.Point(16, 182);
            this.comboBox_Code_3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_3.Name = "comboBox_Code_3";
            this.comboBox_Code_3.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_3.TabIndex = 212;
            this.comboBox_Code_3.ValueMember = "codeId";
            this.comboBox_Code_3.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_3_SelectionChangeCommitted);
            // 
            // textBox_Price_4
            // 
            this.textBox_Price_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_4.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_4.Location = new System.Drawing.Point(151, 219);
            this.textBox_Price_4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_4.Name = "textBox_Price_4";
            this.textBox_Price_4.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_4.TabIndex = 215;
            this.textBox_Price_4.Text = "0";
            this.textBox_Price_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_4.TextChanged += new System.EventHandler(this.textBox_Price_4_TextChanged);
            this.textBox_Price_4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_4_PreviewKeyDown);
            // 
            // comboBox_Code_4
            // 
            this.comboBox_Code_4.DisplayMember = "code";
            this.comboBox_Code_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_4.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_4.FormattingEnabled = true;
            this.comboBox_Code_4.Location = new System.Drawing.Point(16, 217);
            this.comboBox_Code_4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_4.Name = "comboBox_Code_4";
            this.comboBox_Code_4.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_4.TabIndex = 214;
            this.comboBox_Code_4.ValueMember = "codeId";
            this.comboBox_Code_4.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_4_SelectionChangeCommitted);
            // 
            // textBox_Price_5
            // 
            this.textBox_Price_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_5.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_5.Location = new System.Drawing.Point(151, 254);
            this.textBox_Price_5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_5.Name = "textBox_Price_5";
            this.textBox_Price_5.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_5.TabIndex = 217;
            this.textBox_Price_5.Text = "0";
            this.textBox_Price_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_5.TextChanged += new System.EventHandler(this.textBox_Price_5_TextChanged);
            this.textBox_Price_5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_5_PreviewKeyDown);
            // 
            // comboBox_Code_5
            // 
            this.comboBox_Code_5.DisplayMember = "code";
            this.comboBox_Code_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_5.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_5.FormattingEnabled = true;
            this.comboBox_Code_5.Location = new System.Drawing.Point(16, 252);
            this.comboBox_Code_5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_5.Name = "comboBox_Code_5";
            this.comboBox_Code_5.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_5.TabIndex = 216;
            this.comboBox_Code_5.ValueMember = "codeId";
            this.comboBox_Code_5.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_5_SelectionChangeCommitted);
            // 
            // textBox_Price_10
            // 
            this.textBox_Price_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_10.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_10.Location = new System.Drawing.Point(151, 427);
            this.textBox_Price_10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_10.Name = "textBox_Price_10";
            this.textBox_Price_10.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_10.TabIndex = 227;
            this.textBox_Price_10.Text = "0";
            this.textBox_Price_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_10.TextChanged += new System.EventHandler(this.textBox_Price_10_TextChanged);
            this.textBox_Price_10.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_10_PreviewKeyDown);
            // 
            // comboBox_Code_10
            // 
            this.comboBox_Code_10.DisplayMember = "code";
            this.comboBox_Code_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_10.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_10.FormattingEnabled = true;
            this.comboBox_Code_10.Location = new System.Drawing.Point(16, 425);
            this.comboBox_Code_10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_10.Name = "comboBox_Code_10";
            this.comboBox_Code_10.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_10.TabIndex = 226;
            this.comboBox_Code_10.ValueMember = "codeId";
            this.comboBox_Code_10.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_10_SelectionChangeCommitted);
            // 
            // textBox_Price_9
            // 
            this.textBox_Price_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_9.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_9.Location = new System.Drawing.Point(151, 392);
            this.textBox_Price_9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_9.Name = "textBox_Price_9";
            this.textBox_Price_9.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_9.TabIndex = 225;
            this.textBox_Price_9.Text = "0";
            this.textBox_Price_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_9.TextChanged += new System.EventHandler(this.textBox_Price_9_TextChanged);
            this.textBox_Price_9.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_9_PreviewKeyDown);
            // 
            // comboBox_Code_9
            // 
            this.comboBox_Code_9.DisplayMember = "code";
            this.comboBox_Code_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_9.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_9.FormattingEnabled = true;
            this.comboBox_Code_9.Location = new System.Drawing.Point(16, 390);
            this.comboBox_Code_9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_9.Name = "comboBox_Code_9";
            this.comboBox_Code_9.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_9.TabIndex = 224;
            this.comboBox_Code_9.ValueMember = "codeId";
            this.comboBox_Code_9.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_9_SelectionChangeCommitted);
            // 
            // textBox_Price_8
            // 
            this.textBox_Price_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_8.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_8.Location = new System.Drawing.Point(151, 358);
            this.textBox_Price_8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_8.Name = "textBox_Price_8";
            this.textBox_Price_8.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_8.TabIndex = 223;
            this.textBox_Price_8.Text = "0";
            this.textBox_Price_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_8.TextChanged += new System.EventHandler(this.textBox_Price_8_TextChanged);
            this.textBox_Price_8.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_8_PreviewKeyDown);
            // 
            // comboBox_Code_8
            // 
            this.comboBox_Code_8.DisplayMember = "code";
            this.comboBox_Code_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_8.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_8.FormattingEnabled = true;
            this.comboBox_Code_8.Location = new System.Drawing.Point(16, 355);
            this.comboBox_Code_8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_8.Name = "comboBox_Code_8";
            this.comboBox_Code_8.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_8.TabIndex = 222;
            this.comboBox_Code_8.ValueMember = "codeId";
            this.comboBox_Code_8.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_8_SelectionChangeCommitted);
            // 
            // textBox_Price_7
            // 
            this.textBox_Price_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_7.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_7.Location = new System.Drawing.Point(151, 323);
            this.textBox_Price_7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_7.Name = "textBox_Price_7";
            this.textBox_Price_7.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_7.TabIndex = 221;
            this.textBox_Price_7.Text = "0";
            this.textBox_Price_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_7.TextChanged += new System.EventHandler(this.textBox_Price_7_TextChanged);
            this.textBox_Price_7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_7_PreviewKeyDown);
            // 
            // comboBox_Code_7
            // 
            this.comboBox_Code_7.DisplayMember = "code";
            this.comboBox_Code_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_7.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_7.FormattingEnabled = true;
            this.comboBox_Code_7.Location = new System.Drawing.Point(16, 321);
            this.comboBox_Code_7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_7.Name = "comboBox_Code_7";
            this.comboBox_Code_7.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_7.TabIndex = 220;
            this.comboBox_Code_7.ValueMember = "codeId";
            this.comboBox_Code_7.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_7_SelectionChangeCommitted);
            // 
            // textBox_Price_6
            // 
            this.textBox_Price_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Price_6.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Price_6.Location = new System.Drawing.Point(151, 288);
            this.textBox_Price_6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Price_6.Name = "textBox_Price_6";
            this.textBox_Price_6.Size = new System.Drawing.Size(125, 28);
            this.textBox_Price_6.TabIndex = 219;
            this.textBox_Price_6.Text = "0";
            this.textBox_Price_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Price_6.TextChanged += new System.EventHandler(this.textBox_Price_6_TextChanged);
            this.textBox_Price_6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_Price_6_PreviewKeyDown);
            // 
            // comboBox_Code_6
            // 
            this.comboBox_Code_6.DisplayMember = "code";
            this.comboBox_Code_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Code_6.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Code_6.FormattingEnabled = true;
            this.comboBox_Code_6.Location = new System.Drawing.Point(16, 286);
            this.comboBox_Code_6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_Code_6.Name = "comboBox_Code_6";
            this.comboBox_Code_6.Size = new System.Drawing.Size(125, 30);
            this.comboBox_Code_6.TabIndex = 218;
            this.comboBox_Code_6.ValueMember = "codeId";
            this.comboBox_Code_6.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Code_6_SelectionChangeCommitted);
            // 
            // textBox_Total
            // 
            this.textBox_Total.Enabled = false;
            this.textBox_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Total.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Total.Location = new System.Drawing.Point(151, 532);
            this.textBox_Total.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.ReadOnly = true;
            this.textBox_Total.Size = new System.Drawing.Size(125, 28);
            this.textBox_Total.TabIndex = 228;
            this.textBox_Total.Text = "0";
            this.textBox_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_Price
            // 
            this.label_Price.AutoSize = true;
            this.label_Price.BackColor = System.Drawing.Color.Transparent;
            this.label_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Price.ForeColor = System.Drawing.Color.Black;
            this.label_Price.Location = new System.Drawing.Point(145, 88);
            this.label_Price.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Price.Name = "label_Price";
            this.label_Price.Size = new System.Drawing.Size(74, 25);
            this.label_Price.TabIndex = 229;
            this.label_Price.Text = "Price :";
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.BackColor = System.Drawing.Color.Transparent;
            this.label_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Total.ForeColor = System.Drawing.Color.Black;
            this.label_Total.Location = new System.Drawing.Point(23, 532);
            this.label_Total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(74, 25);
            this.label_Total.TabIndex = 230;
            this.label_Total.Text = "Total :";
            // 
            // textBox_Other
            // 
            this.textBox_Other.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Other.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Other.Location = new System.Drawing.Point(151, 474);
            this.textBox_Other.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_Other.Name = "textBox_Other";
            this.textBox_Other.Size = new System.Drawing.Size(125, 28);
            this.textBox_Other.TabIndex = 231;
            this.textBox_Other.Text = "0";
            this.textBox_Other.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Other.TextChanged += new System.EventHandler(this.textBox_Other_TextChanged);
            // 
            // label_Other
            // 
            this.label_Other.AutoSize = true;
            this.label_Other.BackColor = System.Drawing.Color.Transparent;
            this.label_Other.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Other.ForeColor = System.Drawing.Color.Black;
            this.label_Other.Location = new System.Drawing.Point(16, 479);
            this.label_Other.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Other.Name = "label_Other";
            this.label_Other.Size = new System.Drawing.Size(79, 25);
            this.label_Other.TabIndex = 232;
            this.label_Other.Text = "Other :";
            // 
            // label_Line_2
            // 
            this.label_Line_2.AutoSize = true;
            this.label_Line_2.BackColor = System.Drawing.Color.Transparent;
            this.label_Line_2.Font = new System.Drawing.Font("Palace Script MT", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Line_2.ForeColor = System.Drawing.Color.Gray;
            this.label_Line_2.Location = new System.Drawing.Point(-324, 472);
            this.label_Line_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Line_2.Name = "label_Line_2";
            this.label_Line_2.Size = new System.Drawing.Size(982, 50);
            this.label_Line_2.TabIndex = 233;
            this.label_Line_2.Text = "________________________________________";
            // 
            // Form_FeeCalculationSTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(190)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(293, 660);
            this.ControlBox = false;
            this.Controls.Add(this.label_Other);
            this.Controls.Add(this.textBox_Other);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.label_Price);
            this.Controls.Add(this.textBox_Total);
            this.Controls.Add(this.textBox_Price_10);
            this.Controls.Add(this.comboBox_Code_10);
            this.Controls.Add(this.textBox_Price_9);
            this.Controls.Add(this.comboBox_Code_9);
            this.Controls.Add(this.textBox_Price_8);
            this.Controls.Add(this.comboBox_Code_8);
            this.Controls.Add(this.textBox_Price_7);
            this.Controls.Add(this.comboBox_Code_7);
            this.Controls.Add(this.textBox_Price_6);
            this.Controls.Add(this.comboBox_Code_6);
            this.Controls.Add(this.textBox_Price_5);
            this.Controls.Add(this.comboBox_Code_5);
            this.Controls.Add(this.textBox_Price_4);
            this.Controls.Add(this.comboBox_Code_4);
            this.Controls.Add(this.textBox_Price_3);
            this.Controls.Add(this.comboBox_Code_3);
            this.Controls.Add(this.textBox_Price_2);
            this.Controls.Add(this.comboBox_Code_2);
            this.Controls.Add(this.textBox_Price_1);
            this.Controls.Add(this.comboBox_Code_1);
            this.Controls.Add(this.comboBox_Class);
            this.Controls.Add(this.label_Class);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.label_Code);
            this.Controls.Add(this.label_Fee_Calculation_STH);
            this.Controls.Add(this.label_Line_2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Location = new System.Drawing.Point(300, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form_FeeCalculationSTH";
            this.Text = "Fee Calculation STH";
            this.Load += new System.EventHandler(this.Form_FeeCalculationSTH_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Label label_Code;
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.Label label_Class;
        private System.Windows.Forms.Label label_Fee_Calculation_STH;
        private System.Windows.Forms.ComboBox comboBox_Code_1;
        private System.Windows.Forms.TextBox textBox_Price_1;
        private System.Windows.Forms.TextBox textBox_Price_2;
        private System.Windows.Forms.ComboBox comboBox_Code_2;
        private System.Windows.Forms.TextBox textBox_Price_3;
        private System.Windows.Forms.ComboBox comboBox_Code_3;
        private System.Windows.Forms.TextBox textBox_Price_4;
        private System.Windows.Forms.ComboBox comboBox_Code_4;
        private System.Windows.Forms.TextBox textBox_Price_5;
        private System.Windows.Forms.ComboBox comboBox_Code_5;
        private System.Windows.Forms.TextBox textBox_Price_10;
        private System.Windows.Forms.ComboBox comboBox_Code_10;
        private System.Windows.Forms.TextBox textBox_Price_9;
        private System.Windows.Forms.ComboBox comboBox_Code_9;
        private System.Windows.Forms.TextBox textBox_Price_8;
        private System.Windows.Forms.ComboBox comboBox_Code_8;
        private System.Windows.Forms.TextBox textBox_Price_7;
        private System.Windows.Forms.ComboBox comboBox_Code_7;
        private System.Windows.Forms.TextBox textBox_Price_6;
        private System.Windows.Forms.ComboBox comboBox_Code_6;
        private System.Windows.Forms.TextBox textBox_Total;
        private System.Windows.Forms.Label label_Price;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.TextBox textBox_Other;
        private System.Windows.Forms.Label label_Other;
        private System.Windows.Forms.Label label_Line_2;
    }
}