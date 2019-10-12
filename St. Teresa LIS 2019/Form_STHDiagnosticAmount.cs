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
    public partial class Form_STHDiagnosticAmount : Form
    {
        public delegate void STHChanged(string STH_CY, string STH_CYG, string STH_EBV);
        public STHChanged OnSTHChanged;

        public Form_STHDiagnosticAmount()
        {
            InitializeComponent();

        }

        public Form_STHDiagnosticAmount(string STH_CY, string STH_CYG, string STH_EBV)
        {
            InitializeComponent();
            textBox_CY.Text = STH_CY;
            textBox_CYG.Text = STH_CYG;
            textBox_EBV.Text = STH_EBV;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            if(OnSTHChanged != null)
            {
                OnSTHChanged(textBox_CY.Text.Trim(), textBox_CYG.Text.Trim(), textBox_EBV.Text.Trim());
                this.Close();
            }
        }
    }
}
