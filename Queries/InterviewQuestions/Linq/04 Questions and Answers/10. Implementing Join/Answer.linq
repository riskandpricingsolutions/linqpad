<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
	
	s1.SelectMany(e1 => s2, (e1, e2) => new { Left = e1, Right = e2 })
	.Where(s => s.Left.Item1 == s.Right.Item1)
	.Dump();
}

public static class MyJoin
{
	public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
		this IEnumerable<TOuter> outer,
		IEnumerable<TInner> inner,
		Func<TOuter, TKey> outerKeySelector,
		Func<TInner, TKey> innerKeySelector, Func<TOuter,
			TInner, TResult> resultSelector)
	{
		var lookup = inner.ToLookup(innerKeySelector);

		foreach (var outerEl in outer)
			foreach (var innerEl in lookup[outerKeySelector(outerEl)])
			{
				var res = resultSelector(outerEl, innerEl);
				yield return res;
			}
	}

}