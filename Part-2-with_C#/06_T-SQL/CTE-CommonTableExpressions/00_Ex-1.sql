-- Using Sub Query

SELECT * FROM 
(
	SELECT EmployeeId , Name, Sales FROM Employees6
		WHERE Department= 'Sales'
)SalesStaff;


-- Using CTE

WITH SalesStaff AS
(
	SELECT EmployeeId , Name, Sales FROM Employees6
		WHERE Department= 'Sales'
)
SELECT * FROM SalesStaff;

