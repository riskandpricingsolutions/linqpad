<Query Kind="Program" />

void Main()
{
	int[] a = new[] { 4, 3, 2 };

	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)Sort(b)).Equals(c, EqualityComparer<int>.Default);

	MyExtensions.AreEqual(true, compareResults(new[] { 4, 3, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 4, 2, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 4, 2 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 3, 2, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 4, 3 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 3, 4 }, new[] { 2, 3, 4 }));
	MyExtensions.AreEqual(true, compareResults(new[] { 2, 8, 7, 1, 3, 5, 6, 4 }, new[] { 1, 2, 3, 4, 5, 6, 7, 8 }));
}

// Question: Implement MergeSort
public T[] Sort<T>(T[] a) where T : IComparable<T> 
{
	Sort(a,0,a.Length-1);
	return a;
}

void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
	if (lo < hi)
	{
		int mid = (lo + hi / 2);
		Sort(a, lo, mid);
		Sort(a, mid + 1, hi);
		Merge(a, lo, mid, hi);
	}
}

void Merge<T>(T[] a, int low, int mid, int hi) where T : IComparable<T>
{
	// Left array is [low..mid]
	int leftElCount = mid-low+1;
	
	// Right arrays is [mid+1..hi]
	int rightElCount = hi-mid;
	
	T[] l = new T[leftElCount];
	T[] r = new T[rightElCount];
	
	// Populate left and right
	for (int i = 0; i < leftElCount; i++) l[i] = a[low+i];
	for (int i = 0; i < rightElCount; i++) r[i] = a[mid+1+i];
	
	int li=0, ri=0;
	for (int i = low; i <=hi; i++)
	{
		if (li==leftElCount) a[i] = r[ri++];
		else if (ri==rightElCount) a[i] = l[li++];
		else
		{
			if (l[li].CompareTo(r[ri]) <= 0)
				a[i] = l[li++];
			else
				a[i] = r[ri++];
		}
	}
}

public void Swap<T>(T[] a, int i, int j)
{
	T temp = a[i];
	a[i] = a[j];
	a[j] = temp;
}