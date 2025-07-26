DECLARE @max int;
Declare @a int , @b int;

SET @a= 12;
SET @b= 10;

IF @a > @b
BEGIN
	SET @max = @a;
END;

ELSE
BEGIN
	SET @max =@b;
END;

Print 'The Maximum number: '+ CAST(@max as VARCHAR);