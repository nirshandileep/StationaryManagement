
/****** Object:  UserDefinedFunction [dbo].[getNextNumber]    Script Date: 09/01/2013 13:39:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER function [dbo].[getNextNumber](@sPrefix varchar(4), @iNextNo int, @iLength int)
returns varchar(max)
as
begin
	declare @sNextNumber varchar(max)

	set  @sNextNumber = cast (@sPrefix as varchar) + right('00000000000000000000000'+ 
	                               cast(@iNextNo as varchar), @iLength  )

return Replace(@sNextNumber,' ','')
end



--SELECT dbo.[getNextNumber]('C',(select isnull(max(PackageID),0) + 1 from dbo.Package), 5)
