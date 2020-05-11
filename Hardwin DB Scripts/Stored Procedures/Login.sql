USE [Hardwin]
GO

/****** Object:  StoredProcedure [dbo].[uspLogin]    Script Date: 5/11/2020 12:50:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[uspLogin]
@Email varchar(100),
@Password nvarchar(100)
AS
BEGIN
SELECT  Id, Email, [Password], IsActive FROM [Login] where Email=@Email and [Password]=@Password

END




GO

