<Query Kind="Program" />

void Main()
{
	var s1 = new[] { 'a', 'b', 'c' };
	var s2 = new[] { '1', '2', '3' };
	
	// Question: Write both fluent and query syntax queries that
	// 			 perform a hierarchical cross product of s1 and s2
	var f = s1.Select(e => (e,s2));
	f.Dump();
	
	var q =from e in s1
	select (e,s2);
	q.Dump();
}

// Define other methods and classes here
