
Select * from Sales
	Order By 
	Case 
		When SaleAmount >= 150 Then 1
		Else 2
	END, SaleAmount Desc;