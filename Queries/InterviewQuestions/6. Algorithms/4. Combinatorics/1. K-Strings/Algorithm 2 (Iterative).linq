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

/// <summary>
/// Generate all k-strings over the given alphabet
/// </summary>
/// <typeparam name="T">The type of the elements in the set S</typeparam>
/// <param name="set">The elements of the set</param>
/// <param name="k">The length of the strings</param>
/// <returns>All strings of length k over the set S</returns>
public static IEnumerable<T[]> GenerateKStrings<T>( T[] S,int kStringLength)
{
	// There are n^k k-strings of a set of n items
	int numKStrings = (int)Math.Pow(S.Length,kStringLength);
	
	// Holds a k-digit number where each digit is of a base equal to 
	// the number of elements in the set S. So if there are two 
	// character in S,the digits in this number are binary.
	//
	// Each digit forms a index into S telling us exactly which
	// element of the S forms the character at the correspondong location
	// in the current kstring. So if we had k=3 and S{'a','b'} then
	// a seqIndices of {0,1,1} would correspond to the k-string of 
	// {'a','b','c'}
	int[] seqIndices = new int[kStringLength];

	for (int kStringNumber = 0; kStringNumber <= numKStrings-1; kStringNumber++)
	{
		// Generate the current k-string by using the elements
		// of seqIndices to index into S.
		T[] kString = new T[kStringLength];
		for (int i = 0; i < kStringLength; i++)
			kString[i] = S[seqIndices[i]];

		// Return the k-string.
		yield return kString;

		// In this algorithm we treat  the indices array as an
		// n-digit number where the base of each digit is determined by the
		// number of elements in S.
		// Moving to the next n-tuple is then a  case of incrementing the 
		// n-digit number held in seqIndices. To this we need to take care of 
		// overflow which is what the following loop condition does.		
		int digitIdxToIncrement = 0;
		while (digitIdxToIncrement <= seqIndices.Length - 2 && seqIndices[digitIdxToIncrement] == (S.Length-1))
		{
			seqIndices[digitIdxToIncrement] = 0;
			digitIdxToIncrement++;
		}

		seqIndices[digitIdxToIncrement]++;
	}
}


