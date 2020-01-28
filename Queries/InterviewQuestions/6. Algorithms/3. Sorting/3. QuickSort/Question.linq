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
	if (hi>lo)
	{
		int partition = Partition(a,lo,hi);
		QuickSort(a,lo,partition-1);
		QuickSort(a,partition+1,hi);
	}
}

int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
	T pivot = a[hi];
	
	int i=lo-1;
	for(int j=lo;j<hi;j++)
	{
		// The element being compared is greater than the pivot
		// simply move the upper bound of the greater section which is 
		// maintained by j
		if (a[j].CompareTo(pivot)>0)
		{
		}
		else
		{
			// The element being compared is leq the pivot. Move the 
			// index  of smaller items (i) by one which temporarily
			// includes it in the smaller section 
			i++;
			
			// Now we swap i and j so put the bigger element in the
			// big bucket and the small one in the small bucket
			Swap(a,i,j);
		}
	}
	
	// Finally we put the pivot in its place. We put it in the 
	// first location above the small bucket meaning we know
	// we swap it with a bigger element
	Swap(a,i+1,hi);
	
	return i+1;
}

public void Swap<T>(T[] a, int i, int j)
{
	T temp = a[i];
	a[i] = a[j];
	a[j] = temp;
}