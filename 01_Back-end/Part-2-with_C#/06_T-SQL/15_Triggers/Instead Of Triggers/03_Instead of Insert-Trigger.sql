CREATE TRIGGER trg_UnsertStudentView ON StudentView
INSTEAD OF INSERT
AS
BEGIN

	INSERT INTO PersonalInfo (Name, Address)
		SELECT Name,Address FROM inserted;

	INSERT INTO AcademicInfo (StudentID,Course,Grade)
		SELECT StudentID,Course,Grade FROM inserted;

END;