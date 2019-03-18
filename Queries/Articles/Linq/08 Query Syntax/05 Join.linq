<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

(int, string)[] outerSeq = { (1, "one"), (2, "two"), };
(int, string)[] innerSeq = { (1, "Ensimmäinen"), (1, "Ett") };

// Query Syntax
var s1 =
	from ol in outerSeq
	join il in innerSeq on ol.Item1 equals il.Item1
	select (ol.Item2,il.Item2);

var f1 = outerSeq.Join(
	innerSeq,
	ol=>ol.Item1,
	il=>il.Item1,
	(ol,il) => (ol.Item2,il.Item2));


WriteLine(((IStructuralEquatable)s1.ToArray()).Equals(f1.ToArray(), EqualityComparer<(string,string)>.Default));

// Query Syntax
var s2 =
	from ol in outerSeq
	join il in innerSeq on ol.Item1 equals il.Item1
	where ol.Item2 == "one" && il.Item2 == "Ett"
	select (ol.Item2, il.Item2);

// Fluent Syntax 

var f2 = outerSeq
	.Join(
		innerSeq,
		ol => ol.Item1,
		il => il.Item1,
		(ol, il) => new {ol,il})
	.Where(x=>x.ol.Item2 == "one" && x.il.Item2 == "Ett")
	.Select(x => (x.ol.Item2, x.il.Item2));




f2.Dump();
	