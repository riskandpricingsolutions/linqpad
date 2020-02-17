<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


	// Inefficient
	var f1 = s1
		.Select(e1 => new {Left = e1, Right=s2.Where(e2=>e1.Item1 == e2.Item1)})
		.Where(s => s.Right.Any());
	f1.Dump();
		

	// Inefficient
	var q1 = 	from e1 in s1 
				select new {Left = e1, Right=s2.Where(e2=>e1.Item1 == e2.Item1)}
				into r
				where r.Right.Any()
				select r;
	q1.Dump();

	// GroupJoin
	var f2 =s1
		.GroupJoin(s2, e1=>e1.Item1, e2=>e2.Item1,(e,si)=>new {Left = e, Right=si})
		.Where(s => s.Right.Any());
			
	f2.Dump();
	
	// Group Join
	var q2 = 	from e1 in s1
				join e2 in s2 on e1.Item1 equals e2.Item1
				into c
				select new {Left = e1, Right=c}
				into d 
				where d.Right.Any()
				select d;
	q2.Dump();

	// Efficient using select and lookup
	var lookup = s2.ToLookup(s => s.Item1);
	var f3 = s1
	.Select(e1 => new { Left = e1, Right = lookup[e1.Item1] })
	.Where(s => s.Right.Any());
	f3.Dump();

	// Efficient using select and lookup
	var q3 = from e1 in s1
			 select new { Left = e1, Right = lookup[e1.Item1] }
			into r
			 where r.Right.Any()
			 select r;
	q3.Dump();

}