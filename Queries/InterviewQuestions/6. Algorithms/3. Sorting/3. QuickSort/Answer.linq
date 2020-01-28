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
	MyExtensions.AreEqual(true, compareResults(new[] { 2,8,7,1,3,5,6, 4 }, new[] { 1,2,3,4,5,6,7,8 }));
}

// Question: Implement QuickSort
public T[] Sort<T>(T[] a) where T : IComparable<T>
{
	return Sort(a,0,a.Length-1);
}

public T[] Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
{
	if (hi <= lo) return a;
	int j = Paritition(a,lo,hi);
	Sort(a,lo,j-1);
	Sort(a,j+1,hi);
	return a;
}

public int Paritition<T>(T[] A, int p, int r) where T : IComparable<T>
{
	// Select one element that will form the pivot. We select the 
	// last element in the slice we are Partitioning
	var pivot = A[r];
	
	// We maintain three slices of the array. 
	//	 A[p..i] has elements <= pivot
	// 	 A[i+1..j-1] has elements > pivot
	//   A[j..r-1] has elements that can be < or > pivot 
	int i = p-1;
	for (int j = p;j <= r-1; j++)
	{
		if (A[j].CompareTo(pivot) > 0)
		{
			// If the element at index j 
			// if greater than the pivot we 
			// do nothing other than loop around
			// thus increasing j and adding 1 element
			// to A[i+1..j-1]
		}
		else
		{
			// If the element at index j 
			// if less than or equal to the pivot
			// we increase i which brings in an 
			// element >= pivot into the less that 
			// bucket. But we fix the issue by 
			// exchanges the greater than element
			i++;
			Swap(A,i,j);
		}
	}
	
	// Switch the pivot with the first element greater than x
	// to maintain the loop invariant
	Swap(A,i+1,r);
	return i+1;
}

public void Swap<T>(T[]a, int i,int j)
{
	T temp = a[i];
	a[i] = a[j];
	a[j] = temp;
}