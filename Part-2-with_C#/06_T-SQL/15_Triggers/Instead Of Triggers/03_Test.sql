INSERT INTO StudentView (StudentID, Name, Address, Course, Grade)
VALUES (3, 'Alice Johnson', '789 Pine Rd', 'Physics', 88);


SELECT * FROM PersonalInfo WHERE StudentID = 3;
SELECT * FROM AcademicInfo WHERE StudentID = 3;
