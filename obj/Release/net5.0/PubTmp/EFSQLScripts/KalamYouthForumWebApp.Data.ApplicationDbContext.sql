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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'00000000000000_CreateIdentitySchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'00000000000000_CreateIdentitySchema', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210626104454_Project')
BEGIN
    CREATE TABLE [Project] (
        [ProjectIDKey] int NOT NULL IDENTITY,
        [Heading] nvarchar(max) NULL,
        [Content] nvarchar(max) NULL,
        [ImagePath1] nvarchar(max) NULL,
        [ImagePath2] nvarchar(max) NULL,
        [ImagePath3] nvarchar(max) NULL,
        [ImagePath4] nvarchar(max) NULL,
        [ImagePath5] nvarchar(max) NULL,
        [FilePath] nvarchar(max) NULL,
        CONSTRAINT [PK_Project] PRIMARY KEY ([ProjectIDKey])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210626104454_Project')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210626104454_Project', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627042826_image-upload')
BEGIN
    CREATE TABLE [Images] (
        [Id] int NOT NULL IDENTITY,
        [ImageTitle] nvarchar(max) NULL,
        [ImageData] varbinary(max) NULL,
        CONSTRAINT [PK_Images] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627042826_image-upload')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210627042826_image-upload', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627045221_image-upload-url')
BEGIN
    ALTER TABLE [Images] ADD [ImageDataURL] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627045221_image-upload-url')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210627045221_image-upload-url', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'ImagePath1');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Project] DROP COLUMN [ImagePath1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'ImagePath2');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Project] DROP COLUMN [ImagePath2];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'ImagePath3');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Project] DROP COLUMN [ImagePath3];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'ImagePath4');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Project] DROP COLUMN [ImagePath4];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Project]') AND [c].[name] = N'ImagePath5');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Project] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Project] DROP COLUMN [ImagePath5];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    ALTER TABLE [Images] ADD [ProjectIDKey] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    CREATE INDEX [IX_Images_ProjectIDKey] ON [Images] ([ProjectIDKey]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    ALTER TABLE [Images] ADD CONSTRAINT [FK_Images_Project_ProjectIDKey] FOREIGN KEY ([ProjectIDKey]) REFERENCES [Project] ([ProjectIDKey]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627053002_image-projects')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210627053002_image-projects', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627061903_projectXimages')
BEGIN
    ALTER TABLE [Images] DROP CONSTRAINT [FK_Images_Project_ProjectIDKey];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627061903_projectXimages')
BEGIN
    DROP INDEX [IX_Images_ProjectIDKey] ON [Images];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627061903_projectXimages')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Images]') AND [c].[name] = N'ProjectIDKey');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Images] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Images] DROP COLUMN [ProjectIDKey];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627061903_projectXimages')
