-- Sub Query

SELECT * FROM
(
	SELECT Department, SUM(Sales) AS TotalSales
		FROM Employees6
		GROUP BY Department
)DepartmentSales;
  

-- CTE
WITH DepartmentSales AS
(
	SELECT Department, SUM(Sales) AS TotalSales
		FROM Employees6
		GROUP BY Department
)
SELECT * FROM DepartmentSales;