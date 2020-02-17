<Query Kind="Program" />

void Main()
{
	// Question: Implement SelectMany
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee" };

	var res = inseq1.SelectMany<String, String>(el => el.Split()).Dump();



}

public static class MyLinq
{
	public static IEnumerable<TOut> SelectMany<TOut,TIn>(this IEnumerable<TIn> s,
		Func<IEnumerable<TIn>,IEnumerable<TOut>> f)
		{
			
		}
}