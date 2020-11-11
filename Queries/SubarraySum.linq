<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(2, Solution.SubarraySum(new int[] { 1, 2, 1 },3));
	MyExtensions.AreEqual(4, Solution.SubarraySum(new int[] { 3,4,7,2,-3,1,4,2 },7));
	
	MyExtensions.AreEqual(-1,Solution.SubarraySum(new int[100000],0));
	MyExtensions.AreEqual(4, Solution.SubarraySum(new int[] { 2,-2,3,0,4,-7 },0));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//


class Solution
{
	public static int SubarraySum(int[] array, int target)
	{
		int total = 0;
		
		Dictionary<int, int> cache = new Dictionary<int, int>() {}
		cache[0] = 1;
		
		int runningSum = 0;

		for (int j = 0; j < array.Length; j++)
		{
			runningSum += array[j];

			if (cache.ContainsKey(runningSum - target))
				total += cache[runningSum - target];

			if (cache.ContainsKey(runningSum)) cache[runningSum] = cache[runningSum] + 1;
			else cache[runningSum] = 1;
		}

		return total;
	}
}

