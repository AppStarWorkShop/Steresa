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
    public partial class Form_InvoiceAndOtherReportMenu : Form
    {
        public Form_InvoiceAndOtherReportMenu()
        {
            InitializeComponent();
        }

        private void button_1_Invoice_Payment_Click(object sender, EventArgs e)
        {
            Form_InvoicePayment open = new Form_InvoicePayment();
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_2_Payment_For_STH_Click(object sender, EventArgs e)
        {
            Form_InvoicePaymentForSTHCases open = new Form_InvoicePaymentForSTHCases();
            open.Show();
        }

        private void button_3_Invoice_Report_Click(object sender, EventArgs e)
        {
            Form_InvoiceGenerationAndReport open = new Form_InvoiceGenerationAndReport();
            open.Show();
        }

        private void button_4_Daily_Log_For_Gynae_Click(object sender, EventArgs e)
        {
            Form_DailyLogReport open = new Form_DailyLogReport();
            open.Show();
        }

        private void button_5_Daily_Log_By_Cut_Off_Click(object sender, EventArgs e)
        {
            Form_DailyLogReportCutOff open = new Form_DailyLogReportCutOff();
            open.Show();
        }
    }
}
