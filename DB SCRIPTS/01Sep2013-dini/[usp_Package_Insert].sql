
ALTER PROC [dbo].[usp_Package_Insert] 
    @ItemID int,
    @QtyPerPack int,
    @PackageName varchar(50),
    @IsActive bit,
    @CreatedBy int,
    @NewID int output
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	
	INSERT INTO [dbo].[Package] 
	([ItemID], 
	[QtyPerPack], 
	[IsActive], 
	[CreatedBy], 
	[CreatedDate],
	[PackageName],
	[PackageCode])
	SELECT 
		@ItemID, 
		@QtyPerPack, 
		@IsActive, 
		@CreatedBy, 
		GETDATE(), 
		@PackageName, 
		(dbo.[getNextNumber]('P',(select isnull(max(PackageID),0) + 1 from dbo.Package), 5))
	
	SET @NewID = SCOPE_IDENTITY();
	               
	COMMIT

