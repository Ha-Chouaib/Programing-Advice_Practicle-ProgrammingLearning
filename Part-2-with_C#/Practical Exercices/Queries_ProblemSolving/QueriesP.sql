

select * from VehicleDetails;



Select * from MakeModels;
select * from VehicleMasterDetails;

Select * from VehicleDetails where Year between 1950 and 2000;

Select Count(*)As VehiclesNumber from VehicleDetails where Year Between 1950 and 2000 ;


Select Makes.Make, count(*) As VehicleNumber  from VehicleDetails join Makes On VehicleDetails.MakeID= Makes.MakeID
	where Year Between 1950 and 2000
	Group By (Makes.Make )
	Order By VehicleNumber Desc;

----Method 1
Select Makes.Make, count(*) As VehicleNumber  from VehicleDetails join Makes On VehicleDetails.MakeID= Makes.MakeID
	where Year Between 1950 and 2000
	Group By (Makes.Make )
	Having Count(*) > 12000
	Order By VehicleNumber Desc;

	----Method 2 To Do The Same Query But Without Having 
Select * from (

Select Makes.Make, count(*) As VehiclesNumber  from VehicleDetails join Makes On VehicleDetails.MakeID= Makes.MakeID
	where Year Between 1950 and 2000
	Group By (Makes.Make )

)R1 Where VehiclesNumber > 12000 Order By VehiclesNumber Desc;

--## 06 ##
--Get A number Of Vehicles Made Between 1950 and 200 per Make and add Total Vehicles Column Beside
Select Makes.Make, count(*) As VehicleNumber,(Select Count(*) From VehicleDetails) As TatalVehicles
	from VehicleDetails join Makes On VehicleDetails.MakeID= Makes.MakeID
	where Year Between 1950 and 2000
	Group By (Makes.Make )
	Order By VehicleNumber Desc;

--## 7 ##
--Get A number Of Vehicles Made Between 1950 and 200 per Make and add Total Vehicles Column Beside it then Calculate The Percentage
Select *,Cast(VehicleNumber as float) /Cast(TotalVehicles as float) As Perc from (

Select Makes.Make, Count(*) As VehicleNumber,(Select count(*) from VehicleDetails) AS TotalVehicles
	from VehicleDetails join Makes On VehicleDetails.MakeID = Makes.MakeID
	where Year Between 1950 and 2000
	Group By Makes.Make

)R1 Order By VehicleNumber Desc;

--## 8 ##
--Get Make,FuelTypeName  and Number Of Vehicles Per FuelType Per Make

Select Makes.Make ,FuelTypes.FuelTypeName, count(*) As NumberOsVehicles 
from VehicleDetails join 
	Makes On VehicleDetails.MakeID = Makes.MakeID Join
	FuelTypes On VehicleDetails.FuelTypeID =FuelTypes.FuelTypeID
Where (VehicleDetails.Year Between 1950  and 2000)
Group By Makes.Make, FuelTypes.FuelTypeName
Order By Makes.Make;

--## 9 ##
--Get all Vehicles That Runs With GAS

Select VehicleDetails.* , FuelTypes.FuelTypeName from VehicleDetails Join FuelTypes
	On VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID
Where (FuelTypes.FuelTypeName = N'GAS') 
-- N : To Accept  all Langs == nvarchar

--## 10 ##
--Get All Makes That Run  With GAS
Select Distinct Makes.Make, FuelTypes.FuelTypeName from Makes 
	Join VehicleDetails On VehicleDetails.MakeID = Makes.MakeID 
	Join FuelTypes On VehicleDetails.FuelTypeID= FuelTypes.FuelTypeID
Where (FuelTypes.FuelTypeName like N'GaS');

--## 11 ##
--Get Total Makes That Runs With GAS
Select count(*) As TotalMakesRunsWithGAS from
(
Select Distinct Makes.Make, FuelTypes.FuelTypeName from Makes 
	Join VehicleDetails On VehicleDetails.MakeID = Makes.MakeID 
	Join FuelTypes On VehicleDetails.FuelTypeID= FuelTypes.FuelTypeID
Where (FuelTypes.FuelTypeName like N'GaS')

)R1;

--## 12 ##
--Count Vehicles By Make abd Order them By NumberOfVehicles from High To Low

