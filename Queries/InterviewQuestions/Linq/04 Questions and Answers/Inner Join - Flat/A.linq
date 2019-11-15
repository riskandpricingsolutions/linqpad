<Query Kind="Statements" />

var s1 = new[] { (1, "one"), (2, "two"), };
var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };


// Fluent Syntax - Inefficent Group Join
var f1 = s1
		.SelectMany(e1 => s2, (e1, e2) => new { e1,e2})
		.Where(r => r.e1.Item1 == r.e2.Item1)
		.Select(r => new {Left=r.e1, Right=r.e2});

// Query Syntax - Inefficent Group Join
var q1 = from e1 in s1
		 from e2 in s2 
		 where e1.Item1 == e2.Item1
		 select new {Left=e1, Right=e2};
//q1.Dump();

// Fluent - Efficient, using Join which internally uses a lookup
var f2 = s1.Join(s2, e1=>e1.Item1, e2=>e2.Item1, (e1,e2)=>new {Left=e1, Right=e2});

// Query - Efficient, using Join which internally uses a lookup
var q2 = from e1 in s1
		 join e2 in s2 on e1.Item1 equals e2.Item1
		 select new {Left=e1, Right=e2};

// Fluent - Efficient using SelectMany and Lookup
var lookup = s2.ToLookup(e1 => e1.Item1);
var f3 = s1
		.SelectMany(e1 => lookup[e1.Item1], (e1, e2) => new { e1, e2 })
		.Select(r => new { Left = r.e1, Right = r.e2 });

// Query Syntax - Efficient using SelectMany and lookup
var q3 = from e1 in s1
		 from e2 in lookup[e1.Item1]
		 select new { Left = e1, Right = e2 };