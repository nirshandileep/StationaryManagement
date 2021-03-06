/****** Object:  StoredProcedure [dbo].[usp_User_Update]    Script Date: 09/01/2013 21:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_User_Update] 
    @UserID int,
    @RoleID int,
    @UserName varchar(50),
    @Password binary(1000),
    @Email varchar(50),
    @RemainAttempts int,
    @IsActive bit,
    @IsLocked bit,
    @UpdatedBY int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[User]
	SET		RoleID = @RoleID, 
			[UserName] = @UserName, 
			[Password] = @Password, 
			[Email] = @Email, 
			[RemainAttempts] = @RemainAttempts, 
			[IsActive] = @IsActive, 
			[IsLocked] = @IsLocked, 
			[UpdatedBY] = @UpdatedBY, 
			[UpdatedDate] = GETDATE()
	WHERE  [UserID] = @UserID
	
	
	COMMIT
