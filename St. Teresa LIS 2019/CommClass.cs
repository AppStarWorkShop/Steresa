﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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

        public static void fetchDataIntoDataSet(string selectCommand, DataSet dataSet)
        {
            try
            {
                // Create a new data adapter based on the specified query.
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, getConnection());

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                dataSet.Clear();
                dataAdapter.Fill(dataSet, "patient");
            }
            catch (SqlException)
            {
                //return false;
            }
        }
    }

    public static class PageStatus
    {
        public const int STATUS_VIEW = 1;
        public const int STATUS_NEW = 2;
        public const int STATUS_EDIT = 3;
    }
}
