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
public static IEnumerable<T[]> GenerateKStrings<T>( T[] set,int kStringLength)
{
	// Holds a  k digit number where each digit is of base equal to 
	// the number of elements in S. So if there are two character in S
	// the digits in this number are binary.
	//
	// Each digit forms a index into the set S telling us exactly which
	// element of S forms the character at the correspondong location
	// in the current kstring. So if we had k=3 and S{'a','b'} then
	// a seqIndices of {0,1,1} would correspond to the k-string of 
	// {'a','b','c'}
	int[] seqIndices = new int[kStringLength];

	while (true)
	{
		// Process the current value. Convert indices to elements
		T[] kString = new T[kStringLength];
		for (int i = 0; i < kStringLength; i++)
			kString[i] = set[seqIndices[i]];

		// Return the n-tuple
		yield return kString;

		// In this algorithm we treat  the indices array as a
		// n digit number where the base of each digit is determined by the
		// number of elements in that digits corresponding event array from events. 
		// Moving to the next n-tuple is then a  case of incrementing the 
		// n-digit number held in seqIndices. To this we need to take care of 
		// overflow which is what the following loop condition does.		
		int j = 0;
		while (j < kStringLength && seqIndices[j] == set.Length - 1)
		{
			seqIndices[j] = 0;
			j++;
		}

		// If j is greater than the last element in seqIndices we have overflowed
		// off the end of seqIndices. In this case the work of this algorithm is done
		// and we have visited all n-permutations
		if (j == kStringLength)
			break;

		seqIndices[j]++;
	}
}