<Query Kind="Program" />

void Main()
{
	int[] array = new int[] { 3, -1, -1, 10, -3, -2, 4 };
	int sum = MaxSubarraySum(array);
	MyExtensions.AreEqual(11, sum);
}


// Question: Write a linear time best subarray algorithm
public int MaxSubarraySum(int[] array)
{	
	if (array == null) return 0;
	if (array.Length ==1) return array[0];
	
	int currentSum = array[0];
	int bestSum = array[0];
	
	for (int j = 1; j < array.Length; j++)
	{
		// The maxium subarray ending at index j 
		currentSum = Math.Max(currentSum+array[j],array[j]);
		
		// The maximum subarray anywhere in array[0..j]
		bestSum = Math.Max(currentSum,bestSum);
	}
	
	return bestSum;
}