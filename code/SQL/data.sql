USE [CyscoreDB]
GO
SET IDENTITY_INSERT [dbo].[Policies] ON 

INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (1, N'Windows Defender', N'Whether Windows Defender is enabled or not')
INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (2, N'Antivirus', N'Whether an Antivirus is installed on the computer')
INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (3, N'Guest Account', N'Whether there''s a guest account on the station')
INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (1002, N'Unquoted Services', N'Are there any unquoted services running?')
INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (1003, N'Startup Applications', N'Are there alot of startup applications?')
INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (1004, N'Windows Defender Exclusions', N'Is nothing excluded from being scanned by the Windows Defender?')
INSERT [dbo].[Policies] ([Id], [Name], [Description]) VALUES (1005, N'Windows UAC', N'Whether there''s a prompt when using admin priviledges')
SET IDENTITY_INSERT [dbo].[Policies] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [Salt]) VALUES (1, N'user1', 0x7873B40E259497DCDF32637C3950CEFB236CB5075B4EB3F14E6ED50A04927945, N'511SOQQXT5')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
