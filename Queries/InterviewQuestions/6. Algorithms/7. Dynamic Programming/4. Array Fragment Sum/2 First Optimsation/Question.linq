<Query Kind="Program" />

void Main()
{
	//MyExtensions.AreEqual(2, Fragments(new int[] { 1, 2, 1 },3));
	MyExtensions.AreEqual(4, Fragments(new int[] { 3,4,7,2,-3,1,4,2 },7));
}

// Question: Write a quadratic algorithm to solve to sum to k problem
public static int Fragments(int[] nums, int k) 
{
	int count =0;
	
	// one pass to initialize the sums
	int[] sums = new int[nums.Length+1];
	for (int i = 0; i < nums.Length; i++) sums[i+1] = sums[i] + nums[i];
	
	for (int i = 0; i < nums.Length; i++)
	{
		for(int j=i; j<nums.Length;j++)
		{
			if (sums[j+1]-sums[i] == k) count++;
		}
	}

	return count;
}