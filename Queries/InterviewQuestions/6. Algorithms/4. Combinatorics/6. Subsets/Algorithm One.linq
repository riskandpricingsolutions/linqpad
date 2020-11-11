<Query Kind="Program" />

void Main()
{
	char[][] expected = new char[][]
	{
		new char[] {},
		new char[] {'a'},
		new char[] {'b'},
		new char[] {'a','b'},
		new char[] {'c'},
		new char[] {'a','c'},
		new char[] {'b','c'},
		new char[] {'a','b', 'c'}
	};

	var result = GenerateSubsets(new Char[] { 'a', 'b', 'c' }).ToArray();
	MyExtensions.AreEqual(expected.Length,result.Length);

	Func<char[], char[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)(b)).Equals(c, EqualityComparer<char>.Default);
		
	for (int i = 0; i < result.Length; i++)
		MyExtensions.AreEqual(true, compareResults(expected[i], result[i]));
}

public List<T[]> GenerateSubsets<T>(T[] set)
{
	List<T[]> subsets = new List<T[]>();
	
	// Seed the subsets collection with the empty set
	subsets.Add(new T[0]);
	
	for (int setIdx = 0; setIdx < set.Length; setIdx++)
	{
		// We only want to walk the elements that existed in the
		// subsets collection before this iteration. For this reason 
		// we need to store the count and not check it on each iteration
		// of the inner loop (where we are adding to the list).
		int currentSubsetCount = subsets.Count;
		
		for (int subSetIdx = 0; subSetIdx < currentSubsetCount; subSetIdx++)
		{
			// Copy the subset at index subSetIdx and add the 
			// a new element
			var sourceSubset = subsets[subSetIdx];
			var newSubset = new T[sourceSubset.Length+1];
			Array.Copy(sourceSubset,newSubset,sourceSubset.Length);
			newSubset[sourceSubset.Length] = set[setIdx];
			
			// Add the new subset to the subsets collection
			subsets.Add(newSubset);
		}
	}
	
	return subsets;
}
