﻿namespace St.Teresa_LIS_2019
{
    partial class Form_FindingComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FindingComments));
            this.label_Findings_and_Comnents = new System.Windows.Forms.Label();
            this.label_below = new System.Windows.Forms.Label();
            this.button_F8_Confirm_Exit = new System.Windows.Forms.Button();
            this.label_Add = new System.Windows.Forms.Label();
            this.comboBox_Add = new System.Windows.Forms.ComboBox();
            this.textBox_Gynecological_History = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Findings_and_Comnents
            // 
            this.label_Findings_and_Comnents.AutoSize = true;
            this.label_Findings_and_Comnents.BackColor = System.Drawing.Color.Transparent;
            this.label_Findings_and_Comnents.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.label_Findings_and_Comnents.ForeColor = System.Drawing.Color.Black;
            this.label_Findings_and_Comnents.Location = new System.Drawing.Point(12, 9);
            this.label_Findings_and_Comnents.Name = "label_Findings_and_Comnents";
            this.label_Findings_and_Comnents.Size = new System.Drawing.Size(232, 22);
            this.label_Findings_and_Comnents.TabIndex = 148;
            this.label_Findings_and_Comnents.Text = "Findings and Comnents :";
            // 
            // label_below
            // 
            this.label_below.AutoSize = true;
            this.label_below.BackColor = System.Drawing.Color.Transparent;
            this.label_below.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_below.ForeColor = System.Drawing.Color.Black;
            this.label_below.Location = new System.Drawing.Point(235, 14);
            this.label_below.Name = "label_below";
            this.label_below.Size = new System.Drawing.Size(393, 17);
            this.label_below.TabIndex = 271;
            this.label_below.Text = "(auto-generated from selections in template ; editing allowed)";
            // 
            // button_F8_Confirm_Exit
            // 
            this.button_F8_Confirm_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_F8_Confirm_Exit.ForeColor = System.Drawing.Color.DarkRed;
            this.button_F8_Confirm_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_F8_Confirm_Exit.Image")));
            this.button_F8_Confirm_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_F8_Confirm_Exit.Location = new System.Drawing.Point(298, 502);
            this.button_F8_Confirm_Exit.Name = "button_F8_Confirm_Exit";
            this.button_F8_Confirm_Exit.Size = new System.Drawing.Size(195, 48);
            this.button_F8_Confirm_Exit.TabIndex = 272;
            this.button_F8_Confirm_Exit.Text = "F8: Confirm Exit";
            this.button_F8_Confirm_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_F8_Confirm_Exit.UseVisualStyleBackColor = true;
            this.button_F8_Confirm_Exit.Click += new System.EventHandler(this.button_F8_Confirm_Exit_Click);
            // 
            // label_Add
            // 
            this.label_Add.AutoSize = true;
            this.label_Add.BackColor = System.Drawing.Color.Transparent;
            this.label_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_Add.ForeColor = System.Drawing.Color.Black;
            this.label_Add.Location = new System.Drawing.Point(23, 449);
            this.label_Add.Name = "label_Add";
            this.label_Add.Size = new System.Drawing.Size(33, 17);
            this.label_Add.TabIndex = 273;
            this.label_Add.Text = "Add";
            // 
            // comboBox_Add
            // 
            this.comboBox_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Add.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Add.FormattingEnabled = true;
            this.comboBox_Add.Location = new System.Drawing.Point(62, 444);
            this.comboBox_Add.Name = "comboBox_Add";
            this.comboBox_Add.Size = new System.Drawing.Size(568, 26);
            this.comboBox_Add.TabIndex = 274;
            // 
            // textBox_Gynecological_History
            // 
            this.textBox_Gynecological_History.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Gynecological_History.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Gynecological_History.Location = new System.Drawing.Point(16, 34);
            this.textBox_Gynecological_History.Multiline = true;
            this.textBox_Gynecological_History.Name = "textBox_Gynecological_History";
            this.textBox_Gynecological_History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Gynecological_History.Size = new System.Drawing.Size(756, 404);
            this.textBox_Gynecological_History.TabIndex = 295;
            // 
            // Form_FindingComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(187)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_Gynecological_History);
            this.Controls.Add(this.comboBox_Add);
            this.Controls.Add(this.label_Add);
            this.Controls.Add(this.button_F8_Confirm_Exit);
            this.Controls.Add(this.label_below);
            this.Controls.Add(this.label_Findings_and_Comnents);
            this.Name = "Form_FindingComments";
            this.Text = "Finding and Comments";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Findings_and_Comnents;
        private System.Windows.Forms.Label label_below;
        private System.Windows.Forms.Button button_F8_Confirm_Exit;
        private System.Windows.Forms.Label label_Add;
        private System.Windows.Forms.ComboBox comboBox_Add;
        private System.Windows.Forms.TextBox textBox_Gynecological_History;
    }
}