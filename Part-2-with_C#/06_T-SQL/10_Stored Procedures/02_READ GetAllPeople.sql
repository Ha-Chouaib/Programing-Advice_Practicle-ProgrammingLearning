
Create PROCEDURE SP_GetAllPeople

AS 
Begin
Select * from People;
END;

EXEC SP_GetAllPeople;



