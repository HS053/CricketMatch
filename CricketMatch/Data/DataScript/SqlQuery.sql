SET IDENTITY_INSERT [dbo].[Event] ON
INSERT INTO [dbo].[Event] ([EventID], [Eventname], [StartDate], [EndDate], [EventDuration]) VALUES (1, N'IPL', N'2021-03-26 00:00:00', N'2021-04-26 00:00:00', N'31 days')
INSERT INTO [dbo].[Event] ([EventID], [Eventname], [StartDate], [EndDate], [EventDuration]) VALUES (2, N'ICC', N'2021-03-01 00:00:00', N'2021-04-01 00:00:00', N'31 days')
INSERT INTO [dbo].[Event] ([EventID], [Eventname], [StartDate], [EndDate], [EventDuration]) VALUES (3, N'T20', N'2021-03-29 00:00:00', N'2021-04-26 00:00:00', N'29 days')
SET IDENTITY_INSERT [dbo].[Event] OFF


SET IDENTITY_INSERT [dbo].[Fixture] ON
INSERT INTO [dbo].[Fixture] ([Fixture_Id], [vs_Team], [Country], [Date], [Ground_Name]) VALUES (1, N'Australia', N'India', N'2021-03-28 11:28:00', N'Melbourne Cricket Ground (MCG)')
INSERT INTO [dbo].[Fixture] ([Fixture_Id], [vs_Team], [Country], [Date], [Ground_Name]) VALUES (2, N'England', N'England', N'2021-04-06 11:30:00', N'The Oval')
INSERT INTO [dbo].[Fixture] ([Fixture_Id], [vs_Team], [Country], [Date], [Ground_Name]) VALUES (3, N'New Zealand', N'India', N'2021-03-18 11:30:00', N'Sydney Cricket Ground (SCG)')
SET IDENTITY_INSERT [dbo].[Fixture] OFF


SET IDENTITY_INSERT [dbo].[Player] ON
INSERT INTO [dbo].[Player] ([PlayerID], [PlayerFname], [PlayerLname], [DoB], [Address]) VALUES (1, N'MS', N'dhoni', N'11-6-1985', N'6 maitland street')
INSERT INTO [dbo].[Player] ([PlayerID], [PlayerFname], [PlayerLname], [DoB], [Address]) VALUES (2, N'Hardik', N'Pandaya', N'22-7-1989', N'34 memorial drive')
INSERT INTO [dbo].[Player] ([PlayerID], [PlayerFname], [PlayerLname], [DoB], [Address]) VALUES (3, N'virat', N'kholi', N'11-6-1987', N'55 fow street')
SET IDENTITY_INSERT [dbo].[Player] OFF


SET IDENTITY_INSERT [dbo].[Ranking] ON
INSERT INTO [dbo].[Ranking] ([ID], [PlayerID], [EventID]) VALUES (1, 2, 1)
INSERT INTO [dbo].[Ranking] ([ID], [PlayerID], [EventID]) VALUES (2, 1, 2)
SET IDENTITY_INSERT [dbo].[Ranking] OFF
