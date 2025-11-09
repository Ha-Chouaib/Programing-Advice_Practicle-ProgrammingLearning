use C21_DB1;

SELECT * from Students order by Grade DESC;

SELECT 
	StudentID, 
	Name, 
	Subject,
	Grade, 
	RANK() OVER (ORDER BY Grade DESC) AS GradeRank 
from Students;

-- Using Partition BY

SELECT 
	StudentID, 
	Name, 
	Subject,
	Grade, 
	RANK() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS GradeRank 
from Students;