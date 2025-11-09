
WITH EmployeeTreeHierarchy AS
(
	
	SELECT EmployeeID,ManagerID, Name,CAST(Name AS varchar(MAX)) AS 'Hierarchy', 0 AS Level 
	FROM Employees7 
	WHERE ManagerID IS NULL

	UNION ALL

	SELECT e.EmployeeID, e.ManagerID,e.Name,CAST(ETH.Hierarchy + ' -> ' + e.Name AS varchar(Max)),ETH.Level + 1 AS Level
	FROM Employees7 e 
	INNER JOIN
	EmployeeTreeHierarchy ETH ON e.ManagerID = ETH.EmployeeID

)SELECT * from EmployeeTreeHierarchy ORDER BY Hierarchy;