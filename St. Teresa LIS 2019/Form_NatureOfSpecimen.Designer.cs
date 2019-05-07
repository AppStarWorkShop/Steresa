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
            this.SuspendLayout();
            // 
            // button_F8_Back_To_Main
            // 
            this.button_F8_Back_To_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_F8_Back_To_Main.ForeColor = System.Drawing.Color.Black;
            this.button_F8_Back_To_Main.Image = ((System.Drawing.Image)(resources.GetObject("button_F8_Back_To_Main.Image")));
            this.button_F8_Back_To_Main.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_F8_Back_To_Main.Location = new System.Drawing.Point(223, 218);
            this.button_F8_Back_To_Main.Name = "button_F8_Back_To_Main";
            this.button_F8_Back_To_Main.Size = new System.Drawing.Size(134, 37);
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
            this.label_Nature_Of_Specimen.Location = new System.Drawing.Point(12, 7);
            this.label_Nature_Of_Specimen.Name = "label_Nature_Of_Specimen";
            this.label_Nature_Of_Specimen.Size = new System.Drawing.Size(170, 18);
            this.label_Nature_Of_Specimen.TabIndex = 186;
            this.label_Nature_Of_Specimen.Text = "Nature Of Specimen :";
            // 
            // textBox_Nature_Of_Specimen
            // 
            this.textBox_Nature_Of_Specimen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Nature_Of_Specimen.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Nature_Of_Specimen.Location = new System.Drawing.Point(15, 28);
            this.textBox_Nature_Of_Specimen.Multiline = true;
            this.textBox_Nature_Of_Specimen.Name = "textBox_Nature_Of_Specimen";
            this.textBox_Nature_Of_Specimen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Nature_Of_Specimen.Size = new System.Drawing.Size(557, 184);
            this.textBox_Nature_Of_Specimen.TabIndex = 240;
            // 
            // Form_NatureOfSpecimen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(188)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.ControlBox = false;
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
    }
}