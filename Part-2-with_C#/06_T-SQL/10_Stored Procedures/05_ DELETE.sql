CREATE PROCEDURE SP_DeletePerson
	@PersonID int
AS
Begin
	DELETE from People WHERE PersonID = @PersonID;
END;

SELECT * from People;

EXEC SP_DeletePerson @PersonID = 2;

SELECT * from People;
