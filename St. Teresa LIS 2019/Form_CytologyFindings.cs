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
    public partial class Form_CytologyFindings : Form
    {
        public Form_CytologyFindings()
        {
            InitializeComponent();
        }

        private void button_Back_To_Main_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Cobas_4800_System_Click(object sender, EventArgs e)
        {
            Form_Cobas4800System open = new Form_Cobas4800System();
            open.Show();
        }
    }
}
