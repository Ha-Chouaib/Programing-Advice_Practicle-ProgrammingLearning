
BEGIN TRY

	Insert Into Employees3 (EmployeeID, Name, Position) Values(1,'Chouaib Hadadi','HR');
	Insert Into Employees3 (EmployeeID, Name, Position) Values(1,'Soufian ELHadadi','Manager');

END TRY
BEGIN CATCH
	
	Print 'An Error Accured: '+ Error_Message();

END CATCH
