
use HR_Database;
EXEC sp_changedbowner 'sa';

--Restore Database HR_Database
--from disk= 'c:\HR_Database.bak';

--===================Select=====================--

select * from Employees; -- the same as << select Employees.* from Employees; >>

select ID, FirstName, LastName, MonthlySalary from Employees;

select * from Countries;
select Departments.* from Departments;

select FirstName from Employees;  -- this returns the whole data even its repeated.
select distinct FirstName from Employees; -- this one returns the Data Unrepeatedlly just once, even the same value repeated multiple times within diff entitys.

select distinct DepartmentID, FirstName from Employees;									
-- Distinct Must return Different Rows . it looks to the Whole Row of selected Field . So When We have more the one field selected we may find Repeated values in the same column
-->As a result with distinct we May Have Same Column Values But We Never Ever will Find The Same Rows Value.

--==========================================================--

--===============Where================--

Select * from Employees
where BonusPerc <> 0; -- <> equivalent to != .

select * From Employees
where Gendor ='M';

select * From Employees
where (Gendor ='M' and MonthlySalary >=1000) OR ( Gendor ='F' and ExitDate is Not Null);

select FirstName, LastName From Employees
where Gendor='F' and Not BonusPerc = 0;

select distinct FirstName, LastName From Employees
where Gendor='F' and Not BonusPerc = 0;

--=======================================

--=======================in Operator=======================

-- <Column> in (Value1,Value2,...)  <==> Column= Value1 or Column=Value2 or ...

select * from Employees
where DepartmentID =1 or DepartmentID=3 or DepartmentID =5 or DepartmentID=7;

-- The Query Bellow is a shortcut of the one above
select * from Employees
where DepartmentID in (1,3,5,7);

select * from Employees
where FirstName in ('Bella','Jac','Ruby');

select Departments.Name From Departments
where 
ID in (Select DepartmentID from Employees Where MonthlySalary <=210);

select Departments.Name From Departments
where 
ID Not in (Select DepartmentID from Employees Where MonthlySalary <=210);

 select Countries.Name from Countries
 where 
 ID in( select CountryID from Employees where (DepartmentID in(2) and  DepartmentID Not in(7)) );
 --==============================================================

 --===================Sorting=====================

 --Order By <Column> [<ASC> = (From A to Z): Default OR <Desc> = (From Z To A)]

 select * from Employees
 where Gendor='M'
 Order By FirstName ASC; --ASC: Default

 select * from Employees
 where Gendor='F'
 Order By MonthlySalary desc;

 select ID, FirstName,MonthlySalary from Employees
 where DepartmentID=1
 Order By FirstName, MonthlySalary;

 select ID, FirstName, MonthlySalary from Employees
 where DepartmentID=1
 Order By FirstName ASC, MonthlySalary DESC;
 --=================================================

 --================ Top ========================

 Select top 10 * from Employees; --returns By Number
 Select top 10 percent * from Employees; --returns By %

--=== Returns Name ID Salary of top 3 Heigth Salary
 select ID, FirstName,LastName,MonthlySalary from Employees where MonthlySalary in
 (select distinct top 3 MonthlySalary from Employees order by MonthlySalary Desc)
 order By MonthlySalary Desc;

 --=============================================

 --=========Select "As" ..Aliases===============
 select A= 3/2 ,B= 3+2;
 
 select ID, FirstName, A= MonthlySalary/2 from Employees;

 select ID, FirstName + ' '+LastName As FullName from Employees;
 select ID,FullName= FirstName + ' '+LastName from Employees;

 select ID, FirstName, MonthlySalary, YearlySalary= MonthlySalary *12, BounusAmount= BonusPerc * MonthlySalary from Employees;

 select ID,FullName= FirstName + ' '+LastName, Age= DATEDIFF(year,DateOfBirth, getDate()) from Employees;

 select Today=Getdate();-- returns the current date.
 --================================================

 --===================== Between ====================
 select * from Employees where MonthlySalary > 500 and MonthlySalary <1000;
 --Same as 
 select * from Employees where MonthlySalary between 500 and 1000;

 --==================================================

 --=================== Sum() Count() AVG() Min() Max()Total ==================
 select TotalCount= Count(MonthlySalary),TotalSum=Sum(MonthlySalary), Average= AVG(MonthlySalary),Minimum=Min(MonthlySalary),Maximum=Max(MonthlySalary)
 from Employees where DepartmentID in (1,3,5);

 --count(), AVG Methods do not deal with null value. only not null

 --================== Group By ======================

 select TotalCount= Count(MonthlySalary),TotalSum=Sum(MonthlySalary), Average= AVG(MonthlySalary),Minimum=Min(MonthlySalary),Maximum=Max(MonthlySalary)
 from Employees  
 Group By DepartmentID
 Order By DepartmentID;
