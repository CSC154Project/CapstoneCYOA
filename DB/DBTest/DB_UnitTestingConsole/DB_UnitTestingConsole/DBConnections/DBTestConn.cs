/*
    Class Name: DBTestConn
    Purpose:
        NOTE: Use only for Unit Testing

        Easliy connect, query and close the data base. Makes connecting, querying, and closing the database

    Inherits: None       
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole.DBConnections
{
    class DBTestConn
    {
        // private instance variables
        private string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=True";
        private SqlConnection conn;


        /*
            Constructor Name: DBTestConn
            Description:
                Create a connection to the database and open the connection, 
                if it can't be open throw a DBConnException

            Params: None
        */
        public DBTestConn()
        {
            try
            {
                conn = new SqlConnection(strConnectionString);
                conn.Open();
            }
            catch (SqlException ex)
            {
                throw new DBConnException("Unable to connect to Database.", ex);
            }
                
        }
    }
}
