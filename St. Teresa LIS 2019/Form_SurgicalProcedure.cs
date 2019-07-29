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
    public partial class Form_SurgicalProcedure : Form
    {
        public delegate void SurgicalSelectedSingle(string str);
        public SurgicalSelectedSingle OnSurgicalSelectedSingle;

        public Form_SurgicalProcedure(string str)
        {
            InitializeComponent();
            textBox_Surgical_Procedure.Text = str;
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            if (OnSurgicalSelectedSingle != null)
            {
                OnSurgicalSelectedSingle(textBox_Surgical_Procedure.Text);
            }
            this.Close();
        }

        private void button_Add_Edit_Click(object sender, EventArgs e)
        {
            Form_SurgicalProcedureReportMaintenance open = new Form_SurgicalProcedureReportMaintenance();
            open.Show();
        }
    }
}
