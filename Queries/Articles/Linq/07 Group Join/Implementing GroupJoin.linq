<Query Kind="Program" />

void Main()
{
	var inseq1 = new[] { (1, "one"), (2, "two"), };
	var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	IEnumerable<(int, string)> sOuter = new[] { (1, "one"), (2, "two"), };
	IEnumerable<(int, string)> sInner = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	IEnumerable<((int, string), IEnumerable<(int, string)>)> sOut =
		sOuter.GroupJoin(
			sInner,
			outerEl => outerEl.Item1,
			innerEl => innerEl.Item1,
			(outerEl, innerMatches) => (Left: outerEl, RightMatches: innerMatches));


	sOut.Dump();
}



public class Extentions
{
	public static IEnumerable<TRes> GroupJoin<TRes, TOuter, TInner, TKey>(
		IEnumerable<TOuter> sOuter,
		IEnumerable<TInner> sInner,
		Func<TOuter, TKey> outerKeySelector,
		Func<TInner, TKey> innerKeySelector,
		Func<TOuter, IEnumerable<TInner>, TRes> resultSector
	)
	{
		ILookup<TKey, TInner> lookup =
			sInner.ToLookup(innerEl => innerKeySelector(innerEl));

		foreach (TOuter outerEl in sOuter)
		{
			// Convert the element from the outer sequence to its key
			TKey outerElKey = outerKeySelector(outerEl);

			// Use the outer element key to lookup all matching 
			// inner sequence elements using the lookup for efficiency
			IEnumerable<TInner> matchingInnerEls = lookup[outerElKey];

			// Map the current outer element, a sequence of matching 
			// inner elementsto a single result element.
			TRes result = resultSector(outerEl, matchingInnerEls);
			yield return result;
		}
	}
}

