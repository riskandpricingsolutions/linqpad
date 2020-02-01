<Query Kind="Program" />

void Main()
{
	int[] a = new[] { 4, 3, 2 };

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)QuickSort(b)).Equals(c, EqualityComparer<int>.Default);

	MyExtensions.AreEqual(true, compareResults(new[] { 4, 3, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 4, 2, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 4, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 2, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 4, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 8, 7, 1, 3, 5, 6, 4 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
}

// Question: Implement QuickSort
public T[] QuickSort<T>(T[] a) where T : IComparable<T> 
{
	QuickSort(a,0,a.Length-1);
	return a;
}

public void QuickSort<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
	if (lo < hi)
	{
		int pivotIdx = Partition(a,lo,hi);
		QuickSort(a,lo,pivotIdx-1);
		QuickSort(a,pivotIdx+1,hi);
	}
}

int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
	// Use the last element as the pivot
	T pivot = a[hi];
	int i=lo-1;
	for (int j = lo; j < hi; j++)
	{
		if (a[j].CompareTo(pivot) >0)
		{
			// Do nothing and let the greater than array increase by 1
		}
		else
		{
			i = i+1;
			Swap(a,i,j);
		}
	}
	Swap(a,hi,i+1);
	return i+1;
}

public void Swap<T>(T[] a, int i, int j)
{
	T temp = a[i];
	a[i] = a[j];
	a[j] = temp;
}