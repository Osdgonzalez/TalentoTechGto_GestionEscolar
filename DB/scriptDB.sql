USE [GestionEscolar]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Telefono] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlumnosMaterias]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnosMaterias](
	[Id_alumno] [int] NOT NULL,
	[Id_materia] [int] NOT NULL,
	[Id_calificacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_alumno] ASC,
	[Id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlumnosProfesores]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlumnosProfesores](
	[Id_alumno] [int] NOT NULL,
	[Id_profesor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_profesor] ASC,
	[Id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MateriasProfesores]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MateriasProfesores](
	[Id_profesor] [int] NOT NULL,
	[Id_materia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_profesor] ASC,
	[Id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 09/12/2023 01:03:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Telefono] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([Id], [Nombre], [Telefono]) VALUES (1, N'Cho Chang1', N'4910294538')
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Telefono]) VALUES (2, N'Bellatrix Lestrange', N'3100129484')
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Telefono]) VALUES (3, N'Oliver Wood', N'0628489218')
INSERT [dbo].[Alumnos] ([Id], [Nombre], [Telefono]) VALUES (4, N'Harry Potter', N'0471234991')
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
INSERT [dbo].[AlumnosMaterias] ([Id_alumno], [Id_materia], [Id_calificacion]) VALUES (1, 1, 1)
INSERT [dbo].[AlumnosMaterias] ([Id_alumno], [Id_materia], [Id_calificacion]) VALUES (1, 3, 1)
INSERT [dbo].[AlumnosMaterias] ([Id_alumno], [Id_materia], [Id_calificacion]) VALUES (3, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Calificaciones] ON 

INSERT [dbo].[Calificaciones] ([Id], [Descripcion]) VALUES (1, N'Pendiente')
INSERT [dbo].[Calificaciones] ([Id], [Descripcion]) VALUES (2, N'Aprobado')
INSERT [dbo].[Calificaciones] ([Id], [Descripcion]) VALUES (3, N'Reprobado')
SET IDENTITY_INSERT [dbo].[Calificaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Materias] ON 

INSERT [dbo].[Materias] ([Id], [Descripcion]) VALUES (1, N'Transformaciones')
INSERT [dbo].[Materias] ([Id], [Descripcion]) VALUES (2, N'Defensa Contra las Artes Oscuras')
INSERT [dbo].[Materias] ([Id], [Descripcion]) VALUES (3, N'Pociones')
SET IDENTITY_INSERT [dbo].[Materias] OFF
GO
INSERT [dbo].[MateriasProfesores] ([Id_profesor], [Id_materia]) VALUES (1, 2)
INSERT [dbo].[MateriasProfesores] ([Id_profesor], [Id_materia]) VALUES (2, 1)
INSERT [dbo].[MateriasProfesores] ([Id_profesor], [Id_materia]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[Profesores] ON 

INSERT [dbo].[Profesores] ([Id], [Nombre], [Telefono]) VALUES (1, N'Albus Dumbledore', N'4910294538')
INSERT [dbo].[Profesores] ([Id], [Nombre], [Telefono]) VALUES (2, N'Minerva McGonagall', N'3100129484')
INSERT [dbo].[Profesores] ([Id], [Nombre], [Telefono]) VALUES (3, N'Galatea Merrythought', N'0628489218')
SET IDENTITY_INSERT [dbo].[Profesores] OFF
GO
ALTER TABLE [dbo].[AlumnosMaterias]  WITH CHECK ADD FOREIGN KEY([Id_alumno])
REFERENCES [dbo].[Alumnos] ([Id])
GO
ALTER TABLE [dbo].[AlumnosMaterias]  WITH CHECK ADD FOREIGN KEY([Id_calificacion])
REFERENCES [dbo].[Calificaciones] ([Id])
GO
ALTER TABLE [dbo].[AlumnosMaterias]  WITH CHECK ADD FOREIGN KEY([Id_materia])
REFERENCES [dbo].[Materias] ([Id])
GO
ALTER TABLE [dbo].[AlumnosProfesores]  WITH CHECK ADD FOREIGN KEY([Id_alumno])
REFERENCES [dbo].[Alumnos] ([Id])
GO
ALTER TABLE [dbo].[AlumnosProfesores]  WITH CHECK ADD FOREIGN KEY([Id_profesor])
REFERENCES [dbo].[Profesores] ([Id])
GO
ALTER TABLE [dbo].[MateriasProfesores]  WITH CHECK ADD FOREIGN KEY([Id_materia])
REFERENCES [dbo].[Materias] ([Id])
GO
ALTER TABLE [dbo].[MateriasProfesores]  WITH CHECK ADD FOREIGN KEY([Id_profesor])
REFERENCES [dbo].[Profesores] ([Id])
GO
