<Query Kind="SQL">
  <Connection>
    <ID>3103851c-fe09-4d0e-a15c-4222b2a0499b</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Courses</Database>
  </Connection>
</Query>

-- LINQPad also lets you run old-fashioned SQL queries.

-- To illustrate, the following script creates a small fragment of the NORTHWND
-- database, allowing the LINQ query in the preceding example to execute!

-- Before running this, click "Add connection" and create a suitable empty database,
-- then pick that database in the dropdown above.

create table Courses 
(
	CourseID int not null primary key,
	CourseName varchar(100) not null,
	Teacherid int not null
)

create table Teachers
(
	TeacherId int not null primary key,
	TeacherName varchar(100) not null
)

create table Students 
(
	StudentId int not null primary key,
	StudentName varchar(100) not null
)

create table StudentCourse
(
	CourseId int not null,
	StudentId int not null
)


insert Teachers values (1, 'John Smith')
insert Teachers values (2, 'Sam Smith')
insert Teachers values (3, 'Dawn French')

insert Students values (1, 'Kenny Wilson')
insert Students values (2, 'Robert Turnbull')
insert Students values (3, 'Milly Vanilly')

insert Courses values (1, 'Algorithms', 1)
insert Courses values (2, 'Calculus', 2)


insert StudentCourse values (1,1)
insert StudentCourse values (1,2)
insert StudentCourse values (2,1)

SELECT S.StudentName, count(SC.CourseId)
FROM Students S
LEFT JOIN StudentCourse SC 
ON S.StudentId = SC.StudentId
GROUP BY S.StudentId, S.StudentName


--create table Categories
--(
--	CategoryID int not null primary key,
--	CategoryName varchar(100) not null
--)
--
--create table Products
--(
--	ProductID int not null primary key,
--	ProductName varchar(100) not null,
--	CategoryID int references Categories (CategoryID)
--)
--
--create table Orders
--(
--	OrderID int not null primary key,
--	OrderDate DateTime,
--	ShipCountry varchar(100) not null
--)
--
--create table OrderDetails
--(
--	OrderID int not null references Orders (OrderID),
--	ProductID int not null references Products (ProductID),
--	UnitPrice decimal,
--	Quantity int,
--	constraint PK_OrderDetails primary key (OrderID, ProductID)
--)
--
--insert Categories values (1, 'Seafood')
--insert Categories values (2, 'Beverages')
--insert Categories values (3, 'Confections')
--insert Categories values (4, 'Meat/Poultry')
--insert Categories values (5, 'Dairy Products')
--
--insert Products values (1, 'Boston Crab Meat', 1)
--insert Products values (2, 'Chai', 2)
--insert Products values (3, 'Teatime Chocolate Biscuits', 3)
--
--insert Orders values (1, '2007-1-1', 'Spain');
--insert Orders values (2, '2007-2-2', 'Spain');
--insert Orders values (3, '2007-3-3', 'Spain');
--
--insert OrderDetails values (1, 1, 23.5, 2)
--insert OrderDetails values (2, 2, 143, 5)
--insert OrderDetails values (3, 3, 77, 1)
--insert OrderDetails values (3, 2, 70, 3)
--
--PRINT 'Voila!'
--PRINT ''
--PRINT 'Now go back to the preceding example and re-run the LINQ to SQL query.'
--PRINT '(Remember to set the Database).'