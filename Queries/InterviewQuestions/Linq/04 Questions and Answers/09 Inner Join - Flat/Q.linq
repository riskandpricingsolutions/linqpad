<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
	

	s1.SelectMany(e1=> s2, (e1,e2) => new {Left=e1,Right=e2})
	.Where(r => r.Left.Item1 == r.Right.Item1)
	.Dump();
	
	

}