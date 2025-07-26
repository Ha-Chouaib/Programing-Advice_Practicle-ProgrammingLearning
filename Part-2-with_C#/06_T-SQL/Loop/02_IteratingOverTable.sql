
Declare @EmployeeID INT;
Declare @Name VarChar(50);
Declare @MaxID int;

Select @EmployeeID = Min(EmployeeID) from Employees ;

Select @MaxID = Max(EmployeeID) from Employees;

While @EmployeeID Is Not Null AND @EmployeeID <= @MaxID
BEGIN
Select @Name = Name from Employees Where EmployeeID = @EmployeeID;
Print @Name;

Select @EmployeeID = Min(EmployeeID) from Employees where EmployeeID > @EmployeeID;
END;