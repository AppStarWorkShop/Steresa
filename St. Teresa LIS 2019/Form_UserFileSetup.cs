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
    public partial class Form_UserFileSetup : Form
    {
        public Form_UserFileSetup()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_User_Level_Guidelines_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gudelines For User Security Level Contril :\n " +
                            "\n" +
                            "9 = System Administrator - the MOST powerful uesr who can control the whole system.\n " +
                            "8 = Powerful User - can Add/ Change / Delete all EXCEPT user control setup(here).\n" +
                            "6 = Advanced User - can Add / Change / Delete all date EXCEPT signing of report.\n " +
                            "5 = Stadard User - can Add / Change all non-advanced-edit date EXCEPT Delete right.\n " +
                            "4 = Low-level User - can View/Print reports, change non-sensitive data EXCEPT master files.\n" +
                            "3 = Limited User - can View/Print reports only, but NO Edit right.\n" +
                            "2 = Guest User - can View reports only, but NO Edit right.\n" +
                            "1 = Restricted User - can View reports on screen, but CAN'T print and NO Edit right.\n" +
                            "0 = Non-System User - CAN'T entry system.", "System Security");
        }

        private void button_Invoice_Year_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If You Want To Back Date The Invice Year\n" +
                "\n" +
                "To Last Year, Please Change WINDOW's System Date\n" +
                "\n" +
                "Manually And Then Restart This LIS System.", "Help Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_Next_Inv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Next New Invoice No. Will Be : "+ DateTime.Now.ToString("yy")+"-"+ textBox_Next_Inv.Text, "Help Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_Next_Receipt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Next New Receipt No. Will Be : " + "R" + DateTime.Now.ToString("yy") + "-" + textBox_Next_Receipt.Text , "Help Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button_STH_DIA_Amount_Auto_Fill_Setting_Click(object sender, EventArgs e)
        {
            Form_STHDiagnosticAmount open = new Form_STHDiagnosticAmount();
            open.Show();
        }
    }
}
