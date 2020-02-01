<Query Kind="Program" />

void Main()
{
	//MyExtensions.AreEqual(2, Fragments(new int[] { 1, 2, 1 },3));
	MyExtensions.AreEqual(4, Fragments(new int[] { 3,4,7,2,-3,1,4,2 },7));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//
// Time Complexity This is a cubic algorithm O(n^3)
// Space complexity is constant O(1)
public static int Fragments(int[] nums, int k) 
{
	int count = 0;
	for (int start = 0; start < nums.Length; start++)
	{
		for (int end = start + 1; end <= nums.Length; end++)
		{
			int sum = 0;
			for (int i = start; i < end; i++)
				sum += nums[i];
			if (sum == k)
				count++;
		}
	}
	return count;
}