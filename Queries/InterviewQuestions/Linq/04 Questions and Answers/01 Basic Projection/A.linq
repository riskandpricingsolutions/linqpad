<Query Kind="Program" />

void Main()
{
	var inseq1 = new [] {(1, "one"),(2, "two"),(3, "three")};	
	
	var f = inseq1.Select(i => i.Item1);
	f.Dump();
	
	var q = from n in inseq1 select n.Item1;
	q.Dump();
}