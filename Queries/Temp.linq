<Query Kind="Program" />

void Main()
{
	var s1 = new[] {'a','b','c'};
	var s2 = new[] {'1','2','3'};
	

	from s
	
}

public static class Extentions
{
	public static IEnumerable<TResult> SelectMany<TSource,TResult>(
		this IEnumerable<TSource> input,
		Func<TSource, IEnumerable<TResult>> collectionSelector)
	{
		foreach (var element in input)
		{
			IEnumerable<TResult> t = collectionSelector(element);
			foreach(var inner in t)
				yield return inner;
		}
	}
	
//	public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> f)
//	{
//		foreach (var element in source)
//		{
//			IEnumerable<TResult> t = f(element);
//			foreach (var inner in t)
//				yield return inner;
//		}
//	}

}

// Define other methods and classes here