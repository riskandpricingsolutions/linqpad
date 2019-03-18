<Query Kind="Statements" />

var inseq1 = new[] { (1, "one"), (2, "two"), };
var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

var f1 = inseq1.SelectMany( outer => 
	inseq2
	.Where(inner => outer.Item1 == inner.Item1)
	.Select(inner => (outer,inner)));
	
f1.Dump();