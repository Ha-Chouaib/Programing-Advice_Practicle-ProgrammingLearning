

Create FUNCTION GetStudentBySubject( @Subject NVARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT * FROM Students WHERE Subject = @Subject);