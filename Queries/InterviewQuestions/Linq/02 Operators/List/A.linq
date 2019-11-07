<Query Kind="Program" />

void Main()
{
	//BuiltInAgregations();
	//CustomAggregations();
	To();
}


public void BuiltInAgregations()
{
	var s = new[] { 4, 2, 6 };
	// Use LINQ to print number of elements in s
	s.Count().Dump(); 
	
	// Use LINQ to print number of odd elements in s
	s.Count(x=> x%2==1).Dump(); // 1

	// Use LINQ to print minimum value in s
	s.Min().Dump();
	
	// Use LINQ to print double the minimum value in s
	s.Min(x=>x*2).Dump(); 

	// Use LINQ to print the sum of all values in s
	s.Sum().Dump(); // 12
	
	// Use LINQ to print twice the sum of the values in s
	s.Sum(x => x * 2 ).Dump(); 
}

public void CustomAggregations()
{
	var s = new[] { 4, 2, 6 };
	
	// Use aggregate to count the elements in s
	s.Aggregate ( (a,e) => a+1).Dump();
	
	// Use aggregate to return the min value in s
	s.Aggregate (int.MaxValue, (a,e) => e< a ? e : a ).Dump();
	
	// Use aggregate to return the max value in s
	s.Aggregate (int.MinValue, (a,e) => e> a ? e : a ).Dump();
	
	// Use aggregate to return the arithmetic mean value in s
	s.Aggregate ((0,0),(a,e)=> (a.Item1+e,++a.Item2),a=> a.Item1/a.Item2 ).Dump();
}

public void To()
{
	var s = new[] {(1,"one"), (2,"two")};
	
	// Form a dictionary of int => (int,string) using s an input
	s.ToDictionary(i => i.Item1 ).Dump();

	// Form a dictionary of int => (int,string) using s an input
	s.ToDictionary(i => i.Item1, i=>i.Item2).Dump();
	
	// Generate lookup int to string 
	var t = new[] {
		new {Id=1, Name="Kenny"},
		new {Id=1, Name="David"},
		new {Id=2, Name="John"},
		new {Id=2, Name="Brian"}
	};
	
	var lookup =t.ToLookup(i => i.Id, i=>i.Name);
	lookup.Dump();

	
	
	
	
	
	
	
}