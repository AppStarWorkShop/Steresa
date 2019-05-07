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
    public partial class Form_EBVFile : Form
    {
        public Form_EBVFile()
        {
            InitializeComponent();
        }

        private void button_F_S_Detail_Click(object sender, EventArgs e)
        {
            Form_EBVDiagnosisFileMaintenance open = new Form_EBVDiagnosisFileMaintenance();
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
