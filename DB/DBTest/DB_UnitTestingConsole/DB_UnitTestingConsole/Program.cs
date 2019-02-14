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

                Console.WriteLine("\nEncounter contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");

                // EncounterType Table
                query = "SELECT * FROM ENCOUNTERTYPE";
                cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\nEncounter Type contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");

                // Questions Table
                query = "SELECT * FROM QUESTIONS";
                cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\nQuestions contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");

                // Choices Table
                query = "SELECT * FROM CHOICES";
                cmd = new SqlCommand(query, connectMe);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("\nChoices contains " + dt.Rows.Count + " rows and " + dt.Columns.Count + " columns.");
            }

            connectMe.Close();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}