/*
    Class Name: DBConnException
    Description:
        Custom Exception when connecting to the database, allows for more thorough exception messages

    Inherits: Exception
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole.DBConnections
{
    class DBConnException : Exception
    {
        public DBConnException(string Message, SqlException inException) : base(Message, inException)
        { }
    }
}
