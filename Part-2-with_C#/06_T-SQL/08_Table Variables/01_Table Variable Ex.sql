
DECLARE @EmployeesTable TABLE(EmployeeID INT, Name nvarChar(100),Department varchar(50));

Insert Into @EmployeesTable(EmployeeID, Name, Department) Values (1,'Chouaib','Software Engineer');
Insert Into @EmployeesTable(EmployeeID, Name, Department) Values (2,'Soufian',' Manager');

Select * from @EmployeesTable;



