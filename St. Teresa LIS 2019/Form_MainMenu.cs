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
    public partial class Form_MainMenu : Form
    {
        public Form_MainMenu()
        {
            InitializeComponent();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGreen, ButtonBorderStyle.Solid);
        }


        private void Form_MainMenu_Load(object sender, EventArgs e)
        {
            label_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (Properties.Settings.Default.HisEnableDebug)
            {
                buttonPrintReport.Visible = true;
                buttonPrintReport.Enabled = true;
                button1.Visible = true;
                button1.Enabled = true;
            }
        }

        private void button_Doctor_File_Click(object sender, EventArgs e)
        {
            Form_DoctorFileMaintenance open = new Form_DoctorFileMaintenance();
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button_Client_File_Click(object sender, EventArgs e)
        {
            Form_ClientFileMaintenance open = new Form_ClientFileMaintenance();
            open.Show();
        }

        private void panel_System_Maintenance_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkViolet, ButtonBorderStyle.Solid);
        }

        private void button_EBV_Records_Click(object sender, EventArgs e)
        {
            Form_EBVRecordSearch open = new Form_EBVRecordSearch();
            open.Show();
        }

        private void button_Patient_File_Click(object sender, EventArgs e)
        {
            Form_PatientFileMaintenancecs open = new Form_PatientFileMaintenancecs();
            open.Show();
        }

        private void button_BX_CY_Records_Click(object sender, EventArgs e)
        {
            Form_BXCYRecordSearch open = new Form_BXCYRecordSearch();
            open.Show();
        }

        private void Form_MainMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a') { MessageBox.Show("Enter pressed"); }
        }

        private void button_EBV_Test_Type_Click(object sender, EventArgs e)
        {
            Form_ResultFileMaintenance open = new Form_ResultFileMaintenance();
            open.Show();
        }

        private void button_EBV_dx_Code_Click(object sender, EventArgs e)
        {
            Form_EBVDiagnosisFileMaintenance open = new Form_EBVDiagnosisFileMaintenance();
            open.Show();
        }

        private void button_CY_Report_Click(object sender, EventArgs e)
        {
            Form_CYReportMaintenance open = new Form_CYReportMaintenance();
            open.Show();
        }

        private void button_Snop_Code_Click(object sender, EventArgs e)
        {
            Form_SnopCodeMaintenance open = new Form_SnopCodeMaintenance();
            open.Show();
        }

        private void button_User_File_Click(object sender, EventArgs e)
        {
            Form_UserFileSetup open = new Form_UserFileSetup();
            open.Show();
        }

        private void button_Import_Date_Click(object sender, EventArgs e)
        {
            Form_ImportExportDate open = new Form_ImportExportDate();
            open.Show();
        }

        private void button_Invoice_Reports_Click(object sender, EventArgs e)
        {
            Form_InvoiceAndOtherReportMenu open = new Form_InvoiceAndOtherReportMenu();
            open.Show();
        }

        private void button_Upload_To_STH_Click(object sender, EventArgs e)
        {
            Form_UploadDateMenu open = new Form_UploadDateMenu();
            open.Show();
        }

        private void buttonPrintReport_Click(object sender, EventArgs e)
        {
            Form_ReportPreview open = new Form_ReportPreview();
            open.Show();
            open.showReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_TestHis open = new Form_TestHis();
            open.Show();
            
        }
    }
}
