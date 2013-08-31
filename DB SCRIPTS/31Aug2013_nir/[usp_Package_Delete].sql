/****** Object:  StoredProcedure [dbo].[usp_Package_Delete]    Script Date: 09/01/2013 02:16:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_Package_Delete] 
    @PackageID int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	update [dbo].[Package]
	set IsDeleted = 1
	WHERE  [PackageID] = @PackageID

	COMMIT
