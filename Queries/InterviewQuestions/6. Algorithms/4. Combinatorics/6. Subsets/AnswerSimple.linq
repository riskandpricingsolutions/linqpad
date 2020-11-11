<Query Kind="Program" />

void Main()
{
	GenerateSubstrings(new Char[] { 'c', 'b', 'a' });
}


public static void GenerateSubstrings<T>(T[] set)
{
	var flags = new bool[set.Length];
	
	GenerateKStrings(flags, new bool[] {false,true},0, (perm) =>
	{
		var subString = new List<T>();
		
		for (int i = 0; i < perm.Length; i++)
		{
			if (perm[i]) subString.Add(set[i]);
		}
		
		System.Console.WriteLine(subString);
	});
}


public static void GenerateKStrings<T>(T[] kString, T[] set, int kStringIndex,
	Action<T[]> visit)
{
	if (kStringIndex == kString.Length)
	{
		visit(kString);
		return;
	}

	for (int setElementIndex = 0; setElementIndex < set.Length; setElementIndex++)
	{
		kString[kStringIndex] = set[setElementIndex];
		GenerateKStrings(kString, set, kStringIndex + 1, visit);
	}
}