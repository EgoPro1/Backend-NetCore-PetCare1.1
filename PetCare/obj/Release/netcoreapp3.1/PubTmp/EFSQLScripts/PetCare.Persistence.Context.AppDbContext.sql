IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Providers] (
        [Id] int NOT NULL IDENTITY,
        [BusinessName] nvarchar(30) NOT NULL,
        [Region] nvarchar(30) NOT NULL,
        [Field] nvarchar(30) NOT NULL,
        [Address] nvarchar(30) NOT NULL,
        [Email] nvarchar(30) NOT NULL,
        [Description] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Providers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Publish] bit NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [SubscriptionPlans] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] float NOT NULL,
        [Duration] int NOT NULL,
        CONSTRAINT [PK_SubscriptionPlans] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [TypeProducts] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_TypeProducts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Payments] (
        [Id] int NOT NULL IDENTITY,
        [Number] bigint NOT NULL,
        [Name] nvarchar(30) NOT NULL,
        [CVV] int NOT NULL,
        [DateOfExpiry] nvarchar(8) NOT NULL,
        [ServicesProviderForeignKey] int NOT NULL,
        CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Payments_Providers_ServicesProviderForeignKey] FOREIGN KEY ([ServicesProviderForeignKey]) REFERENCES [Providers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Accounts] (
        [Id] int NOT NULL IDENTITY,
        [User] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [RolId] int NOT NULL,
        [SubscriptionPlanId] int NOT NULL,
        CONSTRAINT [PK_Accounts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Accounts_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Accounts_SubscriptionPlans_SubscriptionPlanId] FOREIGN KEY ([SubscriptionPlanId]) REFERENCES [SubscriptionPlans] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [ProviderJoinProducts] (
        [Id] int NOT NULL IDENTITY,
        [ProviderId] int NOT NULL,
        [TypeProductId] int NOT NULL,
        CONSTRAINT [PK_ProviderJoinProducts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProviderJoinProducts_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [Providers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ProviderJoinProducts_TypeProducts_TypeProductId] FOREIGN KEY ([TypeProductId]) REFERENCES [TypeProducts] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [BusinessProfiles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Age] int NOT NULL,
        [Phone] bigint NOT NULL,
        [Password] nvarchar(max) NULL,
        [Document] bigint NOT NULL,
        [AccountId] int NOT NULL,
        [ProviderId] int NOT NULL,
        [Owner] bit NOT NULL,
        CONSTRAINT [PK_BusinessProfiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BusinessProfiles_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BusinessProfiles_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [Providers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [PersonProfiles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(30) NOT NULL,
        [LastName] nvarchar(30) NOT NULL,
        [Email] nvarchar(max) NULL,
        [Age] int NOT NULL,
        [Phone] bigint NOT NULL,
        [Password] nvarchar(max) NULL,
        [Document] bigint NOT NULL,
        [AccountId] int NOT NULL,
        CONSTRAINT [PK_PersonProfiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PersonProfiles_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [PJPId] int NOT NULL,
        [TypeProductId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_ProviderJoinProducts_PJPId] FOREIGN KEY ([PJPId]) REFERENCES [ProviderJoinProducts] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Pets] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(30) NOT NULL,
        [Age] nvarchar(max) NOT NULL,
        [Breed] nvarchar(30) NOT NULL,
        [Photo] nvarchar(50) NOT NULL,
        [Sex] nvarchar(50) NOT NULL,
        [PersonProfileId] int NOT NULL,
        CONSTRAINT [PK_Pets] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Pets_PersonProfiles_PersonProfileId] FOREIGN KEY ([PersonProfileId]) REFERENCES [PersonProfiles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Reviews] (
        [Id] int NOT NULL IDENTITY,
        [Qualification] int NOT NULL,
        [Commentary] nvarchar(50) NOT NULL,
        [PersonProfileId] int NOT NULL,
        [ProviderId] int NOT NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Reviews_PersonProfiles_PersonProfileId] FOREIGN KEY ([PersonProfileId]) REFERENCES [PersonProfiles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Reviews_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [Providers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Availabilities] (
        [Id] int NOT NULL IDENTITY,
        [DayAvailability] nvarchar(max) NULL,
        [StartTime] nvarchar(max) NULL,
        [EndTime] nvarchar(max) NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_Availabilities] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Availabilities_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [Requests] (
        [Id] int NOT NULL IDENTITY,
        [EndTime] nvarchar(max) NULL,
        [ProviderId] int NOT NULL,
        [ProductTypeId] int NOT NULL,
        [PetId] int NOT NULL,
        [PersonProfileId] int NOT NULL,
        [ProductId] int NOT NULL,
        [VeterinaryName] nvarchar(max) NULL,
        [ProductTypeName] nvarchar(max) NULL,
        [ProductName] nvarchar(max) NULL,
        [PetName] nvarchar(max) NULL,
        [DateReservation] datetime2 NOT NULL,
        [StartTime] nvarchar(max) NULL,
        [Status] int NOT NULL,
        [PersonName] nvarchar(max) NULL,
        CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Requests_PersonProfiles_PersonProfileId] FOREIGN KEY ([PersonProfileId]) REFERENCES [PersonProfiles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Requests_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [MedicalProfiles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Weight] nvarchar(max) NULL,
        [Height] nvarchar(max) NULL,
        [Lenght] nvarchar(max) NULL,
        [Eyes] nvarchar(max) NULL,
        [Breed] nvarchar(max) NULL,
        [Sex] nvarchar(max) NULL,
        [Color] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Photo] nvarchar(max) NULL,
        [Age] nvarchar(max) NULL,
        [ProviderId] int NOT NULL,
        [PetId] int NOT NULL,
        CONSTRAINT [PK_MedicalProfiles] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MedicalProfiles_Pets_PetId] FOREIGN KEY ([PetId]) REFERENCES [Pets] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_MedicalProfiles_Providers_ProviderId] FOREIGN KEY ([ProviderId]) REFERENCES [Providers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [MedicalRecords] (
        [Id] int NOT NULL IDENTITY,
        [CreateAt] datetime2 NOT NULL,
        [Description] nvarchar(max) NULL,
        [Type] nvarchar(max) NULL,
        [Action] nvarchar(max) NULL,
        [MedicalProfileId] int NOT NULL,
        CONSTRAINT [PK_MedicalRecords] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MedicalRecords_MedicalProfiles_MedicalProfileId] FOREIGN KEY ([MedicalProfileId]) REFERENCES [MedicalProfiles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE TABLE [VaccinationRecords] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Create_at] datetime2 NOT NULL,
        [ProfileId] int NOT NULL,
        CONSTRAINT [PK_VaccinationRecords] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_VaccinationRecords_MedicalProfiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [MedicalProfiles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Publish') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    INSERT INTO [Roles] ([Id], [Description], [Name], [Publish])
    VALUES (1, N'Busca veterinarias', N'Usuario', CAST(0 AS bit)),
    (2, N'Ofrece Servicios', N'ServicesProvider', CAST(1 AS bit));
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name', N'Publish') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Duration', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[SubscriptionPlans]'))
        SET IDENTITY_INSERT [SubscriptionPlans] ON;
    INSERT INTO [SubscriptionPlans] ([Id], [Description], [Duration], [Name], [Price])
    VALUES (1, N'Plan Free', 1, N'Free', 0.0E0),
    (2, N'Plan Basico', 1, N'Basica', 19.899999999999999E0),
    (3, N'Plan Premium', 1, N'Premium', 39.899999999999999E0);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Duration', N'Name', N'Price') AND [object_id] = OBJECT_ID(N'[SubscriptionPlans]'))
        SET IDENTITY_INSERT [SubscriptionPlans] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Accounts_RolId] ON [Accounts] ([RolId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Accounts_SubscriptionPlanId] ON [Accounts] ([SubscriptionPlanId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE UNIQUE INDEX [IX_Availabilities_ProductId] ON [Availabilities] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE UNIQUE INDEX [IX_BusinessProfiles_AccountId] ON [BusinessProfiles] ([AccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_BusinessProfiles_ProviderId] ON [BusinessProfiles] ([ProviderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE UNIQUE INDEX [IX_MedicalProfiles_PetId] ON [MedicalProfiles] ([PetId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_MedicalProfiles_ProviderId] ON [MedicalProfiles] ([ProviderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_MedicalRecords_MedicalProfileId] ON [MedicalRecords] ([MedicalProfileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE UNIQUE INDEX [IX_Payments_ServicesProviderForeignKey] ON [Payments] ([ServicesProviderForeignKey]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE UNIQUE INDEX [IX_PersonProfiles_AccountId] ON [PersonProfiles] ([AccountId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Pets_PersonProfileId] ON [Pets] ([PersonProfileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Products_PJPId] ON [Products] ([PJPId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_ProviderJoinProducts_ProviderId] ON [ProviderJoinProducts] ([ProviderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_ProviderJoinProducts_TypeProductId] ON [ProviderJoinProducts] ([TypeProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Requests_PersonProfileId] ON [Requests] ([PersonProfileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Requests_ProductId] ON [Requests] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Reviews_PersonProfileId] ON [Reviews] ([PersonProfileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_Reviews_ProviderId] ON [Reviews] ([ProviderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    CREATE INDEX [IX_VaccinationRecords_ProfileId] ON [VaccinationRecords] ([ProfileId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200701041816_ultimate5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200701041816_ultimate5', N'3.1.3');
END;

GO

