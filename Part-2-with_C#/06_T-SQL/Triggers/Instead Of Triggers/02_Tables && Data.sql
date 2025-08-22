
CREATE TABLE PersonalInfo (
	StudentID INT Identity Primary key,
	Name NVARCHAR(100),
	Address NVARCHAR(255)
	);

CREATE TABLE AcademicInfo(
	StudentID INT  Primary Key,
	Course NVARCHAR(100),
	Grade INT ,
	FOREIGN KEY (StudentID) REFERENCES PersonalInfo(StudentID)
);

GO

CREATE VIEW StudentView AS 
SELECT P.StudentID,p.Name, P.Address,  A.Course,A.Grade
FROM PersonalInfo P INNER JOin AcademicInfo A ON P.StudentID = A.StudentID;

GO

INSERT INTO PersonalInfo ( Name, Address) VALUES
('John Doe', '123 Main St'),
( 'Jane Smith', '456 Oak Ave');


INSERT INTO AcademicInfo (StudentID, Course, Grade) VALUES
(1, 'Computer Science', 90),
(2, 'Mathematics', 85);