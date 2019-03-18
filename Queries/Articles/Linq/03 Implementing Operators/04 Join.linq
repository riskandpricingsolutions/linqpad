<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	var seq1 = new[] { (1, "one"), (2, "two"), };
	var seq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
	
	var result = 
		from outerEl in seq1 join innerEl in seq2 on outerEl.Item1 equals innerEl.Item1 select  (outerEl.Item2,innerEl.Item2);
	
	var result2 = seq1.Join(seq2,outerEl => outerEl.Item1, innerEl => innerEl.Item1,(outerEl,innerEl) => (outerEl.Item2,innerEl.Item2));

	
	result.Dump();
	result2.Dump();
}

public static class LinqOperators
{
	public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
		this IEnumerable<TOuter> outer,
		IEnumerable<TInner> inner,
		Func<TOuter, TKey> outerKeySelector,
		Func<TInner, TKey> innerKeySelector, 
		Func<TOuter,TInner, TResult> resultSelector)
	{
		var lookup = inner.ToLookup(innerEl => innerKeySelector(innerEl));

		foreach (var outerEl in outer)
			foreach (var innerEl in lookup[outerKeySelector(outerEl)])
				yield return resultSelector(outerEl, innerEl);
	}
}