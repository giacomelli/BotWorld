
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/04/2012 14:30:54
-- Generated from EDMX file: C:\cwi\Old projects\BotWorld\BotWorld\DG.BotWorld\DG.BotWorld.World.Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DG.BotWorld];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BotRanking_Bot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BotRanking] DROP CONSTRAINT [FK_BotRanking_Bot];
GO
IF OBJECT_ID(N'[dbo].[FK_BotRanking_Environment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BotRanking] DROP CONSTRAINT [FK_BotRanking_Environment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bot]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bot];
GO
IF OBJECT_ID(N'[dbo].[BotRanking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BotRanking];
GO
IF OBJECT_ID(N'[dbo].[Environment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Environment];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bot'
CREATE TABLE [dbo].[Bot] (
    [IdBot] int  NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'BotRanking'
CREATE TABLE [dbo].[BotRanking] (
    [IdBotRanking] int  NOT NULL,
    [Score] real  NOT NULL,
    [Bot_IdBot] int  NOT NULL,
    [Environment_IdEnvironment] int  NOT NULL
);
GO

-- Creating table 'Environment'
CREATE TABLE [dbo].[Environment] (
    [IdEnvironment] int  NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdBot] in table 'Bot'
ALTER TABLE [dbo].[Bot]
ADD CONSTRAINT [PK_Bot]
    PRIMARY KEY CLUSTERED ([IdBot] ASC);
GO

-- Creating primary key on [IdBotRanking] in table 'BotRanking'
ALTER TABLE [dbo].[BotRanking]
ADD CONSTRAINT [PK_BotRanking]
    PRIMARY KEY CLUSTERED ([IdBotRanking] ASC);
GO

-- Creating primary key on [IdEnvironment] in table 'Environment'
ALTER TABLE [dbo].[Environment]
ADD CONSTRAINT [PK_Environment]
    PRIMARY KEY CLUSTERED ([IdEnvironment] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Bot_IdBot] in table 'BotRanking'
ALTER TABLE [dbo].[BotRanking]
ADD CONSTRAINT [FK_BotRanking_Bot]
    FOREIGN KEY ([Bot_IdBot])
    REFERENCES [dbo].[Bot]
        ([IdBot])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BotRanking_Bot'
CREATE INDEX [IX_FK_BotRanking_Bot]
ON [dbo].[BotRanking]
    ([Bot_IdBot]);
GO

-- Creating foreign key on [Environment_IdEnvironment] in table 'BotRanking'
ALTER TABLE [dbo].[BotRanking]
ADD CONSTRAINT [FK_BotRanking_Environment]
    FOREIGN KEY ([Environment_IdEnvironment])
    REFERENCES [dbo].[Environment]
        ([IdEnvironment])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BotRanking_Environment'
CREATE INDEX [IX_FK_BotRanking_Environment]
ON [dbo].[BotRanking]
    ([Environment_IdEnvironment]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------