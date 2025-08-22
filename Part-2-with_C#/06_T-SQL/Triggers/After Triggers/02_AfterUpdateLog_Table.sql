CREATE TABLE StudentUpdatedLog(

	LogID INT IDENTITY PRIMARY KEY,
	StudentID INT,
	OldGrade INT,
	NewGrade INT,
	UpdatedDateTime DATETIME DEFAULT GETDATE();

);