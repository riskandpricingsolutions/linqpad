<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(1, Fragments(new int[] { 1, 1, 1 },2));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k.
public static int Fragments(int[] a, int k) 
{
	int[] sums = new int[k+1];
	sums[0] = 0;
	
	int count = 0;
	
	// Set up the counts.
	for (int i = 0; i < a.Length; i++) sums[a[i]+1]++;
	
	// Change counts elements less than or equal to
	for (int i = 1; i < sums.Length; i++)
	{
		sums[i] = sums[i]+sums[i-1];
	}
	
	return -1;
	
}