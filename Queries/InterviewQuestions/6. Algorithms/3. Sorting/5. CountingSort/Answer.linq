<Query Kind="Program" />

void Main()
{
	int[] a = new[] { 2,5,3,0,2,3,0,3 };

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)Sort(b,9)).Equals(c, EqualityComparer<int>.Default);

//	MyExtensions.AreEqual(true, compareResults(new[] { 4, 3, 2 }, new[] { 2, 3, 4 }));
//	MyExtensions.AreEqual(true, compareResults(new[] { 4, 2, 3 }, new[] { 2, 3, 4 }));
//	MyExtensions.AreEqual(true, compareResults(new[] { 3, 4, 2 }, new[] { 2, 3, 4 }));
//	MyExtensions.AreEqual(true, compareResults(new[] { 3, 2, 4 }, new[] { 2, 3, 4 }));
//	MyExtensions.AreEqual(true, compareResults(new[] { 2, 4, 3 }, new[] { 2, 3, 4 }));
//	MyExtensions.AreEqual(true, compareResults(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }));
//	MyExtensions.AreEqual(true, compareResults(new[] { 2, 8, 7, 1, 3, 5, 6, 4 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2,5,3,0,2,3,0,3}, new[] { 0,0,2,2,3,3,3,5 }));
}

// Question: Implement CountSort
public int[] Sort(int[] a, int k)
{
	// Elements in a must be an integer between 0 and k 
	// inclusive. 
	int[] counts = new int[k + 1];

	// Counts now holds the frequencies of each integer 
	// 0..k in the input array a
	for (int i = 0; i < a.Length; i++) counts[a[i]]++;

	// Each index i in counts now holds the number of 
	// elements in the input array with value <= i
	for (int i = 1; i < counts.Length; i++) counts[i] = counts[i] + counts[i - 1];

	// Create an array to hold the sorted results.
	int[] b = new int[a.Length];

	// Walk back through a from a[i] to a[0]
	for (int i = a.Length - 1; i >= 0; i--) {
	
		// The value in the source array
		int x = a[i];
		
		// The number of elements in the input
		// array whose value is less than or 
		// equal to x. 
		int n = counts[x];
		
		// If there are n elements less than 
		// or equal to x, then x must be the
		// nth element in the sorted list. In 
		// a 0 based array the nth element is at
		// index n-1		
		b[n-1] = x;
		
		// Decrement the number in counts[x]
		counts[x]=counts[x]-1;
	}

	return b;
}