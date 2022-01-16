USE [master]
GO
/****** Object:  Database [dbSpeakUp]    Script Date: 15/01/2022 23:30:57 ******/
CREATE DATABASE [dbSpeakUp]
GO
USE [dbSpeakUp]
GO
/****** Object:  Table [dbo].[Listener]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Listener](
	[SpeakerId] [uniqueidentifier] NOT NULL,
	[ListernerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Listener] PRIMARY KEY CLUSTERED 
(
	[SpeakerId] ASC,
	[ListernerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[RoomName] [nvarchar](50) NOT NULL,
	[Status] [nchar](3) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_Room_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomMate]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomMate](
	[RoomId] [uniqueidentifier] NOT NULL,
	[RoomMateId] [uniqueidentifier] NOT NULL,
	[Status] [nchar](3) NULL,
 CONSTRAINT [PK_RoomMate] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC,
	[RoomMateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomMessage]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomMessage](
	[Id] [uniqueidentifier] NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
	[SpeakerId] [uniqueidentifier] NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[ReferenceId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_RoomMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speaker]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speaker](
	[UserId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [nchar](3) NOT NULL,
 CONSTRAINT [PK_Speaker] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Speaker] ADD  CONSTRAINT [DF_Speaker_Status]  DEFAULT (N'ACT') FOR [Status]
GO
ALTER TABLE [dbo].[Listener]  WITH CHECK ADD  CONSTRAINT [FK_Listener_Speaker_Listen] FOREIGN KEY([ListernerId])
REFERENCES [dbo].[Speaker] ([UserId])
GO
ALTER TABLE [dbo].[Listener] CHECK CONSTRAINT [FK_Listener_Speaker_Listen]
GO
ALTER TABLE [dbo].[Listener]  WITH CHECK ADD  CONSTRAINT [FK_Listener_Speaker_Speak] FOREIGN KEY([SpeakerId])
REFERENCES [dbo].[Speaker] ([UserId])
GO
ALTER TABLE [dbo].[Listener] CHECK CONSTRAINT [FK_Listener_Speaker_Speak]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Speaker] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[Speaker] ([UserId])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Speaker]
GO
ALTER TABLE [dbo].[RoomMessage]  WITH CHECK ADD  CONSTRAINT [FK_RoomMessage_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[RoomMessage] CHECK CONSTRAINT [FK_RoomMessage_Room]
GO
ALTER TABLE [dbo].[RoomMessage]  WITH CHECK ADD  CONSTRAINT [FK_RoomMessage_Speaker] FOREIGN KEY([SpeakerId])
REFERENCES [dbo].[Speaker] ([UserId])
GO
ALTER TABLE [dbo].[RoomMessage] CHECK CONSTRAINT [FK_RoomMessage_Speaker]
GO
ALTER TABLE [dbo].[Speaker]  WITH CHECK ADD  CONSTRAINT [FK_Speaker_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Speaker] CHECK CONSTRAINT [FK_Speaker_User]
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Add]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_Add]
	@UserId VARCHAR(50),
	@Name NVARCHAR(50),
	@Status NCHAR(3)
AS
BEGIN

	INSERT INTO [Speaker] (UserId,[Name],[Status])
		 VALUES
			   (@UserId, @Name, @Status)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Delete]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_Delete]
	@UserId  UNIQUEIDENTIFIER
AS
BEGIN

	DELETE FROM [Speaker] WHERE [UserId] = @UserId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Get]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_Get]  
 @UserId UNIQUEIDENTIFIER
AS  
BEGIN  
  
 SELECT UserId, [Name], [Status]  
   FROM [Speaker]   
 WHERE UserId = @UserId
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_List]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_List]
AS  
BEGIN  
  
 SELECT UserId, [Name], [Status]  
   FROM [Speaker]
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Update]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_Update]
	@UserId VARCHAR(50),
	@Name NVARCHAR(50),
	@Status NCHAR(3)
AS
BEGIN

	UPDATE [Speaker] 
	SET [Name]=@Name, 
		[Status]=@Status
	WHERE UserId= @UserId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Add]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Add]
	@Id VARCHAR(50),
	@Username NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN

	INSERT INTO [User] (Id, UserName, [Password])
		 VALUES
			   (@ID, @Username, @Password)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Authenticate]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Authenticate]
	@UserName NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN

	SELECT Id, UserName, [Password]
		 FROM [User] 
	WHERE UserName = @UserName
		AND Password = @Password

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Delete]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Delete]
	@Id  UNIQUEIDENTIFIER
AS
BEGIN

	DELETE FROM [User] WHERE [Id] = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Get]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Get]  
 @Id UNIQUEIDENTIFIER
AS  
BEGIN  
  
 SELECT Id, UserName, [Password]  
   FROM [User]   
 WHERE Id = @Id
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_List]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_List]
AS  
BEGIN  
  
 SELECT Id, UserName, [Password]  
   FROM [User]
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Update]
	@Id VARCHAR(50),
	@Username NVARCHAR(50),
	@Password NVARCHAR(50)
AS
BEGIN

	UPDATE [User] 
	SET UserName=@Username, 
		[Password]=@Password
	WHERE Id= @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Validate]    Script Date: 15/01/2022 23:30:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Validate]  
 @UserName NVARCHAR(50)  
AS  
BEGIN  
  
 SELECT Id, UserName, [Password]  
   FROM [User]   
 WHERE UserName = @UserName
  
END
GO
USE [master]
GO
ALTER DATABASE [dbSpeakUp] SET  READ_WRITE 
GO
