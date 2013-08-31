USE [StationaryManagement]
GO
/****** Object:  StoredProcedure [dbo].[usp_Package_GetAll]    Script Date: 08/31/2013 22:08:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[usp_Package_GetAll]
 (
	@IsActive bit = null,
	@PackageName varchar(100) = '',
	@PackageCode varchar(20) = ''
	
 )
AS
SET NOCOUNT ON


SELECT
	PackageID, 
	ItemID, 
	PackageCode,
	PackageName,
	QtyPerPack, 
	IsActive,
	CreatedBy,
	CreatedDate,
	UpdatedBY,
	UpdatedDate
FROM [dbo].Package P
where 
(@IsActive IS NULL OR P.IsActive = @IsActive)
AND
(@PackageCode ='' OR P.PackageCode LIKE '%' + @PackageCode + '%')
AND
(@PackageName ='' OR P.PackageName LIKE '%' + @PackageName + '%')
and 
P.IsDeleted = 0