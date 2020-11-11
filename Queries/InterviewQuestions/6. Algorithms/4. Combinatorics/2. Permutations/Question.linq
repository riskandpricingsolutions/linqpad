<Query Kind="Program" />

void Main()
{
	List<List<char>> expected = new List<List<char>>
	{
		new List<char>() {'b','a'},
		new List<char>() {'a','b'},
	};
	
	var result = GeneratePermutations<char>(new List<char>() { 'a','b','c','d', },4).ToArray();
	result.Count().Dump();
	result.Dump();
	MyExtensions.AreEqual(expected.Count, result.Length);

	Func<List<char>, List<char>, bool> compareResults = (b, c)
		=> ((IStructuralEquatable)(b.ToArray())).Equals(c.ToArray(), EqualityComparer<char>.Default);

	//for (int i = 0; i < result.Length; i++)
	//{
	//	var ex = expected[i];
	//	var re = result[i];
	//	var comp = compareResults(ex, re);
	//	MyExtensions.AreEqual(true, compareResults(ex, re));
	//}
}


public IEnumerable<List<T>> GeneratePermutations<T>(List<T> S, int l) where T : IComparable<T>
{
	var permutations = new List<List<T>>();
	var tempPermutations = new  List<List<T>>() {new List<T>()};
	
	foreach (var element in S)
	{
		int tempPermCount = tempPermutations.Count;
		
		for(int tempPermIdx=0; tempPermIdx < tempPermCount; tempPermIdx++)
		{
			var tempPerm = tempPermutations[tempPermIdx];
			
			for (int insertIdx =0; insertIdx <= tempPerm.Count; insertIdx++)
			{
				var newPerm = new List<T>(tempPerm);
				newPerm.Insert(insertIdx,element);
				tempPermutations.Add(newPerm);
				
				if (newPerm.Count == l)
				{
					permutations.Add(newPerm);
				}
			}
		}
	}
	
	return permutations;
}
	

