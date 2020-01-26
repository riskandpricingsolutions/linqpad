<Query Kind="Program" />

void Main()
{
	int[] r = ReverseArray(new[] { 1, 2, 3, 4});

}

// Question: Reverse an array
public static T[] ReverseArray<T>(T[] a)
{
	T[] result = new T[a.Length];
	for (int i = 0; i < a.Length; i++)
	{
		result[result.Length-i-1] = a[i];
	}

	return result;
}