CREATE TABLE [dbo].[userTbl]
(
	[userId] NCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NCHAR(50) NOT NULL, 
    [name] NCHAR(50) NOT NULL, 
    [phone] NCHAR(50) NOT NULL
)
