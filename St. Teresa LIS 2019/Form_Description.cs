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
    public partial class Form_Description : Form
    {
        public Form_Description()
        {
            InitializeComponent();
        }

        private void button_F8_Back_To_Main_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Detail_5_Click(object sender, EventArgs e)
        {
            Form_MacroscopicTemplateMaintenance open = new Form_MacroscopicTemplateMaintenance();
            open.Show();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)

        {

            KeyEventArgs e = new KeyEventArgs(keyData);

            if (e.Control && e.KeyCode == Keys.F1)

            {

                return true; // handled

            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void Form_Description_KeyDown(object sender, KeyEventArgs e)
        {/*
            if (e.KeyCode == Keys.F1)
            {
                tabControl1.SelectedIndex = 0;
                label9.Text = "F1";
            }
            if (e.KeyCode == Keys.F2)
            {
                tabControl1.SelectedIndex = 1;
                label9.Text = "F2";
            }
            if (e.KeyCode == Keys.F3)
            {
                tabControl1.SelectedIndex = 2;
                label9.Text = "F3";
            }
            */
            switch (e.KeyCode)
            {
                case Keys.F1:
                    tabControl1.SelectedIndex = 0;
                    break;
                case Keys.F2:
                    tabControl1.SelectedIndex = 1;
                    break;
                case Keys.F3:
                    tabControl1.SelectedIndex = 2;
                    break;
                //// etc
                default:
                    // do nothing
                    break;
            }
            

        }

        private void button_Caption_Detail_Click(object sender, EventArgs e)
        {
            Form_PictureCaptionMaintenance open = new Form_PictureCaptionMaintenance();
            open.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form_MicroscopicCYTemplateMaintenance open = new Form_MicroscopicCYTemplateMaintenance();
            open.Show();
        }

        private void tabPage_MACROSCOPIC_Click(object sender, EventArgs e)
        {

        }
    }
}
