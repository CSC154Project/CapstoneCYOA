/*
	NOTE: Run this file first
*/

/*
	Table Name: EncounterType

	Description:
		Insert the values for the ID Column and Description Column

		   ID		Description
		--------------------------
			1		question
			2		conversation
			3		narrative
*/
INSERT INTO dbo.EncounterType (ID, Description) VALUES 
	(1, 'question'), (2, 'conversation'), (3, 'narrative');


/*
	Table Name: Encounter

	Description:
		Inserts the EncounterTypeID into the Encounter table

		ID (PK)		EncounterTypeId (FK)
		--------------------------------
			1						3
			2						1
			3						2
			4						1
			5						1
			6						2
			7						2
			8						2
			9						3
			10						2
*/
INSERT INTO dbo.Encounter (EncounterID, EncounterTypeID) VALUES
	(1, 3), (2, 1), (3, 2), (4, 1), (5, 1), 
	(6, 2), (7, 2), (8, 2), (9, 3), (10, 2);


/*
	Table Name: Questions
	Description:
		Inserts EncID, ID, Text

	EncID (FK)		ID (PK)		Text
	-------------------------------------------
		1				1		Narrative
		2				2		How are you?
		3				3		Question A
		4				4		Question B
		5				5		Question C
		6				6		Question D
		7				7		Question E
		8				8		Question F
		9				9		Question G
		10				10		Question H

*/
INSERT INTO dbo.Questions (EncID, ID, Text) VALUES 
	(1, 1, 'Narrative'), (2, 2, 'How are you?'), (3, 3, 'Question A'), (4, 4, 'Question B'), (5, 5, 'Question C'),
	(6, 6, 'Question D'), (7, 7, 'Question E'), (8, 8, 'Question F'), (9, 9, 'Question G'), (10, 10, 'Question H');


/*
	Table Name: Choices

	Description:
		Inserts EncID, ID, QuestionID, Text, NextEID

		EncID (FK)		ID (PK)		QuestionId (FK)		Text		NextId (FK)
		------------------------------------------------------------------------
			1				1					1		Continue			2
			2				2					2		Im Fine				3
			2				3					2		Im Not Fine			4
			2				4					2		Choice A			5
			3				5					3		Choice B			6
			3				6					3		Choice C			7
			3				7					3		Choice D			8
			1				8					1		Choice E			9
			1				9					1		Choice F			10

*/
INSERT INTO dbo.Choices (EncID, ID, QuestionID, Text, NextEID) VALUES
	(1, 1, 1, 'Continue', 2), (2, 2, 2, 'Im Fine', 3), (2, 3, 2, 'Im Not Fine', 4),
	(2, 4, 2, 'Choice A', 5), (3, 5, 3, 'Choice B', 6), (3, 6, 3, 'Choice C', 7),
	(3, 7, 3, 'Choice D', 8), (1, 8, 1, 'Choice E', 9), (1, 9, 1, 'Choice F', 10);