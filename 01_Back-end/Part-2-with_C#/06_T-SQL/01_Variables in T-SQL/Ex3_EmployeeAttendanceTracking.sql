
DECLARE @ReportMonth INT;
DECLARE @ReportYear INT;
DECLARE @TotalDays INT;
DECLARE @EmployeeID INt;
DECLARE @PresentDays Int;
DECLARE @AbsentDays INT;
DECLARE @LeaveDays Int;

SET @ReportMonth = 7;
SET @ReportYear =2023;
SET @EmployeeID = 101;

SET @TotalDays = DAY(EOMONTH(DATEFROMPARTS(@ReportYear , @ReportMonth, 1)));

SELECT @PresentDays = COUNT( * ) from EmployeeAttendance
	where EmployeeID = @EmployeeID AND Month( AttendanceDate ) = @ReportMonth AND Year(AttendanceDate) = @ReportYear AND Status = 'Present';

SELECT @AbsentDays = COUNT( * ) from EmployeeAttendance
	where EmployeeID = @EmployeeID AND Month( AttendanceDate ) = @ReportMonth AND Year(AttendanceDate) = @ReportYear AND Status = 'Absent';

SELECT @LeaveDays = COUNT( * ) from EmployeeAttendance
	where EmployeeID = @EmployeeID AND Month( AttendanceDate ) = @ReportMonth AND Year(AttendanceDate) = @ReportYear AND Status = 'Leave';

PRINT 'Employees Attendance From EmployeeID << '+ CAST(@EmployeeID as VARCHAR) + ' >>' ;
PRINT 'Report Month: ' + CAST(@ReportMonth as VARCHAR);
PRINT 'Report Year: '+ CAST(@ReportYear as VARCHAR);
PRINT 'Total Working Days: '+ CAST(@TotalDays as VARCHAR);
Print 'Present Days: '+ CAST(@PresentDays as VARCHAR);
Print 'Absent Days: '+ CAST(@Absentdays as VARCHAR);
Print 'Leave Days: '+ CAST(@LeaveDays as VARCHAR)




