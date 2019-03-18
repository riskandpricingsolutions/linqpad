<Query Kind="Statements" />

var inseq1 = new [] {(1, "one"),(2, "two"),(3, "three")};

var outseq1 = inseq1.Select(i => i.Item1);

var outseq2 = 
	from i in inseq1 
	select i.Item1;

outseq1.Dump();
outseq2.Dump();