/****** Object:  StoredProcedure [dbo].[usp_User_Insert]    Script Date: 09/01/2013 21:16:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_User_Insert] 
    @RoleID int,
    @UserName varchar(50),
    @Password binary(1000),
    @Email varchar(50),
    @RemainAttempts int,
    @IsActive bit,
    @IsLocked bit,
    @CreatedBy int,
     @NewID int output
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[User] (
				[RoleID],
				[UserName], 
				[Password], 
				[Email], 
				[RemainAttempts], 
				[IsActive], 
				[IsLocked],
				[CreatedBy], 
				[CreatedDate])
	SELECT	@RoleID, 
			@UserName, 
			@Password, 
			@Email, 
			@RemainAttempts, 
			@IsActive, 
			@IsLocked, 
			@CreatedBy, 
			GETDATE()
	
	set @NewID = SCOPE_IDENTITY();
	               
	COMMIT
