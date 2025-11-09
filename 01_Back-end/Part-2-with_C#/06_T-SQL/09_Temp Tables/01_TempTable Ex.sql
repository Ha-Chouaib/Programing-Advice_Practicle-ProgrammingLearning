

CREATE TABLE #EmployeesTemp (EmployeeID int, Name varchar(50),Department varchar(30));

INSERT INTO #EmployeesTemp (EmployeeID, Name, Department) Values (10, 'Chouaib','IT');
INSERT INTO #EmployeesTemp (EmployeeID, Name, Department) Values (11, 'Ali','Sales');

Select * from #EmployeesTemp;


Drop Table #EmployeesTemp;

