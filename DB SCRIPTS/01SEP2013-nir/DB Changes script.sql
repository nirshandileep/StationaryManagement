/*
   Sunday, September 01, 201312:36:25 PM
   User: 
   Server: (local)
   Database: StationaryManagement2
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.[User]
	DROP CONSTRAINT FK_User_UserType
GO
DROP TABLE dbo.UserType
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.webpages_UsersInRoles
	DROP CONSTRAINT fk_UserId
GO
DROP TABLE dbo.UserProfile
GO
COMMIT
BEGIN TRANSACTION
GO
DROP TABLE dbo.UserRole
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.webpages_UsersInRoles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.webpages_UsersInRoles', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.webpages_UsersInRoles', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.webpages_UsersInRoles', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Role SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Role', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Role', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Role', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.[User].UserTypeID', N'Tmp_RoleID_5', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.[User].Tmp_RoleID_5', N'RoleID', 'COLUMN' 
GO
ALTER TABLE dbo.[User] ADD CONSTRAINT
	FK_User_Role FOREIGN KEY
	(
	RoleID
	) REFERENCES dbo.Role
	(
	RoleID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.[User]', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'CONTROL') as Contr_Per 