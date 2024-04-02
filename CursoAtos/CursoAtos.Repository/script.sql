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

CREATE TABLE [TbNoticia] (
    [NotCodigo] int NOT NULL IDENTITY,
    [NotTitulo] varchar(50) NOT NULL,
    [NotTexto] text NOT NULL,
    [NotUltimaAtualizacao] datetime NOT NULL,
    CONSTRAINT [PK_TbNoticia] PRIMARY KEY ([NotCodigo])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240402223553_CriacaoInicial', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TbNoticia] ADD [NotTeste] varchar NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240402224414_AddCampoTeste', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TbNoticia]') AND [c].[name] = N'NotTeste');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TbNoticia] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TbNoticia] DROP COLUMN [NotTeste];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TbNoticia]') AND [c].[name] = N'NotTexto');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TbNoticia] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TbNoticia] ALTER COLUMN [NotTexto] text NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240402224730_CorrecaoCampoTexto', N'8.0.3');
GO

COMMIT;
GO

