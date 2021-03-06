/****** Object:  StoredProcedure [dbo].[usp_User_Select]    Script Date: 09/01/2013 21:50:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_User_Select] 
    @UserID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT	[UserID], 
			[RoleID], 
			[UserName], 
			[Password], 
			[Email], 
			[RemainAttempts], 
			[IsActive], 
			[IsLocked], 
			[CreatedBy], 
			[CreatedDate], 
			[UpdatedBY], 
			[UpdatedDate] 
	FROM   [dbo].[User] 
	WHERE  [UserID] = @UserID 

	COMMIT
