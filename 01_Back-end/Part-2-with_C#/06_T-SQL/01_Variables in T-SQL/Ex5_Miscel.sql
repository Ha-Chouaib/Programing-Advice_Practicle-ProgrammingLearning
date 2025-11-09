-----------------------Exercise [1]-- Declare two integer variables @x = 15, @y = 7. Print their sum, difference, product, and division.

Declare @X INT, @Y INT;
Declare @Result int;

SET @X = 15;
SET @Y = 7;

SET @Result = @X + @Y;
Print CONCAT('( ',@X ,' + ',@Y,' ) = ',@Result);

SET @Result =@X - @Y;
Print CONCAT('( ',@X ,' - ',@Y,' ) = ',@Result);

SET @Result =@X * @Y;
Print CONCAT('( ',@X ,' * ',@Y,' ) = ',@Result);

SET @Result =@X / @Y;
Print CONCAT('( ',@X ,' / ',@Y,' ) = ',@Result);


-----------------------Exercise [2]-- Declare a string variable. And Print only the first 4 characters.
Declare @Name Nvarchar(20);
SET @Name = 'Chouaib Hadadi';
Print SubString(@Name,1,4);

-----------------------Exercise [3]-- Declare a variable @birthYear = 1995. Calculate age using YEAR(GETDATE()) - @birthYear
Declare @BirthYear INT;
Declare @Age INT;

SET @BirthYear = 1995;
SET @Age =YEAR(GETDATE()) - @BirthYear;
PRINT CONCAT('The Age Of a man Birth On 1995 is: ',@Age);



