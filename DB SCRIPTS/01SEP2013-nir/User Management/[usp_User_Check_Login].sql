/****** Object:  StoredProcedure [dbo].[uspCheckUserLogin]    Script Date: 09/01/2013 22:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[usp_User_Check_Login]
	@UserName AS VARCHAR(50),
	@Password AS VARCHAR(50)

AS
BEGIN

DECLARE @nUserId bigint
SET @nUserId = (SELECT UserID FROM [User] WHERE UserName = @UserName AND Password = @Password COLLATE SQL_Latin1_General_Cp1_CS_AS)
	IF EXISTS( SELECT UserID FROM [User] WHERE UserName = @UserName AND Password = @Password COLLATE SQL_Latin1_General_Cp1_CS_AS)
(
		SELECT * FROM [User]		
		WHERE @nUserId=UserID
			
)		
END
