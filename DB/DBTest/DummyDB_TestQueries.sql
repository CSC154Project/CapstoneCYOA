/*
	Tests to ensure queries are outputting the correct data.
	Make sure to run the DummyDB_Inserts.sql script before running this file

	Test1: Basic queries
	Test2: Basic queries w/ conditions and conditional operators
		
-------------------------------------------------------------------------------------------------------------

	Test1: Basic queries

	Basic queries for all tables, i.e. SELECT all rows FROM table_name
	Verify that all rows have the same data as the Dummy data Google Sheets doc found here:
		https://docs.google.com/spreadsheets/d/1xf_nI0X_jiQ3drrmwdxFlHdJlySkUjuoqJlKyUik2ZE/edit?usp=sharing
*/
SELECT * FROM dbo.Choices;
SELECT * FROM dbo.Encounter;
SELECT * FROM dbo.EncounterType;
SELECT * FROM dbo.Questions;


/*
	Test2: Basic queries w/ conditions and conditional operators
	Similar to Test1, however there will be a WHERE statement added onto the end of the query
		i.e. SELECT column_name FROM table_name WHERE condition AND|OR condition
*/
SELECT EncID, QuestionID, Text, NextEID FROM dbo.Choices WHERE EncID = 2 AND NextEID > 4;
SELECT * FROM dbo.Questions WHERE EncID = 1 OR EncID = 3;