<Query Kind="Program" />

void Main()
{
	int[] a =  { 3, -1, -1, 10, -3, -2, 4 };
	Console.WriteLine(MaxSubarraySum(a, 0, 6));
}

public int MaxSubarraySum(int[] arr, int lo, int hi)
{
	// The recursion bottoms out here
	if (lo == hi) return arr[hi];
	
	// Divide
	int mid = (lo + hi ) / 2;	
	
	// Conquer
	int maxLeft = MaxSubarraySum(arr,lo,mid);
	int maxRight = MaxSubarraySum(arr,mid+1,hi);
	
	// Combine
	int maxCrossing = CalcMaxCrossingArray(arr,lo,mid,hi);
	return Math.Max(Math.Max(maxLeft,maxRight),maxCrossing);
}

public int CalcMaxCrossingArray(int[] arr, int lo,int mid, int hi)
{
	// Calculate the largest array fragment that 
	// in the sub-array arr[lo..mid] that also includes
	// arr[mid]
	int leftSum = int.MinValue;
	int sum = 0;
	for (int i = mid; i >= lo; i--)
	{
		sum += arr[i];
		if (sum > leftSum) leftSum = sum;
	}

	// Calculate the largest array fragment that 
	// in the sub-array arr[mid+1..hi] that also includes
	// arr[mid+1]
	int rightSum = int.MinValue;
	sum = 0;
	for (int j = mid + 1; j <= hi; j++)
	{
		sum += arr[j];
		if (sum > rightSum) rightSum = sum;
	}

	// The largest fragment that crosses the midpoint
	// is then the sum of left and right
	int maxCrossing = leftSum + rightSum;
	return maxCrossing;
}

