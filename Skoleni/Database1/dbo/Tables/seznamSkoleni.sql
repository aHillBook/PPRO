CREATE TABLE [dbo].[seznamSkoleni] (
    [idSkoleni] INT            IDENTITY (1, 1) NOT NULL,
    [nazev]     NVARCHAR (MAX) NULL,
    [popis]     NVARCHAR (MAX) NULL,
    [skolitel]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_seznamSkoleni] PRIMARY KEY CLUSTERED ([idSkoleni] ASC)
);

