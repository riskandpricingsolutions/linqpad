<Query Kind="Program" />

void Main()
{
	var s1 = new[] { (1, "one"), (2, "two"), };
	var s2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };
	

	
	IEnumerable<((int,string) leftEl,IEnumerable<(int,string)> rightMatches)>
		joined =
			s1.GroupJoin(s2, e1=>e1.Item1, e2=> e2.Item1, (e1,e2) => (e1,e2));
			
	joined.SelectMany(j => 
		j.rightMatches.DefaultIfEmpty(),
		
		(leftEl, rightMatch) => new {Left=leftEl.leftEl,Right=rightMatch.Item2})
		.Dump();
		
		
		
		
	
		
	
	
	

	
	
	

}