using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace St.Teresa_LIS_2019
{
    public partial class Form_DoctorFileMaintenance : Form
    {
        private DataSet doctorDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        public CurrencyManager currencyManager;
        private DoctorStr copyDoctor;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;

        //public Boolean edit;
        public Form_DoctorFileMaintenance()
        {
            InitializeComponent();
            //edit = false;
        }

        public class Doctor
        {
            public string doctor_id { get; set; }
            public string doctor { get; set; }
            public string cname { get; set; }
            public string initial { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string address3 { get; set; }
            public string address4 { get; set; }
            public string tel1 { get; set; }
            public string tel2 { get; set; }
            public string fax { get; set; }
            public decimal opd { get; set; }
            public string contact { get; set; }
            public string remark { get; set; }
            public string sql_addr1 { get; set; }
            public string sql_addr2 { get; set; }
            public string sql_addr3 { get; set; }
            public string sql_addr4 { get; set; }
            public string sql_sname { get; set; }
            public string sql_gname { get; set; }
            public string sql_mobile { get; set; }
            public string sql_pager { get; set; }
            public string sql_phone { get; set; }
            public string sql_fax { get; set; }
            public DateTime? sql_update { get; set; }
            public string update_by { get; set; }
            public DateTime? update_at { get; set; }
            public decimal update_ctr { get; set; }
            public string updated { get; set; }
            public int id { get; set; }
        }

        public class DoctorStr
        {
            public string doctor_id { get; set; }
            public string doctor { get; set; }
            public string cname { get; set; }
            public string initial { get; set; }
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string address3 { get; set; }
            public string address4 { get; set; }
            public string tel1 { get; set; }
            public string tel2 { get; set; }
            public string fax { get; set; }
            public string opd { get; set; }
            public string contact { get; set; }
            public string remark { get; set; }
            public string sql_addr1 { get; set; }
            public string sql_addr2 { get; set; }
            public string sql_addr3 { get; set; }
            public string sql_addr4 { get; set; }
            public string sql_sname { get; set; }
            public string sql_gname { get; set; }
            public string sql_mobile { get; set; }
            public string sql_pager { get; set; }
            public string sql_phone { get; set; }
            public string sql_fax { get; set; }
            public string sql_update { get; set; }
            public string update_by { get; set; }
            public string update_at { get; set; }
            public string update_ctr { get; set; }
            public string updated { get; set; }
            public string code { get; set; }
            public string id { get; set; }
        }

        private void setButtonStatus(int status)
        {
            currentStatus = status;

            if (status == PageStatus.STATUS_VIEW)
            {
                button_Top.Enabled = true;
                button_Back.Enabled = true;
                button_Next.Enabled = true;
                button_End.Enabled = true;
                button_Save.Enabled = false;
                button_New.Enabled = true;
                button_Edit.Enabled = true;
                button_Delete.Enabled = true;
                button_Undo.Enabled = false;
                button_Label.Enabled = true;
                button_Exit.Enabled = true;

                textBox_Doctor.Enabled = false;
                textBox_Chi_Name.Enabled = false;
                textBox_Initial.Enabled = false;
                textBox_Addess1.Enabled = false;
                textBox_Addess2.Enabled = false;
                textBox_Addess3.Enabled = false;
                textBox_Addess4.Enabled = false;
                checkBox_OPD.Enabled = false;
                textBox_Tel_No1.Enabled = false;
                textBox_Tel_No2.Enabled = false;
                textBox_Fax_No.Enabled = false;
                textBox_Code.Enabled = false;
                textBox_Mobile.Enabled = false;
                textBox_Tel_No_Contact.Enabled = false;
                textBox_Pager.Enabled = false;
                textBox_Fax_No_Contact.Enabled = false;
                textBox_Contact_Info.Enabled = false;
                textBox_Remark.Enabled = false;

                disedit_modle();
            }
            else
            {
                if (status == PageStatus.STATUS_NEW)
                {
                    button_Top.Enabled = false;
                    button_Back.Enabled = false;
                    button_Next.Enabled = false;
                    button_End.Enabled = false;
                    button_Save.Enabled = true;
                    button_New.Enabled = false;
                    button_Edit.Enabled = false;
                    button_Delete.Enabled = false;
                    button_Undo.Enabled = true;
                    button_Label.Enabled = false;
                    button_Exit.Enabled = false;

                    textBox_Doctor.Enabled = true;
                    textBox_Chi_Name.Enabled = true;
                    textBox_Initial.Enabled = true;
                    textBox_Addess1.Enabled = true;
                    textBox_Addess2.Enabled = true;
                    textBox_Addess3.Enabled = true;
                    textBox_Addess4.Enabled = true;
                    checkBox_OPD.Enabled = true;
                    textBox_Tel_No1.Enabled = true;
                    textBox_Tel_No2.Enabled = true;
                    textBox_Fax_No.Enabled = true;
                    textBox_Code.Enabled = true;
                    textBox_Mobile.Enabled = true;
                    textBox_Tel_No_Contact.Enabled = true;
                    textBox_Pager.Enabled = true;
                    textBox_Fax_No_Contact.Enabled = true;
                    textBox_Contact_Info.Enabled = true;
                    textBox_Remark.Enabled = true;

                    edit_modle();
                }
                else
                {
                    if (status == PageStatus.STATUS_EDIT)
                    {
                        button_Top.Enabled = false;
                        button_Back.Enabled = false;
                        button_Next.Enabled = false;
                        button_End.Enabled = false;
                        button_Save.Enabled = true;
                        button_New.Enabled = false;
                        button_Edit.Enabled = false;
                        button_Delete.Enabled = false;
                        button_Undo.Enabled = true;
                        button_Label.Enabled = false;
                        button_Exit.Enabled = false;

                        textBox_Doctor.Enabled = true;
                        textBox_Chi_Name.Enabled = true;
                        textBox_Initial.Enabled = true;
                        textBox_Addess1.Enabled = true;
                        textBox_Addess2.Enabled = true;
                        textBox_Addess3.Enabled = true;
                        textBox_Addess4.Enabled = true;
                        checkBox_OPD.Enabled = true;
                        textBox_Tel_No1.Enabled = true;
                        textBox_Tel_No2.Enabled = true;
                        textBox_Fax_No.Enabled = true;
                        textBox_Code.Enabled = true;
                        textBox_Mobile.Enabled = true;
                        textBox_Tel_No_Contact.Enabled = true;
                        textBox_Pager.Enabled = true;
                        textBox_Fax_No_Contact.Enabled = true;
                        textBox_Contact_Info.Enabled = true;
                        textBox_Remark.Enabled = true;

                        edit_modle();
                    }
                }
            }
        }

        private void panel_Code_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkRed, ButtonBorderStyle.Solid);

        }


        private void edit_modle()
        {
            button_Top.Image = Image.FromFile("Resources/topGra.png");
            button_Top.ForeColor = Color.Gray;
            button_Back.Image = Image.FromFile("Resources/backGra.png");
            button_Back.ForeColor = Color.Gray;
            button_Next.Image = Image.FromFile("Resources/nextGra.png");
            button_Next.ForeColor = Color.Gray;
            button_End.Image = Image.FromFile("Resources/endGra.png");
            button_End.ForeColor = Color.Gray;
            button_Save.Image = Image.FromFile("Resources/save.png");
            button_Save.ForeColor = Color.Black;
            button_New.Image = Image.FromFile("Resources/newGra.png");
            button_New.ForeColor = Color.Gray;
            button_Edit.Image = Image.FromFile("Resources/editGra.png");
            button_Edit.ForeColor = Color.Gray;
            button_Delete.Image = Image.FromFile("Resources/deleteGra.png");
            button_Delete.ForeColor = Color.Gray;
            button_Undo.Image = Image.FromFile("Resources/undo.png");
            button_Undo.ForeColor = Color.Black;
            button_Label.Image = Image.FromFile("Resources/printer-1Gra.png");
            button_Label.ForeColor = Color.Gray;
            button_Exit.Image = Image.FromFile("Resources/exitGra.png");
            button_Exit.ForeColor = Color.Gray;
            button_Excel.Image = Image.FromFile("Resources/excel-32Gra.png");
            button_Excel.ForeColor = Color.Gray;
            //edit = true;
        }
        private void disedit_modle()
        {
            button_Top.Image = Image.FromFile("Resources/top.png");
            button_Top.ForeColor = Color.Black;
            button_Back.Image = Image.FromFile("Resources/back.png");
            button_Back.ForeColor = Color.Black;
            button_Next.Image = Image.FromFile("Resources/next.png");
            button_Next.ForeColor = Color.Black;
            button_End.Image = Image.FromFile("Resources/end.png");
            button_End.ForeColor = Color.Black;
            button_Save.Image = Image.FromFile("Resources/saveGra.png");
            button_Save.ForeColor = Color.Gray;
            button_New.Image = Image.FromFile("Resources/new.png");
            button_New.ForeColor = Color.Black;
            button_Edit.Image = Image.FromFile("Resources/edit.png");
            button_Edit.ForeColor = Color.Black;
            button_Delete.Image = Image.FromFile("Resources/delete.png");
            button_Delete.ForeColor = Color.Black;
            button_Undo.Image = Image.FromFile("Resources/undoGra.png");
            button_Undo.ForeColor = Color.Gray;
            button_Label.Image = Image.FromFile("Resources/printer-1.png");
            button_Label.ForeColor = Color.Black;
            button_Exit.Image = Image.FromFile("Resources/exit.png");
            button_Exit.ForeColor = Color.Black;
            button_Excel.Image = Image.FromFile("Resources/excel-32.png");
            button_Excel.ForeColor = Color.Black;
            //edit = false;
        }



        private void button_Label_Click(object sender, EventArgs e)
        {
            Form_LabelPrinting open = new Form_LabelPrinting();
            open.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button_Edit_Click(object sender, EventArgs e)
        {
            
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = doctorDataSet.Tables["doctor"].NewRow();
            currentEditRow["id"] = -1;
            doctorDataSet.Tables["doctor"].Rows.Add(currentEditRow);

            currencyManager.Position = currencyManager.Count - 1;
        }


        private void button_Delete_Click(object sender, EventArgs e)
        {

        }
        private void button_F1_Click(object sender, EventArgs e)
        {
            Form_SelectDoctor open = new Form_SelectDoctor();
            open.OnDoctorSelectedMore += OnDoctorSelected;
            open.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys)Shortcut.F1)
            {
                button_F1.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void OnDoctorSelected(string idStr)
        {
            if (idStr != null)
            {
                string sql = string.Format("SELECT * FROM [DOCTOR] WHERE ID IN({0})", idStr);
                DBConn.fetchDataIntoDataSet(sql, doctorDataSet, "doctor");

                DataTable dt = doctorDataSet.Tables["doctor"];
                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                dt.Columns["id"].AutoIncrement = true;
                dt.Columns["id"].AutoIncrementStep = 1;
                currencyManager = (CurrencyManager)this.BindingContext[dt];

                currencyManager.Position = 0;
            }
        }

        private void button_Save_Click_1(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = "Admin";
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");

                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, doctorDataSet, "doctor"))
                    {
                        reloadDBData(currencyManager.Count - 1);
                        MessageBox.Show("New doctor saved");
                    }
                    else
                    {
                        MessageBox.Show("Doctor saved fail, please contact Admin");
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {

                    DataRow drow = doctorDataSet.Tables["doctor"].Rows.Find(textBox_ID.Text);
                    if (drow != null)
                    {
                        drow["UPDATE_BY"] = "Admin";
                        drow["UPDATE_AT"] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");

                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, doctorDataSet, "doctor"))
                        {
                            MessageBox.Show("Doctor updated");
                        }
                        else
                        {
                            MessageBox.Show("Doctor updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void Form_DoctorFileMaintenance_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadAndBindingDBData(int position = 1)
        {
            dataAdapter = DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [doctor]", doctorDataSet, "doctor");
            //dataAdapter = DBConn.fetchDataIntoDataSet("SELECT * FROM [doctor]", doctorDataSet, "doctor");
            //fetchDataIntoDataSet("SELECT * FROM [PATIENT]");

            textBox_ID.DataBindings.Clear();
            textBox_Doctor.DataBindings.Clear();
            textBox_Chi_Name.DataBindings.Clear();
            textBox_Initial.DataBindings.Clear();
            textBox_Addess1.DataBindings.Clear();
            textBox_Addess2.DataBindings.Clear();
            textBox_Addess3.DataBindings.Clear();
            textBox_Addess4.DataBindings.Clear();
            checkBox_OPD.DataBindings.Clear();
            textBox_Tel_No1.DataBindings.Clear();
            textBox_Tel_No2.DataBindings.Clear();
            textBox_Fax_No.DataBindings.Clear();
            textBox_Code.DataBindings.Clear();
            textBox_Mobile.DataBindings.Clear();
            textBox_Tel_No_Contact.DataBindings.Clear();
            textBox_Pager.DataBindings.Clear();
            textBox_Fax_No_Contact.DataBindings.Clear();
            textBox_Contact_Info.DataBindings.Clear();
            textBox_Remark.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            dt = doctorDataSet.Tables["doctor"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Doctor.DataBindings.Add("Text", dt, "doctor", false);
            textBox_Chi_Name.DataBindings.Add("Text", dt, "cname", false);
            textBox_Initial.DataBindings.Add("Text", dt, "initial", false);
            textBox_Addess1.DataBindings.Add("Text", dt, "address1", false);
            textBox_Addess2.DataBindings.Add("Text", dt, "address2", false);
            textBox_Addess3.DataBindings.Add("Text", dt, "address3", false);
            textBox_Addess4.DataBindings.Add("Text", dt, "address4", false);
            checkBox_OPD.DataBindings.Add("Text", dt, "opd", false);
            textBox_Tel_No1.DataBindings.Add("Text", dt, "tel1", false);
            textBox_Tel_No2.DataBindings.Add("Text", dt, "tel2", false);
            textBox_Fax_No.DataBindings.Add("Text", dt, "fax", false);
            //textBox_Code.DataBindings.Add("Text", dt, "", false);
            textBox_Mobile.DataBindings.Add("Text", dt, "sql_mobile", false);
            textBox_Tel_No_Contact.DataBindings.Add("Text", dt, "sql_phone", false);
            textBox_Pager.DataBindings.Add("Text", dt, "sql_pager", false);
            textBox_Fax_No_Contact.DataBindings.Add("Text", dt, "sql_fax", false);
            textBox_Contact_Info.DataBindings.Add("Text", dt, "contact", false);
            textBox_Remark.DataBindings.Add("Text", dt, "remark", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);

            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;
        }

        private void reloadDBData(int position = 1)
        {
            //dataAdapter = DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [doctor]", doctorDataSet, "doctor");
            dataAdapter = DBConn.fetchDataIntoDataSet("SELECT * FROM [doctor]", doctorDataSet, "doctor");
            dt = doctorDataSet.Tables["doctor"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            currencyManager.Position++;
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            currencyManager.Position--;
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            currencyManager.Position = 0;
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    doctorDataSet.Tables["doctor"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                //reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyDoctor != null)
                    {
                        textBox_Doctor.Text = copyDoctor.doctor;
                        textBox_Chi_Name.Text = copyDoctor.cname;
                        textBox_Initial.Text = copyDoctor.initial;
                        textBox_Addess1.Text = copyDoctor.address1;
                        textBox_Addess2.Text = copyDoctor.address2;
                        textBox_Addess3.Text = copyDoctor.address3;
                        textBox_Addess4.Text = copyDoctor.address4;
                        checkBox_OPD.Text = copyDoctor.opd;
                        textBox_Tel_No1.Text = copyDoctor.tel1;
                        textBox_Tel_No2.Text = copyDoctor.tel2;
                        textBox_Fax_No.Text = copyDoctor.fax;
                        textBox_Code.Text = copyDoctor.code;
                        textBox_Mobile.Text = copyDoctor.sql_mobile;
                        textBox_Tel_No_Contact.Text = copyDoctor.sql_phone;
                        textBox_Pager.Text = copyDoctor.sql_pager;
                        textBox_Fax_No_Contact.Text = copyDoctor.sql_fax;
                        textBox_Contact_Info.Text = copyDoctor.contact;
                        textBox_Remark.Text = copyDoctor.remark;

                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button_Delete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM DOCTOR WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    currencyManager.Position = 0;
                    reloadDBData(0);

                    MessageBox.Show("Doctor deleted");
                }
                else
                {
                    MessageBox.Show("Doctor deleted fail, please contact Admin");
                }

                setButtonStatus(PageStatus.STATUS_VIEW);
            }
        }

        private void button_Edit_Click_1(object sender, EventArgs e)
        {
            currentPosition = currencyManager.Position;

            copyDoctor = new DoctorStr();
            copyDoctor.doctor = textBox_Doctor.Text;
            copyDoctor.cname = textBox_Chi_Name.Text;
            copyDoctor.initial = textBox_Initial.Text;
            copyDoctor.address1 = textBox_Addess1.Text;
            copyDoctor.address2 = textBox_Addess2.Text;
            copyDoctor.address3 = textBox_Addess3.Text;
            copyDoctor.address4 = textBox_Addess4.Text;
            copyDoctor.opd = checkBox_OPD.Text;
            copyDoctor.tel1 = textBox_Tel_No1.Text;
            copyDoctor.tel2 = textBox_Tel_No2.Text;
            copyDoctor.fax = textBox_Fax_No.Text;
            copyDoctor.code = textBox_Code.Text;
            copyDoctor.sql_mobile = textBox_Mobile.Text;
            copyDoctor.sql_phone = textBox_Tel_No_Contact.Text;
            copyDoctor.sql_pager = textBox_Pager.Text;
            copyDoctor.sql_fax = textBox_Fax_No_Contact.Text;
            copyDoctor.contact = textBox_Contact_Info.Text;
            copyDoctor.remark = textBox_Remark.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadDBData();
        }
    }
}
