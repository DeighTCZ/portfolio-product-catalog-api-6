/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF (NOT EXISTS(SELECT [id] FROM [security].[user]))
BEGIN
    INSERT INTO [security].[user] ([login], [password]) VALUES (N'admin', N'admin')
    INSERT INTO [security].[user] ([login], [password]) VALUES (N'jwtuser', N'jwt')
END
