namespace St.Teresa_LIS_2019
{
    partial class Form_SurgicalProcedure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SurgicalProcedure));
            this.label_Surgical_Procedure = new System.Windows.Forms.Label();
            this.button_F8_Back_To_Main = new System.Windows.Forms.Button();
            this.textBox_Surgical_Procedure = new System.Windows.Forms.TextBox();
            this.comboBox_Surgical_Procedure = new System.Windows.Forms.ComboBox();
            this.label_Add = new System.Windows.Forms.Label();
            this.button_Add_Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Surgical_Procedure
            // 
            this.label_Surgical_Procedure.AutoSize = true;
            this.label_Surgical_Procedure.BackColor = System.Drawing.Color.Transparent;
            this.label_Surgical_Procedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Surgical_Procedure.ForeColor = System.Drawing.Color.Black;
            this.label_Surgical_Procedure.Location = new System.Drawing.Point(12, 6);
            this.label_Surgical_Procedure.Name = "label_Surgical_Procedure";
            this.label_Surgical_Procedure.Size = new System.Drawing.Size(162, 18);
            this.label_Surgical_Procedure.TabIndex = 183;
            this.label_Surgical_Procedure.Text = "Surgical Procedure :";
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
            this.button_F8_Back_To_Main.TabIndex = 185;
            this.button_F8_Back_To_Main.Text = "F8: Back To Main";
            this.button_F8_Back_To_Main.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_F8_Back_To_Main.UseVisualStyleBackColor = true;
            this.button_F8_Back_To_Main.Click += new System.EventHandler(this.button_F8_Back_To_Main_Click);
            // 
            // textBox_Surgical_Procedure
            // 
            this.textBox_Surgical_Procedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Surgical_Procedure.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Surgical_Procedure.Location = new System.Drawing.Point(15, 26);
            this.textBox_Surgical_Procedure.Multiline = true;
            this.textBox_Surgical_Procedure.Name = "textBox_Surgical_Procedure";
            this.textBox_Surgical_Procedure.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Surgical_Procedure.Size = new System.Drawing.Size(557, 170);
            this.textBox_Surgical_Procedure.TabIndex = 240;
            // 
            // comboBox_Surgical_Procedure
            // 
            this.comboBox_Surgical_Procedure.DisplayMember = "SurgicalProcedureVal";
            this.comboBox_Surgical_Procedure.DropDownWidth = 300;
            this.comboBox_Surgical_Procedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Surgical_Procedure.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Surgical_Procedure.FormattingEnabled = true;
            this.comboBox_Surgical_Procedure.Items.AddRange(new object[] {
            "OGD and biopsy.",
            "OGD and polypectomy.",
            "OGD and polypectomy.",
            "OGD, biopsy and polypectomy.",
            "OGD, biopsies and polypectomy.",
            "Colonoscopy and biosy.",
            "Colonoscopy and polypectomy.",
            "Colonoscopy, biopsy and polypectomy.",
            "Colonoscopy, biopsies and polypectomy."});
            this.comboBox_Surgical_Procedure.Location = new System.Drawing.Point(56, 200);
            this.comboBox_Surgical_Procedure.Name = "comboBox_Surgical_Procedure";
            this.comboBox_Surgical_Procedure.Size = new System.Drawing.Size(436, 26);
            this.comboBox_Surgical_Procedure.TabIndex = 242;
            this.comboBox_Surgical_Procedure.ValueMember = "Description";
            this.comboBox_Surgical_Procedure.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Surgical_Procedure_SelectionChangeCommitted);
            this.comboBox_Surgical_Procedure.TextChanged += new System.EventHandler(this.comboBox_Surgical_Procedure_TextChanged);
            this.comboBox_Surgical_Procedure.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBox_Surgical_Procedure_PreviewKeyDown);
            // 
            // label_Add
            // 
            this.label_Add.AutoSize = true;
            this.label_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Add.Location = new System.Drawing.Point(9, 205);
            this.label_Add.Name = "label_Add";
            this.label_Add.Size = new System.Drawing.Size(41, 17);
            this.label_Add.TabIndex = 243;
            this.label_Add.Text = "Add :";
            // 
            // button_Add_Edit
            // 
            this.button_Add_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Add_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Add_Edit.Location = new System.Drawing.Point(498, 201);
            this.button_Add_Edit.Name = "button_Add_Edit";
            this.button_Add_Edit.Size = new System.Drawing.Size(71, 22);
            this.button_Add_Edit.TabIndex = 244;
            this.button_Add_Edit.Text = "Edit";
            this.button_Add_Edit.UseVisualStyleBackColor = true;
            this.button_Add_Edit.Click += new System.EventHandler(this.button_Add_Edit_Click);
            // 
            // Form_SurgicalProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(226)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(584, 270);
            this.ControlBox = false;
            this.Controls.Add(this.button_Add_Edit);
            this.Controls.Add(this.label_Add);
            this.Controls.Add(this.comboBox_Surgical_Procedure);
            this.Controls.Add(this.textBox_Surgical_Procedure);
            this.Controls.Add(this.button_F8_Back_To_Main);
            this.Controls.Add(this.label_Surgical_Procedure);
            this.Name = "Form_SurgicalProcedure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Surgical_Procedure;
        private System.Windows.Forms.Button button_F8_Back_To_Main;
        private System.Windows.Forms.TextBox textBox_Surgical_Procedure;
        private System.Windows.Forms.ComboBox comboBox_Surgical_Procedure;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.Button button_Add_Edit;
    }
}