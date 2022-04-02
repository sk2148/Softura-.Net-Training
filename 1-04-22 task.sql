use AdventureWorks2019
go

--Task 1
select FirstName,LastName
from person.Person where Title is not null

--Task  2
select FirstName,LastName
from person.Person where FirstName like '%a%' and lastname like '%a%'

--Task 3
select CR.CurrencyCode,Name
from Sales.Currency ,Sales.CountryRegionCurrency CR

--Task 4
select * into HR_Dept from HumanResources.Department

--Task 5
use Trail
go
create table Dt(
Sno int identity(1,1),
FName varchar(20),
LName varchar(20),
PNo varchar(10),
Email varchar(40)
constraint pk_rol primary key(Sno))
insert Dt values('Santhosh','kumar',9589875411,'sk2148@srmist.edu.in'),
('Praveen','kumar',7589875411,'pk2148@srmist.edu.in'),
('Tharun','kumar',6589875411,'tk2148@srmist.edu.in'),
('Bala','kumar',8589875411,'bk2148@srmist.edu.in')
select * from Dt

--Task 6
use AdventureWorks2019
go
select Emp.BusinessEntityID,AddressTypeID
from HumanResources.Department Dept
join HumanResources.EmployeeDepartmentHistory Emp
on Dept.DepartmentID=Emp.DepartmentID
join Person.BusinessEntityAddress per
on Emp.BusinessEntityID=per.BusinessEntityID

--Task 7
select Distinct GroupName
from HumanResources.Department

--Task 8
select DocumentNode,pro.StandardCost,sum(ListPrice)SumListPrice,sum(pro.StandardCost)SumStandardCost
from Production.ProductDocument doc
join Production.ProductCostHistory his
on doc.ProductID=his.ProductID
join Production.Product pro
on pro.StandardCost=his.StandardCost
group by DocumentNode,pro.StandardCost

--Task 9
select datediff (YY,StartDate,EndDate) as YOR 
from HumanResources.EmployeeDepartmentHistory

--Task 10
select sum(SalesQuota)SQ
 from Sales.SalesPersonQuotaHistory
 where SalesQuota>5000 and salesquota<100000
 group by SalesQuota

 --Task 11
 select max(taxrate)Max_taxrate
 from sales.SalesTaxRate

 --Task 12
 select hd.BusinessEntityID,dept.DepartmentID,ShiftID,emp.BirthDate,datediff(YY,BirthDate,getdate()) as age
from HumanResources.Employee emp
join HumanResources.EmployeeDepartmentHistory hd
on emp.BusinessEntityID=hd.BusinessEntityID
join HumanResources.Department dept
on dept.DepartmentID=hd.DepartmentID

--Task 13
create view Name_age
as
select hd.BusinessEntityID,dept.DepartmentID,ShiftID,He.BirthDate,getdate() as CurrentDate, datediff(YY,BirthDate,getdate()) as age
from HumanResources.Employee He
join HumanResources.EmployeeDepartmentHistory hd
on he.BusinessEntityID=hd.BusinessEntityID
join HumanResources.Department dept
on dept.DepartmentID=hd.DepartmentID
go
select * from Name_age

--Task 14
SELECT count(*) No_of_rows_hr
FROM [HumanResources].[Department],[HumanResources].[Employee],[HumanResources].[EmployeeDepartmentHistory],[HumanResources].[EmployeePayHistory],[HumanResources].[Shift]

--Task 15
select Name Depatment,max(rate)MaxSalary
from HumanResources.EmployeePayHistory pay
join HumanResources.EmployeeDepartmentHistory dhis
on pay.BusinessEntityID = dhis.BusinessEntityID
join HumanResources.Department dept
on dept.DepartmentID = dhis.DepartmentID
GRoup By name

--Task 16
select FirstName,MiddleName,Title,AddressTypeID,per.BusinessEntityID
from Person.Person per
left join Person.BusinessEntityAddress BEA
on per.BusinessEntityID=BEA.BusinessEntityID
where Title is not null

--Task 17
select ProductID,LocationID,Shelf
from Production.ProductInventory
where ProductID>=300 and ProductID <=350 and LocationID=50 and Shelf='E'

--Task 18
select inv.LocationID,Shelf,Name
from Production.ProductInventory inv
join Production.Location loc
on inv.LocationID=loc.LocationID

--Task 19
select AddressID,AddressLine1,AddressLine2,StateProvinceCode,CountryRegionCode
from Person.StateProvince sp
join Person.Address adr
on sp.StateProvinceID=adr.StateProvinceID

--Task 20
select CurrencyCode,sum(subtotal)SumOfSubtotal,TaxAmt Total
from sales.SalesOrderHeader sh
join Sales.SalesTerritory st
on sh.TerritoryID = st.TerritoryID
join Sales.CountryRegionCurrency crc
on st.CountryRegionCode = crc.CountryRegionCode
group by CurrencyCode,TaxAmt
