<Query Kind="Program" />

void Main()
{
	int[] array = new int[]{ 3, -1, -1, 10, -3, -2, 4 };
	
	int sum = MaxSubarraySum(array);
}


// This is the brute force solution to maximum subarray sum. 
// It is a cubic algorithm.
public int MaxSubarraySum(int[] array)
{
	int max = int.MinValue;
	
	for (int i = 0; i < array.Length; i++)
	{
		for (int j = i+1; j < array.Length; j++)
		{
			int sum = 0;
			for (int idx = i; idx <=j; idx++) sum += array[idx];

			if (sum > max)
				max = sum;
		}
	}
	 return max;
}


