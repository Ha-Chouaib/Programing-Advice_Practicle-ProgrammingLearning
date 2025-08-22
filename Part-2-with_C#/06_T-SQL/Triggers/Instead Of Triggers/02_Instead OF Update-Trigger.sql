
CREATE TRIGGER trg_UpdateStudentView ON StudentView
INSTEAD OF UPDATE
AS
BEGIN

	UPDATE PersonalInfo
	SET Name = I.Name, Address = I.Address
	FROM PersonalInfo
	Inner JOIN inserted I ON  PersonalInfo.StudentID = I.StudentID;



END;
