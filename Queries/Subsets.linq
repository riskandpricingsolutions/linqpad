<Query Kind="Program" />

void Main()
{
	var res = GenerateSubsets(new char[] {'A','B','C'});
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
