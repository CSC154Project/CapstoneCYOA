using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole.DBConn
{
    public class Encounter
    {
        public int EncounterID { get; set; }
        public int EncounterTypeID { get; set; }

        public override string ToString()
        {
            return EncounterID.ToString() + "\t" + EncounterTypeID.ToString();
        }
    }

    public class Questions
    {
        public int EncID { get; set; }
        public int ID { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return EncID.ToString() + "\t" + ID.ToString() + "\t" + Text;
        }
    }

    public class Choices
    {
        public int EncID { get; set; }
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public int NextEID { get; set; }

        public override string ToString()
        {
            return EncID.ToString() + "\t" + ID.ToString() + "\t" + QuestionID.ToString() 
                + "\t" + Text + "\t" + NextEID.ToString();
        }
    }

    public class DBConn
    {
        private SqlConnection conn;

        public DBConn()
        {
            // Connect to the db
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=True";

            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch(SqlException Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        public List<object> RunQuery(string query, object classType)
        {
            List<object> lstQueryResults = new List<object>();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (classType is Encounter)
            {
                while(reader.Read())
                {
                    Encounter enc = new Encounter();
                    enc.EncounterID = (int)reader[0];
                    enc.EncounterTypeID = (int)reader[1];
                    
                    lstQueryResults.Add(enc);
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

            conn.Close();

            return lstQueryResults;
        }
    }
}
