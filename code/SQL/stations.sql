USE [CyscoreDB]
GO

/****** Object:  Table [dbo].[Stations]    Script Date: 12/06/2022 15:55:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ip] [nvarchar](50) NOT NULL,
	[Mac] [nvarchar](50) NOT NULL,
	[Hostname] [nvarchar](50) NOT NULL,
	[StationKey] [nvarchar](50) NOT NULL,
	[LastUpdated] [date] NOT NULL,
 CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

