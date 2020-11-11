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


ALTER TABLE dbo.Products
	ADD CONSTRAINT PK_Products
	PRIMARY KEY(prodId);