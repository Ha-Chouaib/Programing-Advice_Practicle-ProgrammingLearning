
WITH SalesTotals AS
(
	SELECT EmployeeID, SUM(SaleAmount) AS TotalSales
		FROM SalesRecords
		Group BY EmployeeID
),
RankedSales AS
(
	SELECT EmployeeID, TotalSales,
		RANK() OVER(ORDER BY TotalSales DESC) AS SalesRank
		FROM SalesTotals
)Select EmployeeID,TotalSales,SalesRank FROM RankedSales;