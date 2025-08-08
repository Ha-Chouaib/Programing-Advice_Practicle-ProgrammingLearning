CREATE PROCEDURE SP_GetPersonByID2
    @PersonID INT,
    @FirstName NVARCHAR(100) OUTPUT,
    @LastName NVARCHAR(100) OUTPUT,
    @Email NVARCHAR(255) OUTPUT,
    @IsFound BIT OUTPUT 
AS
BEGIN
    IF EXISTS(SELECT 1 FROM People WHERE PersonID = @PersonID)
    BEGIN
        SELECT 
            @FirstName = FirstName, 
            @LastName = LastName, 
            @Email = Email
        FROM People 
        WHERE PersonID = @PersonID;

        SET @IsFound = 1; 
    END
    ELSE
    BEGIN
        SET @IsFound = 0; 
    END
END
