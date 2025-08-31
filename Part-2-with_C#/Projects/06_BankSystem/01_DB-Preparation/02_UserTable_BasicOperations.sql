
CREATE PROCEDURE Sp_AddNewUser
	@PersonID INT,
	@UserName NVARCHAR(30),
	@CreatedDate DateTime,
	@Role NVARCHAR(50),
	@Password NVARCHAR(Max),
	@IsActive BIT ,
	@CreatedByUserID int
AS
BEGIN
	BEGIN TRY

	INSERT INTO Users (PersonID,UserName,CreatedDate,Role,Password,IsActive,CreatedByUserID)
				VALUES (@PersonID,@UserName,@CreatedDate,@Role,@Password,@IsActive,@CreatedByUserID);

	SELECT SCOPE_IDENTITY() AS NewUserID;

	END TRY
	BEGIN CATCH

	SELECT -1 AS Failed , ERROR_MESSAGE() AS ErrorMSG;

	END CATCH;
END;
GO
---------------------------- UPDATE ------------------------------

CREATE PROCEDURE Sp_UpdateUser
	@UserID INT,
	@UserName NVARCHAR(30),
	@CreatedDate DateTime,
	@Role NVARCHAR(50),
	@Password NVARCHAR(Max),
	@IsActive BIT ,
	@CreatedByUserID int
AS
BEGIN

	BEGIN TRY
		UPDATE Users SET
		UserName = @UserName ,
		CreatedDate = @CreatedDate ,
		Role = @Role ,
		Password = @Password ,
		IsActive = @IsActive  ,
		CreatedByUserID = @CreatedByUserID ;

		IF @@ROWCOUNT > 0
			SELECT 1 AS Success;
		ELSE
			SELECT 0 AS Success;

	END TRY
	BEGIN CATCH
		SELECT 0 AS Success , ERROR_MESSAGE() AS ErrorMSG;
	END CATCH;
END;
GO
----------------------- Get User's Info -----------------------

CREATE PROCEDURE Sp_GetUserByID @UserID INT
AS
BEGIN

	SELECT * FROM Users WHERE UserID = @UserID;

END;
GO
				--------------------------------
CREATE PROCEDURE Sp_GetUserByPersonID @PersonID INT
AS
BEGIN

	SELECT * FROM Users WHERE PersonID = @PersonID;

END;
GO

-------------------- DELETE USER ------------------------
CREATE PROCEDURE Sp_DeleteUser @UserID INT
AS
BEGIN
	begin try

		DELETE Users WHERE UserID =@UserID;

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

CREATE FUNCTION Fn_IsUserExistsByID ( @UserID INT )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM Users WHERE UserID = @UserID)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go 
					----------------
CREATE FUNCTION Fn_IsUserExistsByPersonID ( @PersonID INT )
    RETURNS BIT
AS
Begin

    IF EXISTS(SELECT 1 FROM Users WHERE PersonID = @PersonID)
        RETURN 1;
    ELSE
        RETURN 0;
    RETURN 0;
END;
go 

----------------------- Get All Users 

CREATE PROCEDURE Sp_AllUsers
AS 
BEGIN
	SELECT UserID, UserName,CreatedDate,Role, IsActive,CreatedByUserID FROM Users;
END;

	
