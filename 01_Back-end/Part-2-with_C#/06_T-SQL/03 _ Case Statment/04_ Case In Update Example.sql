
Update Employees2 SET Salary=
Case 
	When PerformanceRating > 90  Then Salary * 1.15	
	When PerformanceRating Between 75 AND 90  Then Salary * 1.10
	When PerformanceRating Between 50 AND 74  Then Salary * 1.05

	Else Salary
	END;