

Select SaleID, SaleAmount,
	CASE 
	When SaleAmount <= 100 Then 'Week'
	When SaleAmount Between 101 And 200 Then 'Good'
	When SaleAmount Between 201 And 300 Then 'Exelent'
	
	Else 'Not Specified'
	End As SalesLevel
From Sales;
