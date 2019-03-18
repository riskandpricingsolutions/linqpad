<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	IEnumerable<string> sanat = new[] { "Äiti", "Suomi", "Ranta", "Isi", "Sisu", "Edessä" };

	// Example one basic filtration {"Äiti", "Suomi","Isi","Sisu""}
	IEnumerable<string> os1 = sanat.Where(e => e.Contains("i"));
	WriteLine(os1); // 

	// Example two Index Filtration {"Äiti", "Ranta","Sisu""}
	IEnumerable<string> os2 = sanat.Where((e, i) => i % 2 == 0);

	// Example three multiple multi-where clause query syntax
	IEnumerable<string> os3 = from s in sanat
							  where s.Length == 4
							  let i = s.ToUpper()
							  where i.StartsWith("SI")
							  select i;
}

public static class LinqOperators
{
	public static IEnumerable<T> Where<T>(this IEnumerable<T> source, 
		Func<T,bool> predicate)
	{
		foreach (var element in source)
			if (predicate(element))
				yield return element;				
	}

	public static IEnumerable<T> Where<T>(this IEnumerable<T> source,
		Func<T,int, bool> predicate)
	{
		int i = 0;
		foreach (var element in source)
			if (predicate(element,i++))
				yield return element;
	}
}