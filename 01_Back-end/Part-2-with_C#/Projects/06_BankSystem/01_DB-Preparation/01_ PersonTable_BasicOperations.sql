------------------INSERT---------------------
CREATE PROCEDURE Sp_AddNewPerson
   @FirstName nvarchar(50)	,
   @LastName nvarchar(50)	,
   @DateOfBirth date		,
   @NationalNo nvarchar(15)	,
   @Email nvarchar(60)		,
   @Phone nvarchar(20)		,
   @CountryID int			,
   @Address nvarchar(255)	,
   @ImagePath nvarchar(255)	,
   @CreatedAt datetime		,
   @CreatedByUserID int		,
   @PersonID INT OUTPUT
AS
BEGIN
    BEGIN TRY

	INSERT INTO People (
            FirstName
           ,LastName
           ,DateOfBirth
           ,NationalNo
           ,Email
           ,Phone
           ,CountryID
           ,Address
           ,ImagePath
           ,CreatedAt
           ,CreatedByUserID 
           )
        VALUES
        (
            @FirstName
           ,@LastName
           ,@DateOfBirth
           ,@NationalNo
           ,@Email
           ,@Phone
           ,@CountryID
           ,@Address
           ,@ImagePath
           ,@CreatedAt
           ,@CreatedByUserID 
           );

        SET @PersonID = SCOPE_IDENTITY();
        SELECT 1 AS Success
    END TRY

    BEGIN CATCH
        SELECT 0 AS Success , ERROR_MESSAGE() AS ErrorMSG;
    END CATCH;

END;
GO
--------------------- UPDATE ----------------
CREATE PROCEDURE Sp_UpdatePersonInf
   @PersonID INt,
   @FirstName nvarchar(50)	,
   @LastName nvarchar(50)	,
   @DateOfBirth date		,
   @NationalNo nvarchar(15)	,
   @Email nvarchar(60)		,
   @Phone nvarchar(20)		,
   @CountryID int			,
   @Address nvarchar(255)	,
   @ImagePath nvarchar(255)	
   	
AS
BEGIN
    Begin TRY
	UPDATE  People          
            SET
            FirstName = @FirstName
           ,LastName = @LastName
           ,DateOfBirth = @DateOfBirth
           ,NationalNo  = @NationalNo
           ,Email = @Email
           ,Phone = @Phone
           ,CountryID = @CountryID
           ,Address = @Address
           ,ImagePath = @ImagePath

           WHERE PersonID = @PersonID 

           IF @@ROWCOUNT > 0
                SELECT 1 AS Success;
           ELSE 
                SELECT 0 AS Success;
     End TRY
     BEGIN CATCH
        SELECT 0 AS Success;
     END CATCH
        

END;
GO
-------------------- Get Person's Info ------------------
CREATE PROCEDURE Sp_GetPersonByID
    @PersonID INT
AS
Begin
    SELECT * from People WHERE PersonID = @PersonID;
END;
GO               -------------------------
CREATE PROCEDURE Sp_GetPersonByNationlNo
    @NationalNo Nvarchar(20)
AS
Begin
    SELECT * from People WHERE NationalNo = @NationalNo;
END;
GO

------------------ Delete Person -------------------
CREATE PROCEDURE Sp_DeletePersonByID
    @PersonID INT
AS
Begin
    DELETE People WHERE PersonID = @PersonID;
END;
GO

----------------- Is Person Exists ----------------
CREATE FUNCTION Fn_IsPersonExistsByID ( @PersonID INT )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM People WHERE PersonID = @PersonID)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go    
                ------------------------
CREATE FUNCTION Fn_IsPersonExistsByNationlNo ( @NationalNo NVARCHAR(20) )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM People WHERE NationalNo = @NationalNo)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;




