using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace St.Teresa_LIS_2019
{
    public partial class Form_ClientFileMaintenance : Form
    {
        public Boolean edit;
        private DataSet clientDataSet = new DataSet();
        private SqlDataAdapter dataAdapter;
        public static Boolean merge;
        //public CurrencyManager currencyManager;
        private ClientStr copyClient;
        private int currentStatus;
        private DataTable dt;
        private int currentPosition;
        private DataRow currentEditRow;

        public class Client
        {
            public string CLIENT { get; set; }
            public string CNAME { get; set; }
            public string ADDRESS1 { get; set; }
            public string ADDRESS2 { get; set; }
            public string ADDRESS3 { get; set; }
            public string ADDRESS4 { get; set; }
            public string TEL { get; set; }
            public string TEL2 { get; set; }
            public string FAX { get; set; }
            public string CONTACT { get; set; }
            public string REMARK { get; set; }
            public string UPDATE_BY { get; set; }
            public DateTime? UPDATE_AT { get; set; }
            public decimal UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
            public decimal PRICE_BX { get; set; }
            public decimal PRICE_BB { get; set; }
            public decimal PRICE_CY { get; set; }
            public decimal PRICE_CC { get; set; }
            public decimal PRICE_EBV { get; set; }
            public decimal PRICE_CYG { get; set; }
            public int id { get; set; }
        }

        public class ClientStr
        {
            public string CLIENT { get; set; }
            public string CNAME { get; set; }
            public string ADDRESS1 { get; set; }
            public string ADDRESS2 { get; set; }
            public string ADDRESS3 { get; set; }
            public string ADDRESS4 { get; set; }
            public string TEL { get; set; }
            public string TEL2 { get; set; }
            public string FAX { get; set; }
            public string CONTACT { get; set; }
            public string REMARK { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_AT { get; set; }
            public string UPDATE_CTR { get; set; }
            public string UPDATED { get; set; }
            public string PRICE_BX { get; set; }
            public string PRICE_BB { get; set; }
            public string PRICE_CY { get; set; }
            public string PRICE_CC { get; set; }
            public string PRICE_EBV { get; set; }
            public string PRICE_CYG { get; set; }
            public string id { get; set; }
        }

        public Form_ClientFileMaintenance()
        {
            edit = false;
            InitializeComponent();
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

                textBox_Client.Enabled = false;
                textBox_Chi_Name.Enabled = false;
                textBox_Addess1.Enabled = false;
                textBox_Addess2.Enabled = false;
                textBox_Addess3.Enabled = false;
                textBox_Addess4.Enabled = false;
                textBox_Tel_No1.Enabled = false;
                textBox_Tel_No2.Enabled = false;
                textBox_Fax_No.Enabled = false;
                textBox_Contact_Info.Enabled = false;
                textBox_Remark.Enabled = false;
                textBox_BX.Enabled = false;
                textBox_BB.Enabled = false;
                textBox_CY.Enabled = false;
                textBox_CC.Enabled = false;
                textBox_CYG.Enabled = false;
                textBox_EBV.Enabled = false;

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

                    textBox_Client.Enabled = true;
                    textBox_Chi_Name.Enabled = true;
                    textBox_Addess1.Enabled = true;
                    textBox_Addess2.Enabled = true;
                    textBox_Addess3.Enabled = true;
                    textBox_Addess4.Enabled = true;
                    textBox_Tel_No1.Enabled = true;
                    textBox_Tel_No2.Enabled = true;
                    textBox_Fax_No.Enabled = true;
                    textBox_Contact_Info.Enabled = true;
                    textBox_Remark.Enabled = true;
                    textBox_BX.Enabled = true;
                    textBox_BB.Enabled = true;
                    textBox_CY.Enabled = true;
                    textBox_CC.Enabled = true;
                    textBox_CYG.Enabled = true;
                    textBox_EBV.Enabled = true;

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

                        textBox_Client.Enabled = true;
                        textBox_Chi_Name.Enabled = true;
                        textBox_Addess1.Enabled = true;
                        textBox_Addess2.Enabled = true;
                        textBox_Addess3.Enabled = true;
                        textBox_Addess4.Enabled = true;
                        textBox_Tel_No1.Enabled = true;
                        textBox_Tel_No2.Enabled = true;
                        textBox_Fax_No.Enabled = true;
                        textBox_Contact_Info.Enabled = true;
                        textBox_Remark.Enabled = true;
                        textBox_BX.Enabled = true;
                        textBox_BB.Enabled = true;
                        textBox_CY.Enabled = true;
                        textBox_CC.Enabled = true;
                        textBox_CYG.Enabled = true;
                        textBox_EBV.Enabled = true;

                        edit_modle();
                    }
                }
            }
        }

        private void Form_ClientFileMaintenance_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
            setButtonStatus(PageStatus.STATUS_VIEW);
        }

        private void reloadAndBindingDBData(int position = 0)
        {
            //dataAdapter = DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [client]", clientDataSet, "client");
            dataAdapter = DBConn.fetchDataIntoDataSet("SELECT TOP 1 * FROM [client] ORDER BY ID", clientDataSet, "client");
            //fetchDataIntoDataSet("SELECT * FROM [PATIENT]");

            textBox_ID.DataBindings.Clear();
            textBox_Client.DataBindings.Clear();
            textBox_Chi_Name.DataBindings.Clear();
            textBox_Addess1.DataBindings.Clear();
            textBox_Addess2.DataBindings.Clear();
            textBox_Addess3.DataBindings.Clear();
            textBox_Addess4.DataBindings.Clear();
            textBox_Tel_No1.DataBindings.Clear();
            textBox_Tel_No2.DataBindings.Clear();
            textBox_Fax_No.DataBindings.Clear();
            textBox_Contact_Info.DataBindings.Clear();
            textBox_Remark.DataBindings.Clear();
            textBox_BX.DataBindings.Clear();
            textBox_BB.DataBindings.Clear();
            textBox_CY.DataBindings.Clear();
            textBox_CC.DataBindings.Clear();
            textBox_CYG.DataBindings.Clear();
            textBox_EBV.DataBindings.Clear();
            textBox_Last_Updated_By.DataBindings.Clear();
            textBox_Update_At.DataBindings.Clear();
            textBox_Last_Updated_By_No.DataBindings.Clear();

            dt = clientDataSet.Tables["client"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            textBox_ID.DataBindings.Add("Text", dt, "id", false);
            textBox_Client.DataBindings.Add("Text", dt, "CLIENT", false);
            textBox_Chi_Name.DataBindings.Add("Text", dt, "CNAME", false);
            textBox_Addess1.DataBindings.Add("Text", dt, "ADDRESS1", false);
            textBox_Addess2.DataBindings.Add("Text", dt, "ADDRESS2", false);
            textBox_Addess3.DataBindings.Add("Text", dt, "ADDRESS3", false);
            textBox_Addess4.DataBindings.Add("Text", dt, "ADDRESS4", false);
            textBox_Tel_No1.DataBindings.Add("Text", dt, "TEL", false);
            textBox_Tel_No2.DataBindings.Add("Text", dt, "TEL2", false);
            textBox_Fax_No.DataBindings.Add("Text", dt, "FAX", false);
            textBox_Contact_Info.DataBindings.Add("Text", dt, "CONTACT", false);
            textBox_Remark.DataBindings.Add("Text", dt, "REMARK", false);
            textBox_BX.DataBindings.Add("Text", dt, "PRICE_BX", false);
            textBox_BB.DataBindings.Add("Text", dt, "PRICE_BB", false);
            textBox_CY.DataBindings.Add("Text", dt, "PRICE_CY", false);
            textBox_CC.DataBindings.Add("Text", dt, "PRICE_CC", false);
            textBox_CYG.DataBindings.Add("Text", dt, "PRICE_CYG", false);
            textBox_EBV.DataBindings.Add("Text", dt, "PRICE_EBV", false);
            textBox_Last_Updated_By.DataBindings.Add("Text", dt, "UPDATE_BY", false);
            textBox_Update_At.DataBindings.Add("Text", dt, "UPDATE_AT", false);
            textBox_Last_Updated_By_No.DataBindings.Add("Text", dt, "UPDATE_CTR", false);

            /*currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;*/
        }

        private void reloadDBData(int position = 0)
        {
            //dataAdapter = DBConn.fetchDataIntoDataSet("SELECT TOP 100 * FROM [client]", clientDataSet, "client");
            dataAdapter = DBConn.fetchDataIntoDataSet("SELECT TOP 1 * FROM [client] ORDER BY ID", clientDataSet, "client");
            dt = clientDataSet.Tables["client"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
            dt.Columns["id"].AutoIncrement = true;
            dt.Columns["id"].AutoIncrementStep = 1;

            /*currencyManager = (CurrencyManager)this.BindingContext[dt];

            currencyManager.Position = position;*/
        }

        private void button_Label_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                Form_LabelPrinting open = new Form_LabelPrinting();
                open.Show();
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void button_Edit_Click(object sender, EventArgs e)
        {
            //currentPosition = currencyManager.Position;

            copyClient = new ClientStr();
            copyClient.CLIENT = textBox_Client.Text;
            copyClient.CNAME = textBox_Chi_Name.Text;
            copyClient.ADDRESS1 = textBox_Addess1.Text;
            copyClient.ADDRESS2 = textBox_Addess2.Text;
            copyClient.ADDRESS3 = textBox_Addess3.Text;
            copyClient.ADDRESS4 = textBox_Addess4.Text;
            copyClient.TEL = textBox_Tel_No1.Text;
            copyClient.TEL2 = textBox_Tel_No2.Text;
            copyClient.FAX = textBox_Fax_No.Text;
            copyClient.CONTACT = textBox_Contact_Info.Text;
            copyClient.REMARK = textBox_Remark.Text;
            copyClient.PRICE_BX = textBox_BX.Text;
            copyClient.PRICE_BB = textBox_BB.Text;
            copyClient.PRICE_CY = textBox_CY.Text;
            copyClient.PRICE_CC = textBox_CC.Text;
            copyClient.PRICE_EBV = textBox_CYG.Text;
            copyClient.PRICE_CYG = textBox_EBV.Text;

            setButtonStatus(PageStatus.STATUS_EDIT);

        }

        private void button_New_Click(object sender, EventArgs e)
        {
            setButtonStatus(PageStatus.STATUS_NEW);

            currentEditRow = clientDataSet.Tables["client"].NewRow();
            currentEditRow["id"] = -1;

            clientDataSet.Tables["client"].Rows.Clear();
            clientDataSet.Tables["client"].Rows.Add(currentEditRow);

            //currencyManager.Position = currencyManager.Count - 1;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if (currentEditRow != null)
                {
                    currentEditRow["UPDATE_BY"] = CurrentUser.currentUserId;
                    currentEditRow["UPDATE_AT"] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");

                    textBox_ID.BindingContext[dt].Position++;

                    if (DBConn.updateObject(dataAdapter, clientDataSet, "client"))
                    {
                        reloadDBData();
                        MessageBox.Show("New client saved");
                    }
                    else
                    {
                        MessageBox.Show("Client saved fail, please contact Admin");
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    DataRow drow = clientDataSet.Tables["client"].Rows.Find(textBox_ID.Text);
                    if(drow != null)
                    {
                        drow["UPDATE_BY"] = CurrentUser.currentUserId;
                        drow["UPDATE_AT"] = DateTime.Now.ToString("yyyy-MM-dd HH:MM");

                        textBox_ID.BindingContext[dt].Position++;

                        if (DBConn.updateObject(dataAdapter, clientDataSet, "client"))
                        {
                            MessageBox.Show("Client updated");
                        }
                        else
                        {
                            MessageBox.Show("Client updated fail, please contact Admin");
                        }
                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                    //reloadAndBindingDBData(currentPosition);
                }
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to delete this record?", "Confirm deleting", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string deleteSql = string.Format("DELETE FROM CLIENT WHERE id = '{0}'", textBox_ID.Text);

                if (DBConn.executeUpdate(deleteSql))
                {
                    DataRow rowToDelete = dt.Rows.Find(textBox_ID.Text);
                    rowToDelete.Delete();
                    //currencyManager.Position = 0;
                    reloadDBData(0);

                    MessageBox.Show("Client deleted");
                }
                else
                {
                    MessageBox.Show("Client deleted fail, please contact Admin");
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
            }
        }

        private void button_F1_Click(object sender, EventArgs e)
        {
            Form_SelectClient open = new Form_SelectClient();
            open.OnClientSelectedMore += OnClientSelected;
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

        private void OnClientSelected(string idStr)
        {
            if (idStr != null)
            {
                string sql = string.Format("SELECT * FROM [CLIENT] WHERE ID IN({0})", idStr);
                DBConn.fetchDataIntoDataSet(sql, clientDataSet, "client");

                DataTable dt = clientDataSet.Tables["client"];
                dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };
                dt.Columns["id"].AutoIncrement = true;
                dt.Columns["id"].AutoIncrementStep = 1;
                /*currencyManager = (CurrencyManager)this.BindingContext[dt];

                currencyManager.Position = 0;*/
            }
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            //currencyManager.Position++;
            string countSql = string.Format(" [client] WHERE id > {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [client] WHERE id > {0} ORDER BY ID", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, clientDataSet, "client");
            }
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            //currencyManager.Position--;
            string countSql = string.Format(" [client] WHERE id < {0}", textBox_ID.Text);
            if (DBConn.getSqlRecordCount(countSql) > 0)
            {
                string sql = string.Format("SELECT TOP 1 * FROM [client] WHERE id < {0} ORDER BY ID DESC", textBox_ID.Text);
                dataAdapter = DBConn.fetchDataIntoDataSet(sql, clientDataSet, "client");
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = 0;
            string sql = string.Format("SELECT TOP 1 * FROM [client] ORDER BY ID", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, clientDataSet, "client");
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            //currencyManager.Position = currencyManager.Count - 1;
            string sql = string.Format("SELECT TOP 1 * FROM [client] ORDER BY ID DESC", textBox_ID.Text);
            dataAdapter = DBConn.fetchDataIntoDataSet(sql, clientDataSet, "client");
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
            edit = true;
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
            edit = false;
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (currentStatus == PageStatus.STATUS_NEW)
            {
                if(currentEditRow != null)
                {
                    clientDataSet.Tables["client"].Rows.Remove(currentEditRow);
                }
                setButtonStatus(PageStatus.STATUS_VIEW);
                reloadAndBindingDBData();
            }
            else
            {
                if (currentStatus == PageStatus.STATUS_EDIT)
                {
                    if (copyClient != null)
                    {
                        textBox_Client.Text = copyClient.CLIENT;
                        textBox_Chi_Name.Text = copyClient.CNAME;
                        textBox_Addess1.Text = copyClient.ADDRESS1;
                        textBox_Addess2.Text = copyClient.ADDRESS2;
                        textBox_Addess3.Text = copyClient.ADDRESS3;
                        textBox_Addess4.Text = copyClient.ADDRESS4;
                        textBox_Tel_No1.Text = copyClient.TEL;
                        textBox_Tel_No2.Text = copyClient.TEL2;
                        textBox_Fax_No.Text = copyClient.FAX;
                        textBox_Contact_Info.Text = copyClient.CONTACT;
                        textBox_Remark.Text = copyClient.REMARK;
                        textBox_BX.Text = copyClient.PRICE_BX;
                        textBox_BB.Text = copyClient.PRICE_BB;
                        textBox_CY.Text = copyClient.PRICE_CY;
                        textBox_CC.Text = copyClient.PRICE_CC;
                        textBox_CYG.Text = copyClient.PRICE_EBV;
                        textBox_EBV.Text = copyClient.PRICE_CYG;

                    }

                    setButtonStatus(PageStatus.STATUS_VIEW);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadDBData();
        }

        private void button_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "報表文件(*.xlsx)|*.xlsx";
                sfd.RestoreDirectory = true;
                sfd.FileName = "client_report.xlsx";
                string localFilePath = "c:\\temp\\client_report.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    localFilePath = sfd.FileName.ToString();

                    string checkSql = string.Format("select * from client");
                    SqlCommand checkCmd = new SqlCommand(checkSql, DBConn.getConnection());
                    checkCmd.CommandTimeout = 600;

                    SqlDataAdapter sdap = new SqlDataAdapter();
                    sdap.SelectCommand = checkCmd;

                    DataTable dt = new DataTable();
                    sdap.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        IWorkbook workbook = new XSSFWorkbook();
                        ISheet sheet = (ISheet)workbook.CreateSheet("client_report");
                        FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);

                        IRow sheetRow = (IRow)sheet.CreateRow(0);
                        sheetRow.CreateCell(0).SetCellValue("client");
                        sheetRow.CreateCell(1).SetCellValue("cname");
                        sheetRow.CreateCell(2).SetCellValue("address1");
                        sheetRow.CreateCell(3).SetCellValue("address2");
                        sheetRow.CreateCell(4).SetCellValue("address3");
                        sheetRow.CreateCell(5).SetCellValue("address4");
                        sheetRow.CreateCell(6).SetCellValue("tel1");
                        sheetRow.CreateCell(7).SetCellValue("tel2");
                        sheetRow.CreateCell(8).SetCellValue("fax");
                        sheetRow.CreateCell(9).SetCellValue("contact");
                        sheetRow.CreateCell(10).SetCellValue("remark");

                        /*FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("UTF-8"));
                        sw.WriteLine("client,cname,address1,address2,address3,address4,tel1,tel2,fax,contact,remark");*/

                        //int rowNo = 1;
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            DataRow item = dt.Rows[j];
                            sheetRow = (IRow)sheet.CreateRow(j+1);

                            sheetRow.CreateCell(0).SetCellValue(CommonFunction.getDataRowStrVal(item, "client"));
                            sheetRow.CreateCell(1).SetCellValue(CommonFunction.getDataRowStrVal(item, "cname"));
                            //sheetRow.CreateCell(2).SetCellValue(CommonFunction.getDataRowStrVal(item, "address1"));
                            //sheetRow.CreateCell(3).SetCellValue(CommonFunction.getDataRowStrVal(item, "address2"));
                            //sheetRow.CreateCell(4).SetCellValue(CommonFunction.getDataRowStrVal(item, "address3"));
                            //sheetRow.CreateCell(5).SetCellValue(CommonFunction.getDataRowStrVal(item, "address4"));
                            sheetRow.CreateCell(6).SetCellValue(CommonFunction.getDataRowStrVal(item, "tel"));
                            sheetRow.CreateCell(7).SetCellValue(CommonFunction.getDataRowStrVal(item, "tel2"));
                            sheetRow.CreateCell(8).SetCellValue(CommonFunction.getDataRowStrVal(item, "fax"));
                            sheetRow.CreateCell(9).SetCellValue(CommonFunction.getDataRowStrVal(item, "contact"));
                            sheetRow.CreateCell(10).SetCellValue(CommonFunction.getDataRowStrVal(item, "remark"));


                            /*DataRow item = dt.Rows[j];
                            string rowValue = "";
                            rowValue += item["client"] + "," + item["cname"] + "," + item["address1"] + "," + item["address2"] + "," + item["address3"] + "," + item["address4"] + "," + item["tel"] + "," + item["tel2"] + "," + item["fax"] + "," + item["contact"] + "," + item["remark"];

                            sw.WriteLine(rowValue);*/
                        }

                        workbook.Write(fs);
                        //long fileSize = fs.Length;
                        //context.Response.AddHeader("Content-Length", fileSize.ToString());

                        workbook = null;
                        fs.Close();
                        fs.Dispose();

                        //sw.Close();
                        MessageBox.Show("Export done");
                    }
                    else
                    {
                        MessageBox.Show("No record found");
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show("Fail to export the file");
            }
        }
    }
}
