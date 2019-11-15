<Query Kind="Program" />

void Main()
{
	var s1 = new[] {'a','b','c'};
	var s2 = new[] {'1','2','3'};
	
	var q =	from e1 in s1
			from e2 in s2
			select e1.ToString() + e2.ToString() ;
	q.Dump();
	
	var f = s1.SelectMany(e1 => s2,(o,c) => o.ToString() +c.ToString());
	f.Dump();
	
}

public static class Extentions
{
	public static IEnumerable<TResult> SelectMany<TSource,TResult>(
		this IEnumerable<TSource> inputSequence,
		Func<TSource, IEnumerable<TResult>> collectionSelector)
	{
		foreach (var e1 in inputSequence)
		{
			IEnumerable<TResult> expandedSequence = collectionSelector(e1);
			foreach(var e2 in expandedSequence)
				yield return e2;
		}
	}

	public static IEnumerable<TResult> SelectMany<TSource, TCollection,TResult>(
		this IEnumerable<TSource> inputSequence,
		Func<TSource, IEnumerable<TCollection>> collectionSelector,
		Func<TSource,TCollection,TResult> resultSelector)
	{
		foreach (var e1 in inputSequence)
		{
			IEnumerable<TCollection> expandedSequence = collectionSelector(e1);
			foreach (var e2 in expandedSequence)
				yield return resultSelector(e1,e2);
		}
	}

}

// Define other methods and classes here
