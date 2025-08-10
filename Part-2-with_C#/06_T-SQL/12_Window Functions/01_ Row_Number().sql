use C21_DB1;

SELECT * from Students order by Grade DESC;

SELECT 
	StudentID, 
	Name, 
	Subject,
	Grade, 
	ROW_NUMBER() OVER (ORDER BY Grade DESC) AS RowNum 
from Students;