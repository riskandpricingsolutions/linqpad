<Query Kind="Program" />

void Main()
{
	CustomAggregations();
}


public void BuiltInAgregations()
{
	
	new[] {2,4,6}.Count().Dump(); // 2
	new[] {1,2,3}.Count(x=> x%2==0).Dump(); // 1

	new[] { 4, 2, 6 }.Min().Dump(); // 2
	new[] { 4, 2, 6 }.Min(x=>x*10).Dump(); // 20, projection before min

	new[] { 2, 4, 6 }.Sum().Dump(); // 12
	new[] { 2,4,6 }.Sum(x => x * 2 ).Dump(); // 24, projection before sum
}

public void CustomAggregations()
{
	// Write Count using aggregate
	new[] {1,2,3 }.Aggregate ( (a,e) => a+1).Dump();
	
	// Write Min using aggregate
	new[] {1,2,3 }.Aggregate (int.MaxValue, (a,e) => e< a ? e : a ).Dump();
	
	// Max using aggregate
	new[] {1,2,3 }.Aggregate (int.MinValue, (a,e) => e> a ? e : a ).Dump();
	
	// Average using aggregate
	new[] {1,2,3 }.Aggregate ((0,0),(a,e)=> (a.Item1+e,++a.Item2),a=> a.Item1/a.Item2 ).Dump();

	
}