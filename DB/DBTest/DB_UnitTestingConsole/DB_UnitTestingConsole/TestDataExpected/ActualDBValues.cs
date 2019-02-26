using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole.TestDataExpected
{
    /*
        Class Name: ActualDBValues
        Description:
            Holds the values for the current database data, 
            used for Assertions in the Unit Testing Solutions
    */
    class ActualDBValues
    {
        
        List<DBConn.Encounter>      encounter       { get; }    // Encounter object List, accessible with Getter
        List<DBConn.EncounterType>  encounterType   { get; }    // EncounterType object List, accessible with Getter
        List<DBConn.Questions>      questions       { get; }    // Questions object List, accessible with Getter
        List<DBConn.Choices>        choices         { get; }    // Choices object List, accessible with Getter

        public ActualDBValues()
        {
            // Example for Encounter Table
            encounter.Add(new DBConn.Encounter(1, 3));

            // Example for Choices Table
            choices.Add(new DBConn.Choices(1, 1, 1, "Continue", 2));
        }
    }
}
