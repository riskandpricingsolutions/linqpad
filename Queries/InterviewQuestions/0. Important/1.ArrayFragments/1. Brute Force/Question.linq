<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(4, Fragments(new int[] { 3, 4, 7, 2, -3, 1, 4, 2 }, 7));
}


// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//
// Write a brute force greedy algorithm to solve this problem
public static int Fragments(int[] nums, int k) 
{
	int count = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		for	(int j=i ; j< nums.Length;j++)
		{
			int sum=0;
			for	(int idx=i; idx<=j;idx++)
			{
				sum += nums[idx];
			}
				
			if (sum==k) count++;
		}
	}
	return count;
}