--===================================================

--====================== Having =======================
--Having The Same Functionality as "Where" But Where We Use it ti filter the normal Queries Dealing Directly with Table Results
-- While " Having " Used To Filter Results From  Aggregate Functions like Group By.

select TotalCount= Count(MonthlySalary),TotalSum=Sum(MonthlySalary), Average= AVG(MonthlySalary),Minimum=Min(MonthlySalary),Maximum=Max(MonthlySalary)
 from Employees  
 Group By DepartmentID
 Having Count(MonthlySalary) > 100
 Order By DepartmentID;

-- You Can Not Use Directly < where > with Group By !!But we can Do Some Magic undirectly  using where without having
select * from
(
select TotalCount= Count(MonthlySalary),TotalSum=Sum(MonthlySalary), Average= AVG(MonthlySalary),Minimum=Min(MonthlySalary),Maximum=Max(MonthlySalary)
 from Employees  
 Group By DepartmentID
 Order By DepartmentID
 )Magic --you can name it any //  Here We Take The Whole Query Reult and Forword it to new virtual Table on the memory Then we use where the have the same result as we using Having.
 WHERE Magic.TotalCount >100;
 --========================================================

 --=================================== Like ======================================

 --find any values start with "a".
 select ID, FirstName from Employees
 where FirstName Like 'a%';

 --find Any Values Ends With  "a".
 select ID, FirstName from Employees where FirstName like '%a';

 -- find Any Values that Contain  "tell" in any position.
 select ID, FirstName from Employees where FirstName like '%tell%';

 --find  any Values that Start with "a" and Ends With "b".
 select ID, FirstName from Employees where FirstName like 'a%b';

 --find any Values Contains "a" in Second position
 select ID, FirstName from Employees where FirstName like '_a%';

 --find  Any Values That Start With "a" And are at Least 3 Chars in length
 select ID, FirstName from Employees where FirstName like 'a__%';

 --find  Any Values That Start With "a" And are at Least 4 Chars in length
 select ID, FirstName from Employees where FirstName like 'a____%';

 --find  Any Values That Contains at Second position "a" And are Exactly 4 Chars in length
 select ID, FirstName from Employees where FirstName like '_a__';

  Update Employees
 Set FirstName ='Chouaib', LastName='Hadadi',DateOfBirth=Convert(Date,'2003-6-20',120)  where ID =285;
  select *,Age= DATEDIFF(year, DateOfBirth,GetDate() ) from Employees Where ID =285;

 Update Employees
 Set FirstName ='Soufian', LastName='ElHaddadi'  where ID =286;
 
 select ID, FirstName, LastName, MonthlySalary from Employees  where LastName= 'Hadadi' or LastName='ElHaddadi';

 select ID, FirstName, LastName, MonthlySalary from Employees  where LastName like '%Ha%dadi' ;



 -----------------------WildCards----------------------
 Update Employees
 Set FirstName ='Mohammed', LastName='Abu-Hadhoud'  where ID =287;

 Update Employees
 Set FirstName ='Mohammad', LastName='Ombark'  where ID =288;

 select ID, FirstName, LastName, MonthlySalary from Employees  where FirstName= 'Mohammed' or FirstName='Mohammad';
 --Or we Could Use The WildCard [] .
 select ID, FirstName, LastName, MonthlySalary from Employees  where FirstName like 'Mohamm[ae]d' ;


 select ID, FirstName, LastName, MonthlySalary from Employees  where FirstName like 'a%' or FirstName like'b%' or FirstName like 'c%' ;
 -- The As
  select ID, FirstName, LastName, MonthlySalary from Employees  where FirstName like '[abc]%' ;

  --find All Values Start With Letters Form a to l;
  select ID, FirstName, LastName, MonthlySalary from Employees  where FirstName like '[a-l]%' ;









 
 
 

 











































