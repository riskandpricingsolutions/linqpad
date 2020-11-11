<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(2, Solution.Fragments(new int[] { 1, 2, 1 },3));
	MyExtensions.AreEqual(4, Solution.Fragments(new int[] { 3,4,7,2,-3,1,4,2 },7));
	
	MyExtensions.AreEqual(-1,Solution.Fragments(new int[100000],0));
	MyExtensions.AreEqual(4, Solution.Fragments(new int[] { 2,-2,3,0,4,-7 },0));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//


class Solution
{
	public static int Fragments(int[] nums, int k)
	{
		// We make use of the fundamental result that 
		//
		//   Sum[i..j] = Sum[0..j] - Sum[0..(i-1)]. 
		//
		// We are then interested in cases where 
		//
		//    Sum[0..j] - Sum[0..(i-1)] = k
		//
		// Rearraging we are looking for all values of i where
		// Sum[0..(i-1)] = Sum[0..j] - k

		// Each entry {sum->count} in the map holds the number of times 
		// a particular sum has occured
		Dictionary<int, int> valueCounts = new Dictionary<int, int>();
		valueCounts[0] = 1;

		// The number of fragments that sum to k
		int count = 0;

		// Hold the cumulative sum Sum[a[0]..a[j]] 
		int sum = 0;

		for (int j = 0; j < nums.Length; j++)
		{
			if (count > MAX_COUNT)
				return -1;

			// Sum now holds Sum[0..j]
			sum += nums[j];

			// At this moment in time the valueCounts arrays holds the
			// counts of different sums for all the indices up to j-1
			// (we have not added j yet)

			// Look up the number of times the sum[0..i] = sum-k for 
			// all values of i beteen 0 and j-1 and add this to the 
			// running count
			if (valueCounts.ContainsKey(sum - k))
				count += valueCounts[sum - k];

			// Update the map with the current sum value Sum[0..j]
			if (valueCounts.ContainsKey(sum)) valueCounts[sum] = valueCounts[sum] + 1;
			else valueCounts[sum] = 1;
		}


		return count;
	}
}

