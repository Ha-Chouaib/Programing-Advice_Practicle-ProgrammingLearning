DECLARE @StartDate DATE = '2025-01-01';
DECLARE @EndDate DATE = '2025-01-31';

WITH DateSeries AS
(
	SELECT @StartDate As DateValue

	UNION ALL

	SELECT DATEADD(day,1,DateValue) FROM DateSeries where DateValue < @EndDate
)SELECT DateValue FROM DateSeries;










