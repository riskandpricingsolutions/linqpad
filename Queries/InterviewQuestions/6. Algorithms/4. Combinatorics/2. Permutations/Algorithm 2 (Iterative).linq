<Query Kind="Program" />

void Main()
{
	List<List<char>> expected = new List<List<char>>
	{
		new List<char>() {'b','a'},
		new List<char>() {'a','b'},
	};
	
	var result = GeneratePermutations<char>(new List<char>() { 'a','b' }).ToArray();
	MyExtensions.AreEqual(expected.Count, result.Length);

	Func<List<char>, List<char>, bool> compareResults = (b, c)
		=> ((IStructuralEquatable)(b.ToArray())).Equals(c.ToArray(), EqualityComparer<char>.Default);

	for (int i = 0; i < result.Length; i++)
	{
		var ex = expected[i];
		var re = result[i];
		var comp = compareResults(ex, re);
		MyExtensions.AreEqual(true, compareResults(ex, re));
	}
}


public IEnumerable<List<T>> GeneratePermutations<T>(List<T> S) where T : IComparable<T>
{
	var results = new List<List<T>>();
	var tempPerms = new List<List<T>>() { new List<T>() };

	for (int sIdx = 0; sIdx < S.Count(); sIdx++)
	{
		// The element we are adding to every temporary permutation 
		T el = S[sIdx];

		// The number of temporary permutations from the previous iteration
		int tempPermCount = tempPerms.Count();

		for (int i = 0; i < tempPermCount; i++)
		{
			var tempPerm = tempPerms[i];
			// We insert the element in every position of each
			// temporary perm
			for (int j = 0; j <= tempPerm.Count; j++)
			{
				var newTempPerm = new List<T>(tempPerm);
				newTempPerm.Insert(j, el);

				if (newTempPerm.Count() == S.Count)
					results.Add(newTempPerm);

				tempPerms.Add(newTempPerm);
			}

		}
		// Remove the previous level of temp objects.
		tempPerms.RemoveRange(0, tempPermCount);
	}
	return results;
}
	
