<Query Kind="Program" />

void Main()
{
	var initialPermutation = new int[] { 1, 2, 3};
	GeneratePermutations(initialPermutation.Length, new int[] { 1, 2, 3}, perm =>
	  {
	  	foreach (var element in perm)
		{
			Console.Write(element);
		}
		Console.WriteLine();
	  });
}


public void GeneratePermutations(int N, int[] arr, Action<int[]> processPerm)
{
	if (N == 1)
	{
		processPerm(arr);
		return;
	}

	for (int c = 0; c < N; c++)
	{
		// For the current value of arr[N-1] 
		// lock it down and permutate the array 
		// arr[0..N-2]
		GeneratePermutations(N - 1, arr, processPerm);

		// If N is even permutate arr[N-1] with arr[c]
		if (N % 2 == 0)
			Swap(arr, c, N - 1);
		// If N is odd permutate arr[N-1] with arr[0]
		else
			Swap(arr, 0, N - 1);
	}
}

private void Swap<T>(T[] arr, int idx1, int idx2)
{
	T temp = arr[idx1];
	arr[idx1] = arr[idx2];
	arr[idx2] = temp;
}