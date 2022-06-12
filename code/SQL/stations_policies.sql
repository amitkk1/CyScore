USE [CyscoreDB]
GO

/****** Object:  Table [dbo].[StationsPolicies]    Script Date: 12/06/2022 15:56:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StationsPolicies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PolicyId] [int] NOT NULL,
	[StationId] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[LastChanged] [datetime] NOT NULL,
 CONSTRAINT [PK_StationsPolicies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StationsPolicies]  WITH CHECK ADD  CONSTRAINT [FK_StationsPolicies_Policies] FOREIGN KEY([PolicyId])
REFERENCES [dbo].[Policies] ([Id])
GO

ALTER TABLE [dbo].[StationsPolicies] CHECK CONSTRAINT [FK_StationsPolicies_Policies]
GO

ALTER TABLE [dbo].[StationsPolicies]  WITH CHECK ADD  CONSTRAINT [FK_StationsPolicies_Stations] FOREIGN KEY([StationId])
REFERENCES [dbo].[Stations] ([Id])
GO

ALTER TABLE [dbo].[StationsPolicies] CHECK CONSTRAINT [FK_StationsPolicies_Stations]
GO

