namespace St.Teresa_LIS_2019
{
    partial class Form_FrozenSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FrozenSection));
            this.comboBox_Frozen_Section_Detail = new System.Windows.Forms.ComboBox();
            this.button_Add_Edit = new System.Windows.Forms.Button();
            this.label_Add = new System.Windows.Forms.Label();
            this.textBox_Frozen_Section_Detail = new System.Windows.Forms.TextBox();
            this.button_F8_Back_To_Main = new System.Windows.Forms.Button();
            this.label_Nature_Of_Specimen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_Frozen_Section_Detail
            // 
            this.comboBox_Frozen_Section_Detail.DisplayMember = "FZ_DETAIL";
            this.comboBox_Frozen_Section_Detail.DropDownWidth = 300;
            this.comboBox_Frozen_Section_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Frozen_Section_Detail.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Frozen_Section_Detail.FormattingEnabled = true;
            this.comboBox_Frozen_Section_Detail.Items.AddRange(new object[] {
            "Gastric biopsy.",
            "Gastric polyp.",
            "1) Gastric biopsy. 2) Gastric polyp.",
            "Colonic biopsy.",
            "Colonic polyp.",
            "Colonic polypi."});
            this.comboBox_Frozen_Section_Detail.Location = new System.Drawing.Point(71, 268);
            this.comboBox_Frozen_Section_Detail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_Frozen_Section_Detail.Name = "comboBox_Frozen_Section_Detail";
            this.comboBox_Frozen_Section_Detail.Size = new System.Drawing.Size(580, 30);
            this.comboBox_Frozen_Section_Detail.TabIndex = 255;
            this.comboBox_Frozen_Section_Detail.ValueMember = "FZ_DETAIL";
            this.comboBox_Frozen_Section_Detail.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Frozen_Section_Detail_SelectionChangeCommitted);
            this.comboBox_Frozen_Section_Detail.TextChanged += new System.EventHandler(this.comboBox_Frozen_Section_Detail_TextChanged);
            this.comboBox_Frozen_Section_Detail.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBox_Frozen_Section_Detail_PreviewKeyDown);
            // 
            // button_Add_Edit
            // 
            this.button_Add_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Add_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Add_Edit.Location = new System.Drawing.Point(660, 269);
            this.button_Add_Edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Add_Edit.Name = "button_Add_Edit";
            this.button_Add_Edit.Size = new System.Drawing.Size(95, 28);
            this.button_Add_Edit.TabIndex = 254;
            this.button_Add_Edit.Text = "Edit";
            this.button_Add_Edit.UseVisualStyleBackColor = true;
            this.button_Add_Edit.Click += new System.EventHandler(this.button_Add_Edit_Click);
            // 
            // label_Add
            // 
            this.label_Add.AutoSize = true;
            this.label_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Add.Location = new System.Drawing.Point(8, 274);
            this.label_Add.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Add.Name = "label_Add";
            this.label_Add.Size = new System.Drawing.Size(48, 20);
            this.label_Add.TabIndex = 253;
            this.label_Add.Text = "Add :";
            // 
            // textBox_Frozen_Section_Detail
            // 
            this.textBox_Frozen_Section_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Frozen_Section_Detail.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Frozen_Section_Detail.Location = new System.Drawing.Point(16, 50);
            this.textBox_Frozen_Section_Detail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_Frozen_Section_Detail.Multiline = true;
            this.textBox_Frozen_Section_Detail.Name = "textBox_Frozen_Section_Detail";
            this.textBox_Frozen_Section_Detail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Frozen_Section_Detail.Size = new System.Drawing.Size(741, 212);
            this.textBox_Frozen_Section_Detail.TabIndex = 252;
            // 
            // button_F8_Back_To_Main
            // 
            this.button_F8_Back_To_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F8_Back_To_Main.ForeColor = System.Drawing.Color.Black;
            this.button_F8_Back_To_Main.Image = ((System.Drawing.Image)(resources.GetObject("button_F8_Back_To_Main.Image")));
            this.button_F8_Back_To_Main.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_F8_Back_To_Main.Location = new System.Drawing.Point(289, 305);
            this.button_F8_Back_To_Main.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_F8_Back_To_Main.Name = "button_F8_Back_To_Main";
            this.button_F8_Back_To_Main.Size = new System.Drawing.Size(179, 42);
            this.button_F8_Back_To_Main.TabIndex = 251;
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
            this.label_Nature_Of_Specimen.Location = new System.Drawing.Point(12, 25);
            this.label_Nature_Of_Specimen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Nature_Of_Specimen.Name = "label_Nature_Of_Specimen";
            this.label_Nature_Of_Specimen.Size = new System.Drawing.Size(164, 24);
            this.label_Nature_Of_Specimen.TabIndex = 250;
            this.label_Nature_Of_Specimen.Text = "Frozen Section :";
            // 
            // Form_FrozenSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 355);
            this.Controls.Add(this.comboBox_Frozen_Section_Detail);
            this.Controls.Add(this.button_Add_Edit);
            this.Controls.Add(this.label_Add);
            this.Controls.Add(this.textBox_Frozen_Section_Detail);
            this.Controls.Add(this.button_F8_Back_To_Main);
            this.Controls.Add(this.label_Nature_Of_Specimen);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_FrozenSection";
            this.Text = "Form_FrozenSection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Frozen_Section_Detail;
        private System.Windows.Forms.Button button_Add_Edit;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.TextBox textBox_Frozen_Section_Detail;
        private System.Windows.Forms.Button button_F8_Back_To_Main;
        private System.Windows.Forms.Label label_Nature_Of_Specimen;
    }
}