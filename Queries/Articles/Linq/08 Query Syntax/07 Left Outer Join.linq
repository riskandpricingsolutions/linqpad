<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

(int, string)[] outerSeq = { (1, "one"), (2, "two"), };
(int, string)[] innerSeq = { (1, "Ensimmäinen"), (1, "Ett") };

IEnumerable<(string, string)> q1 = 
	from outerEl in outerSeq
	join innerEl in innerSeq on outerEl.Item1 equals innerEl.Item1
	into matches
	from e in matches.DefaultIfEmpty()
	select default((int, string)).Equals(e) 
		? (outerEl.Item2, "") 
		: (outerEl.Item2, e.Item2);

// We write a small helper function that generates a result 
// element from an (inner,outer) element pair. It has logic to deal
// with default values for the inner element.
(string, string) ResGenFunc((int, string) outerEl, (int, string) innerEl) =>
	default((int, string)).Equals(innerEl)
		? (outerEl.Item2, "")
		: (outerEl.Item2, innerEl.Item2);

IEnumerable<(string, string)> f1 =
	outerSeq
		.GroupJoin(	innerSeq,
					oel => oel.Item1,
					inel => inel.Item1,
					(oel, inEls) => inEls
									.DefaultIfEmpty()
									.Select(innerEl => ResGenFunc(oel, innerEl)))
		.SelectMany(el => el);

q1.Dump();
f1.Dump();