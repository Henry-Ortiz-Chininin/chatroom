USE [master]
GO
/****** Object:  Database [dbSpeakUp]    Script Date: 20/01/2022 20:27:35 ******/
CREATE DATABASE [dbSpeakUp]
GO
USE [dbSpeakUp]
GO
/****** Object:  Table [dbo].[Listener]    Script Date: 20/01/2022 20:27:35 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 20/01/2022 20:27:35 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomMate]    Script Date: 20/01/2022 20:27:35 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomMessage]    Script Date: 20/01/2022 20:27:35 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speaker]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speaker](
	[UserId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [nchar](3) NOT NULL,
	[CurrentRoomId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Speaker] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__User__3214EC0784AFE659] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Speaker] ([UserId], [Name], [Status], [CurrentRoomId]) VALUES (N'3a7a5ac5-780e-4593-988e-a1689358d704', N'Celinda Bot', N'ACT', NULL)
GO
INSERT [dbo].[User] ([Id], [UserName], [Password]) VALUES (N'3a7a5ac5-780e-4593-988e-a1689358d704', N'Celinda@bot.ia', N'1234')
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
/****** Object:  StoredProcedure [dbo].[usp_Listener_Add]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Listener_Add]
	@SpeakerId	uniqueidentifier,
	@ListernerId	uniqueidentifier
AS
BEGIN

	INSERT INTO Listener(SpeakerId, ListernerId)
	VALUES(@SpeakerId, @ListernerId)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Listener_Delete]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Listener_Delete]
	@SpeakerId	uniqueidentifier,
	@ListernerId	uniqueidentifier
AS
BEGIN

	DELETE FROM Listener 
	WHERE SpeakerId = @SpeakerId
	AND ListernerId = @ListernerId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_Listener_List]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Listener_List]
	@SpeakerId	uniqueidentifier
AS
BEGIN

	SELECT SpeakerId, ListernerId
	FROM Listener 
	WHERE SpeakerId = @SpeakerId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_Room_Add]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Room_Add]
	@Id	uniqueidentifier,
	@CreatorId	uniqueidentifier,
	@RoomName	nvarchar(100),
	@Status	nchar(3)
AS
BEGIN

	INSERT INTO [Room] (Id,CreatorId,RoomName,Status,CreationDate,LastUpdate)
		 VALUES
			   (@Id,@CreatorId,@RoomName,@Status,GETDATE(),GETDATE())

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Room_Delete]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Room_Delete]
	@Id	uniqueidentifier
AS
BEGIN

	DELETE FROM [Room] WHERE Id = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Room_Get]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Room_Get]
	@Id uniqueidentifier
AS
BEGIN

	SELECT  Id,CreatorId,RoomName,Status,CreationDate,LastUpdate
	FROM [Room] 
	WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Room_List]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Room_List]
AS
BEGIN

	SELECT  Id,CreatorId,RoomName,Status,CreationDate,LastUpdate
	FROM [Room] 

END
GO
/****** Object:  StoredProcedure [dbo].[usp_Room_Update]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Room_Update]
	@Id	uniqueidentifier,
	@CreatorId	uniqueidentifier,
	@RoomName	nvarchar(100),
	@Status	nchar(3)
AS
BEGIN

	UPDATE [Room] 
	SET CreatorId=@CreatorId,
		RoomName=@RoomName,
		[Status]=@Status,
		LastUpdate=GETDATE()
	WHERE Id = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMate_Add]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMate_Add]
	@RoomId	uniqueidentifier,
	@RoomMateId	uniqueidentifier,
	@Status	nchar(3)
AS
BEGIN

	INSERT INTO RoomMate (RoomId, RoomMateId, [Status])
		VALUES (@RoomId, @RoomMateId, @Status)


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMate_Delete]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMate_Delete]
	@RoomId	uniqueidentifier,
	@RoomMateId	uniqueidentifier
AS
BEGIN

	DELETE FROM RoomMate 
	WHERE RoomId=@RoomId
		AND RoomMateId=@RoomMateId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMate_Update]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMate_Update]
	@RoomId	uniqueidentifier,
	@RoomMateId	uniqueidentifier,
	@Status	nchar(3)
AS
BEGIN

	UPDATE RoomMate 
		SET [Status]=@Status
	WHERE RoomId=@RoomId
		AND RoomMateId=@RoomMateId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMateByMate_List]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMateByMate_List]  
 @RoomMateId uniqueidentifier  
AS  
BEGIN  
  
 SELECT distinct RoomId, RoomMateId, [Status]  
 FROM RoomMate   
 WHERE RoomMateId=@RoomMateId  
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMateByRoom_List]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMateByRoom_List]
	@RoomId	uniqueidentifier
AS
BEGIN

	SELECT RoomId, RoomMateId, [Status]
	FROM RoomMate 
	WHERE RoomId=@RoomId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMessage_Add]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMessage_Add]
	@Id	uniqueidentifier,
	@RoomId	uniqueidentifier,
	@SpeakerId	uniqueidentifier,
	@Message	nvarchar(500),
	@ReferenceId	uniqueidentifier=null
AS
BEGIN

	INSERT INTO RoomMessage
		(Id, RoomId, SpeakerId, [Message], CreationTime, ReferenceId)
	VALUES
		(@Id, @RoomId, @SpeakerId, @Message, GETDATE(), @ReferenceId)
		

END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMessage_Delete]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMessage_Delete]
	@Id	uniqueidentifier
AS
BEGIN

	DELETE FROM RoomMessage
	WHERE Id=@Id


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMessage_Get]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMessage_Get]
	@Id	uniqueidentifier,
	@RoomId	uniqueidentifier
AS
BEGIN

	SELECT Id, RoomId, SpeakerId, [Message], CreationTime, ReferenceId
	FROM RoomMessage
	WHERE Id=@Id
		AND RoomId=@RoomId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMessage_List]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMessage_List]
	@RoomId	uniqueidentifier
AS
BEGIN

	SELECT TOP 50 Id, RoomId, SpeakerId, [Message], CreationTime, ReferenceId
	FROM RoomMessage
	WHERE RoomId=@RoomId
	ORDER BY CreationTime DESC

END
GO
/****** Object:  StoredProcedure [dbo].[usp_RoomMessage_Update]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_RoomMessage_Update]
	@Id	uniqueidentifier,
	@RoomId	uniqueidentifier,
	@Message	nvarchar(500)
AS
BEGIN

	UPDATE RoomMessage
		SET [Message] = @Message
	WHERE Id=@Id
		AND RoomId=@RoomId


END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Add]    Script Date: 20/01/2022 20:27:35 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Delete]    Script Date: 20/01/2022 20:27:35 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Get]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_Get]  
 @UserId UNIQUEIDENTIFIER
AS  
BEGIN  
  
 SELECT UserId, [Name], [Status], CurrentRoomId 
   FROM [Speaker]   
 WHERE UserId = @UserId
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_List]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_List]
AS  
BEGIN  
  
 SELECT UserId, [Name], [Status], CurrentRoomId 
   FROM [Speaker]
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Speaker_Update]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_Speaker_Update]
	@UserId VARCHAR(50),
	@Name NVARCHAR(50),
	@Status NCHAR(3),
	@CurrentRoomId UNIQUEIDENTIFIER
AS
BEGIN

	UPDATE [Speaker] 
	SET [Name]=@Name, 
		[Status]=@Status,
		CurrentRoomId = @CurrentRoomId
	WHERE UserId= @UserId

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Add]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Add]
	@Id VARCHAR(50),
	@Username NVARCHAR(200),
	@Password NVARCHAR(50)
AS
BEGIN

	INSERT INTO [User] (Id, UserName, [Password])
		 VALUES
			   (@ID, LOWER(@Username), @Password)

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Authenticate]    Script Date: 20/01/2022 20:27:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_User_Authenticate]
	@UserName NVARCHAR(200),
	@Password NVARCHAR(50)
AS
BEGIN

	SELECT Id, UserName, [Password]
		 FROM [User] 
	WHERE LOWER(UserName) = LOWER(@UserName)
		AND Password = @Password

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Delete]    Script Date: 20/01/2022 20:27:35 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_User_Get]    Script Date: 20/01/2022 20:27:35 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_User_List]    Script Date: 20/01/2022 20:27:35 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 20/01/2022 20:27:35 ******/
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
	SET UserName=LOWER(@Username), 
		[Password]=@Password
	WHERE Id= @ID

END
GO
/****** Object:  StoredProcedure [dbo].[usp_User_Validate]    Script Date: 20/01/2022 20:27:35 ******/
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
 WHERE LOWER(UserName) = LOWER(@UserName)
  
END
GO
USE [master]
GO
ALTER DATABASE [dbSpeakUp] SET  READ_WRITE 
GO
