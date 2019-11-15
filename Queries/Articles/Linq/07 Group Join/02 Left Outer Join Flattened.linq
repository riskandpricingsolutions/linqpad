<Query Kind="Program" />

void Main()
{
	IEnumerable<(int, string)> sOuter = new[]
		{ (1, "one"), (2, "two"), (3, "three"), (4, "four") };

	IEnumerable<(int, string)> sInner = new[]
		{ (1, "Ensimmäinen"), (1, "Ett"), (2, "Kaksi"), (2, "Tva"), (3, "Kolme") };

	// Group Join gives us a hierarchical left outer join
	IEnumerable<((int, string) OuterEl, IEnumerable<(int, string)> InnerEls)>
		leftOuterHierarchical = sOuter.GroupJoin(
			sInner,
			outerEl => outerEl.Item1,
			innerEl => innerEl.Item1,
			(outEl, innerMatches) => (OutEl: outEl, InEls: innerMatches));

	// SelectMany flattens.
	IEnumerable<(string, string)> outSeq = leftOuterHierarchical
		.SelectMany(hierarchicalEl => hierarchicalEl.InnerEls.DefaultIfEmpty(),
			(hierarchicalEl, innerEl) => (hierarchicalEl.OuterEl.Item2, innerEl.Item2));



	outSeq.Dump();
}

IEnumerable<(int, string)> sOuter = new[]
	{ (1, "one"), (2, "two"), (3, "three"), (4, "four") };

IEnumerable<(int, string)> sInner = new[]
	{ (1, "Ensimmäinen"), (1, "Ett"), (2, "Kaksi"), (2, "Tva"), (3, "Kolme") };

// Group Join gives us a hierarchical left outer join
IEnumerable<((int, string) OuterEl, IEnumerable<(int, string)> InnerEls)>
	leftOuterHierarchical = sOuter.GroupJoin(
		sInner,
		outerEl => outerEl.Item1,
		innerEl => innerEl.Item1,
		(outEl, innerMatches) => (OutEl: outEl, InEls: innerMatches));

// SelectMany flattens.
IEnumerable<(string, string)> outSeq = leftOuterHierarchical
	.SelectMany(hierarchicalEl => hierarchicalEl.InnerEls.DefaultIfEmpty(),
		(hierarchicalEl, innerEl) => 
		(hierarchicalEl.OuterEl.Item2, innerEl.Item2));


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

			// Map the current outer element, a sequence of matching inner elements
			// to a single result element.
			TRes result = resultSector(outerEl, matchingInnerEls);
			yield return result;
		}
	}
	
	public static IEnumerable<TRes> SelectMany<TRes,TSource,TCollection>(
		IEnumerable<TSource> inputSeq,
		Func<TSource,IEnumerable<TCollection>> colSelector,
		Func<TSource,TCollection,TRes> resultSelector)
		{
			foreach (TSource inputEl in inputSeq)
			{
				IEnumerable<TCollection> expandedSeq = colSelector(inputEl);
				
				foreach(TCollection expandedEl in expandedSeq)
				{
					TRes resultEl = resultSelector(inputEl, expandedEl);
					yield return resultEl;
				}
			}
		}
}