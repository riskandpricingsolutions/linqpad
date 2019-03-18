<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	IEnumerable<string> sanat = new[] { "Minun äiti", "Mun Suomi", "Iso ranta", "Sanan isi", };

	// Example 1 - Basic Projection
	WriteLine(sanat.Select(s => s.ToUpper()));

	// Example 2 - Index Projection
	WriteLine(sanat.Select((s, i) => $"{i} => {s}"));

	// Example 2 - Projecting onto anonymous type
	WriteLine(sanat.Select((s, i) => new { Index = i, Element = s }));

	// Example 3 - Projection using correlated subqueries
	sanat.Select(s => s.Split());

}

public static class LinqOperators
{
	public static IEnumerable<TResult> Select<TIn,TResult>(this IEnumerable<TIn> source, 
		Func<TIn,TResult> project)
	{
		foreach (var element in source)
				yield return project(element);				
	}

	public static IEnumerable<TResult> Select<TIn,TResult>(this IEnumerable<TIn> source,
		Func<TIn,int, TResult> project)
	{
		int i = 0;
		foreach (var element in source)
			yield return project(element,i++);
	}
}
