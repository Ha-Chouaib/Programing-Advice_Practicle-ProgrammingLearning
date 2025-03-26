--Exec sp_changedbowner 'sa';


--## 1 ##
--Get All Employees that Have Manager Along With Managers's Name

select * from Employees;

Select Employees.Name, Employees.ManagerID, Employees.Salary, Managers.Name AS ManaagerName
From Employees Join Employees As Managers On Employees.ManagerID = Managers.EmployeeID ;

--## 2 ##
--Get All Employees that Have Manager Or Does Not Have One Along With Managers's Name In Case Manager name Show NUll.


Select Employees.Name, Employees.ManagerID, Employees.Salary, Managers.Name AS ManaagerName
From Employees Left Join Employees As Managers On Employees.ManagerID = Managers.EmployeeID ;

--## 3 ##
--Get All Employees that Have Manager Or Does Not Have One Along With Managers's Name, InCase No Manager name, Name The Manager As Employee Name .

Select Employees.Name, Employees.ManagerID, Employees.Salary, 

Case  
	When Managers.Name is Null then Employees.Name
	Else Managers.Name
	End As Manager_Name
From Employees Left Join Employees As Managers On Employees.ManagerID = Managers.EmployeeID ;

--## 4 ##
--Get All Employees That Have Manager With Name 'Mohammed'.

Select Employees.Name, Employees.ManagerID, Employees.Salary, Managers.Name AS ManaagerName
From Employees Left Join Employees As Managers On Employees.ManagerID = Managers.EmployeeID Where Managers.Name = N'Mohammed' ;

