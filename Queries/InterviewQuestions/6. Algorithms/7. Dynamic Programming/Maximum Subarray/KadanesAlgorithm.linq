<Query Kind="Program" />

void Main()
{
	int[] array = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };

	int sum = MaxSubarraySum(array);

	int[] a = { 3, -1, -1, 10, -3, -2, 4 };
	int sum2 = MaxSubarraySum(a);

}


// This is kadanes algorithm
public int MaxSubarraySum(int[] array)
{	
	var sums = new int[array.Length];

	int currentMax = array[0];
	int max = array[0];
	
	for (int i = 1; i < array.Length; i++)
	{
		currentMax = Math.Max( currentMax + array[i],array[i]);
		max = Math.Max(currentMax,max);
	}
	
	return max;
}


