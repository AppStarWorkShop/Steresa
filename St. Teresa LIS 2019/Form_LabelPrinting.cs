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
    public partial class Form_LabelPrinting : Form
    {
        public Form_LabelPrinting()
        {
            InitializeComponent();
        }

        private void Form_LabelPrinting_Load(object sender, EventArgs e)
        {

        }

        private void button_X_Click(object sender, EventArgs e)
        {

        }

        private void button_Label_Formats_Click(object sender, EventArgs e)
        {
            Form_LabelSetting open = new Form_LabelSetting();
            open.Show();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