BEGIN
    CREATE TABLE [ImageProject] (
        [ImagesId] int NOT NULL,
        [ProjectsProjectIDKey] int NOT NULL,
        CONSTRAINT [PK_ImageProject] PRIMARY KEY ([ImagesId], [ProjectsProjectIDKey]),
        CONSTRAINT [FK_ImageProject_Images_ImagesId] FOREIGN KEY ([ImagesId]) REFERENCES [Images] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ImageProject_Project_ProjectsProjectIDKey] FOREIGN KEY ([ProjectsProjectIDKey]) REFERENCES [Project] ([ProjectIDKey]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627061903_projectXimages')
BEGIN
    CREATE INDEX [IX_ImageProject_ProjectsProjectIDKey] ON [ImageProject] ([ProjectsProjectIDKey]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210627061903_projectXimages')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210627061903_projectXimages', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210704180711_role-add')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210704180711_role-add', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210705162432_roles')
BEGIN
    CREATE TABLE [RoleViewModel] (
        [Id] nvarchar(450) NOT NULL,
        [RoleName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_RoleViewModel] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210705162432_roles')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210705162432_roles', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706044414_user-detail-update')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706044414_user-detail-update', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050054_user-detail-update-2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706050054_user-detail-update-2', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BloodGroup] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [District] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Dob] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Gender] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [LocalBody] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [State] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706050557_user-detail-update-3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706050557_user-detail-update-3', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706054054_chapter-she')
BEGIN
    CREATE TABLE [chapterModels] (
        [ChapterID] int NOT NULL IDENTITY,
        [Panchayat] nvarchar(100) NOT NULL,
        [Muncipality] nvarchar(100) NOT NULL,
        [Taluk] nvarchar(100) NOT NULL,
        [Constituency] nvarchar(100) NOT NULL,
        [OfficeAddress] nvarchar(500) NOT NULL,
        CONSTRAINT [PK_chapterModels] PRIMARY KEY ([ChapterID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706054054_chapter-she')
BEGIN
    CREATE TABLE [sheModels] (
        [SHEId] int NOT NULL IDENTITY,
        [SHEName] nvarchar(50) NOT NULL,
        [DateOfFormation] datetime2 NOT NULL,
        [NumberOfMembers] int NOT NULL,
        [ElectedPresident] nvarchar(100) NOT NULL,
        [PresidentEmail] nvarchar(max) NOT NULL,
        [PresidentPhoneNumber] nvarchar(max) NOT NULL,
        [ElectedSecretary] nvarchar(100) NOT NULL,
        [SecretaryEmail] nvarchar(max) NOT NULL,
        [SecretaryPhoneNumber] nvarchar(max) NOT NULL,
        [ElectedTreasurer] nvarchar(100) NOT NULL,
        [TreasurerEmail] nvarchar(max) NOT NULL,
        [TreasurerPhoneNumber] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_sheModels] PRIMARY KEY ([SHEId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706054054_chapter-she')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706054054_chapter-she', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706061414_chapterXshe')
BEGIN
    ALTER TABLE [sheModels] ADD [ChapterModelsChapterID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706061414_chapterXshe')
BEGIN
    CREATE INDEX [IX_sheModels_ChapterModelsChapterID] ON [sheModels] ([ChapterModelsChapterID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706061414_chapterXshe')
BEGIN
    ALTER TABLE [sheModels] ADD CONSTRAINT [FK_sheModels_chapterModels_ChapterModelsChapterID] FOREIGN KEY ([ChapterModelsChapterID]) REFERENCES [chapterModels] ([ChapterID]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706061414_chapterXshe')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706061414_chapterXshe', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706062713_Chapter1SheMultiple')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706062713_Chapter1SheMultiple', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706082422_shexchapter-2')
BEGIN
    ALTER TABLE [sheModels] DROP CONSTRAINT [FK_sheModels_chapterModels_ChapterModelsChapterID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706082422_shexchapter-2')
BEGIN
    DROP INDEX [IX_sheModels_ChapterModelsChapterID] ON [sheModels];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706082422_shexchapter-2')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[sheModels]') AND [c].[name] = N'ChapterModelsChapterID');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [sheModels] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [sheModels] DROP COLUMN [ChapterModelsChapterID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706082422_shexchapter-2')
BEGIN
    CREATE TABLE [ChapterModelSHEModel] (
        [ChapterModelsChapterID] int NOT NULL,
        [SHEModelsSHEId] int NOT NULL,
        CONSTRAINT [PK_ChapterModelSHEModel] PRIMARY KEY ([ChapterModelsChapterID], [SHEModelsSHEId]),
        CONSTRAINT [FK_ChapterModelSHEModel_chapterModels_ChapterModelsChapterID] FOREIGN KEY ([ChapterModelsChapterID]) REFERENCES [chapterModels] ([ChapterID]) ON DELETE CASCADE,
        CONSTRAINT [FK_ChapterModelSHEModel_sheModels_SHEModelsSHEId] FOREIGN KEY ([SHEModelsSHEId]) REFERENCES [sheModels] ([SHEId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706082422_shexchapter-2')
BEGIN
    CREATE INDEX [IX_ChapterModelSHEModel_SHEModelsSHEId] ON [ChapterModelSHEModel] ([SHEModelsSHEId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706082422_shexchapter-2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706082422_shexchapter-2', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706102049_user-registration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706102049_user-registration', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706154243_project-dateofpublish')
BEGIN
    ALTER TABLE [Project] ADD [DateOfPublish] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210706154243_project-dateofpublish')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210706154243_project-dateofpublish', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707061552_shgMembers')
BEGIN
    CREATE TABLE [shgMembers] (
        [SHGMemberId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Dob] datetime2 NOT NULL,
        [address] nvarchar(500) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone1] nvarchar(max) NOT NULL,
        [Phone2] nvarchar(max) NOT NULL,
        [BloodGroup] int NOT NULL,
        [Gender] int NOT NULL,
        [SHEId] int NOT NULL,
        CONSTRAINT [PK_shgMembers] PRIMARY KEY ([SHGMemberId]),
        CONSTRAINT [FK_shgMembers_sheModels_SHEId] FOREIGN KEY ([SHEId]) REFERENCES [sheModels] ([SHEId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707061552_shgMembers')
BEGIN
    CREATE INDEX [IX_shgMembers_SHEId] ON [shgMembers] ([SHEId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707061552_shgMembers')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210707061552_shgMembers', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    ALTER TABLE [chapterModels] ADD [UserXChapterId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [UserXChapterId] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    CREATE TABLE [UserXChapters] (
        [Id] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_UserXChapters] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    CREATE INDEX [IX_chapterModels_UserXChapterId] ON [chapterModels] ([UserXChapterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    CREATE INDEX [IX_AspNetUsers_UserXChapterId] ON [AspNetUsers] ([UserXChapterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_UserXChapters_UserXChapterId] FOREIGN KEY ([UserXChapterId]) REFERENCES [UserXChapters] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    ALTER TABLE [chapterModels] ADD CONSTRAINT [FK_chapterModels_UserXChapters_UserXChapterId] FOREIGN KEY ([UserXChapterId]) REFERENCES [UserXChapters] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707184745_userXchapter')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210707184745_userXchapter', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    ALTER TABLE [AspNetUsers] DROP CONSTRAINT [FK_AspNetUsers_UserXChapters_UserXChapterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    ALTER TABLE [chapterModels] DROP CONSTRAINT [FK_chapterModels_UserXChapters_UserXChapterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    DROP INDEX [IX_chapterModels_UserXChapterId] ON [chapterModels];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    DROP INDEX [IX_AspNetUsers_UserXChapterId] ON [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[chapterModels]') AND [c].[name] = N'UserXChapterId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [chapterModels] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [chapterModels] DROP COLUMN [UserXChapterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'UserXChapterId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [UserXChapterId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    ALTER TABLE [UserXChapters] ADD [ChapterID] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    ALTER TABLE [UserXChapters] ADD [UserID] nvarchar(450) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    CREATE INDEX [IX_UserXChapters_ChapterID] ON [UserXChapters] ([ChapterID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    CREATE INDEX [IX_UserXChapters_UserID] ON [UserXChapters] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    ALTER TABLE [UserXChapters] ADD CONSTRAINT [FK_UserXChapters_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    ALTER TABLE [UserXChapters] ADD CONSTRAINT [FK_UserXChapters_chapterModels_ChapterID] FOREIGN KEY ([ChapterID]) REFERENCES [chapterModels] ([ChapterID]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210707190757_userXchapter-1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210707190757_userXchapter-1', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708040017_chapterModel-chapterName')
BEGIN
    ALTER TABLE [chapterModels] ADD [ChapterName] nvarchar(100) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708040017_chapterModel-chapterName')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708040017_chapterModel-chapterName', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708041904_chapterXuser-remove')
BEGIN
    DROP TABLE [UserXChapters];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708041904_chapterXuser-remove')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708041904_chapterXuser-remove', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708041943_chapterXuser-add')
BEGIN
    CREATE TABLE [UserXChapters] (
        [Id] int NOT NULL IDENTITY,
        [UserID] nvarchar(450) NULL,
        [ChapterID] int NOT NULL,
        CONSTRAINT [PK_UserXChapters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserXChapters_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_UserXChapters_chapterModels_ChapterID] FOREIGN KEY ([ChapterID]) REFERENCES [chapterModels] ([ChapterID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708041943_chapterXuser-add')
BEGIN
    CREATE INDEX [IX_UserXChapters_ChapterID] ON [UserXChapters] ([ChapterID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708041943_chapterXuser-add')
BEGIN
    CREATE INDEX [IX_UserXChapters_UserID] ON [UserXChapters] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708041943_chapterXuser-add')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708041943_chapterXuser-add', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708043449_shgXuser-1')
BEGIN
    CREATE TABLE [UserXSHGs] (
        [Id] int NOT NULL IDENTITY,
        [UserID] nvarchar(450) NULL,
        [SHGID] int NOT NULL,
        CONSTRAINT [PK_UserXSHGs] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserXSHGs_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_UserXSHGs_sheModels_SHGID] FOREIGN KEY ([SHGID]) REFERENCES [sheModels] ([SHEId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708043449_shgXuser-1')
BEGIN
    CREATE INDEX [IX_UserXSHGs_SHGID] ON [UserXSHGs] ([SHGID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708043449_shgXuser-1')
BEGIN
    CREATE INDEX [IX_UserXSHGs_UserID] ON [UserXSHGs] ([UserID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708043449_shgXuser-1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708043449_shgXuser-1', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708055559_updating-SHe')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708055559_updating-SHe', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708072359_news-letter-user')
BEGIN
    CREATE TABLE [newsletterLists] (
        [Id] int NOT NULL IDENTITY,
        [EmailID] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_newsletterLists] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210708072359_news-letter-user')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210708072359_news-letter-user', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710194003_SHGMemberStateDistrict')
BEGIN
    ALTER TABLE [shgMembers] ADD [District] nvarchar(100) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710194003_SHGMemberStateDistrict')
BEGIN
    ALTER TABLE [shgMembers] ADD [State] nvarchar(100) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710194003_SHGMemberStateDistrict')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210710194003_SHGMemberStateDistrict', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710200206_SHGMemberDonationConfirm')
BEGIN
    ALTER TABLE [shgMembers] ADD [BloodDonation] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210710200206_SHGMemberDonationConfirm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210710200206_SHGMemberDonationConfirm', N'5.0.7');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711020139_user-table-blood-confirm')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [BloodDonation] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210711020139_user-table-blood-confirm')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210711020139_user-table-blood-confirm', N'5.0.7');
END;
GO

COMMIT;
GO

