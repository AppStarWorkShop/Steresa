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
	//testing commit here
    public partial class Form_AdditionalTests : Form
    {
        public delegate void valueUpdated(string er, string em, string sish);
        public valueUpdated OnValueUpdated;

        public Form_AdditionalTests()
        {
            InitializeComponent();
        }

        public Form_AdditionalTests(string er, string em, string sish)
        {
            InitializeComponent();
            textBox_ER.Text = er.Trim();
            textBox_EM.Text = em.Trim();
            textBox_SISH.Text = sish.Trim();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            if(OnValueUpdated != null)
            {
                OnValueUpdated(textBox_ER.Text.Trim(), textBox_EM.Text.Trim(), textBox_SISH.Text.Trim());
            }
            this.Close();
        }
    }
}
