namespace St.Teresa_LIS_2019
{
    partial class Form_NatureOfSpecimen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NatureOfSpecimen));
            this.button_F8_Back_To_Main = new System.Windows.Forms.Button();
            this.label_Nature_Of_Specimen = new System.Windows.Forms.Label();
            this.textBox_Nature_Of_Specimen = new System.Windows.Forms.TextBox();
            this.button_Add_Edit = new System.Windows.Forms.Button();
            this.label_Add = new System.Windows.Forms.Label();
            this.comboBox_Nature_Of_Specimen = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_F8_Back_To_Main
            // 
            this.button_F8_Back_To_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F8_Back_To_Main.ForeColor = System.Drawing.Color.Black;
            this.button_F8_Back_To_Main.Image = ((System.Drawing.Image)(resources.GetObject("button_F8_Back_To_Main.Image")));
            this.button_F8_Back_To_Main.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_F8_Back_To_Main.Location = new System.Drawing.Point(220, 230);
            this.button_F8_Back_To_Main.Name = "button_F8_Back_To_Main";
            this.button_F8_Back_To_Main.Size = new System.Drawing.Size(134, 34);
            this.button_F8_Back_To_Main.TabIndex = 188;
            this.button_F8_Back_To_Main.Text = "F8: Back To Main";
            this.button_F8_Back_To_Main.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_F8_Back_To_Main.UseVisualStyleBackColor = true;
            this.button_F8_Back_To_Main.Click += new System.EventHandler(this.button_F8_Back_To_Main_Click);
            // 
            // label_Nature_Of_Specimen
            // 
            this.label_Nature_Of_Specimen.AutoSize = true;
            this.label_Nature_Of_Specimen.BackColor = System.Drawing.Color.Transparent;
            this.label_Nature_Of_Specimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nature_Of_Specimen.ForeColor = System.Drawing.Color.Black;
            this.label_Nature_Of_Specimen.Location = new System.Drawing.Point(12, 6);
            this.label_Nature_Of_Specimen.Name = "label_Nature_Of_Specimen";
            this.label_Nature_Of_Specimen.Size = new System.Drawing.Size(170, 18);
            this.label_Nature_Of_Specimen.TabIndex = 186;
            this.label_Nature_Of_Specimen.Text = "Nature Of Specimen :";
            // 
            // textBox_Nature_Of_Specimen
            // 
            this.textBox_Nature_Of_Specimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Nature_Of_Specimen.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Nature_Of_Specimen.Location = new System.Drawing.Point(15, 26);
            this.textBox_Nature_Of_Specimen.Multiline = true;
            this.textBox_Nature_Of_Specimen.Name = "textBox_Nature_Of_Specimen";
            this.textBox_Nature_Of_Specimen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Nature_Of_Specimen.Size = new System.Drawing.Size(557, 170);
            this.textBox_Nature_Of_Specimen.TabIndex = 240;
            // 
            // button_Add_Edit
            // 
            this.button_Add_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Add_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Add_Edit.Location = new System.Drawing.Point(498, 201);
            this.button_Add_Edit.Name = "button_Add_Edit";
            this.button_Add_Edit.Size = new System.Drawing.Size(71, 22);
            this.button_Add_Edit.TabIndex = 247;
            this.button_Add_Edit.Text = "Edit";
            this.button_Add_Edit.UseVisualStyleBackColor = true;
            this.button_Add_Edit.Click += new System.EventHandler(this.button_Add_Edit_Click);
            // 
            // label_Add
            // 
            this.label_Add.AutoSize = true;
            this.label_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Add.Location = new System.Drawing.Point(9, 205);
            this.label_Add.Name = "label_Add";
            this.label_Add.Size = new System.Drawing.Size(41, 17);
            this.label_Add.TabIndex = 246;
            this.label_Add.Text = "Add :";
            // 
            // comboBox_Nature_Of_Specimen
            // 
            this.comboBox_Nature_Of_Specimen.DisplayMember = "SurgicalProcedureVal";
            this.comboBox_Nature_Of_Specimen.DropDownWidth = 300;
            this.comboBox_Nature_Of_Specimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Nature_Of_Specimen.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Nature_Of_Specimen.FormattingEnabled = true;
            this.comboBox_Nature_Of_Specimen.Items.AddRange(new object[] {
            "Gastric biopsy.",
            "Gastric polyp.",
            "1) Gastric biopsy. 2) Gastric polyp.",
            "Colonic biopsy.",
            "Colonic polyp.",
            "Colonic polypi."});
            this.comboBox_Nature_Of_Specimen.Location = new System.Drawing.Point(56, 200);
            this.comboBox_Nature_Of_Specimen.Name = "comboBox_Nature_Of_Specimen";
            this.comboBox_Nature_Of_Specimen.Size = new System.Drawing.Size(436, 26);
            this.comboBox_Nature_Of_Specimen.TabIndex = 249;
            this.comboBox_Nature_Of_Specimen.ValueMember = "SurgicalProcedureVal";
            this.comboBox_Nature_Of_Specimen.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Nature_Of_Specimen_SelectionChangeCommitted);
            // 
            // Form_NatureOfSpecimen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(188)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(584, 273);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_Nature_Of_Specimen);
            this.Controls.Add(this.button_Add_Edit);
            this.Controls.Add(this.label_Add);
            this.Controls.Add(this.textBox_Nature_Of_Specimen);
            this.Controls.Add(this.button_F8_Back_To_Main);
            this.Controls.Add(this.label_Nature_Of_Specimen);
            this.Name = "Form_NatureOfSpecimen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_F8_Back_To_Main;
        private System.Windows.Forms.Label label_Nature_Of_Specimen;
        private System.Windows.Forms.TextBox textBox_Nature_Of_Specimen;
        private System.Windows.Forms.Button button_Add_Edit;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.ComboBox comboBox_Nature_Of_Specimen;
    }
}