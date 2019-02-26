using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole.DBConn
{
    #region Database Table Row Representation Classes

    /*
        Class Name: Encounter
        Description:
            Store an EncounterID value and EncounterTypeID value,
            This class represents a Row from the Encounter Table
    */
    public class Encounter
    {
        public int EncounterID { get; set; }
        public int EncounterTypeID { get; set; }

        public Encounter() { }
        public Encounter(int EncounterID, int EncounterTypeID)
        {
            this.EncounterID = EncounterID;
            this.EncounterTypeID = EncounterTypeID;
        }

        /*
            Function Name: ToString()
            Description:
                Return the string value of the "Row" which are EncounterID and EncounterTypeID values concantenated
            
            Params:     None
            Returns:    -> string
        */
        public override string ToString()
        {
            return EncounterID.ToString() + "\t" + EncounterTypeID.ToString();
        }
    }


    /*
        Class Name: EncounterType
        Description:
            Store an ID value and Description value,
            This class represents a Row from the EncounterType Table
    */
    public class EncounterType
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public EncounterType() { }
        public EncounterType(int ID, string Description)
        {
            this.ID = ID;
            this.Description = Description;
        }

        /*
            Function Name: ToString()
            Description:
                Return the string value of the "Row" which are ID and Description values concantenated

            Params:     None
            Returns:    -> string
        */
        public override string ToString()
        {
            return ID.ToString() + "\t" + Description;
        }
    }


    /*
        Class Name: Questions
        Description:
            Store an EncID value, ID value, a Text Value,
            This class represents a Row from the Questions Table
    */
    public class Questions
    {
        public int EncID { get; set; }
        public int ID { get; set; }
        public string Text { get; set; }

        public Questions() { }
        public Questions(int EncID, int ID, string Text)
        {
            this.EncID = EncID;
            this.ID = ID;
            this.Text = Text;
        }

        /*
            Function Name: ToString()
            Description:
                Return the string value of the "Row" which are the values EncID, ID, and Text concantenated
            
            Params:     None
            Returns:    -> string
        */
        public override string ToString()
        {
            return EncID.ToString() + "\t" + ID.ToString() + "\t" + Text;
        }
    }


    /*
        Class Name: Choices
        Description:
            Store an EncID value, ID value, QuestionID value, Text value, and NextEID value,
            This class represents a Row from the Choices Table
    */
    public class Choices
    {
        public int EncID { get; set; }
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public int NextEID { get; set; }

        /*
            Function Name: ToString()
            Description:
                Return the string value of the "Row" which are the values EncID, ID,
                QuestionID, Text, and NextEID concantenated

            Params:     None
            Returns:    -> string
        */
        public override string ToString()
        {
            return EncID.ToString() + "\t" + ID.ToString() + "\t" + QuestionID.ToString()
                + "\t" + Text + "\t" + NextEID.ToString();
        }
    }

    #endregion

    #region DBConn Class

    /*
        Class Name: DBConn
        Description:
            Connect to the "capstone" database, and run a query requested by the user
    */
    public class DBConn
    {
        // Connection Instance var
        private SqlConnection conn;
        public bool isConnected
        {
            get;
        }

        /*
            Constructor: DBConn
            Description:
                Try to open a new connection to the "capstone" database, 
                if connection was unsuccessful throw a new DBConnException
        */
        public DBConn()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=True";

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();

                if (conn.State != ConnectionState.Open)
                    isConnected = false;
                else
                    isConnected = true;
            }
            catch (Exception Ex)
            {
                throw new DBConnException("Unable to make the connection to the database.\n" + 
                    "Ensure that the connection string is correct.\n" +
                    "Or make sure that SQLSERVER Service has been started.", Ex);
            }
        }

        /*
            Function Name: RunQuery
            Description:
                Things that are going on in this function:

                    1: Setup the lstQueryResults, cmd, and reader variables then execute the query

                    2: Check the object type, set the instance variables of that type of object
                       and then populate the list with each object

                    3: Close the connection to the database

                    4: Return the populated List

            Params: query       -> string
                    classType   -> object

            Returns: lstQueryResults -> List<object>
        */
        public List<object> RunQuery(string query, object classType)
        {
            List<object> lstQueryResults = new List<object>();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (classType is Encounter)
            {
                while (reader.Read())
                {
                    Encounter enc = new Encounter();
                    enc.EncounterID = (int)reader[0];
                    enc.EncounterTypeID = (int)reader[1];

                    lstQueryResults.Add(enc);
                }
            }
            else if (classType is EncounterType)
            {
                while (reader.Read())
                {
                    EncounterType encType = new EncounterType();
                    encType.ID = (int)reader[0];
                    encType.Description = (string)reader[1];

                    lstQueryResults.Add(encType);
                }
            }
            else if (classType is Questions)
            {
                while (reader.Read())
                {
                    Questions question = new Questions();
                    question.EncID = (int)reader[0];
                    question.ID = (int)reader[1];
                    question.Text = (string)reader[2];

                    lstQueryResults.Add(question);
                }
            }
            else if (classType is Choices)
            {
                while (reader.Read())
                {
                    Choices choice = new Choices();
                    choice.EncID = (int)reader[0];
                    choice.ID = (int)reader[1];
                    choice.QuestionID = (int)reader[2];
                    choice.Text = (string)reader[3];
                    choice.NextEID = (int)reader[4];

                    lstQueryResults.Add(choice);
                }
            }
            else
                lstQueryResults.Add("None");

            conn.Close();

            return lstQueryResults;
        }
    }

    #endregion
}
