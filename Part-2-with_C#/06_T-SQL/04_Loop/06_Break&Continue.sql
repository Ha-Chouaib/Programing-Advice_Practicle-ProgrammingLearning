
DECLARE @Counter Int;

Print '--- Break Example ---'
Set @Counter =1;

While @Counter <= 10
BEGIN

	If @Counter > 5
	Begin
		Break;
	End;
	Print '[ '+ Cast(@Counter as varchar) + ' ]';
	SET @Counter +=1;

END;

Print '';
Print '--- Continue Example ---'
Set @Counter =0;

While @Counter <= 10
Begin
	Set @Counter+=1;

	If @Counter % 2 = 0
	Begin
		Continue;
	End;
	Print'<< '+Cast (@Counter as varchar) + ' >>';

END;