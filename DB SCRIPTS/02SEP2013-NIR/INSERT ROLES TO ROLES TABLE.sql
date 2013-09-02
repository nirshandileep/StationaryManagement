/*
INSERT ROLES TO ROLES TABLE
*/

IF (ISNULL((SELECT 1 FROM [Role] WHERE [Description] = 'SuperAdmin'),0) = 0)
BEGIN
	INSERT INTO [dbo].[Role]
			   ([Description]
			   ,[IsActive]
			   ,[CreatedDate]
			   ,[CreatedBy]
			   )
		SELECT 'SuperAdmin',1,GETDATE(),1
		UNION ALL
		SELECT 'Administrator',1,GETDATE(),1
		UNION ALL
		SELECT 'User',1,GETDATE(),1

END