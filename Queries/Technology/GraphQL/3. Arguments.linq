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
	  var schema = new Schema {Query = new PersonQuery()};
	  
	  
	  var json = await schema.ExecuteAsync(_ =>
	 {
		 _.Query = @"
		 {
  			getPerson(name:""John"") {
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
		Field(x=>x.Age);
		Field(x=>x.FirstName);
	}
}

public class PersonQuery : ObjectGraphType
{
	private List<Person> _people = new List<UserQuery.Person>()
	{
		new Person {Age=21, FirstName="John"},
				new Person {Age=45, FirstName="Ken"},
	};
	
	public PersonQuery() 
	{
		Field<PersonType>( "getPerson",
			arguments: new QueryArguments(
				new QueryArgument<StringGraphType> {Name="name"}),
			resolve: ctx => 
				_people.FirstOrDefault(x =>
					x.FirstName == (string)ctx.Arguments["name"])
		);
		
			
		Field<ListGraphType<PersonType>>( "getPeople",
			resolve: ctx => new List<Person>
			{
				new Person {Age=21, FirstName="John"},
				new Person {Age=45, FirstName="Ken"},
			});
	}
}