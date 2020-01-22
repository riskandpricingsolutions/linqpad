<Query Kind="Program" />

void Main()
{

	int[] a = {0,1,5,9};

	MyExtensions.AreEqual(2, SearchIterative(a,5));
	MyExtensions.AreEqual(~4, SearchIterative(a,10));
	MyExtensions.AreEqual(-1, SearchIterative(a,-1));
}

// Question: Implement Iterative Binary Search
public static int SearchIterative(int[] arr, int searchKey)
{
	if (arr == null) throw new ArgumentException();
	
	int hiIdx = arr.Length-1;
	int loIdx= 0;
	while (loIdx <= hiIdx)
	{
		int midIdx = loIdx + (hiIdx-loIdx) / 2;
		int comp = searchKey.CompareTo(arr[midIdx]);
		
		if (comp == 0) return midIdx;
		
		if (comp > 0) loIdx = midIdx+1;
		else hiIdx = midIdx -1;		
	}
	return ~loIdx;
}