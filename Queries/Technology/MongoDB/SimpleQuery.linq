<Query Kind="Program">
  <NuGetReference>MongoDB.Bson</NuGetReference>
  <NuGetReference>MongoDB.Driver</NuGetReference>
  <Namespace>MongoDB.Bson</Namespace>
  <Namespace>MongoDB.Driver</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>MongoDB.Bson.IO</Namespace>
</Query>

async void Main()
{
	var connectionString = "mongodb://localhost:27017";
	var database = new MongoClient(connectionString).GetDatabase("products");
	var options = database.GetCollection<BsonDocument>("options");
	
	var documents = await options.Find(_ => true ).ToListAsync();
	
	foreach (var doc in documents)
	{
		doc.ToJson(new JsonWriterSettings() { Indent = true}).Dump();
	}
}
