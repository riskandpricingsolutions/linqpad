<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	IEnumerable<string> parit = new[] { "Minun äiti", "Mun Suomi", "Iso ranta", "Sanan isi", };

	// Example 1 - SelectMany flattens
	parit.SelectMany(s => s.Split()).Dump("SelectMany flattens subsequences");

	// Example 2 - 	SelectMany is specified via a second from clause in
	//				query syntax
	(
		from p in parit       
		from s in p.Split() // SelectMany
		select s            
	)
	.Dump("SelectMany in Query Syntax");
}

public static class LinqOperators
{
	public static IEnumerable<TResult> SelectMany<TIn,TResult>(
		this IEnumerable<TIn> source, 
		Func<TIn,IEnumerable<TResult>> project)
	{
		foreach (var element in source)
			foreach (var subelement in project(element))
				yield return subelement;				
	}

	public static IEnumerable<TResult> SelectMany<TIn, TResult>(this IEnumerable<TIn> source,
		Func<TIn,int, IEnumerable<TResult>> project)
	{
		int i = 0;
		foreach (var element in source)
			foreach (var subelement in project(element,i++))
				yield return subelement;
	}
}

// Define other methods and classes here