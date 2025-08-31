
----------------------------- Insert Customer -------------------
CREATE PROCEDURE Sp_AddNewCustomer
	@PersonID INT,
	@Occupation NVARCHAR(30),
	@CustomerType TinyINT
AS
BEGIN

	BEGIN TRY
		INSERT INTO Customers (PersonID, Occupation, CustomerType)
			VALUES (@PersonID, @Occupation,@CustomerType);

		SELECT SCOPE_IDENTITY() AS CustomerID;

	END TRY
	BEGIN CATCH
	 
	 SELECT -1 AS Failed, ERROR_MESSAGE() AS Error_MSG;

	END CATCH

END;
GO
------------------------ GET Customer ----------------
CREATE PROCEDURE Sp_GetCustomerByID
	@CustomerID INT
AS
BEGIN
	BEGIN TRY
		SELECT * FROM Customers WHERE CustomerID = @CustomerID;
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO
			-------------------------------
CREATE PROCEDURE Sp_GetCustomerByPersonID
	@PersonID INT
AS
BEGIN
	BEGIN TRY
		SELECT * FROM Customers WHERE PersonID = @PersonID;
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO
------------------------- Update Cusrtomer info -----------------

CREATE PROCEDURE Sp_UpdateCustomer @CustomerID int, @Occupation NVARCHAR(50), @CustomerType tinyint
AS
BEGIN

	BEGIN TRY
		UPDATE Customers SET
				Occupation =@Occupation,
				CustomerType = @CustomerType
				WHERE
				CustomerID = @CustomerID;
		IF @@ROWCOUNT > 0
			SELECT 1 AS Success
		ELSE 
			SELECT 0 AS Success

	END TRY
	BEGIN CATCH
		SELECT 0 AS Success , ERROR_MESSAGE() AS ErrorMSG;
	END CATCH



END;
GO
--------------------------- Delete Customer --------------------

CREATE PROCEDURE Sp_DeleteCustomer @CustomerID int
AS
BEGIN
	begin try

		DELETE Customers WHERE CustomerID =@CustomerID;

		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;
	END TRY
	BEGIN CATCH

		SELECT 0 AS Success, ERROR_MESSAGE() AS ErrorMSG;
	END CATCH
END;
GO

-------------------- EXISTS --------------------------

CREATE FUNCTION Fn_IsCustomerExistsByID ( @CustomerID INT )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM Customers WHERE CustomerID = @CustomerID)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go 
					----------------
CREATE FUNCTION Fn_IsCustomerExistsByPersonID ( @PersonID INT )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM Customers WHERE PersonID = @PersonID)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go 

----------------------- Get All Users 

CREATE PROCEDURE Sp_GetAllUsers
AS 
BEGIN
	SELECT * FROM Customers;
END;

	