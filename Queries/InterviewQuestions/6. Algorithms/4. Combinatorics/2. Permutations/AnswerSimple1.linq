<Query Kind="Program" />

void Main()
{
	HashSet<int> initialPermutation = new HashSet<int>() { 1, 2, 3 };
	GeneratePermutations(initialPermutation, new int[initialPermutation.Count], 0, perm =>
	  {
	  	foreach (var element in perm)
		{
			Console.Write(element);
		}
		Console.WriteLine();
	  });
}

public void GeneratePermutations<T>(HashSet<T> set, T[] permutation, int permIdx, Action<T[]> visitFunc) where T : IComparable<T>
{
	if(permIdx == permutation.Length)
	{
		visitFunc(permutation);
		return;
	}
	
	foreach (var element in set)
	{
		permutation[permIdx] = element;
		var clonedSet = new HashSet<T>(set);
		clonedSet.Remove(element);
		GeneratePermutations(clonedSet,permutation,permIdx+1,visitFunc);
	}
}	
