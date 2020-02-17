<Query Kind="Program" />

void Main()
{
	// Question: Implement SelectMany
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee" };

	var res = inseq1.SelectMany<String, String>(el => el.Split()).Dump()

}

public static class MyLinq
{
	public static IEnumerable<TResult> SelectMany<TResult,TSource>(
		this IEnumerable<TSource> source, 
		Func<TSource,IEnumerable<TResult>> f )
		{
			foreach (var element in source)
			{
				IEnumerable<TResult> temp = f(element);
				foreach(var e2 in temp)
					yield return e2;
			}
		}
}