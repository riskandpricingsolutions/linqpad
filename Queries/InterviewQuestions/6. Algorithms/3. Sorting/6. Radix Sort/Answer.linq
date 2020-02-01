<Query Kind="Program" />

void Main()
{
	int[] a = new[] {
		
		329,
		457,
		839,
		436,
		720,
		355
	};

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)RadixSort(b,3)).Equals(c, EqualityComparer<int>.Default);

	MyExtensions.AreEqual(true, compareResults(a , new[] { 329,355,436,457,657,720,839 }));
}

// Question: Implement Radix Sort
public int[] RadixSort(int[] a, int digits) {

	for (int i = 0; i < digits; i++)
	{
		int e = i;
		a = Sort(a,10, x=>(int)((x / Math.Pow(10,e))) % 10);
	}
	
	return a;
}

public int[] Sort(int[] a, int k, Func<int,int> f)
{
	// Elements in a must be an integer between 0 and k 
	// inclusive. 
	int[] counts = new int[k + 1];

	// Counts now holds the frequencies of each integer 
	// 0..k in the input array a
	for (int i = 0; i < a.Length; i++) counts[f(a[i])]++;

	// Each index i in counts now holds the number of 
	// elements in the input array with value <= i
	for (int i = 1; i < counts.Length; i++) counts[i] = counts[i] + counts[i - 1];

	// Create an array to hold the sorted results.
	int[] b = new int[a.Length];

	// Walk back through a from a[i] to a[0]
	for (int i = a.Length - 1; i >= 0; i--)
	{

		// The value in the source array
		int x = f(a[i]);

		// The number of elements in the input
		// array whose value is less than or 
		// equal to x. 
		int n = counts[x];

		// If there are n elements less than 
		// or equal to x, then x must be the
		// nth element in the sorted list. In 
		// a 0 based array the nth element is at
		// index n-1		
		b[n - 1] = a[i];

		// Decrement the number in counts[x]
		counts[x] = counts[x] - 1;
	}

	return b;
}