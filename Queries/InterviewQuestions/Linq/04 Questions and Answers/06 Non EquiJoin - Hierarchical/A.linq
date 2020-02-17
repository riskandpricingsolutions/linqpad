<Query Kind="Program" />

void Main()
{
	var s1 = new[] { 1, 2, 3};

	var q1 = from e1 in s1
			 select new {
			 	Left=e1,
				Right=from e2 in s1 
				where e2 != e1
				select e2
			 };
	q1.Dump();


	var f1 = s1.Select(e1 => new { Left = e1, Right = s1.Where(e2 => e1 != e2) });
	f1.Dump();
}