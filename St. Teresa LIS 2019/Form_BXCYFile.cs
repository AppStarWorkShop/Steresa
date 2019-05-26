using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace St.Teresa_LIS_2019
{
    public partial class Form_BXCYFile : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["medlabConnectionString"]);
        SqlCommand command;
        SqlDataReader mdr;
        public string selected { get; private set; }

        public Form_BXCYFile()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkGreen, ButtonBorderStyle.Solid);
        }

        private void Form_BXCYFile_Load(object sender, EventArgs e)
        {
            Console.WriteLine("testtesttest");
            // TODO: This line of code loads data into the 'medlabDataSet1.BXCY_SPECIMEN' table. You can move, or remove it, as needed.
            this.bXCY_SPECIMENTableAdapter.Fill(this.medlabDataSet1.BXCY_SPECIMEN);
            // TODO: This line of code loads data into the 'medlabDataSet.BXCY_SPECIMEN' table. You can move, or remove it, as needed.
            this.bxcY_SPECIMENTableAdapter1.Fill(this.medlabDataSet.BXCY_SPECIMEN);
            // TODO: This line of code loads data into the 'medlabDataSet1.BXCY_SPECIMEN' table. You can move, or remove it, as needed.
            this.selected = Form_BXCYRecordSearch.selected;
            


        }

        private void LoadDateMDR()
        {
            Console.WriteLine("testtesttest123");
            this.selected = Form_BXCYRecordSearch.selected;
            connection.Open();
            string selectQuery = "SELECT * FROM [medlab].[dbo].[BXCY_SPECIMEN] WHERE case_no = '" + selected+"'";
            command = new SqlCommand(selectQuery, connection);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {

                textBox_Case_No.Text = mdr.GetString(0);
            }
            connection.Close();
        }


        private void button_Exit_Click(object sender, EventArgs e)
        {
            button_Escm();
        }
        private void button_Escm()
        {
            this.Close();
        }






        private void button_Cytology_Click(object sender, EventArgs e)
        {
            button_F10m();
        }
        private void button_F10m()
        {
            Form_CytologyFindings open = new Form_CytologyFindings();
            open.Show();
        }

        private void button_F_S_Detail_Click(object sender, EventArgs e)
        {
            Form_FrozenSectionDianosis open = new Form_FrozenSectionDianosis();
            open.Show();
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            button_F1m();
        }

        private void button_F1m()
        {
            Form_SelectPatient open = new Form_SelectPatient();
            open.Show();
        }

        private void button_F2_Previous_Click(object sender, EventArgs e)
        {
            button_F2m();
        }
        private void button_F2m()
        {
            Form_PrevoiusCasesCondition open = new Form_PrevoiusCasesCondition();
            open.Show();
        }

        private void button_F3_Surgical_Click(object sender, EventArgs e)
        {
            button_F3m();
        }
        private void button_F3m()
        {
            Form_SurgicalProcedure open = new Form_SurgicalProcedure();
            open.Show();
        }

        private void button_F4_Nature_Click(object sender, EventArgs e)
        {
            button_F4m();
        }
        private void button_F4m()
        {
            Form_NatureOfSpecimen open = new Form_NatureOfSpecimen();
            open.Show();
        }
        private void button_F5_Description_Click(object sender, EventArgs e)
        {
            button_F5m();
        }
        private void button_F5m()
        {
            Form_Description open = new Form_Description();
            open.Show();
        }

        private void button_F7_Click(object sender, EventArgs e)
        {
            button_F7m();
        }
        private void button_F7m()
        {
            Form_SelectClient open = new Form_SelectClient();
            open.Show();
        }

        private void button_F8_Click(object sender, EventArgs e)
        {
            button_F8m();
        }
        private void button_F8m()
        {
            Form_SelectClientInstitute open = new Form_SelectClientInstitute();
            open.Show();
        }

        private void button_F9_Click(object sender, EventArgs e)
        {
            button_F9m();
        }
        private void button_F9_2_Click(object sender, EventArgs e)
        {
            button_F9m();
        }
        private void button_F9_3_Click(object sender, EventArgs e)
        {
            button_F9m();
        }
        private void button_F9m()
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.Show();
        }
        private void button_F11_Add_test_Click(object sender, EventArgs e)
        {
            button_F11m();
        }
        private void button_F11m()
        {
            Form_AdditionalTests open = new Form_AdditionalTests();
            open.Show();
        }

        private void button_CY_Report_Detail_Click(object sender, EventArgs e)
        {
            Form_CYReportMaintenance open = new Form_CYReportMaintenance();
            open.Show();
        }

        private void button_Fee_Click(object sender, EventArgs e)
        {
            if (textBox_Client.Text == "ST. TERESA'S HOSPITAL")
            {
                Form_FeeCalculationSTH open = new Form_FeeCalculationSTH();
                open.Show();
            }
            else
            {
                Form_FeeCalculationPrivate open = new Form_FeeCalculationPrivate();
                open.Show();
            }
            
        }

        private void button_Sign_By_Dr_1_Click(object sender, EventArgs e)
        {
            Form_DoctorsSignatureMaintenance open = new Form_DoctorsSignatureMaintenance();
            open.Show();
        }

        private void button_Sign_By_Dr_2_Click(object sender, EventArgs e)
        {
            Form_DoctorsSignatureMaintenance open = new Form_DoctorsSignatureMaintenance();
            open.Show();
        }



        private void Form_BXCYFile_KeyDown(object sender, KeyEventArgs e)
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
                 // button_F6m();
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
                case Keys.F11:
                    button_F11m();
                    break;
                case Keys.Escape:
                    button_Escm();
                    break;
                case Keys.Right:
                    if (textBox_Doctor_I_C.Focused || textBox_Doctor_I_C_2.Focused || textBox_Doctor_I_C_3.Focused || textBox_Dr_I_C_Free_Text.Focused || textBox_Doctor_I_C_ID_1.Focused || textBox_Doctor_I_C_ID_2.Focused || textBox_Doctor_I_C_ID_3.Focused)
                    {
                    Shif_3_4();
                    Shif_2_3();
                    Shif_1_2();
                    }
                    
                    break;
                //// etc
                default:
                    // do nothing
                    break;
            }
        }

        private void button_Shif_Click(object sender, EventArgs e)
        {
            
            if (textBox_Doctor_I_C.Text != "")
            {
                if (textBox_Doctor_I_C_2.Text != "")
                {
                    if (textBox_Doctor_I_C_3.Text != "")
                    {
                        Shif_3_4();
                    }
                    Shif_2_3();
                }  
                Shif_1_2();
            }
        }

        private void button_Shif_2_Click(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C_2.Text != "")
            {
                if (textBox_Doctor_I_C_3.Text != "")
                {
                    Shif_3_4();
                }
                Shif_2_3();
            }
            
        }

        private void button_Shif_3_Click(object sender, EventArgs e)
        {
            if (textBox_Doctor_I_C_3.Text != "")
            {
                Shif_3_4();
            }
        }

        private void Shif_1_2()
        {
            textBox_Doctor_I_C_2.Text = textBox_Doctor_I_C.Text;
            textBox_Doctor_I_C_ID_2.Text = textBox_Doctor_I_C_ID_1.Text;
            textBox_Doctor_I_C.Text = "";
            textBox_Doctor_I_C_ID_1.Text = "";
        }
        private void Shif_2_3()
        {
            textBox_Doctor_I_C_3.Text = textBox_Doctor_I_C_2.Text;
            textBox_Doctor_I_C_ID_3.Text = textBox_Doctor_I_C_ID_2.Text;
            textBox_Doctor_I_C_2.Text = "";
            textBox_Doctor_I_C_ID_2.Text = "";
        }
        private void Shif_3_4()
        {
            if (textBox_Doctor_I_C_3.Text != "")
            {
            textBox_Dr_I_C_Free_Text.Text += "\r\n" + textBox_Doctor_I_C_3.Text;
            textBox_Dr_I_C_Free_Text.Text += " (" + textBox_Doctor_I_C_ID_3.Text + ")";
            textBox_Doctor_I_C_3.Text = "";
            textBox_Doctor_I_C_ID_3.Text = "";

            }
            
        }


    }
}
