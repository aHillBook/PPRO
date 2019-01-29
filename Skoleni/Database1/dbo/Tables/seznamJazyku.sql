CREATE TABLE [dbo].[seznamJazyku] (
    [idJazyka] INT            IDENTITY (1, 1) NOT NULL,
    [nazev]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_seznamJazyku] PRIMARY KEY CLUSTERED ([idJazyka] ASC)
);

