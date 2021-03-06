/****** Object:  StoredProcedure [dbo].[usp_User_GetAll]    Script Date: 09/02/2013 23:05:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_User_GetAll] 
    @IsActive bit,
    @UserName varchar(50) = '',
    @RoleID int = 0
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	
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
	FROM   [dbo].[User] u 
	inner join Role r on u.RoleID = r.RoleID
	WHERE	--(@IsActive is null or [IsActive] = @IsActive) and 
			(@RoleID = 0 or u.[RoleID] = @RoleID)
			and	(@UserName = '' or [UserName] like '%' + @UserName + '%')
			and isnull(IsDeleted,0) = 0
	
