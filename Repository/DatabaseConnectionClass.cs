using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DatabaseConnectionClass
    {
        private SqlConnection myConnection;
        private SqlCommand myCommand;

        public DatabaseConnectionClass()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\BankingManagementSystem\BankingManagementSystemdb.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection = new SqlConnection(connectionString);
        }

        public virtual void ConnectWithDB()
        {
            myConnection.Open();
        }
        public virtual void CloseConnection()
        {
            myConnection.Close();
        }

        public virtual IDataReader GetData(string query)
        {
            myCommand = new SqlCommand(query, myConnection);
            //SqlDataReader sdr = myCommand.ExecuteReader();
            //return sdr;
            return myCommand.ExecuteReader();
        }
        public virtual int ExecuteSQL(string query)
        {
            myCommand = new SqlCommand(query, myConnection);
            //int x= myCommand.ExecuteNonQuery();
            //return x;
            return myCommand.ExecuteNonQuery();
        }
    }

}
