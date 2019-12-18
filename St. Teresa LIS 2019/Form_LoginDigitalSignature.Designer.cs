namespace St.Teresa_LIS_2019
{
    partial class Form_LoginDigitalSignature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LoginDigitalSignature));
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_Log_in_Digital_Signature = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_Dr = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Password
            // 
            this.textBox_Password.BackColor = System.Drawing.Color.White;
            this.textBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Password.ForeColor = System.Drawing.Color.Blue;
            this.textBox_Password.Location = new System.Drawing.Point(101, 70);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(145, 24);
            this.textBox_Password.TabIndex = 69;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Password.ForeColor = System.Drawing.Color.Black;
            this.label_Password.Location = new System.Drawing.Point(12, 73);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(83, 18);
            this.label_Password.TabIndex = 70;
            this.label_Password.Text = "Password";
            // 
            // label_Log_in_Digital_Signature
            // 
            this.label_Log_in_Digital_Signature.AutoSize = true;
            this.label_Log_in_Digital_Signature.BackColor = System.Drawing.Color.Transparent;
            this.label_Log_in_Digital_Signature.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Log_in_Digital_Signature.ForeColor = System.Drawing.Color.Blue;
            this.label_Log_in_Digital_Signature.Location = new System.Drawing.Point(69, 22);
            this.label_Log_in_Digital_Signature.Name = "label_Log_in_Digital_Signature";
            this.label_Log_in_Digital_Signature.Size = new System.Drawing.Size(227, 24);
            this.label_Log_in_Digital_Signature.TabIndex = 71;
            this.label_Log_in_Digital_Signature.Text = "Log-in Digital Signature";
            // 
            // button_Login
            // 
            this.button_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Login.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.button_Login.Image = ((System.Drawing.Image)(resources.GetObject("button_Login.Image")));
            this.button_Login.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Login.Location = new System.Drawing.Point(264, 82);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(84, 44);
            this.button_Login.TabIndex = 240;
            this.button_Login.Text = "Login";
            this.button_Login.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(203)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.comboBox_Dr);
            this.panel1.Controls.Add(this.textBox_Password);
            this.panel1.Controls.Add(this.label_Log_in_Digital_Signature);
            this.panel1.Controls.Add(this.label_Password);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 209);
            this.panel1.TabIndex = 243;
            // 
            // comboBox_Dr
            // 
            this.comboBox_Dr.DisplayMember = "DOCTOR";
            this.comboBox_Dr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Dr.ForeColor = System.Drawing.Color.Blue;
            this.comboBox_Dr.FormattingEnabled = true;
            this.comboBox_Dr.Items.AddRange(new object[] {
            "Please select a doctor"});
            this.comboBox_Dr.Location = new System.Drawing.Point(15, 121);
            this.comboBox_Dr.Name = "comboBox_Dr";
            this.comboBox_Dr.Size = new System.Drawing.Size(231, 26);
            this.comboBox_Dr.TabIndex = 244;
            this.comboBox_Dr.Text = "Please select a doctor";
            this.comboBox_Dr.ValueMember = "DOCTOR";
            // 
            // Form_LoginDigitalSignature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(141)))), ((int)(((byte)(209)))));
            this.ClientSize = new System.Drawing.Size(385, 238);
            this.ControlBox = false;
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.panel1);
            this.Name = "Form_LoginDigitalSignature";
            this.Text = "Log in Digital Signature";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Log_in_Digital_Signature;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_Dr;
    }
}