DECLARE @Row INT =1;
DECLARE @Col INT;
DECLARE @Result INT;
DECLARE @HeaderString VarChar(255);
DECLARE @RowString Varchar(255);

Set @HeaderString = CHAR(9);
SET @Col = 1;

While @Col <= 10
Begin
	Set @HeaderString+= Cast(@Col as varchar) + Char(9);
	Set @Col +=1;
END;
Print @HeaderString;

While @Row <= 10
BEGIN
	SET @Col =1;
	WHile @Col <= 10
	Begin
		SET @Result = @Row * @Col;
		SET @RowString +=  CAST(@Result as varchar) + CHAR(9);
		SET @Col+=1;
	END;

	Print Char(9) + @RowString;
	Set @RowString='';
	SET @Row+=1;
END;
