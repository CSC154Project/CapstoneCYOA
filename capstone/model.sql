CREATE TABLE [dbo].[Choices] (
    [EncID]      INT            NOT NULL,
    [ID]         INT            NOT NULL,
    [QuestionID] INT            NOT NULL,
    [Text]       NVARCHAR (MAX) NULL,
    [NextEID]    INT            NOT NULL
);

GO
CREATE TABLE [dbo].[Encounter] (
    [EncounterID]     INT NOT NULL,
    [EncounterTypeID] INT NOT NULL
);

GO
CREATE TABLE [dbo].[EncounterType] (
    [ID]          INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL
);

GO
CREATE TABLE [dbo].[Questions] (
    [EncID] INT            NOT NULL,
    [ID]    INT            NOT NULL,
    [Text]  NVARCHAR (MAX) NULL
);

GO
ALTER TABLE [dbo].[Choices]
    ADD CONSTRAINT [FK_Choices_EncounterID] FOREIGN KEY ([EncID]) REFERENCES [dbo].[Encounter] ([EncounterID]);

GO
ALTER TABLE [dbo].[Choices]
    ADD CONSTRAINT [FK_Choices_NextEID] FOREIGN KEY ([NextEID]) REFERENCES [dbo].[Encounter] ([EncounterID]);

GO
ALTER TABLE [dbo].[Choices]
    ADD CONSTRAINT [FK_Choices_Questions] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([ID]);

GO
ALTER TABLE [dbo].[Encounter]
    ADD CONSTRAINT [FK_Encounter_EncounterType] FOREIGN KEY ([EncounterTypeID]) REFERENCES [dbo].[EncounterType] ([ID]);

GO
ALTER TABLE [dbo].[Questions]
    ADD CONSTRAINT [FK_Questions_Encounter] FOREIGN KEY ([EncID]) REFERENCES [dbo].[Encounter] ([EncounterID]);

GO
ALTER TABLE [dbo].[Choices]
    ADD CONSTRAINT [PK_Choices] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Encounter]
    ADD CONSTRAINT [PK_Encounter] PRIMARY KEY CLUSTERED ([EncounterID] ASC);

GO
ALTER TABLE [dbo].[EncounterType]
    ADD CONSTRAINT [PK_EncounterType] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
ALTER TABLE [dbo].[Questions]
    ADD CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([ID] ASC);

GO
