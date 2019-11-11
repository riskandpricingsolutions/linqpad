<Query Kind="Program" />

void Main()
{
	// Question: Translate this to fluent syntax
	(int, string)[] outerSeq = { (1, "one"), (2, "two"), };
	(int, string)[] innerSeq = { (1, "Ensimmäinen"), (1, "Ett") };

	var q =
		from ol in outerSeq
		join il in innerSeq on ol.Item1 equals il.Item1
		into matches
		select (ol.Item2, matches);
	q.Dump();

	var f = outerSeq.
		GroupJoin(innerSeq,ol=>ol.Item1, il=>il.Item1,(ol,i)=>(ol.Item2,i));
	f.Dump();
	
		

}