<Query Kind="Program" />

void Main()
{
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee"};
	
	var f = inseq1.Select(i => i.Split());
	f.Dump();
	
	var q =from n in inseq1 select n.Split();
	q.Dump();
	
}