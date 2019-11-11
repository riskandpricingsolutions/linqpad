<Query Kind="Program" />

void Main()
{
	// Question: Form an inner join of the following two 
	// sequences using fluent and query syntax
	(int, string)[] outerSeq = { (1, "one"), (2, "two"), };
	(int, string)[] innerSeq = { (1, "Ensimmäinen"), (1, "Ett") };


	var q1 =
		from ol in outerSeq
		join il in innerSeq on ol.Item1 equals il.Item1
		select (ol.Item2, il.Item2);
	q1.Dump();
	
	var f = outerSeq.Join(
		innerSeq, 
		ol=> ol.Item1,
		il => il.Item1,(o,i) => (o.Item2,i.Item2));
	f.Dump();

}