use C21_DB1;

SELECT * from Students order by Grade DESC;

SELECT 
	StudentID, 
	Name, 
	Subject,
	Grade, 
	DENSE_RANK() OVER (ORDER BY Grade DESC) AS GradeRank 
from Students;