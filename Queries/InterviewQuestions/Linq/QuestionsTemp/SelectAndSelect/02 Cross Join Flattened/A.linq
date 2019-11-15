<Query Kind="Program" />

void Main()
{
	var s1 = new[] { 'a', 'b', 'c' };
	var s2 = new[] { '1', '2', '3' };
	
	// Question: Write both fluent and query syntax queries that
	// 			 perform a flat cross product of s1 and s2
	var f = s1.SelectMany(e1 => s2,(e1,e2)=>(e1,e2));
	f.Dump();
	
	var q =
		from e1 in s1
		from e2 in s2
		select (e1,e2);
	q.Dump();
	
}