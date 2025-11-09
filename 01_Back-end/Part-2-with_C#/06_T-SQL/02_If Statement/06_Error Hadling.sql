
DECLARE @ErrorValue INT;

INsert into  Employees (Name) Values ('Chouaib');

SET @ErrorValue = @@ERROR;

If @ErrorValue <> 0
BEGIN
	Print 'An Error Accured with number [ ' + CAST(@ErrorValue as VarChar) + ' ]';
END;