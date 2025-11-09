
DECLARE  @a int, @b int ;

Set @a = 10;
Set @b = 11;

IF @a < @b
	BEGIN
	Print 'Yes [ a ] is Lower than [ b ]';
	END;