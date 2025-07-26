
Select EmployeeID ,
	CASE DepartmentID 
		When 1 Then 'Engineering'
		When 2 Then 'Human Resources'
		When 3 Then 'Sales'

	Else 'Other'
	END As DepartmentName
From Employees;
