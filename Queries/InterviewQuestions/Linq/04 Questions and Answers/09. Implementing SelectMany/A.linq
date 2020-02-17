<Query Kind="Program" />

void Main()
{
	// Question: Implement Select
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee"};

	var res =inseq1.SelectMany<String,String>(el=>el.Split()).Dump();
	


}

public static class MyLinq
{
	public static IEnumerable<TResult> SelectMany<TSource,TResult>(this IEnumerable<TSource> input, Func<TSource, IEnumerable<TResult>> f)
	{
		foreach (var element in input)
		{
			foreach(var el2 in f(element))
				yield return el2;
		}
	}
}