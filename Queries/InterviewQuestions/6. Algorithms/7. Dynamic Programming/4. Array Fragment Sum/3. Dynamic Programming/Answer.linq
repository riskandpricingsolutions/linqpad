<Query Kind="Program" />

void Main()
{
	//MyExtensions.AreEqual(2, Fragments(new int[] { 1, 2, 1 },3));
	MyExtensions.AreEqual(4, Fragments(new int[] { 3,4,7,2,-3,1,4,2 },7));
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k. 
//

public static int Fragments(int[] nums, int k) 
{
	// If Sum[0..i] = x and Sum[0..j] = y then Sum[i..j] = y-x
	// 
	// Working backwards if Sum[0..j] = y and there exists some i 
	// such that Sum[0..i] = y-k then Sum[i..j] = k
	
	// Each entry {sum->count} in the map holds the number of times 
	// Sum[0..i] = sum
	Dictionary< int, int > map = new Dictionary<int, int>();
	map[0] = 1;
	
	// The number of fragments that sum to k
	int count = 0;
	
	// Hold the cumulative sum Sum[a[0]..a[i]] 
	int sum = 0;
        
    for (int i = 0; i < nums.Length; i++)
	{
		sum += nums[i];
		
		// If Sum[a[0]..a[l]] = sum-k for sum index l
		// then the sum Sum[a[l]..a[i]] = k and we incremenet
		// count
		if (map.ContainsKey(sum - k))
			count += map[sum - k];
		
		// Add or increment the relevent map entry for sum
		if (map.ContainsKey(sum)) map[sum] = map[sum] + 1;
		else map[sum] = 1;
	}
	return count;
}