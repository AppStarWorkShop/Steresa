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
    public partial class Form_BXCYRecordSearch : Form
    {
        public Boolean edit;

        private int SearchTypeCount;
        public static string selected { get; private set; }

        public Form_BXCYRecordSearch()
        {
            InitializeComponent();
            edit = false;
        }

        public void getSelected()
        {
            selected = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            MessageBox.Show(selected);
        }

        private void Form_BXCYRecordSearch_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medlabDataSet.BXCY_SPECIMEN' table. You can move, or remove it, as needed.
            this.bXCY_SPECIMENTableAdapter.Fill(this.medlabDataSet.BXCY_SPECIMEN);
            dataGridViewFormat();
            SearchTypeCount = 0;
            radioButton_Data_All.Checked = true;

        }

        private void dataGridViewFormat()
        {
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 130;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Blue;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 150;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 240;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 30;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 60;
            DataGridViewColumn column5 = dataGridView1.Columns[5];
            column5.Width = 20;
            DataGridViewColumn column6 = dataGridView1.Columns[6];
            column6.Width = 150;
            DataGridViewColumn column7 = dataGridView1.Columns[7];
            column7.Width = 240;
            DataGridViewColumn column8 = dataGridView1.Columns[8];
            column8.Width = 240;
            DataGridViewColumn column9 = dataGridView1.Columns[9];
            column9.Width = 20;
            DataGridViewColumn column10 = dataGridView1.Columns[10];
            column10.Width = 60;
            DataGridViewColumn column11 = dataGridView1.Columns[11];
            column11.Width = 130;
            DataGridViewColumn column12 = dataGridView1.Columns[12];
            column12.Width = 60;
            DataGridViewColumn column13 = dataGridView1.Columns[13];
            column13.Width = 130;
            DataGridViewColumn column14 = dataGridView1.Columns[14];
            column14.Width = 60;
            DataGridViewColumn column15 = dataGridView1.Columns[15];
            column15.Width = 130;
            DataGridViewColumn column16 = dataGridView1.Columns[16];
            column16.Width = 60;
            DataGridViewColumn column17 = dataGridView1.Columns[17];
            column17.Width = 130;
            DataGridViewColumn column18 = dataGridView1.Columns[18];
            column18.Width = 60;
            DataGridViewColumn column19 = dataGridView1.Columns[19];
            column19.Width = 130;
            DataGridViewColumn column20 = dataGridView1.Columns[20];
            column20.Width = 60;
            DataGridViewColumn column21 = dataGridView1.Columns[21];
            column21.Width = 130;
            DataGridViewColumn column22 = dataGridView1.Columns[22];
            column22.Width = 120;
            DataGridViewColumn column23 = dataGridView1.Columns[23];
            column23.Width = 150;
            DataGridViewColumn column24 = dataGridView1.Columns[24];
            column24.Width = 20;
            DataGridViewColumn column25 = dataGridView1.Columns[25];
            column25.Width = 20;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            /*
            dataGridView1.Columns[0].HeaderCell.Style.Font = new Font("Tahoma", 18, FontStyle.Bold);
            dataGridView1.Columns[1].HeaderCell.Style.Font = new Font("Tahoma", 22, FontStyle.Italic);
            dataGridView1.Columns[2].HeaderCell.Style.Font = new Font("Tahoma", 25, FontStyle.Strikeout);
            dataGridView1.Columns[3].HeaderCell.Style.Font = new Font("Tahoma", 28, FontStyle.Underline);
            */

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            /*
            
            dataGridView1.Columns[1].HeaderCell.Style.ForeColor = Color.Green;
            dataGridView1.Columns[2].HeaderCell.Style.ForeColor = Color.Blue;
            dataGridView1.Columns[3].HeaderCell.Style.ForeColor = Color.Brown;
            */
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;



            /*
            dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.White;
            dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.Yellow;
            dataGridView1.Columns[2].HeaderCell.Style.BackColor = Color.AliceBlue;
            dataGridView1.Columns[3].HeaderCell.Style.BackColor = Color.Aqua;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Yellow;
             */


            // center text

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            dataGridView1.EnableHeadersVisualStyles = false;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            edit_modle();
            
        }

        private void edit_modle()
        {
            button_F2_New_Record.ForeColor = Color.Black;
            buttonF3_Edit_Record.ForeColor = Color.Black;
            button_F5_New_Patient.ForeColor = Color.Black;
            button_F6_View_Record.ForeColor = Color.Black;
            edit = true;

        }

        private void disedit_modle()
        {
            button_F2_New_Record.ForeColor = Color.Gray;
            buttonF3_Edit_Record.ForeColor = Color.Gray;
            button_F5_New_Patient.ForeColor = Color.Gray;
            button_F6_View_Record.ForeColor = Color.Gray;
            edit = false;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void textBox_Search_Type_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Search_Type_Click(object sender, EventArgs e)
        {

        }

        private void button_F1_Search_Click(object sender, EventArgs e)
        {
            button_F1m();
            //Form_CaseSearch open = new Form_CaseSearch();
            //open.Show();

            //switch seach type
        }
        private void button_F1m()
        {
            SearchTypeCount += 1;
            switch (SearchTypeCount)
            {
                case 0:
                    label_Search_Type.Text = "Locate Case No.";
                    break;
                case 1:
                    label_Search_Type.Text = "Patient";
                    break;
                case 2:
                    label_Search_Type.Text = "Patient HKID";
                    break;
                case 3:
                    label_Search_Type.Text = "Hospital No.";
                    break;
                case 4:
                    label_Search_Type.Text = "Client";
                    break;
                case 5:
                    label_Search_Type.Text = "Doctor";
                    break;
                case 6:
                    SearchTypeCount = 0;
                    label_Search_Type.Text = "Locate Case No.";
                    break;
            }
        }
        private void button_F2_New_Record_Click(object sender, EventArgs e)
        {
            button_F2m();
        }
        private void button_F2m()
        {
            if (edit)
            {
                Form_CYTOLOGYFileGyname open = new Form_CYTOLOGYFileGyname();
            open.Show();
            }
        }
        private void buttonF3_Edit_Record_Click(object sender, EventArgs e)
        {
            button_F3m();
        }
        
        private void button_F3m()
        {
            
        }
        private void button_F4_Daily_Report_Click(object sender, EventArgs e)
        {
            button_F4m();
        }
        private void button_F4m()
        {
            Form_DailyLogReportForBiopsyCytolgyMokculurCase open = new Form_DailyLogReportForBiopsyCytolgyMokculurCase();
            open.Show();
        }
        private void button_F5_New_Patient_Click(object sender, EventArgs e)
        {
            button_F5m();
        }
        private void button_F5m()
        {
            
        }
        private void button_F6_View_Record_Click(object sender, EventArgs e)
        {
            button_F6m();
        }
        private void button_F6m()
        {
            if (edit)
            {
                getSelected();
                Form_BXCYFile open = new Form_BXCYFile();
                open.Show();
            }
        }
        private void button_F7_Columas_Click(object sender, EventArgs e)
        {
            button_F7m();
        }
        private void button_F7m()
        {

        }

        private void button_F8_Pic_Path_Click(object sender, EventArgs e)
        {
            button_F8m();
        }
        private void button_F8m()
        {
            Form_ChangePicturePath open = new Form_ChangePicturePath();
            open.Show();
        }
        private void button_F9_Set_BX_CY_Click(object sender, EventArgs e)
        {

        }
        private void button_F9m()
        {
            
        }

        private void button_Digital_Signature_Click(object sender, EventArgs e)
        {
            button_F10m();
        }
        private void button_F10m()
        {
            Form_LoginDigitalSignature open = new Form_LoginDigitalSignature();
            open.Show();
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            button_Escm();
        }
        private void button_Escm()
        {
            this.Close();
        }
        private void Form_BXCYRecordSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    button_F1m();
                    break;
                case Keys.F2:
                    button_F2m();
                    break;
                case Keys.F3:
                    button_F3m();
                    break;
                case Keys.F4:
                    button_F4m();
                    break;
                case Keys.F5:
                    button_F5m();
                    break;
                case Keys.F6:
                    button_F6m();
                    break;
                case Keys.F7:
                    button_F7m();
                    break;
                case Keys.F8:
                    button_F8m();
                    break;
                case Keys.F9:
                    button_F9m();
                    break;
                case Keys.F10:
                    button_F10m();
                    break;
                case Keys.Escape:
                    button_Escm();
                    break;
                //// etc
                default:
                    // do nothing
                    break;
            }
        }
        
        
        
        
        
        
        
        

        
    }
}
