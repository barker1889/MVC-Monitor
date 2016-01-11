/****** MVC Monitor baseline database creation script (v2.0) ******/

/* For upgrading database from version 1 without losing data use Ver2.0.Upgrade.sql */

USE [MvcMonitor]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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






USE [MvcMonitorTest]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
