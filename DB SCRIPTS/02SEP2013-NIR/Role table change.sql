/*
   Monday, September 02, 201310:53:03 PM
   User: 
   Server: (local)
   Database: StationaryManagement
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
CREATE TABLE dbo.Tmp_Role
	(
	RoleID int NOT NULL IDENTITY (1, 1),
	Description varchar(50) NOT NULL,
	IsActive bit NULL,
	CreatedDate datetime NOT NULL,
	CreatedBy int NOT NULL,
	UpdatedBY int NULL,
	UpdatedDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Role SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Role ON
GO
IF EXISTS(SELECT * FROM dbo.Role)
	 EXEC('INSERT INTO dbo.Tmp_Role (RoleID, Description, IsActive, CreatedDate, CreatedBy, UpdatedBY, UpdatedDate)
		SELECT RoleID, CONVERT(varchar(50), Description), IsActive, CreatedDate, CreatedBy, UpdatedBY, UpdatedDate FROM dbo.Role WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Role OFF
GO
ALTER TABLE dbo.[User]
	DROP CONSTRAINT FK_User_Role
GO
DROP TABLE dbo.Role
GO
EXECUTE sp_rename N'dbo.Tmp_Role', N'Role', 'OBJECT' 
GO
ALTER TABLE dbo.Role ADD CONSTRAINT
	PK_Role PRIMARY KEY CLUSTERED 
	(
	RoleID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Role', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Role', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Role', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
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