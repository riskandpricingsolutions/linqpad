<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


	// Inefficient 1
	s1.SelectMany(s => s2, (e1, e2) => new { Left = e1, Right = e2})
	.Where(s => s.Left.Item1 == s.Right.Item1)
	.Dump();
	
	// Inefficient select many
	(from e1 in s1 
	from e2 in s2
	where e1.Item1 == e2.Item1
	select new { Left = e1, Right = e2})
	.Dump();
	
	//Efficient Join
	s1.Join(s2, e1=>e1.Item1, e2 => e2.Item1, (e1,e2) => new {e1,e2})
	.Dump();
	
	// Efficient Join
	(from e1 in s1
	join e2 in s2 on e1.Item1 equals e2.Item1
	select new { Left = e1, Right = e2})
	.Dump();
	
	// Efficient SelectMany and lookup
	ILookup<int,(int,string)> lookup = s2.ToLookup(e2=>e2.Item1);
	s1.SelectMany(e1 => lookup[e1.Item1],(e1, e2) => new { Left = e1, Right = e2})
	.Dump();
	
	(from e1 in s1
	from e2 in lookup[e1.Item1]
	select new { Left = e1, Right = e2 })
	.Dump();



}