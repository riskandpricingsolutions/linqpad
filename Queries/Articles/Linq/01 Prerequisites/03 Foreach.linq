<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// the simplest consumer of enumerators via enumerables is the foreach loop
	var sequence = new List<int>( new [] {1,2,3});
	
	foreach (var element in sequence)
	{
		WriteLine(element);
	}
	
	using (IEnumerator<int> en = sequence.GetEnumerator())
	{
		while (en.MoveNext())
			WriteLine(en.Current);
	}
}

