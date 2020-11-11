<Query Kind="SQL">
  <Connection>
    <ID>d3d6e86a-3c29-4e40-a01d-c98b427e4150</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>Products</Database>
  </Connection>
</Query>

DROP TABLE IF EXISTS dbo.Products;

CREATE TABLE dbo.Products
(
	prodId INT NOT NULL,
	description VARCHAR(30) NOT NULL
);

CREATE TABLE dbo.Trades	
(
	tradeId INT NOT NULL,
	description VARCHAR(30) NOT NULL
);