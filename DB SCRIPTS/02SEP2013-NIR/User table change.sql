/*
   Monday, September 02, 201311:02:02 PM
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
ALTER TABLE dbo.[User]
	DROP CONSTRAINT FK_User_Role
GO
ALTER TABLE dbo.Role SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Role', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Role', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Role', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_User
	(
	UserID int NOT NULL IDENTITY (1, 1),
	RoleID int NOT NULL,
	UserName varchar(50) NOT NULL,
	Password nvarchar(50) NULL,
	Email varchar(50) NULL,
	RemainAttempts int NULL,
	IsActive bit NULL,
	IsLocked bit NOT NULL,
	CreatedBy int NOT NULL,
	CreatedDate datetime NOT NULL,
	UpdatedBY int NULL,
	UpdatedDate datetime NULL,
	IsDeleted bit NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_User SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_User ON
GO
IF EXISTS(SELECT * FROM dbo.[User])
	 EXEC('INSERT INTO dbo.Tmp_User (UserID, RoleID, UserName, Password, Email, RemainAttempts, IsActive, IsLocked, CreatedBy, CreatedDate, UpdatedBY, UpdatedDate, IsDeleted)
		SELECT UserID, RoleID, UserName, CONVERT(nvarchar(50), Password), Email, RemainAttempts, IsActive, IsLocked, CreatedBy, CreatedDate, UpdatedBY, UpdatedDate, IsDeleted FROM dbo.[User] WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_User OFF
GO
ALTER TABLE dbo.LogBook
	DROP CONSTRAINT FK_LogBook_User
GO
DROP TABLE dbo.[User]
GO
EXECUTE sp_rename N'dbo.Tmp_User', N'User', 'OBJECT' 
GO
ALTER TABLE dbo.[User] ADD CONSTRAINT
	PK_User PRIMARY KEY CLUSTERED 
	(
	UserID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

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
COMMIT
select Has_Perms_By_Name(N'dbo.[User]', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.[User]', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.LogBook ADD CONSTRAINT
	FK_LogBook_User FOREIGN KEY
	(
	UserID
	) REFERENCES dbo.[User]
	(
	UserID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.LogBook SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.LogBook', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.LogBook', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.LogBook', 'Object', 'CONTROL') as Contr_Per 