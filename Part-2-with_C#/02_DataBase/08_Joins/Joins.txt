

--======================== Inner join = Join =======================
select * from Customers;
select * from Orders;

select Customers.CustomerID, Customers.Name, Orders.Amount 
from Customers inner join Orders				--We Could Put Just << Join >> Raather than << inner join >> are the same thing.
ON Customers.CustomerID = Orders.CustomerID;	 -- On Equevalent to Where But We Use On With Inner

--==================== Left Join ===================================
 -- Left join == left Outer join

 select Customers.CustomerID, Customers.Name, Orders.Amount 
from Customers left join Orders				--We Could Put  << Left outer Join >> Raather than << left join >> are the same thing.
ON Customers.CustomerID = Orders.CustomerID;
-- it taks the whole record of the left side Table < Customers > and the Maches Ones On the Right side < Orders >
--===================================================================


--==================== Right join ==================================
-- Rigth join == Rigth outer join

 select Customers.CustomerID, Customers.Name, Orders.Amount 
from Customers right join Orders				--We Could Put  << right outer Join >> Raather than << right join >> are the same thing.
ON Customers.CustomerID = Orders.CustomerID;
--===================================================================

--==================== Full join ==================================
-- Full join == Full outer join

 select Customers.CustomerID, Customers.Name, Orders.Amount 
from Customers Full join Orders				--We Could Put  << Full outer Join >> Raather than << Full join >> are the same thing.
ON Customers.CustomerID = Orders.CustomerID;
--Full join = right join + Left join.
--===================================================================









