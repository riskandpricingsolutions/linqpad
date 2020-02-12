<Query Kind="Program" />

void Main()
{
	int[] array = new int[]{ 3, -1, -1, 10, -3, -2, 4 };	
	int sum = MaxSubarraySum(array);
	MyExtensions.AreEqual(11,sum);
}


// Question: Implement a brute force MaxSubarray
public int MaxSubarraySum(int[] a)
{
	if (a == null) return 0;	
	if (a.Length==1) return a[0];
	int bestSum = int.MinValue;
	for (int i = 0; i < a.Length; i++)
	{
		for(int j=i+1; j<a.Length; j++)
		{
			int sum = 0;
			for( int k=i; k<=j;k++ ) sum += a[k];
			bestSum = Math.Max(sum,bestSum);
		}
		

	}
	
	return bestSum;
}