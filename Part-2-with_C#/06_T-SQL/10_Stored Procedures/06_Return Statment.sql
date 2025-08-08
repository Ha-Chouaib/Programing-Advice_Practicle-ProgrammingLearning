
CREATE PROCEDURE SP_IsPersonExists
	@PersonID INT
AS
BEGIN
	IF EXISTS(SELECT * from People where PersonID = @PersonID)
		RETURN 1;
	ELSE
		RETURN 0;
END;

-----------------------------
DECLARE @Result int;

EXEC @Result = SP_IsPersonExists @PersonID = 5 ;

IF @Result = 1
	PRINT 'Person Exists';
ELSE
	PRINT 'Person Does not Exists';
