USE [master]
GO
/****** Object:  Database [NotesDB]    Script Date: 01.05.2023 17:23:45 ******/
CREATE DATABASE [NotesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NotesDB', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NotesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NotesDB_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NotesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NotesDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NotesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NotesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NotesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NotesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NotesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NotesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NotesDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NotesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NotesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NotesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NotesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NotesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NotesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NotesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NotesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NotesDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NotesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NotesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NotesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NotesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NotesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NotesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NotesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NotesDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NotesDB] SET  MULTI_USER 
GO
ALTER DATABASE [NotesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NotesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NotesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NotesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NotesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NotesDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NotesDB', N'ON'
GO
ALTER DATABASE [NotesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [NotesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NotesDB]
GO
/****** Object:  Table [dbo].[AccountDetails]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountDetails](
	[ID_Account] [int] IDENTITY(1,1) NOT NULL,
	[LoginUser] [varchar](max) NOT NULL,
	[Pass] [varchar](max) NOT NULL,
 CONSTRAINT [PK_AccountDetails] PRIMARY KEY CLUSTERED 
(
	[ID_Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeHistory]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeHistory](
	[ID_User] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[Operation] [varchar](max) NOT NULL,
	[ChangeDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameNote] [varchar](max) NOT NULL,
	[TextNote] [varchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotesList]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotesList](
	[ID_User] [int] NOT NULL,
	[ID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[NameUser] [varchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](255) NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountDetails]  WITH CHECK ADD FOREIGN KEY([ID_Account])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[ChangeHistory]  WITH CHECK ADD FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[ChangeHistory]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[Note] ([ID])
GO
ALTER TABLE [dbo].[NotesList]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[Note] ([ID])
GO
ALTER TABLE [dbo].[NotesList]  WITH CHECK ADD FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
/****** Object:  StoredProcedure [dbo].[Notes_AddNoteUSERPROFILE]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_AddNoteUSERPROFILE]
	@name nvarchar(255),
	@TextNote nvarchar(255),
	@CreationDate datetime,
	@iduser int

AS
BEGIN

	SET	NOCOUNT OFF;
	INSERT INTO dbo.Note(NameNote, TextNote, CreationDate)
	VALUES(@name, @TextNote, @CreationDate)

	DECLARE @IDnote int = (SELECT MAX(ID) FROM Note)
	INSERT INTO dbo.NotesList(ID_User, ID)
	VALUES(@iduser, @IDnote)
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_AddUser]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Notes_AddUser]
	@NameUs nvarchar(255),
	@Pass nvarchar(255),
	@Login nvarchar(255),
	@PhoneNumber nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	--SET	NOCOUNT OFF;
	INSERT INTO Users VALUES(@NameUs, @PhoneNumber, GETDATE())
	INSERT INTO AccountDetails VALUES(@Login, HASHBYTES('SHA2_512',@Pass))
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_CheckAccount]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_CheckAccount]
	@Login nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT COUNT(LoginUser) FROM AccountDetails WHERE LoginUser = @Login AND Pass =  HASHBYTES('SHA2_512', @Password)
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_EditAccount]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_EditAccount]
	@ID int,
	@Login nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	UPDATE AccountDetails
	SET LoginUser = @Login, Pass = HASHBYTES('SHA2_512', @Password)
	WHERE ID_Account = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_EditNote]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Notes_EditNote]
	@id int,
	@newTextNote nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	UPDATE dbo.Note
	SET TextNote = @newTextNote where ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_EditUser]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_EditUser]
	@ID_User int,
	@NameUser nvarchar(255),
	@PhoneNumber nvarchar(255)

AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Users
	SET NameUser = @NameUser, PhoneNumber = @PhoneNumber
	WHERE ID_User = @ID_User
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_GetAccountById]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_GetAccountById]
	@ID_User int
as
BEGIN
	SET	NOCOUNT ON;
	SELECT TOP 1 ID_Account, LoginUser, Pass
	FROM AccountDetails
	WHERE ID_Account = @ID_User
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_GetAccountByLogin]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_GetAccountByLogin]
	@Login nvarchar(255)
as
BEGIN
	SET	NOCOUNT ON;
	SELECT TOP 1 ID_Account, LoginUser, Pass
	FROM AccountDetails
	WHERE LoginUser = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_GetNoteById]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Notes_GetNoteById]
	@id int
	

AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		ID, NameNote, TextNote, CreationDate
		FROM Note
		WHERE ID = @id
	
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_GetNotes]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Notes_GetNotes]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID, NameNote, TextNote, CreationDate FROM Note
	ORDER BY ID
	
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_GetUserById]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_GetUserById]
	@ID_User int
as
BEGIN
	SET	NOCOUNT ON;
	SELECT TOP 1
		ID_User, NameUser, PhoneNumber, RegistrationDate
	FROM Users
	WHERE ID_User = @ID_User
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_GetUserNotes]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Notes_GetUserNotes]
	@ID_User int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Note.ID, NameNote, TextNote, CreationDate
	FROM Note
	INNER JOIN NotesList ON (NotesList.ID = Note.ID)
	INNER JOIN Users ON (NotesList.ID_User = Users.ID_User)
	WHERE Users.ID_User = @ID_User
END
GO
/****** Object:  StoredProcedure [dbo].[Notes_RemoveNote]    Script Date: 01.05.2023 17:23:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Notes_RemoveNote]
	@Id int

AS
BEGIN
	SET NOCOUNT ON;

	SET	NOCOUNT OFF;
	DELETE FROM NotesList WHERE ID = @ID
	DELETE FROM dbo.Note where ID = @Id
END
GO
USE [master]
GO
ALTER DATABASE [NotesDB] SET  READ_WRITE 
GO
