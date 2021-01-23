IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Bills] (
    [Id] bigint NOT NULL IDENTITY,
    [Ref] nvarchar(max) NULL,
    [RefDeb] int NOT NULL,
    [Objet] nvarchar(max) NULL,
    [Total] float NOT NULL,
    [ModeR] int NOT NULL,
    [Date] nvarchar(max) NULL,
    [mDate] datetime2 NOT NULL,
    [DateP] nvarchar(max) NULL,
    [ClientId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Bills] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Clients] (
    [Id] bigint NOT NULL IDENTITY,
    [Statut] int NOT NULL,
    [Societe] nvarchar(max) NULL,
    [Civil] int NOT NULL,
    [Nom] nvarchar(max) NULL,
    [Prenom] nvarchar(max) NULL,
    [Adresse] nvarchar(max) NULL,
    [Pays] nvarchar(max) NULL,
    [CP] nvarchar(max) NULL,
    [Ville] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Tel] nvarchar(max) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Estimates] (
    [Id] bigint NOT NULL IDENTITY,
    [Ref] nvarchar(max) NULL,
    [RefDeb] int NOT NULL,
    [Objet] nvarchar(max) NULL,
    [Total] float NOT NULL,
    [ModeR] int NOT NULL,
    [Date] nvarchar(max) NULL,
    [mDate] datetime2 NOT NULL,
    [DateP] nvarchar(max) NULL,
    [ClientId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Estimates] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200409095730_Initial', N'3.1.3');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estimates]') AND [c].[name] = N'Ref');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Estimates] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Estimates] DROP COLUMN [Ref];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estimates]') AND [c].[name] = N'RefDeb');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Estimates] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Estimates] DROP COLUMN [RefDeb];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'Ref');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Bills] DROP COLUMN [Ref];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'RefDeb');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Bills] DROP COLUMN [RefDeb];

GO

ALTER TABLE [Estimates] ADD [Num] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Estimates] ADD [Year] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Bills] ADD [Num] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Bills] ADD [Year] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200409103537_UpdateRef', N'3.1.3');

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estimates]') AND [c].[name] = N'mDate');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Estimates] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Estimates] DROP COLUMN [mDate];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'mDate');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Bills] DROP COLUMN [mDate];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estimates]') AND [c].[name] = N'DateP');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Estimates] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Estimates] ALTER COLUMN [DateP] datetime2 NOT NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estimates]') AND [c].[name] = N'Date');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Estimates] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Estimates] ALTER COLUMN [Date] datetime2 NOT NULL;

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Estimates]') AND [c].[name] = N'ClientId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Estimates] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Estimates] ALTER COLUMN [ClientId] bigint NOT NULL;

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'DateP');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Bills] ALTER COLUMN [DateP] datetime2 NOT NULL;

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'Date');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Bills] ALTER COLUMN [Date] datetime2 NOT NULL;

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bills]') AND [c].[name] = N'ClientId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Bills] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Bills] ALTER COLUMN [ClientId] bigint NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200412161445_UpdateClientId', N'3.1.3');

GO

CREATE TABLE [BillsWordings] (
    [Id] bigint NOT NULL IDENTITY,
    [BillId] bigint NOT NULL,
    [WordingId] bigint NOT NULL,
    CONSTRAINT [PK_BillsWordings] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [EstimatesWordings] (
    [Id] bigint NOT NULL IDENTITY,
    [EstimateId] bigint NOT NULL,
    [WordingId] bigint NOT NULL,
    CONSTRAINT [PK_EstimatesWordings] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Wordings] (
    [Id] bigint NOT NULL IDENTITY,
    [Quantite] real NOT NULL,
    [PrixU] real NOT NULL,
    [Content] nvarchar(max) NULL,
    [BillId] bigint NULL,
    [EstimateId] bigint NULL,
    CONSTRAINT [PK_Wordings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Wordings_Bills_BillId] FOREIGN KEY ([BillId]) REFERENCES [Bills] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Wordings_Estimates_EstimateId] FOREIGN KEY ([EstimateId]) REFERENCES [Estimates] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Wordings_BillId] ON [Wordings] ([BillId]);

GO

CREATE INDEX [IX_Wordings_EstimateId] ON [Wordings] ([EstimateId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200512210244_addWordings', N'3.1.3');

GO

