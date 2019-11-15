<Query Kind="Statements" />

// SelectMany as a flattening operator
//----------------------------------------------------------------------
//
// Consider the following query index query. We note two significant 
// features. 
//		1) We have two from clauses one after the
// 			other. In this situation the compiler will translate 
//			this into a SelectMany operator. 
//
//		2) The second from clause references the range variable from
//			the first from clause. This causes our query to carry out
//			a flattning operation	 


IEnumerable<(string, int[])> sIn = 
	new[] { ("Kenny", new[] { 1, 2, 3 }), ("Joe", new[] { 4, 5, 6 }) };

// Flattening/Concatentating subsequences using SelectMany - Fluent Syntax
IEnumerable<int> seq2 = sIn
	.SelectMany(s => s.Item2);

IEnumerable<int> seq1 =
	from p in sIn
	from s in p.Item2   // A second from clause causes SelectMany
					select s;



seq1.Dump("Query Syntax");
seq2.Dump("Fluent Syntax");


public static class LinqOperators
{
	public static IEnumerable<TResult> SelectMany<TSource,TResult>(
		this IEnumerable<TSource> source, 
		Func<TSource,IEnumerable<TResult>> project)
	{
		foreach (var element in source)
			foreach (var subelement in project(element))
				yield return subelement;				
	}

	public static IEnumerable<TResult> SelectMany<TSource,TCollection, TResult>(
		this IEnumerable<TSource> source,
		Func<TSource, IEnumerable<TCollection>> collectionSelector,
		Func<TSource,TCollection,TResult> resultSelector)
	{
		foreach (var sourceElement in source)
		{
			foreach (var subelement in collectionSelector(sourceElement))
			{
				yield return resultSelector(sourceElement,subelement);
			}
		}
	}

	public static IEnumerable<TResult> SelectMany<TIn, TResult>(
		this IEnumerable<TIn> source,
		Func<TIn,int, IEnumerable<TResult>> project)
	{
		int i = 0;
		foreach (var element in source)
			foreach (var subelement in project(element,i++))
				yield return subelement;
	}
}