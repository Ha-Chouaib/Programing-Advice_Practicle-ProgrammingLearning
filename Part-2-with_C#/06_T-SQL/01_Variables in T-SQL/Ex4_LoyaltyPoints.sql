
DECLARE @CustomerID INT ;
DECLARE @TotalSpent DECIMAL(10 ,2) ;
DECLARE @PointsEarned INT;
DECLARE @CurrentYear Int = Year(GETDATE());

SET @CustomerID = 1;

SELECT @TotalSpent = Count(Amount) from Purchases
	Where CustomerID = @CustomerID AND Year (PurchaseDate) = @CurrentYear;

SET @PointsEarned = CAST( @TotalSpent / 10 as INT);

UPDATE Customers 
	SET LoyaltyPoints= LoyaltyPoints  + @PointsEarned where CustomerID = @CustomerID;

Print 'Loyalty Points For Customer ID: << '+CAST(@CustomerID as VARCHAR)+' >>';
Print 'Total Amount Spent In: '+CAST(@CurrentYear as VARCHAR)+' $'+ CAST(@TotalSpent as VarChar);
Print 'Loyalty Points Earned: '+CAST(@PointsEarned as VARCHAR);






