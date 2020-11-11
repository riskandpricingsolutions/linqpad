<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(2, Fragments(new int[] { 1, 1, 1 },2));
	MyExtensions.AreEqual(4, Fragments(new int[] { 3,4,7,2,-3,1,4,2 },7));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
public static int Fragments(int[] a, int k) 
{
	int fragCount=0;
	
	// Map each running Sum[0..i] with the number of values of
	// i for which that value has occured.
	IDictionary<int,int> valueCounts = new Dictionary<int, int>();
	
	// Special case
	valueCounts[0] = 1;
	
	// Hold the total A[0..j]	
	int total =0;
	for (int l = 0; l < a.Length; l++)
	{
		int y = total += a[l];
		int x = y-k;
		
		// If Sum(a[0..i]) = x for n different values of i
		// we increment the fragment COUNT by n
		if (valueCounts.TryGetValue(x,out int n))
			fragCount = fragCount + n;
		

		// add Sum(a[0..i]) = y
		if (!valueCounts.TryGetValue(y,out int yCount )) yCount = 0;				
			valueCounts[y] = yCount+1;
	}
	
	return fragCount;
}