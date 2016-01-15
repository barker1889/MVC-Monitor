/****** MVC Monitor baseline database creation script (v2.0) ******/

/* Upgrades a version 1.0 database and migrates data. Use V2.0.Clean.sql for a new install without migrating data */

USE [AppsMonitor]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

sp_rename 'ErrorModel', 'ErrorModel_V1_0';


CREATE TABLE [dbo].[ErrorModel](
	[Id] [uniqueidentifier] NOT NULL,
	[ErrorId] [uniqueidentifier] NULL,
	[Application] [varchar](200) NULL,
	[Time] [datetime] NULL,
	[Username] [varchar](200) NULL,
	[Host] [varchar](200) NULL,
	[Url] [varchar](2083) NULL,
	[StatusCode] [int] NULL,
	[RequestMethod] [varchar](100) NULL,
	[UserAgent] [varchar](600) NULL,
	[ExceptionType] [varchar](300) NULL,
	[ExceptionMessage] [varchar](1000) NULL,
	[ExceptionSource] [varchar](1000) NULL,
	[ExceptionStackTrace] [varchar](max) NULL,
	[ServerName] [varchar](200) NULL,
	[ServerPort] [int] NULL,
	[ServerPortSecure] [varchar](200) NULL,
	[ServerApplicationPath] [varchar](1000) NULL,
	[ServerApplicationPathTranslated] [varchar](1000) NULL,
	[QueryString] [varchar](2083) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE INDEX IX_ErrorModel_ErrorId
ON [dbo].[ErrorModel] (ErrorId)

CREATE INDEX IX_ErrorModel_Application
ON [dbo].[ErrorModel] ([Application])

CREATE INDEX IX_ErrorModel_Time
ON [dbo].[ErrorModel] ([Time])

CREATE INDEX IX_ErrorModel_Username
ON [dbo].[ErrorModel] ([Username])

CREATE INDEX IX_ErrorModel_Host
ON [dbo].[ErrorModel] ([Host])

CREATE INDEX IX_ErrorModel_Server
ON [dbo].[ErrorModel] ([ServerName])

INSERT INTO [dbo].[ErrorModel] ([Id]
      ,[ErrorId]
      ,[Application]
      ,[Time]
      ,[Username]
      ,[Host]
      ,[Url]
      ,[StatusCode]
      ,[RequestMethod]
      ,[UserAgent]
      ,[ExceptionType]
      ,[ExceptionMessage]
      ,[ExceptionSource]
      ,[ExceptionStackTrace]
      ,[ServerName]
      ,[ServerPort]
      ,[ServerPortSecure]
      ,[ServerApplicationPath]
      ,[ServerApplicationPathTranslated]
      ,[QueryString])
SELECT [Id]
      ,[ErrorId]
      ,CAST([Application] AS varchar(200))
      ,[Time]
      ,CAST([Username] AS varchar(200))
      ,CAST([Host] AS varchar(200))
      ,CAST([Url] AS varchar(2083))
      ,[StatusCode]
      ,CAST([RequestMethod] AS varchar(100))
      ,CAST([UserAgent] AS varchar(600))
      ,CAST([ExceptionType] AS varchar(300))
      ,CAST([ExceptionMessage] AS varchar(1000))
      ,CAST([ExceptionSource] AS varchar(1000))
      ,CAST([ExceptionStackTrace] AS varchar(max))
      ,CAST([ServerName] AS varchar(200))
      ,[ServerPort]
      ,CAST([ServerPortSecure] AS varchar(200))
      ,CAST([ServerApplicationPath] AS varchar(1000))
      ,CAST([ServerApplicationPathTranslated] AS varchar(1000))
      ,CAST([QueryString] AS varchar(2083)) 
	FROM [dbo].[ErrorModel_V1_0];








USE [AppsMonitorTest]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

sp_rename 'ErrorModel', 'ErrorModel_V1_0';


CREATE TABLE [dbo].[ErrorModel](
	[Id] [uniqueidentifier] NOT NULL,
	[ErrorId] [uniqueidentifier] NULL,
	[Application] [varchar](200) NULL,
	[Time] [datetime] NULL,
	[Username] [varchar](200) NULL,
	[Host] [varchar](200) NULL,
	[Url] [varchar](2083) NULL,
	[StatusCode] [int] NULL,
	[RequestMethod] [varchar](100) NULL,
	[UserAgent] [varchar](600) NULL,
	[ExceptionType] [varchar](300) NULL,
	[ExceptionMessage] [varchar](1000) NULL,
	[ExceptionSource] [varchar](1000) NULL,
	[ExceptionStackTrace] [varchar](max) NULL,
	[ServerName] [varchar](200) NULL,
	[ServerPort] [int] NULL,
	[ServerPortSecure] [varchar](200) NULL,
	[ServerApplicationPath] [varchar](1000) NULL,
	[ServerApplicationPathTranslated] [varchar](1000) NULL,
	[QueryString] [varchar](2083) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE INDEX IX_ErrorModel_ErrorId
ON [dbo].[ErrorModel] (ErrorId)

CREATE INDEX IX_ErrorModel_Application
ON [dbo].[ErrorModel] ([Application])

CREATE INDEX IX_ErrorModel_Time
ON [dbo].[ErrorModel] ([Time])

CREATE INDEX IX_ErrorModel_Username
ON [dbo].[ErrorModel] ([Username])

CREATE INDEX IX_ErrorModel_Host
ON [dbo].[ErrorModel] ([Host])

CREATE INDEX IX_ErrorModel_Server
ON [dbo].[ErrorModel] ([ServerName])

INSERT INTO [dbo].[ErrorModel] ([Id]
      ,[ErrorId]
      ,[Application]
      ,[Time]
      ,[Username]
      ,[Host]
      ,[Url]
      ,[StatusCode]
      ,[RequestMethod]
      ,[UserAgent]
      ,[ExceptionType]
      ,[ExceptionMessage]
      ,[ExceptionSource]
      ,[ExceptionStackTrace]
      ,[ServerName]
      ,[ServerPort]
      ,[ServerPortSecure]
      ,[ServerApplicationPath]
      ,[ServerApplicationPathTranslated]
      ,[QueryString])
SELECT [Id]
      ,[ErrorId]
      ,CAST([Application] AS varchar(200))
      ,[Time]
      ,CAST([Username] AS varchar(200))
      ,CAST([Host] AS varchar(200))
      ,CAST([Url] AS varchar(2083))
      ,[StatusCode]
      ,CAST([RequestMethod] AS varchar(100))
      ,CAST([UserAgent] AS varchar(600))
      ,CAST([ExceptionType] AS varchar(300))
      ,CAST([ExceptionMessage] AS varchar(1000))
      ,CAST([ExceptionSource] AS varchar(1000))
      ,CAST([ExceptionStackTrace] AS varchar(max))
      ,CAST([ServerName] AS varchar(200))
      ,[ServerPort]
      ,CAST([ServerPortSecure] AS varchar(200))
      ,CAST([ServerApplicationPath] AS varchar(1000))
      ,CAST([ServerApplicationPathTranslated] AS varchar(1000))
      ,CAST([QueryString] AS varchar(2083)) 
	FROM [dbo].[ErrorModel_V1_0];
