<Query Kind="Statements" />

var inseq1 = new[] { (1, "one"), (2, "two"), };
var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


var q1 = from i in inseq1
		 select (i, from j in inseq2 select j);

var f1 = inseq1.Select(i => (i, inseq2.Select(j => j)));

q1.Dump();
f1.Dump();
