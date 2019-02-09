﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_UnitTestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a connection to the database
            CapstoneDBDataContext CapstoneDB = new CapstoneDBDataContext(Properties.Settings.Default.capstoneConnectionString);
            int flag = 0;

            // Check to make sure the database exists, 
            // If it does exist. Set flag to 1,
            // if it is still 0 the queries won't run
            if (CapstoneDB.DatabaseExists())
            {
                Console.WriteLine("The DB Exsists");
                flag = 1;
            }
            else
            {
                Console.WriteLine("The DB Does not Exsist");
                flag = 0;
            }

            if (flag == 1)
            {
                try
                {
                    // Run the query and store the results in the questionQuery variable.
                    // There is an issue with querying the "Question" table it will throw an exception
                    var questionQuery = CapstoneDB.ExecuteQuery<Encounter>(@"SELECT * FROM Encounter");

                    // Loop through the questionQuery list and print every single item
                    Console.WriteLine("EncID \t" + "EncTypeID");
                    foreach (Encounter encounter in questionQuery)
                        Console.WriteLine(encounter.EncounterID + "\t" + encounter.EncounterTypeID);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }   
            }

            Console.ReadKey();



        }
    }
}
