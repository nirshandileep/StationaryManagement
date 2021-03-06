/****** Object:  StoredProcedure [dbo].[usp_User_Delete]    Script Date: 09/01/2013 21:55:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_User_Delete] 
    @UserID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	update [dbo].[User]
	SET IsActive = 0
		,IsLocked = 1
		,IsDeleted = 1
	WHERE  [UserID] = @UserID

	COMMIT
