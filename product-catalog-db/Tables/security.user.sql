CREATE TABLE [security].[user]
(
	[id] BIGINT IDENTITY(1,1) NOT NULL,
    [login] NVARCHAR(64) NOT NULL, 
    [password] NVARCHAR(64) NOT NULL, 
)
GO
ALTER TABLE [security].[user] ADD CONSTRAINT pk_security_user PRIMARY KEY CLUSTERED (id)
GO
ALTER TABLE [security].[user] ADD CONSTRAINT uk_security_user UNIQUE NONCLUSTERED ([login])
GO
