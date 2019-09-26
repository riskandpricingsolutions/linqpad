<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	int n = 3;
	int[] a = { 0, 0, 0 };
	int[] m = { 2, 2, 2 };


	string[][] threeByTwo = new string[3][]
	{
		new string[] {"a","b"},
		new string[] {"i","ii"},
		new string[] {"1","2"},
	};



	PrintAllPermutations(new int[] { 1, 2,2, 3 });
	PrintAllPermutations(new char[] { 'a', 'b','c' });
}

	
public void PrintAllPermutations<T>(T[] initialPermutation)where T : IComparable<T>
{
	foreach (var element in Permutate(initialPermutation))
	{
		foreach (var e in element)
		{
			Console.Write($"{e} ");
		}
		Console.WriteLine();
	}
}




public IEnumerable<T[]> Permutate<T>(T[] initialPermutation) where T : IComparable<T>
{
	// To be clear on our terminology. We assume the given elements 
	// array is sorted in lexicographical order. That is to say we
	// expect the elements inside initialPermutation to be in weakly 
	// increasing order from index 0 to index (initialPermutation.Length-1)
	// For example we might expect this situation
	// initialPermutation = {1, 2, 3} We assume this is the lowest value so 
	// index 0 would hold the most significant digit. 	
	T[] currentPermutation = initialPermutation;
	int   n = initialPermutation.Length;

	while (true)
	{
		// Take a shallow copy of the current permutation 
		// before we modify it
		currentPermutation = (T[])currentPermutation.Clone();

		// Return the current permutation
		yield return currentPermutation;
		
		// L2: Find the highest value of index j such that 
		// currentPermutation[j] <= currentPermutation[j + 1]. If we say that in 
		// permuation {1,2,3} that the value 1 is in the leftmost position and the value
		// 3 is in the rightmost position then we are finding the rightmost value of j
		// such that the value at position j is greater than the element at position j+1
		// If we are looking at permutaion {1,2,3} j is at index 1. 
		// 
		var pivot = n - 2;
		while (pivot >= 0 && currentPermutation[pivot].CompareTo(currentPermutation[pivot + 1]) >= 0) pivot--;

		// If there is no such j then we are at the highest permutation lexicographically speaking
		// so we end the function
		if (pivot == -1)
			break;

		//// L3: Find rightmost/highest index  l such that 
		// currentPermutation[pivot] <= currentPermutation[l], then exchange elements j and l:
		var l = n - 1;
		while (currentPermutation[pivot].CompareTo(currentPermutation[l]) >= 0) l -= 1;

		// swap
		Swap(currentPermutation,pivot,l);

		// L4: Reverse elements j+1 ... count-1:
		for(int lo = pivot+1, hi = n-1;lo<hi; lo++,hi--)
			Swap(currentPermutation,lo,hi);
	}
}

public void Swap<T>(T[] arr, int idx1, int idx2)
{
	T temp = arr[idx1];
	arr[idx1] = arr[idx2];
	arr[idx2] = temp;	
}


