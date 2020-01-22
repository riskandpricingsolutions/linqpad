<Query Kind="Program" />

void Main()
{

	int[] a = {0,1,5,9};

	MyExtensions.AreEqual(2, SearchRecursive(a,5));
	MyExtensions.AreEqual(~4, SearchRecursive(a,10));
	MyExtensions.AreEqual(-1, SearchRecursive(a,-1));
}

// Question: Implement Recursive Binary Search
public static int SearchRecursive(int[] arr, int searchKey) => throw new NotImplementedException();