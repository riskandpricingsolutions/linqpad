<Query Kind="Program">
  <NuGetReference Prerelease="true">GraphQL</NuGetReference>
  <NuGetReference Version="3.4.0" Prerelease="true">GraphQL.Server.Core</NuGetReference>
  <NuGetReference Version="3.5.0-alpha0027" Prerelease="true">GraphQL.Server.Transports.AspNetCore</NuGetReference>
  <NuGetReference Prerelease="true">GraphQL.SystemTextJson</NuGetReference>
  <Namespace>GraphQL</Namespace>
  <Namespace>GraphQL.Server</Namespace>
  <Namespace>GraphQL.Server.Transports.AspNetCore</Namespace>
  <Namespace>GraphQL.SystemTextJson</Namespace>
  <Namespace>GraphQL.Types</Namespace>
</Query>

async void Main()
{
	  var schema = new Schema {Query = new StarWardQuery()};
	  
	  var json = await schema.ExecuteAsync(_ =>
	 {
		 _.Query = @"
		 {
  			hero {
			 		id,
    				name
  				 }
	 	}";
		
  		_.Root = schema;
});

	json.Dump();
}
public class Droid
{
	public string Id { get; set; }
	public string Name { get; set; }
}

public class DroidType : GraphQL.Types.ObjectGraphType<Droid>
{
	public DroidType()
	{
		Field(x => x.Id).Description("The Id");
		Field(x => x.Name).Description("Name");
	}
}

public class StarWardQuery : ObjectGraphType
{
	public StarWardQuery()
	{
		Field<DroidType>("hero", resolve: context => new Droid() { Id = "1", Name = "R2 D2" });
	}
}

// Define other methods, classes and namespaces here
