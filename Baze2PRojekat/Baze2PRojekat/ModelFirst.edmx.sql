
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 01:21:05
-- Generated from EDMX file: C:\Users\basic\source\repos\Baze2Projekat\Baze2PRojekat\ModelFirst.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirst2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BendUcestvuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucestvujes] DROP CONSTRAINT [FK_BendUcestvuje];
GO
IF OBJECT_ID(N'[dbo].[FK_UcestvujeFestival]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucestvujes] DROP CONSTRAINT [FK_UcestvujeFestival];
GO
IF OBJECT_ID(N'[dbo].[FK_BendMenadzer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menadzers] DROP CONSTRAINT [FK_BendMenadzer];
GO
IF OBJECT_ID(N'[dbo].[FK_FestivalDaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dajes] DROP CONSTRAINT [FK_FestivalDaje];
GO
IF OBJECT_ID(N'[dbo].[FK_NagradaDaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dajes] DROP CONSTRAINT [FK_NagradaDaje];
GO
IF OBJECT_ID(N'[dbo].[FK_UcestvujeOsvaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osvajas] DROP CONSTRAINT [FK_UcestvujeOsvaja];
GO
IF OBJECT_ID(N'[dbo].[FK_DajeOsvaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Osvajas] DROP CONSTRAINT [FK_DajeOsvaja];
GO
IF OBJECT_ID(N'[dbo].[FK_BendPripada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pripadas] DROP CONSTRAINT [FK_BendPripada];
GO
IF OBJECT_ID(N'[dbo].[FK_ZanrPripada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pripadas] DROP CONSTRAINT [FK_ZanrPripada];
GO
IF OBJECT_ID(N'[dbo].[FK_BendSvira]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sviras] DROP CONSTRAINT [FK_BendSvira];
GO
IF OBJECT_ID(N'[dbo].[FK_MuzicarSvira]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sviras] DROP CONSTRAINT [FK_MuzicarSvira];
GO
IF OBJECT_ID(N'[dbo].[FK_BendSnima]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Snimas] DROP CONSTRAINT [FK_BendSnima];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumSnima]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Snimas] DROP CONSTRAINT [FK_AlbumSnima];
GO
IF OBJECT_ID(N'[dbo].[FK_AlbumIzdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdajes] DROP CONSTRAINT [FK_AlbumIzdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_MuzickaIzdavackaKucaIzdaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Izdajes] DROP CONSTRAINT [FK_MuzickaIzdavackaKucaIzdaje];
GO
IF OBJECT_ID(N'[dbo].[FK_BendOdrzi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odrzis] DROP CONSTRAINT [FK_BendOdrzi];
GO
IF OBJECT_ID(N'[dbo].[FK_KoncertOdrzi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odrzis] DROP CONSTRAINT [FK_KoncertOdrzi];
GO
IF OBJECT_ID(N'[dbo].[FK_Gitarista_inherits_Muzicar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Muzicars_Gitarista] DROP CONSTRAINT [FK_Gitarista_inherits_Muzicar];
GO
IF OBJECT_ID(N'[dbo].[FK_Bubnjar_inherits_Muzicar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Muzicars_Bubnjar] DROP CONSTRAINT [FK_Bubnjar_inherits_Muzicar];
GO
IF OBJECT_ID(N'[dbo].[FK_Klavijaturista_inherits_Muzicar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Muzicars_Klavijaturista] DROP CONSTRAINT [FK_Klavijaturista_inherits_Muzicar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bends];
GO
IF OBJECT_ID(N'[dbo].[Festivals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Festivals];
GO
IF OBJECT_ID(N'[dbo].[Ucestvujes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ucestvujes];
GO
IF OBJECT_ID(N'[dbo].[Zanrs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zanrs];
GO
IF OBJECT_ID(N'[dbo].[Muzicars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Muzicars];
GO
IF OBJECT_ID(N'[dbo].[Albums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Albums];
GO
IF OBJECT_ID(N'[dbo].[MuzickaIzdavackaKucas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MuzickaIzdavackaKucas];
GO
IF OBJECT_ID(N'[dbo].[Koncerts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Koncerts];
GO
IF OBJECT_ID(N'[dbo].[Menadzers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menadzers];
GO
IF OBJECT_ID(N'[dbo].[Nagradas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nagradas];
GO
IF OBJECT_ID(N'[dbo].[Dajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dajes];
GO
IF OBJECT_ID(N'[dbo].[Osvajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Osvajas];
GO
IF OBJECT_ID(N'[dbo].[Pripadas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pripadas];
GO
IF OBJECT_ID(N'[dbo].[Sviras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sviras];
GO
IF OBJECT_ID(N'[dbo].[Snimas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Snimas];
GO
IF OBJECT_ID(N'[dbo].[Izdajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Izdajes];
GO
IF OBJECT_ID(N'[dbo].[Odrzis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odrzis];
GO
IF OBJECT_ID(N'[dbo].[Muzicars_Gitarista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Muzicars_Gitarista];
GO
IF OBJECT_ID(N'[dbo].[Muzicars_Bubnjar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Muzicars_Bubnjar];
GO
IF OBJECT_ID(N'[dbo].[Muzicars_Klavijaturista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Muzicars_Klavijaturista];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bends'
CREATE TABLE [dbo].[Bends] (
    [IdBenda] int IDENTITY(1,1) NOT NULL,
    [NazB] nvarchar(max)  NOT NULL,
    [Logo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Festivals'
CREATE TABLE [dbo].[Festivals] (
    [IdF] int IDENTITY(1,1) NOT NULL,
    [NazF] nvarchar(max)  NOT NULL,
    [ModrzF] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ucestvujes'
CREATE TABLE [dbo].[Ucestvujes] (
    [BendIdBenda] int  NOT NULL,
    [FestivalIdf] int  NOT NULL
);
GO

-- Creating table 'Zanrs'
CREATE TABLE [dbo].[Zanrs] (
    [Idz] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Muzicars'
CREATE TABLE [dbo].[Muzicars] (
    [Jmbg] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prz] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [IdAlb] int IDENTITY(1,1) NOT NULL,
    [NazLab] nvarchar(max)  NOT NULL,
    [Cd] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MuzickaIzdavackaKucas'
CREATE TABLE [dbo].[MuzickaIzdavackaKucas] (
    [Idmik] int IDENTITY(1,1) NOT NULL,
    [NazMik] nvarchar(max)  NOT NULL,
    [AdrMik] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Koncerts'
CREATE TABLE [dbo].[Koncerts] (
    [IdKon] int IDENTITY(1,1) NOT NULL,
    [NazKon] nvarchar(max)  NOT NULL,
    [MoKon] nvarchar(max)  NOT NULL,
    [DatumKon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Menadzers'
CREATE TABLE [dbo].[Menadzers] (
    [IdMen] int IDENTITY(1,1) NOT NULL,
    [ImeMen] nvarchar(max)  NOT NULL,
    [BendIdBenda] int  NULL
);
GO

-- Creating table 'Nagradas'
CREATE TABLE [dbo].[Nagradas] (
    [IdNag] int IDENTITY(1,1) NOT NULL,
    [NazNag] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Dajes'
CREATE TABLE [dbo].[Dajes] (
    [FestivalIdF] int  NOT NULL,
    [NagradaIdNag] int  NOT NULL
);
GO

-- Creating table 'Osvajas'
CREATE TABLE [dbo].[Osvajas] (
    [UcestvujeBendIdBenda] int  NOT NULL,
    [UcestvujeFestivalIdf] int  NOT NULL,
    [DajeFestivalIdF] int  NOT NULL,
    [DajeNagradaIdNag] int  NOT NULL
);
GO

-- Creating table 'Pripadas'
CREATE TABLE [dbo].[Pripadas] (
    [BendIdBenda] int  NOT NULL,
    [ZanrIdz] int  NOT NULL
);
GO

-- Creating table 'Sviras'
CREATE TABLE [dbo].[Sviras] (
    [BendIdBenda] int  NOT NULL,
    [MuzicarJmbg] int  NOT NULL
);
GO

-- Creating table 'Snimas'
CREATE TABLE [dbo].[Snimas] (
    [BendIdBenda] int  NOT NULL,
    [AlbumIdAlb] int  NOT NULL
);
GO

-- Creating table 'Izdajes'
CREATE TABLE [dbo].[Izdajes] (
    [AlbumIdAlb] int  NOT NULL,
    [MuzickaIzdavackaKucaIdmik] int  NOT NULL
);
GO

-- Creating table 'Odrzis'
CREATE TABLE [dbo].[Odrzis] (
    [BendIdBenda] int  NOT NULL,
    [KoncertIdKon] int  NOT NULL
);
GO

-- Creating table 'Muzicars_Gitarista'
CREATE TABLE [dbo].[Muzicars_Gitarista] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'Muzicars_Bubnjar'
CREATE TABLE [dbo].[Muzicars_Bubnjar] (
    [Jmbg] int  NOT NULL
);
GO

-- Creating table 'Muzicars_Klavijaturista'
CREATE TABLE [dbo].[Muzicars_Klavijaturista] (
    [Jmbg] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdBenda] in table 'Bends'
ALTER TABLE [dbo].[Bends]
ADD CONSTRAINT [PK_Bends]
    PRIMARY KEY CLUSTERED ([IdBenda] ASC);
GO

-- Creating primary key on [IdF] in table 'Festivals'
ALTER TABLE [dbo].[Festivals]
ADD CONSTRAINT [PK_Festivals]
    PRIMARY KEY CLUSTERED ([IdF] ASC);
GO

-- Creating primary key on [BendIdBenda], [FestivalIdf] in table 'Ucestvujes'
ALTER TABLE [dbo].[Ucestvujes]
ADD CONSTRAINT [PK_Ucestvujes]
    PRIMARY KEY CLUSTERED ([BendIdBenda], [FestivalIdf] ASC);
GO

-- Creating primary key on [Idz] in table 'Zanrs'
ALTER TABLE [dbo].[Zanrs]
ADD CONSTRAINT [PK_Zanrs]
    PRIMARY KEY CLUSTERED ([Idz] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Muzicars'
ALTER TABLE [dbo].[Muzicars]
ADD CONSTRAINT [PK_Muzicars]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [IdAlb] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([IdAlb] ASC);
GO

-- Creating primary key on [Idmik] in table 'MuzickaIzdavackaKucas'
ALTER TABLE [dbo].[MuzickaIzdavackaKucas]
ADD CONSTRAINT [PK_MuzickaIzdavackaKucas]
    PRIMARY KEY CLUSTERED ([Idmik] ASC);
GO

-- Creating primary key on [IdKon] in table 'Koncerts'
ALTER TABLE [dbo].[Koncerts]
ADD CONSTRAINT [PK_Koncerts]
    PRIMARY KEY CLUSTERED ([IdKon] ASC);
GO

-- Creating primary key on [IdMen] in table 'Menadzers'
ALTER TABLE [dbo].[Menadzers]
ADD CONSTRAINT [PK_Menadzers]
    PRIMARY KEY CLUSTERED ([IdMen] ASC);
GO

-- Creating primary key on [IdNag] in table 'Nagradas'
ALTER TABLE [dbo].[Nagradas]
ADD CONSTRAINT [PK_Nagradas]
    PRIMARY KEY CLUSTERED ([IdNag] ASC);
GO

-- Creating primary key on [FestivalIdF], [NagradaIdNag] in table 'Dajes'
ALTER TABLE [dbo].[Dajes]
ADD CONSTRAINT [PK_Dajes]
    PRIMARY KEY CLUSTERED ([FestivalIdF], [NagradaIdNag] ASC);
GO

-- Creating primary key on [UcestvujeBendIdBenda], [UcestvujeFestivalIdf], [DajeFestivalIdF], [DajeNagradaIdNag] in table 'Osvajas'
ALTER TABLE [dbo].[Osvajas]
ADD CONSTRAINT [PK_Osvajas]
    PRIMARY KEY CLUSTERED ([UcestvujeBendIdBenda], [UcestvujeFestivalIdf], [DajeFestivalIdF], [DajeNagradaIdNag] ASC);
GO

-- Creating primary key on [BendIdBenda], [ZanrIdz] in table 'Pripadas'
ALTER TABLE [dbo].[Pripadas]
ADD CONSTRAINT [PK_Pripadas]
    PRIMARY KEY CLUSTERED ([BendIdBenda], [ZanrIdz] ASC);
GO

-- Creating primary key on [BendIdBenda], [MuzicarJmbg] in table 'Sviras'
ALTER TABLE [dbo].[Sviras]
ADD CONSTRAINT [PK_Sviras]
    PRIMARY KEY CLUSTERED ([BendIdBenda], [MuzicarJmbg] ASC);
GO

-- Creating primary key on [BendIdBenda], [AlbumIdAlb] in table 'Snimas'
ALTER TABLE [dbo].[Snimas]
ADD CONSTRAINT [PK_Snimas]
    PRIMARY KEY CLUSTERED ([BendIdBenda], [AlbumIdAlb] ASC);
GO

-- Creating primary key on [AlbumIdAlb], [MuzickaIzdavackaKucaIdmik] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [PK_Izdajes]
    PRIMARY KEY CLUSTERED ([AlbumIdAlb], [MuzickaIzdavackaKucaIdmik] ASC);
GO

-- Creating primary key on [BendIdBenda], [KoncertIdKon] in table 'Odrzis'
ALTER TABLE [dbo].[Odrzis]
ADD CONSTRAINT [PK_Odrzis]
    PRIMARY KEY CLUSTERED ([BendIdBenda], [KoncertIdKon] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Muzicars_Gitarista'
ALTER TABLE [dbo].[Muzicars_Gitarista]
ADD CONSTRAINT [PK_Muzicars_Gitarista]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Muzicars_Bubnjar'
ALTER TABLE [dbo].[Muzicars_Bubnjar]
ADD CONSTRAINT [PK_Muzicars_Bubnjar]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- Creating primary key on [Jmbg] in table 'Muzicars_Klavijaturista'
ALTER TABLE [dbo].[Muzicars_Klavijaturista]
ADD CONSTRAINT [PK_Muzicars_Klavijaturista]
    PRIMARY KEY CLUSTERED ([Jmbg] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BendIdBenda] in table 'Ucestvujes'
ALTER TABLE [dbo].[Ucestvujes]
ADD CONSTRAINT [FK_BendUcestvuje]
    FOREIGN KEY ([BendIdBenda])
    REFERENCES [dbo].[Bends]
        ([IdBenda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [FestivalIdf] in table 'Ucestvujes'
ALTER TABLE [dbo].[Ucestvujes]
ADD CONSTRAINT [FK_UcestvujeFestival]
    FOREIGN KEY ([FestivalIdf])
    REFERENCES [dbo].[Festivals]
        ([IdF])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UcestvujeFestival'
CREATE INDEX [IX_FK_UcestvujeFestival]
ON [dbo].[Ucestvujes]
    ([FestivalIdf]);
GO

-- Creating foreign key on [BendIdBenda] in table 'Menadzers'
ALTER TABLE [dbo].[Menadzers]
ADD CONSTRAINT [FK_BendMenadzer]
    FOREIGN KEY ([BendIdBenda])
    REFERENCES [dbo].[Bends]
        ([IdBenda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BendMenadzer'
CREATE INDEX [IX_FK_BendMenadzer]
ON [dbo].[Menadzers]
    ([BendIdBenda]);
GO

-- Creating foreign key on [FestivalIdF] in table 'Dajes'
ALTER TABLE [dbo].[Dajes]
ADD CONSTRAINT [FK_FestivalDaje]
    FOREIGN KEY ([FestivalIdF])
    REFERENCES [dbo].[Festivals]
        ([IdF])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [NagradaIdNag] in table 'Dajes'
ALTER TABLE [dbo].[Dajes]
ADD CONSTRAINT [FK_NagradaDaje]
    FOREIGN KEY ([NagradaIdNag])
    REFERENCES [dbo].[Nagradas]
        ([IdNag])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_NagradaDaje'
CREATE INDEX [IX_FK_NagradaDaje]
ON [dbo].[Dajes]
    ([NagradaIdNag]);
GO

-- Creating foreign key on [UcestvujeBendIdBenda], [UcestvujeFestivalIdf] in table 'Osvajas'
ALTER TABLE [dbo].[Osvajas]
ADD CONSTRAINT [FK_UcestvujeOsvaja]
    FOREIGN KEY ([UcestvujeBendIdBenda], [UcestvujeFestivalIdf])
    REFERENCES [dbo].[Ucestvujes]
        ([BendIdBenda], [FestivalIdf])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DajeFestivalIdF], [DajeNagradaIdNag] in table 'Osvajas'
ALTER TABLE [dbo].[Osvajas]
ADD CONSTRAINT [FK_DajeOsvaja]
    FOREIGN KEY ([DajeFestivalIdF], [DajeNagradaIdNag])
    REFERENCES [dbo].[Dajes]
        ([FestivalIdF], [NagradaIdNag])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DajeOsvaja'
CREATE INDEX [IX_FK_DajeOsvaja]
ON [dbo].[Osvajas]
    ([DajeFestivalIdF], [DajeNagradaIdNag]);
GO

-- Creating foreign key on [BendIdBenda] in table 'Pripadas'
ALTER TABLE [dbo].[Pripadas]
ADD CONSTRAINT [FK_BendPripada]
    FOREIGN KEY ([BendIdBenda])
    REFERENCES [dbo].[Bends]
        ([IdBenda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ZanrIdz] in table 'Pripadas'
ALTER TABLE [dbo].[Pripadas]
ADD CONSTRAINT [FK_ZanrPripada]
    FOREIGN KEY ([ZanrIdz])
    REFERENCES [dbo].[Zanrs]
        ([Idz])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZanrPripada'
CREATE INDEX [IX_FK_ZanrPripada]
ON [dbo].[Pripadas]
    ([ZanrIdz]);
GO

-- Creating foreign key on [BendIdBenda] in table 'Sviras'
ALTER TABLE [dbo].[Sviras]
ADD CONSTRAINT [FK_BendSvira]
    FOREIGN KEY ([BendIdBenda])
    REFERENCES [dbo].[Bends]
        ([IdBenda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MuzicarJmbg] in table 'Sviras'
ALTER TABLE [dbo].[Sviras]
ADD CONSTRAINT [FK_MuzicarSvira]
    FOREIGN KEY ([MuzicarJmbg])
    REFERENCES [dbo].[Muzicars]
        ([Jmbg])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MuzicarSvira'
CREATE INDEX [IX_FK_MuzicarSvira]
ON [dbo].[Sviras]
    ([MuzicarJmbg]);
GO

-- Creating foreign key on [BendIdBenda] in table 'Snimas'
ALTER TABLE [dbo].[Snimas]
ADD CONSTRAINT [FK_BendSnima]
    FOREIGN KEY ([BendIdBenda])
    REFERENCES [dbo].[Bends]
        ([IdBenda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AlbumIdAlb] in table 'Snimas'
ALTER TABLE [dbo].[Snimas]
ADD CONSTRAINT [FK_AlbumSnima]
    FOREIGN KEY ([AlbumIdAlb])
    REFERENCES [dbo].[Albums]
        ([IdAlb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumSnima'
CREATE INDEX [IX_FK_AlbumSnima]
ON [dbo].[Snimas]
    ([AlbumIdAlb]);
GO

-- Creating foreign key on [AlbumIdAlb] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_AlbumIzdaje]
    FOREIGN KEY ([AlbumIdAlb])
    REFERENCES [dbo].[Albums]
        ([IdAlb])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MuzickaIzdavackaKucaIdmik] in table 'Izdajes'
ALTER TABLE [dbo].[Izdajes]
ADD CONSTRAINT [FK_MuzickaIzdavackaKucaIzdaje]
    FOREIGN KEY ([MuzickaIzdavackaKucaIdmik])
    REFERENCES [dbo].[MuzickaIzdavackaKucas]
        ([Idmik])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MuzickaIzdavackaKucaIzdaje'
CREATE INDEX [IX_FK_MuzickaIzdavackaKucaIzdaje]
ON [dbo].[Izdajes]
    ([MuzickaIzdavackaKucaIdmik]);
GO

-- Creating foreign key on [BendIdBenda] in table 'Odrzis'
ALTER TABLE [dbo].[Odrzis]
ADD CONSTRAINT [FK_BendOdrzi]
    FOREIGN KEY ([BendIdBenda])
    REFERENCES [dbo].[Bends]
        ([IdBenda])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KoncertIdKon] in table 'Odrzis'
ALTER TABLE [dbo].[Odrzis]
ADD CONSTRAINT [FK_KoncertOdrzi]
    FOREIGN KEY ([KoncertIdKon])
    REFERENCES [dbo].[Koncerts]
        ([IdKon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KoncertOdrzi'
CREATE INDEX [IX_FK_KoncertOdrzi]
ON [dbo].[Odrzis]
    ([KoncertIdKon]);
GO

-- Creating foreign key on [Jmbg] in table 'Muzicars_Gitarista'
ALTER TABLE [dbo].[Muzicars_Gitarista]
ADD CONSTRAINT [FK_Gitarista_inherits_Muzicar]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Muzicars]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Muzicars_Bubnjar'
ALTER TABLE [dbo].[Muzicars_Bubnjar]
ADD CONSTRAINT [FK_Bubnjar_inherits_Muzicar]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Muzicars]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jmbg] in table 'Muzicars_Klavijaturista'
ALTER TABLE [dbo].[Muzicars_Klavijaturista]
ADD CONSTRAINT [FK_Klavijaturista_inherits_Muzicar]
    FOREIGN KEY ([Jmbg])
    REFERENCES [dbo].[Muzicars]
        ([Jmbg])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------