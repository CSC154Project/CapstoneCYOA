using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole.DBConn
{
    /*
        Class Name: DBConnException
        Description:
            Custom exception to throw when the database is not correctly
            connected to.
        
        Inherits: Exception
    */
    class DBConnException : Exception
    {
        /*
            Constructor: DBConnException
            Description:
                Call the inherited class's(Exception) construstor and
                pass in the expectionMessage value and baseException value | base(message, inner_class)
                
            Params: exceptionMessage    -> string
                    baseException       -> Exception
            Returns: None
        */
        public DBConnException(string exceptionMessage, Exception baseException) : base(exceptionMessage, baseException) { }
    }
}
