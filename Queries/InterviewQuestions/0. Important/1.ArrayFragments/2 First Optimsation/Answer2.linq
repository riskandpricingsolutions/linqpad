<Query Kind="Program" />

void Main()
{
	//MyExtensions.AreEqual(2, Fragments(new int[] { 1, 2, 1 },3));
	MyExtensions.AreEqual(4, Fragments(new int[] { 3,4,7,2,-3,1,4,2 },7));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//
// Time Complexity This is a quadratic algorithm O(n^2)
// Space complexity is constant O(n) to hold the cumulative sumes
public static int Fragments(int[] nums, int k) 
{
	int count = 0;
	int[] sum = new int[nums.Length + 1];
	sum[0] = 0;
	for (int i = 1; i <= nums.Length; i++)
		sum[i] = sum[i - 1] + nums[i - 1];
	for (int start = 0; start < nums.Length; start++)
	{
		for (int end = start + 1; end <= nums.Length; end++)
		{
			if (sum[end] - sum[start] == k)
				count++;
		}
	}
	return count;
}