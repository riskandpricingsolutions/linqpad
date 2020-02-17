<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	// Inefficient
	s1.Select(e1 => new { Left = e1, Right = s2.Where(e2 => e1.Item1 == e2.Item1)})
	.Where(s => s.Right.Any())
	.Dump();

	// Inefficient
	(from e1 in s1
	select new { Left = e1, Right = from e2 in s2 where e1.Item1 == e2.Item1 select e2}
	into r
	where r.Right.Any()
	select r).Dump();
	
	// Efficient using group join
	s1.GroupJoin(s2,
		e1=>e1.Item1,
		e2 => e2.Item1,
		(e1, e2) => new { Left = e1, Right = e2})
		.Where(s => s.Right.Any());
		
	// Efficient using group join and query syntax
	(from e1 in s1
	join e2 in s2 on e1.Item1 equals e2.Item1
	into r
	select new  { Left = e1, Right = r}
	into c 
	where c.Right.Any()
	select c).Dump();
	
	// Efficient using lookup
	ILookup<int,(int,string)> lookup = s2.ToLookup(e2=> e2.Item1);
	s1.Select(e1 => new { Left = e1, Right = lookup[e1.Item1] })
	.Where(r => r.Right.Any()).Dump();

	(from e1 in s1
	select new { Left = e1, Right = lookup[e1.Item1]}
	into r
	where r.Right.Any()
	select r).Dump();
	
	
	
}