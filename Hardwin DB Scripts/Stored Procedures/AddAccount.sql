USE [Hardwin]
GO

/****** Object:  StoredProcedure [dbo].[uspAddAccount]    Script Date: 5/11/2020 12:50:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[uspAddAccount]
@FirstName varchar(100),
@LastName varchar(100),
@Address nvarchar(250),
@Phone varchar(15),
@State varchar(100),
@Country varchar(100),
@Email varchar(100),
@Amount Decimal(18,2),

@AccountId int OUTPUT
as
begin

insert into [dbo].[Account](FirstName,LastName,[Address],Phone,[State],Country,Email,Amount) 
values(@FirstName,@LastName,@Address,@Phone,@State,@Country,@Email,@Amount)
set @AccountId=(select SCOPE_IDENTITY())
end

GO

