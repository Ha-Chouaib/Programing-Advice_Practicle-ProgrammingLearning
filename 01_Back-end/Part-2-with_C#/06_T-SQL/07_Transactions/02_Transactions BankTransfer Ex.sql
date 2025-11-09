
SELECT * From Accounts;

BEGIN TRANSACTION
	
	BEGIN TRY

	UPDATE Accounts SET Balance -= 100 Where AccountID =1;

	UPDATE Accounts SET Balance += 100 Where AccountID =2;

	INSERT INTO Transactions(FromAccount, ToAccount,Amount,Date) Values(1,2,100, GETDATE());

	COMMIT; --Means that all statments are done successfully and ready to be applaied from Transacttion log file to the real tables
	END TRY

	BEGIN CATCH

	ROLLBACK ; -- In Case At Least One Of The Statments failed all  other ones will return to the original state and ignore the current changes
	
	END CATCH;
	
	SELect * from Accounts;
