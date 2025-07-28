
BEGIN TRY

 Select 1 / 0;

END TRY
BEGIN CATCH

SELECT	ERROR_NUMBER() as ErrorNumber, 
		ERROR_LINE () as ErrorLine, 
		ERROR_SEVERITY() as ErrorSeverity,
		ERROR_STATE() as ErrorState, 
		ERROR_PROCEDURE() as ErrorProcedure,
		ERROR_MESSAGE() as ErrorMessage;

END CATCH