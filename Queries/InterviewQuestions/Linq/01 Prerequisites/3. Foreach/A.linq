<Query Kind="Program" />

void Main()
{
	var l = new List<int> {1,2,3};
	
	foreach (var element in l)
	{
		Console.WriteLine(element);
	}
	
	// Question: Show what the compiler generates when it sees a foreach
	using( IEnumerator<int> en = l.GetEnumerator())
	{
		while (en.MoveNext())
		{
			Console.WriteLine(en.Current);
		}
	}
}