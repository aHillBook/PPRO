CREATE TABLE [dbo].[seznamTerminu] (
    [idTerminu]        INT           IDENTITY (1, 1) NOT NULL,
    [terminKonani]     DATETIME2 (7) NOT NULL,
    [dobaTrvani]       INT           NOT NULL,
    [skoleniidSkoleni] INT           NULL,
    [jazykidJazyka]    INT           NULL,
    CONSTRAINT [PK_seznamTerminu] PRIMARY KEY CLUSTERED ([idTerminu] ASC),
    CONSTRAINT [FK_seznamTerminu_seznamJazyku_jazykidJazyka] FOREIGN KEY ([jazykidJazyka]) REFERENCES [dbo].[seznamJazyku] ([idJazyka]),
    CONSTRAINT [FK_seznamTerminu_seznamSkoleni_skoleniidSkoleni] FOREIGN KEY ([skoleniidSkoleni]) REFERENCES [dbo].[seznamSkoleni] ([idSkoleni])
);


GO
CREATE NONCLUSTERED INDEX [IX_seznamTerminu_skoleniidSkoleni]
    ON [dbo].[seznamTerminu]([skoleniidSkoleni] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_seznamTerminu_jazykidJazyka]
    ON [dbo].[seznamTerminu]([jazykidJazyka] ASC);