Select Makes.Make , Count(*) AS NumberOfVehicles from VehicleDetails join Makes On VehicleDetails.MakeID = Makes.MakeID
Group By Makes.Make
Order By NumberOfVehicles Desc;

--## 13 ##
--Get All Makes/Count Of Vehicles that Manufactures more than 20K Vehicles
--Method One
Select Makes.Make , Count(*) AS NumberOfVehicles from VehicleDetails join Makes On VehicleDetails.MakeID = Makes.MakeID
Group By Makes.Make
Having Count(*) >20000
Order By NumberOfVehicles Desc;

--Methode Tow
Select * from
(
Select Makes.Make , Count(*) AS NumberOfVehicles from VehicleDetails join Makes On VehicleDetails.MakeID = Makes.MakeID
Group By Makes.Make

)R Where NumberOfVehicles > 20000 Order By NumberOfVehicles Desc;

--## 14 ##
--Get All Makes with Make Start With 'B'
Select Makes.Make from Makes where Make like 'B%';

--## 15 ##
--Get All Makes With Make Ends With 'W'
Select Makes.Make from Makes where Make like '%W';

--## 16 ##
--Get All Makes That Manufactures DriveType Name =FWD

Select Distinct Makes.Make, DriveTypes.DriveTypeName from Makes Join VehicleDetails On VehicleDetails.MakeID= Makes.MakeID 
	Join DriveTypes On VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID 
	Where(DriveTypes.DriveTypeName = N'FWD');

--## 17 ##
--Get Total Makes That Manufactures DriveTypeName = FWD
 Select Count(*) AS FWD_Drive from
 (
Select Distinct Makes.Make, DriveTypes.DriveTypeName from Makes Join VehicleDetails On VehicleDetails.MakeID= Makes.MakeID 
	Join DriveTypes On VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID 
	Where(DriveTypes.DriveTypeName = N'FWD')

)r;

--## 18 ##
--Get TOtal Vehicles Per DriveTypeName Per Make and Order them By per make Asc then Per Total Desc

Select Distinct Makes.Make, DriveTypes.DriveTypeName,Count(*) AS TotalVehicles from Makes Join VehicleDetails On VehicleDetails.MakeID= Makes.MakeID 
	Join DriveTypes On VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID 
	Group By DriveTypes.DriveTypeName, Makes.Make
	Order By Makes.Make Asc, TotalVehicles;

--## 19 ##
--Get Total Vehicles Per DriveTypeName Per Make Then Filter Only The  results with Total Vehicles > 10K
Select Distinct Makes.Make, DriveTypes.DriveTypeName,Count(*) AS TotalVehicles from Makes Join VehicleDetails On VehicleDetails.MakeID= Makes.MakeID 
	Join DriveTypes On VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID 
	Group By DriveTypes.DriveTypeName, Makes.Make
	Having Count(*) > 10000
	Order By Makes.Make Asc, TotalVehicles;

--## 20 ## 
--Get ALL Vehicles That Number Of Dors is Not Specified
Select * from VehicleDetails Where NumDoors is Null;

--## 21 ##
--Get Total Vehicles That Number Of Dors is Not Specified
Select Count(*)AS TotalVheiclesWithNoSpecifiedDoors  from VehicleDetails Where NumDoors is Null;

--## 22 ##
--Get Percentage Of Vehicles That has No Doore Specified
--Method One
Select * , Cast( TotalVheiclesWithNoSpecifiedDoors As float) / Cast((Select Count(*) from VehicleDetails) As float) As Perc  from
(
Select  Count(*)AS TotalVheiclesWithNoSpecifiedDoors from VehicleDetails Where NumDoors is Null

)R;

--Method Tow
Select(
Cast ( (Select  Count(*)AS TotalVheiclesWithNoSpecifiedDoors from VehicleDetails Where NumDoors is Null) As float)
/
Cast((Select Count(*) As TotalVehicles from VehicleDetails )As float )
) As Perc

--## 23 ##
--Get MakeID, Make, SubModelName fro all Vehicles that have SubModelName 'Elite'.

select distinct Makes.MakeID , Makes.Make, SubModels.SubModelName from VehicleDetails 
	join Makes on VehicleDetails.MakeID =Makes.MakeID
	Join SubModels On VehicleDetails.SubModelID =SubModels.SubModelID
	where SubModels.SubModelName = 'Elite';


