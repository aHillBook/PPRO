CREATE TABLE [dbo].[seznamUzivatelu] (
    [idUzivatele] INT            IDENTITY (1, 1) NOT NULL,
    [jmeno]       NVARCHAR (MAX) NULL,
    [prijmeni]    NVARCHAR (MAX) NULL,
    [stredisko]   INT            NOT NULL,
    [email]       NVARCHAR (MAX) NULL,
    [idJazyka]    INT            NOT NULL,
    CONSTRAINT [PK_seznamUzivatelu] PRIMARY KEY CLUSTERED ([idUzivatele] ASC),
    CONSTRAINT [FK_seznamUzivatelu_seznamJazyku_idJazyka] FOREIGN KEY ([idJazyka]) REFERENCES [dbo].[seznamJazyku] ([idJazyka]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_seznamUzivatelu_idJazyka]
    ON [dbo].[seznamUzivatelu]([idJazyka] ASC);

