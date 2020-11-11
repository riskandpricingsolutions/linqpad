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
	  var schema = new Schema {Query = new OptionsCacheQuery()};
	  
	  
	  var json = await schema.ExecuteAsync(_ =>
	 {
		 _.Query = @"
		 {
  			getOptions(ulRic:"".SPX"") {
			 		expiry,
    				strike,
					underlying {
						ricCode
					}
					
			}
					
	 	}";
		
  		_.Root = schema;
});

	json.Dump();
}
public class Option
{
	public string Expiry { get; set; }
	public double Strike { get; set; }
	public Equity Underlying { get; set; }
}

public class Equity {
	public string RicCode { get; set; }
}

public class EquityType : GraphQL.Types.ObjectGraphType<Equity>
{
	public EquityType()
	{
		Field(x=>x.RicCode);
	}
}


public class OptionType : GraphQL.Types.ObjectGraphType<Option>
{
	public OptionType()
	{
		Field(x => x.Expiry).Description("Expiration Date String");
		Field(x => x.Strike).Description("The exercise price");
		Field<EquityType>("underlying",description:"The underlying security");
	}
}

public class OptionsCacheQuery : ObjectGraphType
{
	private IList<Option> _options = new List<Option>
	{
		new Option {Expiry="Dec20", Strike=4000,Underlying=new Equity {RicCode=".FTSE"}},
		new Option {Expiry="Dec20", Strike=3000,Underlying=new Equity {RicCode=".SPX"}},
		new Option {Expiry="Dec21", Strike=3200,Underlying=new Equity {RicCode=".SPX"}},
	};
	
	public OptionsCacheQuery()
	{
		Field<ListGraphType<OptionType>>("getOptions",
		arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "ulRic" }),
		resolve: context =>
		{
			var ric = context.Arguments["ulRic"];
			return 	_options.Where(x => x.Underlying.RicCode.Equals(ric) );
		});
	}
}

