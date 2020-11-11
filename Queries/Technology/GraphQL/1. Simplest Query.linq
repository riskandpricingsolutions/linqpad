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
	var schema = new Schema { Query = new PersonQuery() };


   var json = await schema.ExecuteAsync(_ =>
   {
	   _.Query = @"
		 {
  			getPerson {
			 		age,
    				firstName,
			}
					
	 	}";

	   _.Root = schema;
   });

	json.Dump();
}

public class Person
{
	public int Age { get; set; }

	public string FirstName { get; set; }
}

public class PersonType : ObjectGraphType<Person>
{
	public PersonType()
	{
		Field(x => x.Age);
		Field(x => x.FirstName);
	}
}

public class PersonQuery : ObjectGraphType
{
	public PersonQuery()
	{
		Field<PersonType>("getPerson",
			resolve: ctx => new Person()
			{
				Age = 21,
				FirstName = "Dave"
			});
	}
}