<Query Kind="Program" />

void Main()
{
	char[][] expected = new char[][]
	{
		new char[] {},
		new char[] {'a'},
		new char[] {'b'},
		new char[] {'a','b'},
		new char[] {'b','b'},
		new char[] {'a','b', 'b'},
	};

	var result = GenerateSubsets(new Char[] { 'a', 'b', 'b' }).ToArray();
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

	int subsetsEndIdx = 0;
	int subsetsStartIdx = 0;


	for (int setIdx = 0; setIdx < set.Length; setIdx++)
	{
		subsetsStartIdx =  (setIdx > 0 && set[setIdx].Equals(set[setIdx-1])) ? subsetsEndIdx : 0;
		subsetsEndIdx = subsets.Count;
		
		for (int subSetIdx = subsetsStartIdx; subSetIdx < subsetsEndIdx; subSetIdx++)
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
