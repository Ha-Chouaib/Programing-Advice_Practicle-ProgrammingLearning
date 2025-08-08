CREATE Procedure SP_UpdatePerson
	@PersonID int,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR (100),
	@Email NVARCHAR(255)
AS
BEGIN
	Update People
	SET FirstName =@FirstName, LastName= @LastName, Email=@Email
	WHERE PersonID = @PersonID;
END;

----------------------------------------

EXEC SP_UpdatePerson
	@PersonID =1,
	@FirstName= 'Jook',
	@LastName='Hordy',
	@Email='Jook@Gmail.Com';

SELECT * from People where PersonID = 1;