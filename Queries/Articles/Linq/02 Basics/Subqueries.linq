<Query Kind="Program" />

void Main()
{
	string[] names = new[] {"Kenny", "John", "Bob", "Jimmy","Rob"};

	var enumerable1 = from n in names
					  where n.Length == names.Min(s => s.Length)
					  select n;

	var min = names.Min(s => s.Length);
	IEnumerable<string> enumerable2 = from n in names
									  where n.Length == min
									  select n;
}

// Define other methods and classes here
