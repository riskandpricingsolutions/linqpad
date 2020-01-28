<Query Kind="Program" />

void Main()
{
	int[] a = new[] { 4, 3, 2 };

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)MergeSort(b)).Equals(c, EqualityComparer<int>.Default);

	MyExtensions.AreEqual(true, compareResults(new[] { 4, 3, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 4, 2, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 4, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 2, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 4, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 8, 7, 1, 3, 5, 6, 4 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
}

// Question: Implement MergeSort
public T[] MergeSort<T>(T[] a) where T : IComparable<T> 
{
	MergeSort(a,0,a.Length-1);
	return a;
}

void MergeSort<T>(T[] a, int lo, int hi) where T : IComparable<T> 
{
	if (lo <hi)
	{
		int mid = (lo + hi) / 2;
		MergeSort(a,lo,mid);
		MergeSort(a,mid+1,hi);
		Merge(a,lo,mid,hi);
	}
}

void Merge<T>(T[] a, int lo, int mid, int hi) where T : IComparable<T>
{
	// Populate the left array
	T[] left = new T[mid - lo+1];
	for (int i = 0; i < left.Length; i++) left[i] = a[lo + i];

	// Populate the right array
	T[] right = new T[hi - mid];
	for (int i = 0; i < right.Length; i++) right[i] = a[mid +1+ i];

	// Start the merge
	int lIdx = 0, rIdx = 0;
	for (int i = lo; i <= hi; i++)
	{
		if (lIdx == left.Length) a[i] = right[rIdx++];
		else if (rIdx == right.Length) a[i] = left[lIdx++];
		else if (left[lIdx].CompareTo(right[rIdx]) < 0) a[i] = left[lIdx++];
		else a[i] = right[rIdx++];
	}
}

public void Swap<T>(T[] a, int i, int j)
{
	T temp = a[i];
	a[i] = a[j];
	a[j] = temp;
}