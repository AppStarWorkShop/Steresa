namespace St.Teresa_LIS_2019
{
    partial class Form_ChangePicturePath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ChangePicturePath));
            this.textBox_Picture_Path = new System.Windows.Forms.TextBox();
            this.label_Picture_Path = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_by_person = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Picture_Path
            // 
            this.textBox_Picture_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Picture_Path.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox_Picture_Path.Location = new System.Drawing.Point(175, 66);
            this.textBox_Picture_Path.Name = "textBox_Picture_Path";
            this.textBox_Picture_Path.Size = new System.Drawing.Size(361, 29);
            this.textBox_Picture_Path.TabIndex = 196;
            this.textBox_Picture_Path.Text = "PHOTO\\Wed\\Mar-27\\";
            // 
            // label_Picture_Path
            // 
            this.label_Picture_Path.AutoSize = true;
            this.label_Picture_Path.BackColor = System.Drawing.Color.Transparent;
            this.label_Picture_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Picture_Path.ForeColor = System.Drawing.Color.DarkRed;
            this.label_Picture_Path.Location = new System.Drawing.Point(35, 69);
            this.label_Picture_Path.Name = "label_Picture_Path";
            this.label_Picture_Path.Size = new System.Drawing.Size(134, 24);
            this.label_Picture_Path.TabIndex = 195;
            this.label_Picture_Path.Text = "Picture Path :";
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Exit.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Exit.Image = ((System.Drawing.Image)(resources.GetObject("button_Exit.Image")));
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(346, 142);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(126, 42);
            this.button_Exit.TabIndex = 197;
            this.button_Exit.Text = "Exit";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Save.ForeColor = System.Drawing.Color.Black;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Save.Location = new System.Drawing.Point(138, 142);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(126, 42);
            this.button_Save.TabIndex = 198;
            this.button_Save.Text = "Save";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // label_by_person
            // 
            this.label_by_person.AutoSize = true;
            this.label_by_person.BackColor = System.Drawing.Color.Transparent;
            this.label_by_person.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_by_person.ForeColor = System.Drawing.Color.Green;
            this.label_by_person.Location = new System.Drawing.Point(36, 102);
            this.label_by_person.Name = "label_by_person";
            this.label_by_person.Size = new System.Drawing.Size(102, 17);
            this.label_by_person.TabIndex = 199;
            this.label_by_person.Text = "( by person )";
            // 
            // Form_ChangePicturePath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(584, 220);
            this.ControlBox = false;
            this.Controls.Add(this.label_by_person);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.textBox_Picture_Path);
            this.Controls.Add(this.label_Picture_Path);
            this.Name = "Form_ChangePicturePath";
            this.Text = "Change Picture Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Picture_Path;
        private System.Windows.Forms.Label label_Picture_Path;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_by_person;
    }
}