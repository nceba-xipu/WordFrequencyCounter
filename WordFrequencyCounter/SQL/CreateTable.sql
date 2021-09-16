USE [WordCounterDB]
GO

/****** Object:  Table [dbo].[WordFrequency]    Script Date: 2021/09/16 12:57:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WordFrequency](
	[Word] [nvarchar](100) NULL,
	[Frequency] [int] NULL
) ON [PRIMARY]
GO


