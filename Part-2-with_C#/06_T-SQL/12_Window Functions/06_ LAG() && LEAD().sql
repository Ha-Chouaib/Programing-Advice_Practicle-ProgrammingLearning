Use C21_DB1;

SELECT * from Students;

SELECT StudentID, Name, 
	LAG(Grade,1) OVER (Order BY Grade DESC) AS PreviousGrade,--Previous
	Grade,
	Lead(Grade,1) OVER (ORDER BY Grade DESC)AS NextGrade --NEXT
from Students;