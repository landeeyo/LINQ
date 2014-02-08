/*
Deployment script for Linq2SQL
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Linq2SQL"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
USE [master]
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)] COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]
GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[Address]...';


GO
CREATE TABLE [dbo].[Address] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [buildingNumber] INT           NOT NULL,
    [dwellingNumber] INT           NOT NULL,
    [street]         VARCHAR (100) NULL,
    [cityId]         INT           NOT NULL,
    [countryId]      INT           NOT NULL
);


GO
PRINT N'Creating AddressIdPK...';


GO
ALTER TABLE [dbo].[Address]
    ADD CONSTRAINT [AddressIdPK] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[City]...';


GO
CREATE TABLE [dbo].[City] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (100) NOT NULL
);


GO
PRINT N'Creating CityIdPK...';


GO
ALTER TABLE [dbo].[City]
    ADD CONSTRAINT [CityIdPK] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Country]...';


GO
CREATE TABLE [dbo].[Country] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] VARCHAR (100) NULL
);


GO
PRINT N'Creating CountryIdPK...';


GO
ALTER TABLE [dbo].[Country]
    ADD CONSTRAINT [CountryIdPK] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Person]...';


GO
CREATE TABLE [dbo].[Person] (
    [id]        INT          IDENTITY (1, 1) NOT NULL,
    [surname]   VARCHAR (50) NOT NULL,
    [firstname] VARCHAR (50) NOT NULL,
    [addressId] INT          NOT NULL
);


GO
PRINT N'Creating PersonIdPK...';


GO
ALTER TABLE [dbo].[Person]
    ADD CONSTRAINT [PersonIdPK] PRIMARY KEY CLUSTERED ([id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating CityIdFK...';


GO
ALTER TABLE [dbo].[Address] WITH NOCHECK
    ADD CONSTRAINT [CityIdFK] FOREIGN KEY ([cityId]) REFERENCES [dbo].[City] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating CountryIdFK...';


GO
ALTER TABLE [dbo].[Address] WITH NOCHECK
    ADD CONSTRAINT [CountryIdFK] FOREIGN KEY ([countryId]) REFERENCES [dbo].[Country] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating AddressIdFK...';


GO
ALTER TABLE [dbo].[Person] WITH NOCHECK
    ADD CONSTRAINT [AddressIdFK] FOREIGN KEY ([addressId]) REFERENCES [dbo].[Address] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


print 'Populating database tables...'

insert into City values('London');
insert into City values('New York');
insert into City values('Ottawa');
insert into City values('Dublin');

insert into Country values('United Kingdom');
insert into Country values('USA');
insert into Country values('Canada');
insert into Country values('Ireland');

insert into Address values(1,2,'Darwin Road',1,1);
insert into Address values(6,4,'Windmill Road',1,1);
insert into Address values(8,9,'Pleasant Park Road',3,3);
insert into Address values(5,3,'LexingtonAvenue',2,2);
insert into Address values(7,1,'Rothe Abbey',4,4);

insert into Person values('Caroll','Lewis', 1);
insert into Person values('Orwell','George', 2);
insert into Person values('Gibson','William', 3);
insert into Person values('Dick','Philip K.', 4);
insert into Person values('Joyce','James', 5);

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Address] WITH CHECK CHECK CONSTRAINT [CityIdFK];

ALTER TABLE [dbo].[Address] WITH CHECK CHECK CONSTRAINT [CountryIdFK];

ALTER TABLE [dbo].[Person] WITH CHECK CHECK CONSTRAINT [AddressIdFK];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET MULTI_USER 
    WITH ROLLBACK IMMEDIATE;


GO
