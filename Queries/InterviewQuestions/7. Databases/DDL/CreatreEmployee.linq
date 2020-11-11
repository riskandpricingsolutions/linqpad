<Query Kind="SQL">
  <Connection>
    <ID>a9c5b3f6-74da-4f5a-b0cb-87a6da57dadf</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>TSQLv4</Database>
  </Connection>
</Query>

DROP TABLE IF EXISTS Employees;

CREATE TABLE dbo.Employees
(
	empId INT NOT NULL,
	firstName VARCHAR(30) NOT NULL,
	lastName VARCHAR(30) NOT NULL,
	hiredDate DATE NOT NULL,
	mgrid INT NULL,
	ssn VARCHAR(20) NOT NULL,
	salary MONEY NOT NULL
);