--## 24 ##
--Get all Vehicles that Have Engines > 3 Liter and have only 3 doors
Select * from VehicleDetails where Engine_Liter_Display > 3 and NumDoors = 3;

--## 25 ##
--Get Make and Vehicles that  the Engine Contains 'OHV' and have Cylindres =4

Select Makes.Make, VehicleDetails.* from VehicleDetails Join Makes On VehicleDetails.MakeID = Makes.MakeID
	where (VehicleDetails.Engine like '%OHV%' and VehicleDetails.Engine_Cylinders =4);

--## 26 ##
--Get All Vehicles that thier Body is 'Sport Utility' ans Year > 2020
Select Bodies.BodyName, VehicleDetails.* from VehicleDetails join Bodies On VehicleDetails.BodyID = Bodies.BodyID
	where (Bodies.BodyName like N'Sport Utility' And VehicleDetails.Year > 2020);

--## 27 ##
--Get All Vehicles that their Body is 'Coupe' or 'Hatchback' or 'Sedan'
Select Bodies.BodyName, VehicleDetails.* from VehicleDetails join Bodies On VehicleDetails.BodyID = Bodies.BodyID
	where (Bodies.BodyName in ('Coupe','Hatchback','Sedan'));

--## 28 ##
--Get All Vehicles that their Body is 'Couper' Or 'Hatchback' or 'Sedan' and Manufactured in year 2008 or 2020 or 2021

Select Bodies.BodyName, VehicleDetails.* from VehicleDetails join Bodies On VehicleDetails.BodyID = Bodies.BodyID
	where (Bodies.BodyName in ('Coupe','Hatchback','Sedan') AND VehicleDetails.Year in (2008,2020,2021));

--## 29 ##
--Return Found if there is any Vehicle Made in year 1950
Select Found =1 
where
Exists( select top 1 t='T' from  VehicleDetails where VehicleDetails.Year = 1950 ) 

--## 30 ##
--Get All Vehicle_Display_Name, NumDoors and Extra column to describe number of Doors By Words, and if Dors is Null Display 'Not Set'
Select Vehicle_Display_Name, NumDoors, 
	Case  NumDoors 
		When 0 then 'Zero Doors'
		When 1 then 'One Door'
		When 2 then 'Tow Doors'
		When 3 then 'Three Doors'
		When 4 then 'four Doors'
		When 5 then 'Five Doors'
		when 6 then 'Six Doors'
		when 8 then 'Eigth Doors'
		when Null then 'Not Set'
		Else 'Unknown'
		End As NumDoorsOnLetters
	 from VehicleDetails;

--## 31 ##
--Get All Vehicle_Display_Name, Year and Add Extra Column to Calculate the age Of the car then Sort the result by Age desc

Select Vehicle_Display_Name, year ,YEAR(GetDate())- VehicleDetails.Year As Car_Age
From VehicleDetails
Order By Car_Age Desc;

--## 32 ##
--Get All Vehicle_Display_Name, Year, Age for Vehicles That Their Age Betwen 15 and 25 Years Old

Select * from
(
Select Vehicle_Display_Name, year ,YEAR(GetDate())- VehicleDetails.Year As Car_Age
From VehicleDetails
)R Where Car_Age between 15 and 25;

--## 33 ##
--Get Minimum Engine CC, Maximum Engine CC Of All Vehicles
Select Min(Engine_CC) As MinEngine_CC, Max(Engine_CC) As MaxEngine_CC, AVG(Engine_CC) As Engine_CC_AVG from VehicleDetails;

--## 34 ##
--Get All Vehicles that Have The Min EngineCC
select * from VehicleDetails where Engine_CC = (Select Min(Engine_CC) As MinEngineCC from VehicleDetails);

--## 35 ##
--Get All Vehicles that Have The Max EngineCC
select * from VehicleDetails where Engine_CC = (Select Max(Engine_CC) As MaxEngineCC from VehicleDetails);

--## 36 ##
--Get All Vehicles that Have The EngineCC Below Average
select * from VehicleDetails where Engine_CC < (Select AVG(Engine_CC) As EngineCC_AVG from VehicleDetails);

