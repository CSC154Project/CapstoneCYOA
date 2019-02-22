/*
    Class Name: DBTestConn
    Purpose:
        NOTE: Use only for Unit Testing

        Easliy connect, query and close the data base. Makes connecting, querying, and closing the database

    Inherits: None       
*/

using System;
using System.Collections.Generic;
using System.Data;
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
                Empty Constructor
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

        /*
            Function Name: RunQuery
            Description:
                Run a Sql Server Query with the connection information set in
                this classes Constructor. Return a SqlDataReader object after 
                the query is run.

            Params: query -> string
            Returns returnedReader -> SqlDataReader
        */
        public DataTable RunQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable resultTable = new DataTable();
            var adapter = new SqlDataAdapter(cmd).Fill(resultTable);

            if (conn.State == ConnectionState.Open)
                conn.Close();

            return resultTable;
        }

        /*
            
        */
        public List<List<string>> ResultsToList(SqlDataReader results)
        {
            return new List<List<string>>();
        }

        #region Overriden Built-In Method ToString()

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
