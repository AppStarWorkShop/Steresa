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
    public partial class Form_BXeHRCCSPFile : Form
    {
        public Form_BXeHRCCSPFile()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F5_Description_Click(object sender, EventArgs e)
        {
            Form_DescriptionBXeHRCCSP open = new Form_DescriptionBXeHRCCSP();
            open.Show();
        }
    }
}
