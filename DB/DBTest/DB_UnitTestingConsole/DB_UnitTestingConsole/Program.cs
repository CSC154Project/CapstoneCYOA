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
            /*
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
             */



            DBConn.DBConn conn = new DBConn.DBConn();
            List<object> lstResult = conn.RunQuery("SELECT * FROM Choices", new DBConn.Choices());

            for (int i = 0; i < lstResult.Count; i++)
                Console.WriteLine(lstResult[i].ToString());
            Console.WriteLine("\n\n\n\nPress any key to exit.");
            Console.ReadKey();

        }

    }
}