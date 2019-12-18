using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BarcodeLib;
using System.Drawing;

namespace St.Teresa_LIS_2019
{
    public static class DBConn
    {
        public static SqlConnection connection = new SqlConnection(Properties.Settings.Default.medlabConnectionString);

        public static SqlConnection getConnection()
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }

        public static bool executeUpdate(string updateSql)
        {

            SqlCommand sqlCmd = new SqlCommand(updateSql, getConnection());
            int result = sqlCmd.ExecuteNonQuery();

            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool updateObject(SqlDataAdapter dataAdapter, DataSet dataSet, string tableName)
        {
            bool result = false;
            if (dataAdapter != null && dataSet != null) { 
                if(dataAdapter.Update(dataSet, tableName)>0)
                {
                    result = true;
                }
            }
            return result;
        }

        public static SqlDataAdapter fetchDataIntoDataSet(string selectCommandStr, DataSet dataSet, string tableName)
        {
            try
            {
                // Create a new data adapter based on the specified query.
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = getConnection();
                selectCommand.CommandText = selectCommandStr;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.SelectCommand = selectCommand;
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();

                // Populate a new data table and bind it to the BindingSource.
                dataSet.Clear();
                dataAdapter.Fill(dataSet, tableName);
                return dataAdapter;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static SqlDataAdapter fetchDataIntoDataSetSelectOnly(string selectCommandStr, DataSet dataSet, string tableName)
        {
            try
            {
                // Create a new data adapter based on the specified query.
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = getConnection();
                selectCommand.CommandText = selectCommandStr;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand);

                // Populate a new data table and bind it to the BindingSource.
                dataSet.Clear();
                dataAdapter.Fill(dataSet, tableName);
                return dataAdapter;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public static int getSqlRecordCount(string tableNameAndStatement)
        {
            string countSql = string.Format("SELECT COUNT(*) AS recordCount FROM {0} ", tableNameAndStatement);
            int count = 0;
            SqlCommand command = new SqlCommand(countSql, getConnection());
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            reader.Close();
            return count;
        }
    }

    public static class PageStatus
    {
        public const int STATUS_VIEW = 1;
        public const int STATUS_NEW = 2;
        public const int STATUS_EDIT = 3;
        public const int STATUS_ADVANCE_EDIT = 4;
    }

    public static class CommonFunction
    {
        public static int GetAgeByBirthdate(string birthdate)
        {
            int returnAge = 0;
            try
            {
                DateTime now = DateTime.Now;
                DateTime birth = DateTime.Parse(birthdate);
                int age = now.Year - birth.Year;
                if (now.Month < birth.Month || (now.Month == birth.Month && now.Day < birth.Day))
                {
                    age--;
                }
                returnAge = age < 0 ? 0 : age;
                return returnAge;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                returnAge = 0;
                return returnAge;
            }
        }

        public static string getDataRowStrVal(DataRow dr, string fieldName)
        {
            if (dr != null)
            {
                if (dr[fieldName] != null && !Convert.IsDBNull(dr[fieldName]))
                {
                    return dr[fieldName].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public static Image CreateBarCode(string content)
        {
            using (var barcode = new Barcode()
            {
                //true显示content，false反之
                IncludeLabel = true,

                //content的位置
                Alignment = AlignmentPositions.CENTER,

                //条形码的宽高
                Width = 150,
                Height = 50,

                //类型
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,

                //颜色
                BackColor = System.Drawing.Color.White,
                ForeColor = System.Drawing.Color.Black,
            })
            {
                return barcode.Encode(TYPE.CODE128B, content);
            }
        }

        public static System.Drawing.Image CreateBarcodePicture(string BarcodeString)
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();//实例化一个条码对象
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;//编码类型

            //获取条码图片
            System.Drawing.Image BarcodePicture = b.Encode(type, BarcodeString, System.Drawing.Color.Black, System.Drawing.Color.White, 150, 50);

            return BarcodePicture;
        }

        public static void setDateWithStr(DataRow currentEditRow, string fieldName, string strVal, string format = "ddMMyyyy")
        {
            if(currentEditRow != null)
            {
                try
                {
                    currentEditRow[fieldName] = DateTime.ParseExact(strVal, format, null);
                }catch(Exception ex)
                {

                }
            }
        }
    }

    public static class CurrentUser
    {
        public static int currentUserLevel;
        public static int currentId;
        public static string picturePath;
        public static string currentUserId;
        public static string currentUserName;
    }

    public static class PaymentStatus
    {
        public static string PAID_YES = "Yes";
        public static string PAID_NO = "No";
    }

    public static class PatientAgeCalculator
    {
        public static Double calculate(DateTime dob)
        {
            Double age = Double.NaN;

            if (dob != null)
            {
                TimeSpan ts = DateTime.Now - dob;
                age = Math.Round(ts.TotalDays / 365.25, 2);
            }

            return age;
        }
    }
}
