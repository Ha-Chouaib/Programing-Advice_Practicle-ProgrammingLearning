
DECLARE @Year int;

SET @Year = 2025;

IF @Year >= 2000
	BEGIN
	Print '21th Century';
	END;
ELSE
	BEGIN
	Print '20th Century or Earlier';
	END;