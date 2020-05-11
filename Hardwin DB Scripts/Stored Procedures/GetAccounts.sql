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

