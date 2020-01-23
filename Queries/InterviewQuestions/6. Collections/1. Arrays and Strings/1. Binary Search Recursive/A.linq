<Query Kind="Program" />

void Main()
{

	int[] a = {0,1,5,9};

	MyExtensions.AreEqual(2, SearchRecursive(a,5));
	MyExtensions.AreEqual(~4, SearchRecursive(a,10));
	MyExtensions.AreEqual(-1, SearchRecursive(a,-1));
}

// Question: Implement Recursive Binary Search
public static int SearchRecursive(int[] arr, int searchKey)
{
	if (arr == null) throw new ArgumentNullException();

	return SearchRecursive(arr, 0, arr.Length - 1, searchKey);
}

private static int SearchRecursive(int[] arr, int lo, int hi, int searchKey)
{
	// The search key is not in the array. Return the complement of the index
	// at which it should be inserted.
	if (lo > hi) return ~lo;

	int median = lo + (hi - lo) / 2;
	int comparisonResult = arr[median].CompareTo(searchKey); ;

	//  a direct hit
	if (comparisonResult == 0) return median;

	return comparisonResult < 0
		? SearchRecursive(arr, median + 1, hi, searchKey)
		: SearchRecursive(arr, lo, median - 1, searchKey);
}

