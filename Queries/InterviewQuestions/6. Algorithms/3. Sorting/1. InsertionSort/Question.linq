<Query Kind="Program" />

void Main()
{
	int[] a = new[] { 4, 3, 2 };

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)InsertionSort(b)).Equals(c, EqualityComparer<int>.Default);

	MyExtensions.AreEqual(true, compareResults(new[] { 4, 3, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 4, 2, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 4, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 2, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 4, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }));
}

// Question: Implement InsertionSort
public T[] InsertionSort<T>(T[] a) where T : IComparable<T>
{
	for (int i = 1; i < a.Length; i++)
	{
		for(int j=i; j>0 && a[j].CompareTo(a[j-1]) <0;j--) Swap(a,j,j-1);
	}
	
	return a;
}


public void Swap<T>(T[] a, int i, int j)
{
	T temp = a[i];
	a[i] = a[j];
	a[j] = temp;
}