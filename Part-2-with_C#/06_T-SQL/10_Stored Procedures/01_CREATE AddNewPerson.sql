CREATE PROCEDURE SP_AddNewPerson
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR (100),
	@Email nvarchar(255),
	@NewPersonID INT OUTPUT
AS
BEGIN
	INSERT INTO People (FirstName, LAstName,Email)  VALUES (@FirstName,@LastName,@Email);

	SET @NewPersonID = SCOPE_IDENTITY();
END;

---------------------------------------- EXECUTE SP ----------------------------------------

DECLARE @PersonID INT;

EXEC SP_AddNewPerson
	@FirstName ='Chouaib',
	@LastName = 'Hadadi',
	@Email = 'Ha@Gmail.com',
	@NewPersonID = @PersonID OUTPUT;

SELECT @PersonID AS NewPersonID;
Select * from People;
