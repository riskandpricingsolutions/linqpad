<Query Kind="Program" />

void Main()
{
	int[] a = new[] { 4, 3, 2 };

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)Sort(b,9)).Equals(c, EqualityComparer<int>.Default);

	MyExtensions.AreEqual(true, compareResults(new[] { 4, 3, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 4, 2, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 4, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 2, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 4, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 8, 7, 1, 3, 5, 6, 4 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
}

// Question: Implement CountSort
public int[] Sort(int[] a, int max) 
{
	int[] buckets = new int[max+1];
	
	for (int i = 0; i < a.Length; i++)
		buckets[a[i]]++;	
		
	int[] res = new int[a.Length];
	
	int resIdx=0;
	for (int i = 0; i < buckets.Length; i++)
	{
		while(buckets[i]-->0) res[resIdx++] = i;
	}
	
	return res;
}

