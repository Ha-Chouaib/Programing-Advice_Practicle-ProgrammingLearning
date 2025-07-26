

IF EXISTS ( SELECT * from Employees Where Name = 'John Smith')
BEGIN
	PRint 'Yes John Smith Is There';
END;
ELSE
BEGIN 
	Print 'No John Smith Is Not There';
End;