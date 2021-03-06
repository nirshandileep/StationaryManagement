/****** Object:  StoredProcedure [dbo].[usp_Package_Select]    Script Date: 08/31/2013 22:38:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_Package_Select] 
    @PackageID INT
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN

	SELECT 
		[PackageID], 
		[ItemID], 
		[QtyPerPack], 
		[IsActive], 
		[CreatedBy], 
		[CreatedDate], 
		[UpdatedBY], 
		[UpdatedDate],
		[PackageName]
				
	FROM   [dbo].[Package] 
	WHERE  [PackageID] = @PackageID 

	COMMIT
