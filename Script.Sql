CREATE DATABASE Hardwin
GO

USE [Hardwin]
GO

/****** Object:  Table [dbo].[Login]    Script Date: 5/11/2020 12:47:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Hardwin]
GO

/****** Object:  Table [dbo].[Account]    Script Date: 5/11/2020 12:46:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[Address] [nvarchar](250) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[Country] [varchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO


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


USE [Hardwin]
GO

/****** Object:  StoredProcedure [dbo].[GetAccounts]    Script Date: 5/11/2020 12:50:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccounts] 
	@FromDate DateTime = NULL,
	@ToDate DateTime = NULL,
	@Amount decimal=null
AS
BEGIN
	IF(@Amount IS NOT NULL)
		BEGIN
			IF(@FromDate IS NOT NULL AND @ToDate IS NOT NULL)
		BEGIN
			SELECT * FROM ACCOUNT WHERE CONVERT(VARCHAR(30),CreatedDate,101) BETWEEN  @FromDate AND @ToDate AND Amount<=@Amount
		END
		ELSE IF(@FromDate IS NOT NULL AND @ToDate IS NULL)
		BEGIN
			SELECT * FROM ACCOUNT WHERE CONVERT(VARCHAR(30),CreatedDate,101) >=@FromDate  AND Amount<=@Amount
		END
		ELSE IF(@FromDate IS NULL AND @ToDate IS NOT NULL)
		BEGIN
			SELECT * FROM ACCOUNT WHERE (CONVERT(VARCHAR(30),CreatedDate,101) <= @ToDate  )  AND Amount<=@Amount
		END
		ELSE
		BEGIN
			SELECT * FROM ACCOUNT WHERE Amount<=@Amount
		END
	END
	ELSE
	BEGIN	 
		BEGIN
			IF(@FromDate IS NOT NULL AND @ToDate IS NOT NULL)
		BEGIN
			SELECT * FROM ACCOUNT WHERE CONVERT(VARCHAR(30),CreatedDate,101) BETWEEN  @FromDate AND @ToDate  
		END
		ELSE IF(@FromDate IS NOT NULL AND @ToDate IS NULL)
		BEGIN
			SELECT * FROM ACCOUNT WHERE CONVERT(VARCHAR(30),CreatedDate,101) >=@FromDate  
		END
		ELSE IF(@FromDate IS NULL AND @ToDate IS NOT NULL)
		BEGIN
			SELECT * FROM ACCOUNT WHERE (CONVERT(VARCHAR(30),CreatedDate,101) <= @ToDate  )  
		END
		ELSE
		BEGIN
			SELECT * FROM ACCOUNT  
		END	
	END
	
END 
end
GO

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


