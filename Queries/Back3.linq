<Query Kind="Program" />


	// Return true if there exists a sub-array of array[0..n] with given sum
	public static Boolean subsetSum(int[] A, int n, int sum)
	{
		// return true if sum becomes 0 (subset found)
		if (sum == 0)
		{
			return true;
		}

		// base case: no items left or sum becomes negative
		if (n < 0 || sum < 0)
		{
			return false;
		}

		// Case 1. include current item in the subset (A[n]) and recur
		// for remaining items (n - 1) with remaining sum (sum - A[n])
		Boolean include = subsetSum(A, n - 1, sum - A[n]);

		// Case 2. exclude current item n from subset and recur for
		// remaining items (n - 1)
		Boolean exclude = subsetSum(A, n - 1, sum);

		// return true if we can get subset by including or excluding the
		// current item
		return include || exclude;
	}

	// Subset Sum Problem
	public static void Main(String[] args)
	{
		// Input: set of items and a sum
		int[] A = { 7, 3, 2, 5, 8 };
		int sum = 14;

		if (subsetSum(A, A.Length - 1, sum))
		{
			Console.WriteLine("Yes");
		}
		else
		{
			Console.WriteLine("No");
		}
	}
