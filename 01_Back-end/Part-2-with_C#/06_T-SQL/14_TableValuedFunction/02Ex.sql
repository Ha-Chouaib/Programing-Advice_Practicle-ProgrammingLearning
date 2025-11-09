CREATE FUNCTION GetTopPerformingStudent()
RETURNS @Result TABLE(StudentID INT, Name NVARCHAR(50), Subject NVARCHAR(50), Grade INT)
AS
Begin

INSERT INTO @Result(StudentID,Name, Subject, Grade)
	SELECT Top 3 StudentID ,Name, Subject, Grade FROM Students
Order By Grade DESC;

RETURN;

END;