CREATE TABLE [dbo].[seznamMistnosti] (
    [idMistnosti] INT            IDENTITY (1, 1) NOT NULL,
    [nazev]       NVARCHAR (MAX) NULL,
    [kapacita]    INT            NOT NULL,
    CONSTRAINT [PK_seznamMistnosti] PRIMARY KEY CLUSTERED ([idMistnosti] ASC)
);

