<Query Kind="Program" />

void Main()
{
	//	MyExtensions.AreEqual(0, FibonacciRecursive(0));
	//	MyExtensions.AreEqual(1, FibonacciRecursive(1));
	//	MyExtensions.AreEqual(1, FibonacciRecursive(2));
	//	MyExtensions.AreEqual(2, FibonacciRecursive(3));
	//	MyExtensions.AreEqual(3, FibonacciRecursive(4));

	//MyExtensions.AreEqual(2, PairCount(new[] {3,4,5,-2,3,4}));
	//PrintPairsManyTimes(new[] { 0, 1, 2 }, new[] {10,11,12});
	int[] a = new[] {0,1,2,3};
	ReverseArray(a);
}

// Question: Implement Recursive Binary Search
public static int FibonacciRecursive(int n)
{
	if (n == 0)
		return 0;
	if (n == 1)
		return 1;

	return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}


public static int Function1(int n)
{
	if (n == 1)
		return 1;

	return Function1(n - 1) + Function1(n - 1);
}

public static int Function2(int n)
{
	int res = 0;
	for (int i = 0; i < n; i++)
		res += i;

	for (int i = 0; i < n; i++)
		res += i;
		
	return res;
}

public static int PairCount(int[] a)
{
	int count = 0;
	for (int i = 0; i < a.Length; i++)
	{
		for (int j = i + 1; j < a.Length; j++)
		{
			if (a[i] == a[j]) count++;
		}
	}
	
	return count;
}

public static void PrintPairs(int[] a, int[] b)
{
	for (int i = 0; i < a.Length; i++)
	{
		for (int j = 0; j < b.Length; j++)
		{
			Console.WriteLine($"({a[i]},{b[j]})");
		}
	}
}

public static void PrintPairsManyTimes(int[] a, int[] b)
{
	for (int i = 0; i < a.Length; i++)
	{
		for (int j = 0; j < b.Length; j++)
		{
			for (int k = 0; k < 10; k++)
			{
				Console.WriteLine($"({a[i]},{b[j]})");
			}
		}
	}
}

public void ReverseArray(int[] a)
{
	for (int i = 0; i < a.Length/2; i++)
	{
		int temp = a[i];
		a[i] = a[a.Length-1-i];
		a[a.Length-1-i] = temp;
	}
}




