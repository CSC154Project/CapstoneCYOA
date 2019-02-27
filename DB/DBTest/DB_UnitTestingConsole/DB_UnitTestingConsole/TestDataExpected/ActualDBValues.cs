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
            // Encounter Table
            encounter.Add(new DBConn.Encounter(1, 3));
            encounter.Add(new DBConn.Encounter(2, 1));
            encounter.Add(new DBConn.Encounter(3, 2));
            encounter.Add(new DBConn.Encounter(4, 1));
            encounter.Add(new DBConn.Encounter(5, 1));
            encounter.Add(new DBConn.Encounter(6, 2));
            encounter.Add(new DBConn.Encounter(7, 2));
            encounter.Add(new DBConn.Encounter(8, 2));
            encounter.Add(new DBConn.Encounter(9, 3));
            encounter.Add(new DBConn.Encounter(10, 2));

            // EncounterType Table
            encounterType.Add(new DBConn.EncounterType(1, "question"));
            encounterType.Add(new DBConn.EncounterType(2, "conversation"));
            encounterType.Add(new DBConn.EncounterType(3, "narrative"));

            // Questions Table
            questions.Add(new DBConn.Questions(1, 1, "Narrative"));
            questions.Add(new DBConn.Questions(2, 2, "How are you?"));
            questions.Add(new DBConn.Questions(3, 3, "Question A"));
            questions.Add(new DBConn.Questions(4, 4, "Question B"));
            questions.Add(new DBConn.Questions(5, 5, "Question C"));
            questions.Add(new DBConn.Questions(6, 6, "Question D"));
            questions.Add(new DBConn.Questions(7, 7, "Question E"));
            questions.Add(new DBConn.Questions(8, 8, "Question F"));
            questions.Add(new DBConn.Questions(9, 9, "Question G"));
            questions.Add(new DBConn.Questions(10, 10, "Question H"));
            
            // Choices Table
            choices.Add(new DBConn.Choices(1, 1, 1, "Continue", 2));
            choices.Add(new DBConn.Choices(2, 2, 2, "Im Fine", 3));
            choices.Add(new DBConn.Choices(2, 3, 2, "Im Not Fine", 4));
            choices.Add(new DBConn.Choices(2, 4, 2, "Choice A", 5));
            choices.Add(new DBConn.Choices(3, 5, 3, "Choice B", 6));
            choices.Add(new DBConn.Choices(3, 6, 3, "Choice C", 7));
            choices.Add(new DBConn.Choices(3, 7, 3, "Choice D", 8));
            choices.Add(new DBConn.Choices(1, 8, 1, "Choice E", 9));
            choices.Add(new DBConn.Choices(1, 9, 1, "Choice F", 10));
        }
    }
}
