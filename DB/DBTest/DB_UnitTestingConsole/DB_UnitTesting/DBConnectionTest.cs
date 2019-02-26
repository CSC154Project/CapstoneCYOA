using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB_UnitTestingConsole.DBConn;

namespace DB_UnitTesting
{
    [TestClass]
    public class DBConnectionTest
    {
        /*
            Test Method Name: DatabaseConnectionTest
            Description:
                Creates a new DBConn object and just runs the constructor,
                and then check to make sure the isConnected instance variable from
                the DBConn class is True, if isConnected is False then the test will
                ultimately fail.
            
            Params: None
            Returns: None
        */
        [TestMethod]
        public void DatabaseConnectionTest()
        {
            DBConn connection = new DBConn();
            Assert.IsTrue(connection.isConnected);
        }
    }
}
