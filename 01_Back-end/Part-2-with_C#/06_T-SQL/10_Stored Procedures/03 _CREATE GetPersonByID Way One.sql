--Get One Record Way One:

CREATE PROCEDURE SP_GetPersonByID1
	@PersonID INT 
AS
BEGIN
SELECT * From People where PersonID = @PersonID;
END;

EXEC SP_GetPersonByID1 @PersonID = 4;
