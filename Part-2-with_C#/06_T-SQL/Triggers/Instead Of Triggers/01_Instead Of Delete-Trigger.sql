CREATE TRIGGER trg_InsteadOfDeleteStudent ON Students
INSTEAD OF DELETE
AS 
BEGIN

UPDATE Students
SET IsActive = 0
FROM Students S INNER JOIN deleted d ON S.StudentID = d.StudentID;

END;
