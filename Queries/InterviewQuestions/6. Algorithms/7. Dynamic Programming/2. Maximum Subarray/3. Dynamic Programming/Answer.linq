<Query Kind="Program" />

void Main()
{
	int[] a = { 3, -1, -1, 10, -3, -2, 4 };
	var sum2 = MaxSubarraySum(a);
}


// This is kadanes algorithm
public (int,int,int) MaxSubarraySum(int[] array)
{	
	var sums = new int[array.Length];

	// The current sum is the best sum
	// of any subarray that ends at 
	// ends at index ßj
	int currentSum = array[0];
	int startIdx = 0;
	int endIdx = 0;
	
	// The sum of the largest subarray 
	// anywhere in array[0..j] This is 
	// obviously the best value seen so 
	// far of all values of currentSum
	int bestSum = array[0];
	(int,int,int) bestArray = (bestSum,0,0);
	
	for (int i = 1; i < array.Length; i++)
	{
		// What is the best sum ending at index i ? It 
		// is one of two things. 
		//  1) The best sum ending at i-1 + array[i]
		//  2) A single element array[i]
		if (currentSum + array[i] > array[i])
		{
			currentSum =  currentSum + array[i];
			endIdx++;
		}
		else
		{
			startIdx = i;
			endIdx = i;
			currentSum = array[i];
		}
		
		
		// If the best sum ending at i is better than the best
		// sum seen anywhere in arr[0..i-1] we update the best sum
		if (currentSum > bestSum)
		{
			bestSum = currentSum;
			bestArray = (bestSum,startIdx,endIdx);
		}

	}
	
	return bestArray;
}