/****** Object:  ForeignKey [FK_Ledger_LedgerSubType]    Script Date: 08/31/2013 09:18:44 ******/
ALTER TABLE [dbo].[Ledger] DROP CONSTRAINT [FK_Ledger_LedgerSubType]
GO
/****** Object:  ForeignKey [FK_LedgerSubType_LedgerType]    Script Date: 08/31/2013 09:18:44 ******/
ALTER TABLE [dbo].[LedgerSubType] DROP CONSTRAINT [FK_LedgerSubType_LedgerType]
GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 08/31/2013 09:18:44 ******/
ALTER TABLE [dbo].[Ledger] DROP CONSTRAINT [FK_Ledger_LedgerSubType]
GO
DROP TABLE [dbo].[Ledger]
GO
/****** Object:  Table [dbo].[LedgerSubType]    Script Date: 08/31/2013 09:18:44 ******/
ALTER TABLE [dbo].[LedgerSubType] DROP CONSTRAINT [FK_LedgerSubType_LedgerType]
GO
DROP TABLE [dbo].[LedgerSubType]
GO
/****** Object:  Table [dbo].[LedgerType]    Script Date: 08/31/2013 09:18:44 ******/
DROP TABLE [dbo].[LedgerType]
GO
/****** Object:  Table [dbo].[LedgerType]    Script Date: 08/31/2013 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LedgerType](
	[LedgerTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LedgerType] [varchar](50) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBY] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_LedgerType] PRIMARY KEY CLUSTERED 
(
	[LedgerTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LedgerSubType]    Script Date: 08/31/2013 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LedgerSubType](
	[LedgerSubTypeID] [int] IDENTITY(1,1) NOT NULL,
	[LedgerSubType] [varchar](50) NOT NULL,
	[LedgerTypeID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBY] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_LedgerSubType] PRIMARY KEY CLUSTERED 
(
	[LedgerSubTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 08/31/2013 09:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledger](
	[LedgerID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[LedgerSubTypeID] [int] NOT NULL,
	[Amount] [money] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedBY] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Ledger] PRIMARY KEY CLUSTERED 
(
	[LedgerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Ledger_LedgerSubType]    Script Date: 08/31/2013 09:18:44 ******/
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Ledger_LedgerSubType] FOREIGN KEY([LedgerSubTypeID])
REFERENCES [dbo].[LedgerSubType] ([LedgerSubTypeID])
GO
ALTER TABLE [dbo].[Ledger] CHECK CONSTRAINT [FK_Ledger_LedgerSubType]
GO
/****** Object:  ForeignKey [FK_LedgerSubType_LedgerType]    Script Date: 08/31/2013 09:18:44 ******/
ALTER TABLE [dbo].[LedgerSubType]  WITH CHECK ADD  CONSTRAINT [FK_LedgerSubType_LedgerType] FOREIGN KEY([LedgerTypeID])
REFERENCES [dbo].[LedgerType] ([LedgerTypeID])
GO
ALTER TABLE [dbo].[LedgerSubType] CHECK CONSTRAINT [FK_LedgerSubType_LedgerType]
GO
