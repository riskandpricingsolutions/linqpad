<Query Kind="Program" />

void Main()
{
	
	var l = new List<int> {1,2,3};
	
	foreach (var element in l)
	{
		Console.WriteLine(element);
	}
	

	using (var enumerator = l.GetEnumerator())
	{
		while (enumerator.MoveNext()) Console.WriteLine(enumerator.Current);
	}
}