/*
	----------WARNING------------------
		TESTING PURPOSES ONLY

		RUN AT YOUR OWN RISK

		DELETES THE ROWS
		FROM ALL THE TABLES

		ONLY USE AFTER YOU RUN THE 
		DummyDB_Inserts.sql SCRIPT

		YOU MAY GET A CONFLICT ERROR
		JUST TRY RUNNING THE SCRIPT
		AGAIN AND IT SHOULD WORK

	--------END WARNING-----------------
*/
BEGIN TRANSACTION;

DELETE FROM dbo.Questions;
DELETE FROM dbo.Encounter;
DELETE FROM dbo.EncounterType;
DELETE FROM dbo.Choices;

COMMIT;

/*
	Verify that no data remains in the rows
*/
SELECT * FROM dbo.Questions;
SELECT * FROM dbo.Encounter;
SELECT * FROM dbo.EncounterType;
SELECT * FROM dbo.Choices;