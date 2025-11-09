Select StudentID, Name, Subject, Grade, 
	AVG (Grade) OVER (PARTITION BY Subject) AS SubjectAVG,
	SUM(Grade) OVER (PARTITION BY Subject) As SubjectSUM
from Students  ORDER BY Subject;