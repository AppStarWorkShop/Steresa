using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace St.Teresa_LIS_2019
{
    public partial class Form_LoginDigitalSignature : Form
    {
        public Form_LoginDigitalSignature()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            Form_DigitalSignature open = new Form_DigitalSignature();
            open.Show();
            this.Close();
        }
    }
}
