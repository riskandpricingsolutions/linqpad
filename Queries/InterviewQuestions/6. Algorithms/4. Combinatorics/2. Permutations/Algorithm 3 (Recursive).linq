<Query Kind="Program" />

void Main()
{
	List<List<char>> expected = new List<List<char>>
	{
		new List<char>() {'a','b'},
		new List<char>() {'b','a'},
	};
	
	var result = GeneratePermutations<char>(new List<char>() { 'a','b' }).ToArray();
	result.Dump();
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
	var permutations = new List<List<T>>();
	GeneratePermutations(S, 0,permutation => permutations.Add(new List<T>(permutation)));
	return permutations;
}

public static void GeneratePermutations<T>(List<T> S, int k, Action<List<T>> visit)
{
	if (k == S.Count - 1)
	{
		visit(S);
		return;
	}

	for (int i = k; i < S.Count; i++)
	{
		Swap(S, k, i);
		GeneratePermutations(S, k + 1, visit);
		Swap(S, k, i);
	}

}

private static void Swap<T>(List<T> arr, int idx1, int idx2)
{
	T temp = arr[idx1];
	arr[idx1] = arr[idx2];
	arr[idx2] = temp;
}

