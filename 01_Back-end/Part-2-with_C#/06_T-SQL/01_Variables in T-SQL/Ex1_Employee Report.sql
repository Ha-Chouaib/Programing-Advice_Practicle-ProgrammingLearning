--[ 1 ] Declare Variables

DECLARE @DepartmentID INT;
DECLARE @StartDate DATE;
DECLARE @EndDate DATE;
DECLARE @TotalEmployees INT;
DECLARE @DepartmentName VARCHAR(50);

--[ 2 ] Initiate Variables

SET @DepartmentID = 3;
SET @StartDate='2023-01-01';
SET @EndDate = '2023-12-31';

-- dO yOUR OPERATIONS
SELECT @DepartmentName = Name From Departments Where DepartmentID = @DepartmentID;

SELECT @TotalEmployees = COUNT(*) From Employees Where DepartmentID = @DepartmentID  AND HireDate Between @StartDate ANd @EndDate;

-- Print Results.

PRINT '- Department Report -';
PRINT 'Department Name: '  + @DepartmentName;
PRINT 'Reporting Period: ' + CAST(@StartDate As VARCHAR) + ' To ' + CAst(@EndDate AS VARCHAR);
PRINT 'Total Employees Hired in ' + CAST(YEAR(@StartDate) AS VARCHAR) + ': '+ Cast(@TotalEmployees AS VARCHAR);
