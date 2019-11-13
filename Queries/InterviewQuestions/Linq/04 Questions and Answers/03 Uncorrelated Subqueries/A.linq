<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

	// Inefficient because the inner query iterated once per outer element
	var f1 = s1.Select(e1 => new { Left = e1, Right = s2.Where(e2 => e1.Item1 == e2.Item1)});
	f1.Dump();
	
	// Inefficient because the inner query iterated once per outer element
	var q1 = from e1 in s1
			select new {Left=e1, Right = from e2 in s2 where e1.Item1 == e2.Item1 select e2 };
	q1.Dump();
	
	// Effcient because internally Group Join uses a lookup
	var f2 = s1.GroupJoin(s2,e1=>e1.Item1, e2=> e2.Item1,(e1,c) => new {Left=e1, Right =c });
	f2.Dump();
	
	// Effcient because internally Group Join uses a lookup
	var q2 = from e1 in s1 
	join e2 in s2 on e1.Item1 equals e2.Item1
	into collection
	select new {Left=e1, Right =collection };
	q2.Dump();
	
	// Efficient - uses lookup
	var lookup = s2.ToLookup(e2 => e2.Item1, e2=>e2);
	var f3 = s1.Select(e1 => new {Left=e1, Right=lookup[e1.Item1]});
	f3.Dump();

	// Efficient - uses lookup
	var q3 =from e1 in s1
	select new {Left=e1, Right=lookup[e1.Item1]};
	q3.Dump();
	
}