Declare @Balance Decimal (10 , 2) = 950.00;
Declare @Withdraw Decimal (10 ,2) = 100.00;

While @Balance > 0
Begin
	
	Set @Balance -= @Withdraw;
	IF @Balance < 0
	Begin
		Print 'Insuffusient Balance'
		BREAK;
	END;
	Print 'The New Balance -> [ '+ Cast(@Balance as VARCHAR) + ' ]';
End;

