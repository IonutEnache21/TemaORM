USE [Facultate]
GO
SET IDENTITY_INSERT [FACULTATE].[Profesor] ON 

INSERT [FACULTATE].[Profesor] ([ProfesorId], [Nume], [Prenume], [DataAngajarii]) VALUES (1, N'Logan', N'Alexandra', CAST(N'1990-10-01 00:00:00.000' AS DateTime))
INSERT [FACULTATE].[Profesor] ([ProfesorId], [Nume], [Prenume], [DataAngajarii]) VALUES (2, N'Ramirez', N'Yvette', CAST(N'1995-10-10 00:00:00.000' AS DateTime))
INSERT [FACULTATE].[Profesor] ([ProfesorId], [Nume], [Prenume], [DataAngajarii]) VALUES (3, N'Doyle', N'Lena', CAST(N'1999-10-01 00:00:00.000' AS DateTime))
INSERT [FACULTATE].[Profesor] ([ProfesorId], [Nume], [Prenume], [DataAngajarii]) VALUES (4, N'Howard', N'Rachel', CAST(N'2004-10-01 00:00:00.000' AS DateTime))
INSERT [FACULTATE].[Profesor] ([ProfesorId], [Nume], [Prenume], [DataAngajarii]) VALUES (5, N'Bishop', N'Etel', CAST(N'2010-10-01 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [FACULTATE].[Profesor] OFF
SET IDENTITY_INSERT [FACULTATE].[Student] ON 

INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (1, N'Williams', N'Howard', N'1590501016736', CAST(9.90 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (2, N'Flores', N'Ryan', N'1380720349192', CAST(6.01 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (3, N'Scott', N'Gloria', N'2650125304029', NULL)
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (4, N'Gonzales', N'Robert', N'1690508084351', CAST(7.83 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (6, N'Ross', N'Virginia', N'2761231447355', CAST(8.20 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (7, N'Martin', N'Emily', N'2330813108781', CAST(8.70 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (9, N'Walker', N'Doris', N'2330813158781', CAST(7.44 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (10, N'Murphy', N'Gregory', N'6040209114929', CAST(9.23 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (11, N'Butler', N'Ralph', N'5071122287040', CAST(8.87 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (12, N'West', N'Kathryn', N'6130317456994', CAST(6.75 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (13, N'Steven', N'Betsy', N'5160212198702', CAST(6.20 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (14, N'Ward', N'Tyrone', N'6180709025920', CAST(6.67 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (15, N'Parker', N'Molly', N'5000525165982', CAST(5.65 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (16, N'Norton', N'William', N'1670426248133', CAST(6.93 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (17, N'Moss ', N'Lucy', N'5140625011311', CAST(8.99 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (18, N'Klein', N'Josh', N'1511005261626', CAST(9.56 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (19, N'Barton', N'Stuart', N'6070905275591', CAST(7.69 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (20, N'Massey', N'Kate', N'1710212112236', CAST(8.01 AS Decimal(10, 2)))
INSERT [FACULTATE].[Student] ([StudentId], [Nume], [Prenume], [CNP], [MediaBac]) VALUES (21, N'Bowers', N'Loretta', N'6030419136341', CAST(6.66 AS Decimal(10, 2)))
SET IDENTITY_INSERT [FACULTATE].[Student] OFF
