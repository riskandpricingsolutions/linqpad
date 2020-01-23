<Query Kind="Program" />

void Main()
{
	int[] r = ReverseArray(new[] { 1, 2, 3, 4});
	int[] r2 = ReverseArray(new[] { 1, 2, 3, });

}

// Question: Reverse an array
public static T[] ReverseArray<T>(T[] a)
{
	for (int i = 0; i < a.Length/2; i++)
	{
		var temp = a[i];
		a[i] = a[a.Length-i-1];
		a[a.Length-i-1] = temp;
	}

	return a;
}