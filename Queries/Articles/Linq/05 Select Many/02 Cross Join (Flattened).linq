<Query Kind="Statements" />

var inseq1 = new[] { (1, "one"), (2, "two"), };
var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

var f1 = inseq1.SelectMany( i => inseq2.Select(j => (i,j)));

f1.Dump();