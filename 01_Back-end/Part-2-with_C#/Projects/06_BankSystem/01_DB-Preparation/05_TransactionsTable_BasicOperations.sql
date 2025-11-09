------------------INSERT New Transaction ----------------------

CREATE PROCEDURE Sp_AddNewTransaction
				@TransactionType tinyint,
				@TransactionDate dateTime,
				@AccountFromID int,
				@AccountToID int,
				@Amount decimal(18,2),
				@OldBalance decimal(18,2),
				@NewBalance decimal(18,2),
				@Notes Nvarchar(255),
				@PerformedByUserID int
AS
BEGIN
	BEGIN TRY
		
		INSERT INTO Transactions (TransactionType, TransactionDate,AccountFromID,AccountToID,Amount,OldBalance,NewBalance,Notes,PerformedByUserID)
			VALUES (@TransactionType,@TransactionDate,@AccountFromID,@AccountToID,@Amount,@OldBalance,@NewBalance,@Notes,@PerformedByUserID);

		SELECT SCOPE_IDENTITY() AS TransactionID;

	END TRY
	BEGIN CATCH

	SELECT -1 AS TranactionID, ERROR_MESSAGE() AS ErrorMSG;

	END CATCH
END;
GO

------------------- Get Transaction ----------------------

			------------By ID------------

CREATE PROCEDURE Sp_GetTransactionByID @TransactionID int
AS
BEGIN
	BEGIN TRY

		SELECT * FROM Transactions WHERE TransactionID =@TransactionID;
		SELECT 1 AS Success;

	END TRY
	BEGIN CATCH
		SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
	
END;
GO

			------------By AccountID------------

CREATE PROCEDURE Sp_GetTransactionsByAccountID @AccountID int
AS
BEGIN
	BEGIN TRY

		SELECT * FROM Transactions WHERE AccountFromID =@AccountID;
		SELECT 1 AS Success;

	END TRY
	BEGIN CATCH
		SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
	
END;
GO

