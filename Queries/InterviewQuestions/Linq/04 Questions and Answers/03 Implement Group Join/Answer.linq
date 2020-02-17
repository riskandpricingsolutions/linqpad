<Query Kind="Program">
  <DisableMyExtensions>true</DisableMyExtensions>
</Query>

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
	
	s1.GroupJoin(
		s2,
		e1=> e1.Item1,
		e2 => e2.Item1,
		(e1,e2) => new {Left=e1,Right=e2}
		);

	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee" };

	inseq1.Select(i => i.First()).Dump();

	inseq1.Select((i, el) => i).Dump();

}


public static class MyLinq
{
	public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
		  this System.Collections.Generic.IEnumerable<TOuter> outer,
		  System.Collections.Generic.IEnumerable<TInner> inner,
		  Func<TOuter, TKey> outerKeySelector,
		  Func<TInner, TKey> innerKeySelector,
		  Func<TOuter, System.Collections.Generic.IEnumerable<TInner>, TResult> resultSelector)
	{

		ILookup<TKey, TInner> lookup =
			inner.ToLookup(innerEl => innerKeySelector(innerEl));

		foreach (TOuter outerEl in outer)
		{
			// Convert the element from the outer sequence to its key
			TKey outerElKey = outerKeySelector(outerEl);

			// Use the outer element key to lookup all matching 
			// inner sequence elements using the lookup for efficiency
			IEnumerable<TInner> matchingInnerEls = lookup[outerElKey];

			// Map the current outer element, a sequence of matching 
			// inner elementsto a single result element.
			TResult result = resultSelector(outerEl, matchingInnerEls);
			yield return result;
		}
	}
}