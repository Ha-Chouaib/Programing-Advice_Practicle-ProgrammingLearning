---------------Insert New Account -------------------

CREATE PROCEDURE Sp_AddNewAccount	@CustomerID int, 
									@AccountNumber NVARCHAR(50),
									@AccountType Bit,
									@Balance decimal(18,2),
									@IsActive BIT, 
									@CreatedAt DateTime,
									@CreatedByUserID int

AS
BEGIN
	BEGIN TRY

		INSERT INTO dbo.Accounts (CustomerID, AccountNumber,AccountType, Balance,IsActive,CreatedAt,CreatedByUserID)
				Values(@CustomerID,@AccountNumber,@AccountType,@Balance,@IsActive,@CreatedAt,@CreatedByUserID);
		SELECT SCOPE_IDENTITY() AS AccountID;

	END TRY
	BEGIN CATCH
		SELECT -1 AS AccountID, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO

-------------------------GET Account bY ----------------
CREATE PROCEDURE Sp_GetAccountByID @AccountID INT
AS
BEGIN 
	BEGIN TRY

	
	SELECT * FROM Accounts where AccountID = @AccountID;
	SELECT 1 AS Success;
	END TRY
	BEGIN CATCH
		SELECT 0 AS Success, ERROR_MESSAGE() as ErrorMSG;
	END CATCH
END;
GO
					----------------------------------
CREATE PROCEDURE Sp_GetAccountByCustomerID @CustomerID INT
AS
BEGIN 
	BEGIN TRY

	
	SELECT * FROM Accounts where CustomerID = @CustomerID;
	SELECT 1 AS Success;
	END TRY
	BEGIN CATCH
		SELECT 0 AS Success, ERROR_MESSAGE() as ErrorMSG;
	END CATCH
END;
GO

					------------------------------------
										----------------------------------
CREATE PROCEDURE Sp_GetAccountByAccountNumber @AccountNumber NVARCHAR(50)
AS
BEGIN 
	BEGIN TRY

	
	SELECT * FROM Accounts where AccountNumber = @AccountNumber;
	SELECT 1 AS Success;
	END TRY
	BEGIN CATCH
		SELECT 0 AS Success, ERROR_MESSAGE() as ErrorMSG;
	END CATCH
END;
GO


		----------------------Update Account --------------------
				---------Update Balance ------------
CREATE PROCEDURE Sp_UpdateBalanceByAccountID
									@AccountID INT,
									@Balance decimal(18,2)

AS
BEGIN
	BEGIN TRY
		
		UPDATE Accounts SET Balance = @Balance  WHERE  AccountID =@AccountID;
		
		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;

	END TRY
	BEGIN CATCH
			SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO
				----------------------------
CREATE PROCEDURE Sp_UpdateBalanceByAccountNumber
									@AccountNumber NVARCHAR(50),
									@Balance decimal(18,2)

AS
BEGIN
	BEGIN TRY
		
		UPDATE Accounts SET Balance = @Balance  WHERE  AccountNumber =@AccountNumber;
		
		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;

	END TRY
	BEGIN CATCH
			SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO
					----------------- Update status ---------------

CREATE PROCEDURE Sp_UpdateAccountStatusByID @AccountID INT, @IsActive BIT

AS
BEGIN
	BEGIN TRY
		
		UPDATE Accounts SET IsActive = @IsActive  WHERE  AccountID =@AccountID;
		
		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;

	END TRY
	BEGIN CATCH
			SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO
						-----------------------------------
CREATE PROCEDURE Sp_UpdateStatusByAccountNumber @AccountNumber  NVARCHAR(50), @IsActive BIT

AS
BEGIN
	BEGIN TRY
		
		UPDATE Accounts SET IsActive = @IsActive  WHERE  AccountNumber = @AccountNumber;
		
		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;

	END TRY
	BEGIN CATCH
			SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO

			------------------------Delete Account -----------------------
CREATE PROCEDURE Sp_DeleteAccount @AccountID INt
AS
BEGIN
	begin try

		DELETE Accounts WHERE AccountID =@AccountID;

		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;
	END TRY
	BEGIN CATCH

		SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO

-------------------- EXISTS --------------------------

CREATE FUNCTION Fn_IsAccountExistsByID ( @AccountID INT )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM Accounts WHERE AccountID = @AccountID)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go 
					----------------
CREATE FUNCTION Fn_IsAccountExistsByAccountNumber ( @AccountNumber NVARCHAR(50) )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM Accounts WHERE AccountNumber = @AccountNumber)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go 

----------------------- Get All Accounts

CREATE PROCEDURE Sp_GetAccounts
AS 
BEGIN
	SELECT * FROM Accounts;
END;


