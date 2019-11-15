<Query Kind="Statements" />

(int, string)[] s1 = new[] { (1, "one"), (2, "two"), };
(int, string)[] s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

/* First we show how the mechanics work of first doing a group join 
*  and then a SelectMany */
IEnumerable<((int, string) leftEl, IEnumerable<(int, string)> rightMatches)> joinResults
	= Enumerable.GroupJoin(
		/* Left Sequence */ s1,
		/* Right Sequence */ s2,
		/* Left Key Selector */ leftEl => leftEl.Item1,
		/* Right Key Selector */ rightEl => rightEl.Item1,
		/* Result Selector */ (leftEl, rightMatches) => (leftEl, rightMatches)
	);

IEnumerable<(string Left, string Right)> flattenedResults =
	Enumerable.SelectMany(
		/* Source Sequence */ joinResults,
		/* Collection Selector */ jointElement => jointElement.rightMatches.DefaultIfEmpty(),
		/* Result Selector */
		(tuple, valueTuple) => (Left: tuple.leftEl.Item2, Right: valueTuple.Item2));
flattenedResults.Dump();


// Concise Fluent Syntax
IEnumerable<(string Left, string Right)> f1 = s1
	.GroupJoin(s2, e1 => e1.Item1, e2 => e2.Item1, (leftEl, rightMatches) => (leftEl, rightMatches))
	.SelectMany(jointElement => jointElement.rightMatches.DefaultIfEmpty(),
		(tuple, valueTuple) => (Left: tuple.leftEl.Item2, Right: valueTuple.Item2));

// Concise Query Syntax
IEnumerable<(string Left, string Right)> q2 = from leftEl in s1
											  join rightEl in s2 on leftEl.Item1 equals rightEl.Item1 into matches
											  from match in matches.DefaultIfEmpty()
											  select (Left: leftEl.Item2, Right: match.Item2);