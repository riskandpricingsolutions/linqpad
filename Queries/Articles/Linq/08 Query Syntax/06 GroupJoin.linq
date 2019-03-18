<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

(int, string)[] outerSeq = { (1, "one"), (2, "two"), };
(int, string)[] innerSeq = { (1, "Ensimmäinen"), (1, "Ett") };

// Query Syntax
var q1 =
	from ol in outerSeq
	join il in innerSeq on ol.Item1 equals il.Item1
	into matches
	select (ol.Item2,matches);

var f1 = outerSeq.GroupJoin(
	innerSeq,
	ol=>ol.Item1,
	il=>il.Item1,
	(ol,il) => (ol.Item2,il));


//WriteLine(((IStructuralEquatable)s1.ToArray()).Equals(f1.ToArray(), EqualityComparer<(string,string)>.Default));

// Query Syntax
var q2 =
	from ol in outerSeq
	join il in innerSeq on ol.Item1 equals il.Item1
	into matches
	where ol.Item2 == "one" && matches.Count() == 2
	select (ol.Item2, matches);


// Fluent Syntax 

var f2 = outerSeq
	.GroupJoin(
		innerSeq,
		ol => ol.Item1,
		il => il.Item1,
		(ol, matches) => new {ol,matches})
	.Where(x=>x.ol.Item2 == "one" && x.matches.Count() == 2)
	.Select(x => (x.ol.Item2, x.matches));




q2.Dump();
f2.Dump();