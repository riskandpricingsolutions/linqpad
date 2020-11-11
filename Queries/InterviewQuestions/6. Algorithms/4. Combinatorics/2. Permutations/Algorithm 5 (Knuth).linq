<Query Kind="Program" />

void Main()
{
	List<List<char>> expected = new List<List<char>>
	{
		new List<char>() {'a','a'},
		new List<char>() {'a','b'},
	};

	var result = GeneratePermutations<char>(new List<char>() { 'a', 'b' }).ToArray();
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


public IEnumerable<List<T>> GeneratePermutations<T>(List<T> initialPermutation) where T : IComparable<T>
{
	// To be clear on our terminology. We assume the given initialPermutation 
	// is the permutation with lowest lexicographical value. As such we expect
	// a[0] <= a[1] <= ... <= a[n-1] Put another way we expect the values in the
	// permutation to be in weakly increasing (non-decreasing) order from index 0 
	// through to index n-1. For the purposes of this method we will refer to the element
	// with the highest value of j as the rightmost element and the value with the lowest value
	// of j as the left most element
	//
	//     Left/MSB  {1,2,3,4} Right/LSB
	//     Index     {0,1,2,3} 
	//  
	// For example initialPermutation might hold {1,2,3,4} and we assume index 0 
	// hold the 'most significant digit' and index 3 holds the 'least significant digit'
	List<T> a = initialPermutation;
	int n = initialPermutation.Count;

	while (true)
	{
		// Take a shallow copy of the current permutation and yield return
		// it before we make any modifications
		List<T> b = new List<T>(a);
		yield return b;

		// Find the value of index j such that we have visited all permutations of
		// a[0],a[1],...a[j] We obtain this by finding the highest index j such that
		// a[j] < a[j+1]
		//
		// Example: If we say that a={1,2,3} then we are finding the highest value of j
		// such that the value at position j is greater than the element at position j+1 In 
		// our case that occurs at j=1
		//
		// {1,2,3} 
		//    |
		//    j
		var j = n - 2;
		while (j >= 0 && a[j].CompareTo(a[j + 1]) >= 0) j--;

		// If there is no such j then we are already on the lexicographically highest and 
		// therefore the last permutation. In this case we break out of the while loop
		// thereby terminating the method
		if (j == -1)
			break;

		// If we have visited all permutations {a[0],...[aj]} then the way to move to the next
		// permutation lexicographically is to swap a[j] with the smallest element greater than
		// a[j] whose index is greater than j. As the elements to the right of a[j] are sorted in 
		// decreasing order from left to right, the first element greater than a[j] when walking from right
		// to left is the smallest value greater than a[j]
		var l = n - 1;
		while (a[j].CompareTo(a[l]) >= 0) l -= 1;

		// swap
		Swap(a, j, l);


		// At the moment, everything to the right of a[j] is sorted in decreasing order 
		// As we have just increased a[j] we need to reverse a[j+1]..a[n] so we have the next
		// lexicographical element
		for (int lo = j + 1, hi = n - 1; lo < hi; lo++, hi--)
			Swap(a, lo, hi);
	}
}

private void Swap<T>(List<T> arr, int idx1, int idx2)
{
	T temp = arr[idx1];
	arr[idx1] = arr[idx2];
	arr[idx2] = temp;
}


