using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DB_UnitTests
{
    [TestClass]
    public class DBConnectionTest
    {
        [TestMethod]
        public void DB_Connection_Test()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost";
                builder.UserID = "sa";
                builder.Password = "";
                builder.InitialCatalog = "master";

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();
                }
            }
            catch(SqlException sqlex)
            {
                Console.WriteLine(sqlex.ToString());
            }
        }
    }
}
