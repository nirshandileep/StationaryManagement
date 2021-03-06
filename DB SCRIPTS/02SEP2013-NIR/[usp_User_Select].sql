/****** Object:  StoredProcedure [dbo].[usp_User_Select]    Script Date: 09/02/2013 23:39:53 ******/
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
			u.[RoleID], 
			r.Description as [RoleDescription],
			[UserName], 
			[Password], 
			[Email], 
			[RemainAttempts], 
			u.[IsActive], 
			[IsLocked], 
			u.[CreatedBy], 
			u.[CreatedDate], 
			u.[UpdatedBY], 
			u.[UpdatedDate] 
	FROM   [dbo].[User] u inner join Role r on u.RoleID = r.RoleID
	WHERE  [UserID] = @UserID 

	COMMIT
