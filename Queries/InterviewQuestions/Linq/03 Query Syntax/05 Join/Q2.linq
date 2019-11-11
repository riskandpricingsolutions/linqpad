<Query Kind="Program" />

void Main()
{
	// Question: Converr the following to fluent
	(int, string)[] outerSeq = { (1, "one"), (2, "two"), };
	(int, string)[] innerSeq = { (1, "Ensimmäinen"), (1, "Ett") };

	var q =
		from ol in outerSeq
		join il in innerSeq on ol.Item1 equals il.Item1
		where ol.Item2 == "one" && il.Item2 == "Ett"
		select (ol.Item2, il.Item2);
	q.Dump();


}