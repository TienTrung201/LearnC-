IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Articles] (
    [ArticleId] int NOT NULL IDENTITY,
    [Title] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([ArticleId])
);
GO

CREATE TABLE [Tags] (
    [TagId] nvarchar(20) NOT NULL,
    [Content] ntext NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230212091751_MgratV0', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Articles].[Title]', N'Name', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230212152439_V1', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Articles] ADD [Content] ntext NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230212153838_V2', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Tags] DROP CONSTRAINT [PK_Tags];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tags]') AND [c].[name] = N'TagId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tags] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tags] DROP COLUMN [TagId];
GO

ALTER TABLE [Tags] ADD [TagIDNew] int NOT NULL IDENTITY;
GO

ALTER TABLE [Tags] ADD CONSTRAINT [PK_Tags] PRIMARY KEY ([TagIDNew]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230212160217_removeTagID', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Tags].[TagIDNew]', N'TagID', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230212160856_V3ChangeTag', N'7.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [articletag] (
    [ArticleTagId] int NOT NULL IDENTITY,
    [TagID] int NOT NULL,
    [ArticleId] int NOT NULL,
    CONSTRAINT [PK_articletag] PRIMARY KEY ([ArticleTagId]),
    CONSTRAINT [FK_articletag_Articles_ArticleId] FOREIGN KEY ([ArticleId]) REFERENCES [Articles] ([ArticleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_articletag_Tags_TagID] FOREIGN KEY ([TagID]) REFERENCES [Tags] ([TagID]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_articletag_ArticleId_TagID] ON [articletag] ([ArticleId], [TagID]);
GO

CREATE INDEX [IX_articletag_TagID] ON [articletag] ([TagID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230212172937_V4', N'7.0.2');
GO

COMMIT;
GO

