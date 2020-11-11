<Query Kind="Program" />

void Main()
{
	ex = 0;
	MyExtensions.AreEqual(4, Fragments(new int[] { 3, 4, 7, 2, -3, 1, 4, 2 }, 7));
	//MyExtensions.AreEqual(4, Fragments(new int[] { 1,2,3,4,5,6},0));
}


// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//
// Below is a very simple algorithm. Essentially we require to look at 
// all pairs of possible indices i,j to give us every subarray. This 
// is  n(n+1) / 2 = O(n^2)

// Space complexity is constant O(1)

public static int ex = 0;
public static int ex2 = 0;

public static int Fragments(int[] nums, int k) 
{
	int count = 0;
	for (int start = 0; start < nums.Length; start++)
	{
		for (int end = start; end < nums.Length; end++)
		{
			int sum = 0;
			for (int i = start; i <= end; i++)
			{
				sum += nums[i];
			}
				
			if (sum == k)
				count++; 	
		}
	}
	return count;
}


