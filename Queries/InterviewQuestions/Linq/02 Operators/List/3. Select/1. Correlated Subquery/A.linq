<Query Kind="Program" />

void Main()
{
	// Question: Implement Select
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee"};

	inseq1.Select(i => i.First()).Dump();
	
	inseq1.Select((i,el) => i).Dump();

}

public static class MyLinq
{
	public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> input, Func<TSource,TResult> f)
	{
		foreach (var element in input)
		{
			yield return f(element);
		}
	}

	public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> input, Func<int,TSource, TResult> f)
	{
		int i =0;
		foreach (var element in input)
		{
			yield return f(i++,element);
		}
	}
}

