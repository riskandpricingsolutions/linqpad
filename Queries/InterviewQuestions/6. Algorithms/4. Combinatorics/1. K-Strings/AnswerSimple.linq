<Query Kind="Program" />

void Main()
{
	GenerateKStrings(new Char[2], new Char[] { 'a', 'b', 'c' }, 0, a =>
	 {
	 	for (int i = 0; i < a.Length; i++)
		 {
			 Console.Write(a[i] + " ");
		 }
		 Console.WriteLine();
	 });
}

public static void GenerateKStrings<T>(T[] kString, T[] set, int position,
	Action<T[]> visit)
{
	if (position == kString.Length)
	{
		visit(kString);
		return;
	}

	for (int kStringIdx = 0; kStringIdx < set.Length; kStringIdx++)
	{
		kString[position] = set[kStringIdx];
		GenerateKStrings(kString, set, position + 1, visit);
	}
}