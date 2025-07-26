DECLARE @Score int;

SET @Score = 98;

IF @Score >= 90
	BEGIN
		PRINT 'Grade [ A ]';
	END;
ELSE
	BEGIN

	IF @Score >= 80
		BEGIN
			PRINT 'Grade [ B ]';
		END;

	ELSE
	BEGIN
		PRINT 'Grade [ C ]';
		END;
	END;