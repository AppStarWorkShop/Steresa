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
    public partial class Form_FeeCalculationSTH : Form
    {
        private bool isPrice1Entering = false;
        private bool isPrice2Entering = false;
        private bool isPrice3Entering = false;
        private bool isPrice4Entering = false;
        private bool isPrice5Entering = false;
        private bool isPrice6Entering = false;
        private bool isPrice7Entering = false;
        private bool isPrice8Entering = false;
        private bool isPrice9Entering = false;
        private bool isPrice10Entering = false;

        string classId;
        string codeId1, codeId2, codeId3, codeId4, codeId5, codeId6, codeId7, codeId8, codeId9, codeId10;
        string charge1, charge2, charge3, charge4, charge5, charge6, charge7, charge8, charge9, charge10;
        string chargeOther, chargeTotal;

        public delegate void FeeCalculationConfirm(string classId, string codeId1, string codeId2, string codeId3, string codeId4, string codeId5, string codeId6, string codeId7, string codeId8, string codeId9, string codeId10,
            string charge1, string charge2, string charge3, string charge4, string charge5, string charge6, string charge7, string charge8, string charge9, string charge10,
            string chargeOther, string chargeTotal);
        public FeeCalculationConfirm OnFeeCalculationConfirm;

        public Form_FeeCalculationSTH()
        {
            InitializeComponent();
        }

        public Form_FeeCalculationSTH(string classId, string codeId1, string codeId2, string codeId3, string codeId4, string codeId5, string codeId6, string codeId7, string codeId8, string codeId9, string codeId10,
            string charge1, string charge2, string charge3, string charge4, string charge5, string charge6, string charge7, string charge8, string charge9, string charge10,
            string chargeOther, string chargeTotal)
        {
            this.classId = classId;

            this.codeId1 = codeId1;
            this.codeId2 = codeId2;
            this.codeId3 = codeId3;
            this.codeId4 = codeId4;
            this.codeId5 = codeId5;
            this.codeId6 = codeId6;
            this.codeId7 = codeId7;
            this.codeId8 = codeId8;
            this.codeId9 = codeId9;
            this.codeId10 = codeId10;

            this.charge1 = charge1;
            this.charge2 = charge2;
            this.charge3 = charge3;
            this.charge4 = charge4;
            this.charge5 = charge5;
            this.charge6 = charge6;
            this.charge7 = charge7;
            this.charge8 = charge8;
            this.charge9 = charge9;
            this.charge10 = charge10;

            this.chargeOther = chargeOther;
            this.chargeTotal = chargeTotal;
            InitializeComponent();
        }

        private void reloadAndBindingDBData() {

            string classSql = "SELECT [class_id],[class_name] FROM [sth_charge_classes] WHERE active = 1 ORDER BY class_id";
            DataSet classDataSet = new DataSet();
            SqlDataAdapter classDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(classSql, classDataSet, "sth_charge_classes");

            DataTable classDt = new DataTable();
            classDt.Columns.Add("classId");
            classDt.Columns.Add("className");

            foreach (DataRow mDr in classDataSet.Tables["sth_charge_classes"].Rows)
            {
                classDt.Rows.Add(new object[] { mDr["class_id"], mDr["class_name"].ToString().Trim() });
            }

            comboBox_Class.DataSource = classDt;


            string codeSql = "SELECT [code_id],[code] FROM [sth_pay_code] WHERE active = 1 ORDER BY code_id";
            DataSet codeDataSet = new DataSet();
            SqlDataAdapter codeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(codeSql, codeDataSet, "sth_pay_code");

            DataTable codeDt1 = new DataTable();
            codeDt1.Columns.Add("codeId");
            codeDt1.Columns.Add("code");
            DataTable codeDt2 = codeDt1.Clone();
            DataTable codeDt3 = codeDt1.Clone();
            DataTable codeDt4 = codeDt1.Clone();
            DataTable codeDt5 = codeDt1.Clone();
            DataTable codeDt6 = codeDt1.Clone();
            DataTable codeDt7 = codeDt1.Clone();
            DataTable codeDt8 = codeDt1.Clone();
            DataTable codeDt9 = codeDt1.Clone();
            DataTable codeDt10 = codeDt1.Clone();

            foreach (DataRow mDr in codeDataSet.Tables["sth_pay_code"].Rows)
            {
                codeDt1.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt2.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt3.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt4.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt5.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt6.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt7.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt8.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt9.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
                codeDt10.Rows.Add(new object[] { mDr["code_id"], mDr["code"].ToString().Trim() });
            }

            comboBox_Code_1.DataSource = codeDt1;
            comboBox_Code_2.DataSource = codeDt2;
            comboBox_Code_3.DataSource = codeDt3;
            comboBox_Code_4.DataSource = codeDt4;
            comboBox_Code_5.DataSource = codeDt5;
            comboBox_Code_6.DataSource = codeDt6;
            comboBox_Code_7.DataSource = codeDt7;
            comboBox_Code_8.DataSource = codeDt8;
            comboBox_Code_9.DataSource = codeDt9;
            comboBox_Code_10.DataSource = codeDt10;

            try
            {
                comboBox_Class.SelectedValue = classId;
            }catch(Exception ex)
            {

            }

            try
            {
                comboBox_Code_1.SelectedValue = codeId1;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_Code_2.SelectedValue = codeId2;
            }catch (Exception ex)
            {

            }

            try
            {
                comboBox_Code_3.SelectedValue = codeId3;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_Code_4.SelectedValue = codeId4;
            }catch (Exception ex)
            {

            }

            try
            {
                comboBox_Code_5.SelectedValue = codeId5;
            }
            catch (Exception ex)
            {

            }

            try
            {
                comboBox_Code_6.SelectedValue = codeId6;
            }catch (Exception ex)
            {

            }

            try
            {
                comboBox_Code_7.SelectedValue = codeId7;
            }
            catch (Exception ex)
            {

            }

            try { 
                comboBox_Code_8.SelectedValue = codeId8;
            }catch (Exception ex)
            {

            }

            try { 
                comboBox_Code_9.SelectedValue = codeId9;
            }catch (Exception ex)
            {

            }

            try { 
                comboBox_Code_10.SelectedValue = codeId10;
            }catch (Exception ex)
            {

            }

            textBox_Price_1.Text = charge1;
            textBox_Price_2.Text = charge2;
            textBox_Price_3.Text = charge3;
            textBox_Price_4.Text = charge4;
            textBox_Price_5.Text = charge5;
            textBox_Price_6.Text = charge6;
            textBox_Price_7.Text = charge7;
            textBox_Price_8.Text = charge8;
            textBox_Price_9.Text = charge9;
            textBox_Price_10.Text = charge10;

            textBox_Other.Text = chargeOther;
            textBox_Total.Text = chargeTotal;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_FeeCalculationSTH_Load(object sender, EventArgs e)
        {
            reloadAndBindingDBData();
        }

        private void comboBox_Class_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice1();
            recalPrice2();
            recalPrice3();
            recalPrice4();
            recalPrice5();
            recalPrice6();
            recalPrice7();
            recalPrice8();
            recalPrice9();
            recalPrice10();

            recalSum();
        }

        private void recalPrice1()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_1.SelectedValue == null ? "" : comboBox_Code_1.SelectedValue.ToString().Trim();

            if(classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_1.Text = charge;

                    textBox_Price_1.Focus();
                    textBox_Price_1.Select(textBox_Price_1.TextLength, 0);
                    textBox_Price_1.ScrollToCaret();
                }
            }
        }

        private void recalPrice2()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_2.SelectedValue == null ? "" : comboBox_Code_2.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_2.Text = charge;

                    textBox_Price_2.Focus();
                    textBox_Price_2.Select(textBox_Price_2.TextLength, 0);
                    textBox_Price_2.ScrollToCaret();
                }
            }
        }

        private void recalPrice3()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_3.SelectedValue == null ? "" : comboBox_Code_3.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_3.Text = charge;

                    textBox_Price_3.Focus();
                    textBox_Price_3.Select(textBox_Price_3.TextLength, 0);
                    textBox_Price_3.ScrollToCaret();
                }
            }
        }

        private void recalPrice4()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_4.SelectedValue == null ? "" : comboBox_Code_4.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_4.Text = charge;

                    textBox_Price_4.Focus();
                    textBox_Price_4.Select(textBox_Price_4.TextLength, 0);
                    textBox_Price_4.ScrollToCaret();
                }
            }
        }

        private void recalPrice5()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_5.SelectedValue == null ? "" : comboBox_Code_5.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_5.Text = charge;

                    textBox_Price_5.Focus();
                    textBox_Price_5.Select(textBox_Price_5.TextLength, 0);
                    textBox_Price_5.ScrollToCaret();
                }
            }
        }

        private void recalPrice6()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_6.SelectedValue == null ? "" : comboBox_Code_6.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_6.Text = charge;

                    textBox_Price_6.Focus();
                    textBox_Price_6.Select(textBox_Price_6.TextLength, 0);
                    textBox_Price_6.ScrollToCaret();
                }
            }
        }

        private void recalPrice7()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_7.SelectedValue == null ? "" : comboBox_Code_7.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_7.Text = charge;

                    textBox_Price_7.Focus();
                    textBox_Price_7.Select(textBox_Price_7.TextLength, 0);
                    textBox_Price_7.ScrollToCaret();
                }
            }
        }

        private void recalPrice8()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_8.SelectedValue == null ? "" : comboBox_Code_8.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_8.Text = charge;

                    textBox_Price_8.Focus();
                    textBox_Price_8.Select(textBox_Price_8.TextLength, 0);
                    textBox_Price_8.ScrollToCaret();
                }
            }
        }

        private void recalPrice9()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_9.SelectedValue == null ? "" : comboBox_Code_9.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_9.Text = charge;

                    textBox_Price_9.Focus();
                    textBox_Price_9.Select(textBox_Price_9.TextLength, 0);
                    textBox_Price_9.ScrollToCaret();
                }
            }
        }

        private void recalPrice10()
        {
            string classId = "";
            string codeId = "";
            classId = comboBox_Class.SelectedValue == null ? "" : comboBox_Class.SelectedValue.ToString().Trim();
            codeId = comboBox_Code_10.SelectedValue == null ? "" : comboBox_Code_10.SelectedValue.ToString().Trim();

            if (classId != "" && codeId != "")
            {
                string chargeSql = string.Format("SELECT charge FROM [sth_charging_table] WHERE class_id = {0} and code_id = {1}", classId, codeId);
                DataSet chargeDataSet = new DataSet();
                SqlDataAdapter chargeDataAdapter = DBConn.fetchDataIntoDataSetSelectOnly(chargeSql, chargeDataSet, "sth_charging_table");

                DataTable chargeDt = chargeDataSet.Tables["sth_charging_table"];
                if (chargeDt.Rows.Count > 0)
                {
                    string charge = chargeDt.Rows[0]["charge"].ToString();
                    textBox_Price_10.Text = charge;

                    textBox_Price_10.Focus();
                    textBox_Price_10.Select(textBox_Price_10.TextLength, 0);
                    textBox_Price_10.ScrollToCaret();
                }
            }
        }

        private void comboBox_Code_1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice1();
            recalSum();
        }

        private void comboBox_Code_2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice2();
            recalSum();
        }

        private void comboBox_Code_3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice3();
            recalSum();
        }

        private void comboBox_Code_4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice4();
            recalSum();
        }

        private void comboBox_Code_5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice5();
            recalSum();
        }

        private void comboBox_Code_6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice6();
            recalSum();
        }

        private void comboBox_Code_7_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice7();
            recalSum();
        }

        private void comboBox_Code_8_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice8();
            recalSum();
        }

        private void comboBox_Code_9_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice9();
            recalSum();
        }

        private void comboBox_Code_10_SelectionChangeCommitted(object sender, EventArgs e)
        {
            recalPrice10();
            recalSum();
        }

        private void recalSum()
        {
            decimal price1 = 0;
            decimal price2 = 0;
            decimal price3 = 0;
            decimal price4 = 0;
            decimal price5 = 0;
            decimal price6 = 0;
            decimal price7 = 0;
            decimal price8 = 0;
            decimal price9 = 0;
            decimal price10 = 0;

            decimal priceOther = 0;
            decimal totalPrice = 0;

            decimal.TryParse(textBox_Price_1.Text.Trim(), out price1);
            decimal.TryParse(textBox_Price_2.Text.Trim(), out price2);
            decimal.TryParse(textBox_Price_3.Text.Trim(), out price3);
            decimal.TryParse(textBox_Price_4.Text.Trim(), out price4);
            decimal.TryParse(textBox_Price_5.Text.Trim(), out price5);
            decimal.TryParse(textBox_Price_6.Text.Trim(), out price6);
            decimal.TryParse(textBox_Price_7.Text.Trim(), out price7);
            decimal.TryParse(textBox_Price_8.Text.Trim(), out price8);
            decimal.TryParse(textBox_Price_9.Text.Trim(), out price9);
            decimal.TryParse(textBox_Price_10.Text.Trim(), out price10);

            decimal.TryParse(textBox_Other.Text.Trim(), out priceOther);

            totalPrice = price1 + price2 + price3 + price4 + price5 + price6 + price7 + price8 + price9 + price10 + priceOther;

            textBox_Total.Text = totalPrice.ToString();
        }

        private void textBox_Price_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice1Entering = true;
        }

        private void textBox_Price_1_TextChanged(object sender, EventArgs e)
        {
            if (isPrice1Entering)
            {
                isPrice1Entering = false;
                recalSum();
            }
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            if (OnFeeCalculationConfirm != null)
            {
                string classId = "";
                string codeId1 = "", codeId2 = "", codeId3 = "", codeId4 = "", codeId5 = "", codeId6 = "", codeId7 = "", codeId8 = "", codeId9 = "", codeId10 = "";
                string charge1 = "", charge2 = "", charge3 = "", charge4 = "", charge5 = "", charge6 = "", charge7 = "", charge8 = "", charge9 = "", charge10 = "";
                string chargeOther = "", chargeTotal = "";

                classId = comboBox_Class.SelectedValue.ToString();

                codeId1 = comboBox_Code_1.SelectedValue == null ? "" : comboBox_Code_1.SelectedValue.ToString();
                codeId2 = comboBox_Code_2.SelectedValue == null ? "" : comboBox_Code_2.SelectedValue.ToString();
                codeId3 = comboBox_Code_3.SelectedValue == null ? "" : comboBox_Code_3.SelectedValue.ToString();
                codeId4 = comboBox_Code_4.SelectedValue == null ? "" : comboBox_Code_4.SelectedValue.ToString();
                codeId5 = comboBox_Code_5.SelectedValue == null ? "" : comboBox_Code_5.SelectedValue.ToString();
                codeId6 = comboBox_Code_6.SelectedValue == null ? "" : comboBox_Code_6.SelectedValue.ToString();
                codeId7 = comboBox_Code_7.SelectedValue == null ? "" : comboBox_Code_7.SelectedValue.ToString();
                codeId8 = comboBox_Code_8.SelectedValue == null ? "" : comboBox_Code_8.SelectedValue.ToString();
                codeId9 = comboBox_Code_9.SelectedValue == null ? "" : comboBox_Code_9.SelectedValue.ToString();
                codeId10 = comboBox_Code_10.SelectedValue == null ? "" : comboBox_Code_10.SelectedValue.ToString();

                charge1 = textBox_Price_1.Text.Trim();
                charge2 = textBox_Price_2.Text.Trim();
                charge3 = textBox_Price_3.Text.Trim();
                charge4 = textBox_Price_4.Text.Trim();
                charge5 = textBox_Price_5.Text.Trim();
                charge6 = textBox_Price_6.Text.Trim();
                charge7 = textBox_Price_7.Text.Trim();
                charge8 = textBox_Price_8.Text.Trim();
                charge9 = textBox_Price_9.Text.Trim();
                charge10 = textBox_Price_10.Text.Trim();

                chargeOther = textBox_Other.Text.Trim();
                chargeTotal = textBox_Total.Text.Trim();

                OnFeeCalculationConfirm(classId, codeId1, codeId2, codeId3, codeId4, codeId5, codeId6, codeId7, codeId8, codeId9, codeId10,
                    charge1, charge2, charge3, charge4, charge5, charge6, charge7, charge8, charge9, charge10,
                    chargeOther, chargeTotal);
            }
            this.Close();
        }

        private void textBox_Price_2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice2Entering = true;
        }

        private void textBox_Price_2_TextChanged(object sender, EventArgs e)
        {
            if (isPrice2Entering)
            {
                isPrice2Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice3Entering = true;
        }

        private void textBox_Price_3_TextChanged(object sender, EventArgs e)
        {
            if (isPrice3Entering)
            {
                isPrice3Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice4Entering = true;
        }

        private void textBox_Price_4_TextChanged(object sender, EventArgs e)
        {
            if (isPrice4Entering)
            {
                isPrice4Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice5Entering = true;
        }

        private void textBox_Price_5_TextChanged(object sender, EventArgs e)
        {
            if (isPrice5Entering)
            {
                isPrice5Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice6Entering = true;
        }

        private void textBox_Price_6_TextChanged(object sender, EventArgs e)
        {
            if (isPrice6Entering)
            {
                isPrice6Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice7Entering = true;
        }

        private void textBox_Price_7_TextChanged(object sender, EventArgs e)
        {
            if (isPrice7Entering)
            {
                isPrice7Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice8Entering = true;
        }

        private void textBox_Price_8_TextChanged(object sender, EventArgs e)
        {
            if (isPrice8Entering)
            {
                isPrice8Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice9Entering = true;
        }

        private void textBox_Price_9_TextChanged(object sender, EventArgs e)
        {
            if (isPrice9Entering)
            {
                isPrice9Entering = false;
                recalSum();
            }
        }

        private void textBox_Price_10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            isPrice10Entering = true;
        }

        private void textBox_Price_10_TextChanged(object sender, EventArgs e)
        {
            if (isPrice10Entering)
            {
                isPrice10Entering = false;
                recalSum();
            }
        }

        private void textBox_Other_TextChanged(object sender, EventArgs e)
        {
            recalSum();
        }
    }
}
