/****** Object:  StoredProcedure [dbo].[usp_Package_Update]    Script Date: 08/31/2013 22:42:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_Package_Update] 
    @PackageID int,
    @QtyPerPack int,
    @IsActive bit,
    @UpdatedBY int,
    @PackageName varchar(50)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[Package]
	SET    
		[QtyPerPack] = @QtyPerPack
		,[IsActive] = @IsActive
		,[PackageName] = @PackageName
		,[UpdatedBY] = @UpdatedBY
		, [UpdatedDate] = GETDATE()
	WHERE  [PackageID] = @PackageID
	
	COMMIT
