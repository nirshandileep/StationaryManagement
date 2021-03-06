/****** Object:  StoredProcedure [dbo].[usp_User_Select]    Script Date: 09/02/2013 06:57:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[usp_User_GetAll] 
    @IsActive INT,
    @UserName varchar(50) = '',
    @RoleID int = 0
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	
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
	WHERE	(@IsActive is null or [IsActive] = @IsActive) 
			and (@RoleID = 0 or [RoleID] = @RoleID)
			and	(@UserName = '' or [UserName] like '%' + @UserName + '%')

	
