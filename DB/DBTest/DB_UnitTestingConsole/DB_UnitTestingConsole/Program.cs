using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DB_UnitTestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the db
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=True";
            SqlConnection connectMe = new SqlConnection(connectionString);

            List<string> result = new List<string>();
            string query;
            SqlDataAdapter da;
            DataTable dt;

            int colNum = 0;

            // Open the db
            connectMe.Open();

            if (connectMe.State != ConnectionState.Open)
            {
                Console.WriteLine("Unable to open the database.");
            }
            else
            {
                Console.WriteLine("Successfully opened the database...\nNow checking tables...");

                // Check contents of each table in db
                // Encounter Table
                query = "SELECT * FROM ENCOUNTER";
                SqlCommand cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\nEncounter\n----------");
                foreach (DataRow row in dt.Rows)
                {
                    // Run the query and store the results in the questionQuery variable.
                    // There is an issue with querying the "Question" table it will throw an exception
                    var questionQuery = CapstoneDB.ExecuteQuery<Question>(@"SELECT * FROM Question");

                    // Loop through the questionQuery list and print every single item
                    Console.WriteLine("ID \t" + "Text");
                    foreach (Question question in questionQuery)
                        Console.WriteLine(question.ID + "\t" + question.Text);

                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write("{0, -9}", row[column]);
                        colNum++;

                        if (colNum == dt.Columns.Count)
                        {
                            Console.WriteLine();
                            colNum = 0;
                        }
                    }
                }

                Console.WriteLine("\nEncounter contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");

                // EncounterType Table
                query = "SELECT * FROM ENCOUNTERTYPE";
                cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\n\nEncounterType\n--------------");
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write("{0, -9}", row[column]);
                        colNum++;

                        if (colNum == dt.Columns.Count)
                        {
                            Console.WriteLine();
                            colNum = 0;
                        }
                    }
                }

                Console.WriteLine("\nEncounter Type contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");

                // Questions Table
                query = "SELECT * FROM QUESTIONS";
                cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\n\nQuestions\n----------");
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write("{0, -9}", row[column]);
                        colNum++;

                        if (colNum == dt.Columns.Count)
                        {
                            Console.WriteLine();
                            colNum = 0;
                        }
                    }
                }

                Console.WriteLine("\nQuestions contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");

                // Choices Table
                query = "SELECT * FROM CHOICES";
                cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\n\nChoices\n--------");
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write("{0, -15}", row[column]);
                        colNum++;

                        if (colNum == dt.Columns.Count)
                        {
                            Console.WriteLine();
                            colNum = 0;
                        }
                    }
                }

                Console.WriteLine("\nChoices contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");
            }

            connectMe.Close();
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}