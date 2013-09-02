SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[usp_User_Check_UserName_Exist]

@UserName varchar(50),
@IsExists bit output

AS
BEGIN
	if exists(select 1 from [User] where UserName = @UserName)
	begin
		set @IsExists = 1
	end	
	else
	begin
		set @IsExists = 0
	end

END







