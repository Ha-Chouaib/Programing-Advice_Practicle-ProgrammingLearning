Declare @Score int;

SET @Score = 90;

IF @Score >= 50 
Begin
	Print 'Pass'ENd;
ELSE
Begin
	Print 'Fail';
END;