
Select PerformanceCategory, Count(*) As NumbersOfEmployees, AVG(Salary) As AverageSalary
FROM 
(
	Select Name, Salary, 
	Case 
		When PerformanceRating >=80 Then 'High'
		When PerformanceRating >=60 Then 'Meduim'
		Else 'Low'
		END as PerformanceCategory
	from Employees2
	
) As Performancetable
Group By PerformanceCategory;