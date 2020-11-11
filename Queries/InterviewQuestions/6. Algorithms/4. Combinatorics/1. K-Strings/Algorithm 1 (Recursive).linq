<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	List<List<char>> expected = new List<List<char>>
	{
		new List<char>(new [] {'a','a'}),
		new List<char>(new [] {'b','a'}),
		new List<char>(new [] {'c','a'}),
		new List<char>(new []  {'a','b'}),
		new List<char>(new []  {'b','b'}),
		new List<char>(new []  {'c','b'}),
		new List<char>(new []  {'a','c'}),
		new List<char>(new []  {'b','c'}),
		new List<char>(new []  {'c','c'}),
	};

	var result = GenerateKStrings(new List<Char>( new [] { 'a', 'b', 'c' }), 2).ToArray();
	MyExtensions.AreEqual(expected.Count, result.Length);

	Func<List<char>, List<char>, bool> compareResults = (b, c)
		=> ((IStructuralEquatable)(b.ToArray())).Equals(c.ToArray(), EqualityComparer<char>.Default);

	for (int i = 0; i < result.Length; i++)
		MyExtensions.AreEqual(true, compareResults(expected[i], result[i]));
}

public IEnumerable<List<T>> GenerateKStrings<T>( List<T> S, int k)
{
	var kStrings = new List<List<T>>();
	GenerateKStrings(S, new List<T>(new T[k]),0, k => kStrings.Add(k));
	return kStrings;
}

public static void GenerateKStrings<T>(List<T> kString, List<T> S, int stringIdx, Action<List<T>> visit)
{
	if (stringIdx == kString.Count)
	{
		visit(kString);
		return;
	}

	for (int setIdx = 0; setIdx < S.Count; setIdx++)
	{
		var clone = new List<T>(kString);
		clone[stringIdx] = S[setIdx];
		GenerateKStrings(kString, S, stringIdx + 1, visit);
	}
}