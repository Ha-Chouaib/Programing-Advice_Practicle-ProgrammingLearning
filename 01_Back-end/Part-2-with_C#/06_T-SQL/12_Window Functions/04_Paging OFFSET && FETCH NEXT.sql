DECLARE @PageNumber AS INT, @RowsPerPage AS INT;

SELECT * from Students;

SET @PageNumber = 2;
SET @RowsPerPage =3;



SELECT * FROM Students
	ORDER BY StudentID
	OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
	FETCH NEXT @RowsPerPage ROWS ONLY;
