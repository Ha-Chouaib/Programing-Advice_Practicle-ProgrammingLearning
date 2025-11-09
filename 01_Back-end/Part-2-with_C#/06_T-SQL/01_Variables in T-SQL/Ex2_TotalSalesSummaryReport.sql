
Declare @Year INT;
Declare @Month INT;
Declare @TotalSales Decimal (10,2);
Declare @TotalTransactions Int;
Declare @AverageSale Decimal(10,2);

Set @Year = 2023;
Set @Month = 6;

Select @TotalSales = COUNT(SaleAmount) 
from Sales WHERE Year(SaleDate) = @Year  AND MONTH(SaleDate) = @Month;

Select @TotalTransactions = COUNT(*) 
from Sales where  Year(SaleDate) = @Year  AND MONTH(SaleDate) = @Month;

Set @AverageSale = @TotalSales / @TotalTransactions;

PRINT 'Total Sales Summary Report';
PRINT 'Year: '+ Cast(@Year as VARCHAR) + ' || Month: ' + CAST(@Month as VARCHAR);
PRINT 'Tortal Sales: '+ CAST(@TotalSales as Varchar);
PRINT 'Tortal Transactions: '+ Cast(@TotalTransactions as Varchar);
PRINT 'Average Sales: '+ Cast(@AverageSale as Varchar);