<Query Kind="Program" />

void Main()
{
	List<List<char>> expected = new List<List<char>>
	{
		new List<char>() {'a','b'},
		new List<char>() {'a','c'},
		new List<char>() {'b','a'},
		new List<char>() {'b','c'},
		new List<char>() {'c','a'},
		new List<char>() {'c','b'},
	};

	var result = GeneratePermutations<char>(new List<char>() { 'a', 'b', 'c' },2).ToArray();
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

public IEnumerable<List<T>> GeneratePermutations<T>(List<T> S, int k) where T : IComparable<T>
{
	var permutations = new List<List<T>>();
	GeneratePermutations(S, new List<T>(new T[k]), 0,
		permutation => permutations.Add(permutation));
	return permutations;
}

public void GeneratePermutations<T>(List<T> S, List<T> P, int idx,
	Action<List<T>> f) where T : IComparable<T>
{
	if (idx == P.Count())
	{
		f(P);
		return;
	}

	foreach (var element in S)
	{
		var permutation = new List<T>(P);
		permutation[idx] = element;

		var clonedSet = new List<T>(S);
		clonedSet.Remove(element);

		GeneratePermutations(clonedSet, permutation, idx + 1, f);
	}
}
