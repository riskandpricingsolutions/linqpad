<Query Kind="Program" />

void Main()
{
	char[][] expected = new char[9][]
	{
		new char[] {'a','a'},
		new char[] {'b','a'},
		new char[] {'c','a'},
		new char[] {'a','b'},
		new char[] {'b','b'},
		new char[] {'c','b'},
		new char[] {'a','c'},
		new char[] {'b','c'},
		new char[] {'c','c'},
	};

	var result = GenerateKStrings(new Char[] { 'a', 'b', 'c' },2).ToArray();
	MyExtensions.AreEqual(expected.Length,result.Length);

	Func<char[], char[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)(b)).Equals(c, EqualityComparer<char>.Default);
		
	for (int i = 0; i < result.Length; i++)
		MyExtensions.AreEqual(true, compareResults(expected[i], result[i]));
}

public static IEnumerable<T[]> GenerateKStrings<T>( T[] S,int kStringLength)
{
	int numKStrings = (int)Math.Pow(S.Length,kStringLength);
	List<T[]> kstrings = new List<T[]>(numKStrings);
	
	int[] kDigitNumber = new int[kStringLength];

	for (int i = 0; i <= numKStrings-1; i++)
	{
		kstrings.Add(BuildKString(kDigitNumber,S));
		IncrementNumber(kDigitNumber,S.Length);
	}
	
	return kstrings;
}

