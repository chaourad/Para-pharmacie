CREATE TABLE [dbo].[Demmande] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [DateTime]      DATETIME NOT NULL,
    [FournisseurId] INT            NOT NULL,
    CONSTRAINT [PK_Demmande] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Demmande_Fournisseur_FournisseurId] FOREIGN KEY ([FournisseurId]) REFERENCES [dbo].[Fournisseur] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Demmande_FournisseurId]
    ON [dbo].[Demmande]([FournisseurId] ASC);