--## 37 ##
--Get Total vehicles  that Have EngineCC Above Average
Select COUNT(*) As EngineCCAboveAVG from
(
select * from VehicleDetails where Engine_CC > (Select AVG(Engine_CC) As EngineCC_AVG from VehicleDetails)

)R;

--## 38 ##
--Get All Unique EngineCC and Sort Them  Desc
Select Distinct Engine_CC  from VehicleDetails Order By Engine_CC Desc;

--## 39 ##
--Get The Max # Engine CC
Select Distinct Top 3 Engine_CC from VehicleDetails Order By Engine_CC Desc;

--## 40 ##
--Get All Vehicles That Has One Of the Max 3 Engine CC
Select  Vehicle_Display_Name from VehicleDetails
where Engine_CC in (Select distinct top 3 Engine_CC from VehicleDetails order by Engine_CC Desc);

--## 41 ##
--Get All Makes tha Manufactures one Of the Max 3 EngineCC
Select Distinct Makes.Make from VehicleDetails Join Makes On VehicleDetails.MakeID= Makes.MakeID 
Where(VehicleDetails.Engine_CC in ( Select Distinct Top(3) Engine_CC from VehicleDetails Order By Engine_CC Desc) );

--## 42 ##
--Get a Table Of Unique Engen_CC and Calculate Tax Per Engine_CC
Select Engine_CC,
Case 
	when Engine_CC between 0 and 1000 then 100
	when Engine_CC between 1001 and 2000 then 200
	when Engine_CC between 2001 and 3000 then 300
	when Engine_CC between 3001 and 4000 then 400
	when Engine_CC between 4001 and 5000 then 500
	when Engine_CC > 8000 then 600
	Else 0
	End As Tax
	
From (Select Distinct Engine_CC from VehicleDetails)R Order By Engine_CC ;

--## 43 ##
--Get Make and Total Number Of Doors Manufactured Per Make

select Makes.Make, Sum(VehicleDetails.NumDoors)As TotalDoors from VehicleDetails join Makes On Makes.MakeID =VehicleDetails.MakeID
Group By Makes.Make
Order By TotalDoors Desc
;


--## 44 ##
--Get Total Number Of  Doors Manufactured By 'Ford'
Select Makes.Make, Sum(VehicleDetails.NumDoors) As FordDoors from VehicleDetails join Makes On Makes.MakeID =VehicleDetails.MakeID
Group By Make
Having Makes.Make= 'Ford';

--## 45 ##
--Get Number Of Madels Per make
Select Makes.Make, Count(*) As NumberOfModels From Makes Join MakeModels On Makes.MakeID = MakeModels.MakeID
Group By Makes.Make
Order By NumberOfModels Desc;

--## 46 ##
--Get the Highest 3 manufactures That Make The Hieghest Number Of Models
Select top (3) Makes.Make ,Count(*)As NumberOfModels from  Makes Join MakeModels On Makes.MakeID = MakeModels.MakeID
Group By Makes.Make
Order By NumberOfModels Desc;

--## 47 ##
--Get the Highest Number Of Models Manufactures
Select Max(NumberOfModels)As MaxNumberOfModel from
(
Select Makes.Make, Count(*) As NumberOfModels From Makes Join MakeModels On Makes.MakeID = MakeModels.MakeID
Group By Makes.Make
)r  ;

--## 48 ##
-- Get The Highest ManuFactures Manufactured the highest Number Of Models
Select Makes.Make, Count(*) As NumberOfModels From Makes Join MakeModels On Makes.MakeID = MakeModels.MakeID
 Group By Makes.Make
 Having  Count(*) = 
 (Select Max(NumberOfModels) 
	from (
		Select MakeID, Count(*)As NumberOfModels from MakeModels
			group By MakeID
			)R 
);

--## 49 ##
-- Get The Lowest ManuFactures Manufactured the highest Number Of Models
Select Makes.Make, Count(*) As NumberOfModels From Makes Join MakeModels On Makes.MakeID = MakeModels.MakeID
 Group By Makes.Make
 Having  Count(*) = 
 (Select Min(NumberOfModels) 
	from (
		Select MakeID, Count(*)As NumberOfModels from MakeModels
			group By MakeID
			)R 
);

--## 50 ##
--Get All Fuel types, Each time the Result Should Be Showed In Random Order.
Select *,NewID() AS RandomID From FuelTypes Order By RandomID ;

