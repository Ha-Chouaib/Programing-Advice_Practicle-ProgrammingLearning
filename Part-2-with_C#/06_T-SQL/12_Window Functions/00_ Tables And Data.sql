use C21_DB1;

CREATE TABLE Students (
	StudentID INT PRIMARY KEY,
	Name NVARCHAR(50),
	Subject NVARCHAR(50),
	Grade INT
	);

GO

INSERT INTO Students (StudentID, Name,Subject,Grade)
	Values(1,'Chouaib','English',95),
		(2 ,'Ali','Math',83),
		(3,'Omar','Math',90),
		(4,'Idris','English',79),
		(5,'Fedua','Science',88),
		(6,'Mohammed','Engilsh',72),
		(7, 'Hiba','Science',80),
		(8, 'Dave','Science',77);

