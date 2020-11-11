<Query Kind="Program" />

//#load "..\..\6. Collections\5. Priority Queues\PriorityQueue"

void Main()
{
	Func<int, int, int> a = (x, y) => y.CompareTo(x);

	a(4, 5).Dump();
	a(5, 4).Dump();

	MyExtensions.AreEqual(0, Solution.CalculateOptimumMergeCost(new int[] {}));
	MyExtensions.AreEqual(0, Solution.CalculateOptimumMergeCost(new int[] {100}));
	MyExtensions.AreEqual(2, Solution.CalculateOptimumMergeCost(new int[] {1,1}));
	MyExtensions.AreEqual(5, Solution.CalculateOptimumMergeCost(new int[] {1,1,1}));
	MyExtensions.AreEqual(8, Solution.CalculateOptimumMergeCost(new int[] {1,1,1,1}));
	MyExtensions.AreEqual(12, Solution.CalculateOptimumMergeCost(new int[] {1,1,1,1,1}));

	MyExtensions.AreEqual(68, Solution.CalculateOptimumMergeCost(new int[] { 2, 3, 4, 5, 6, 7 }));
	MyExtensions.AreEqual(1700, Solution.CalculateOptimumMergeCost(new int[] { 100, 250, 1000 }));
	MyExtensions.AreEqual(19, Solution.CalculateOptimumMergeCost(new int[] { 3, 2, 4, 1 }));
	MyExtensions.AreEqual(14, Solution.CalculateOptimumMergeCost(new int[] { 2, 3, 4 }));
	MyExtensions.AreEqual(205, Solution.CalculateOptimumMergeCost(new int[] { 20, 30, 10, 5, 30 }));
}

class Solution
{
	public static int CalculateOptimumMergeCost(int[] files)
	{
		PriorityQueue<int> pq
			= new PriorityQueue<int>((x, y) => y.CompareTo(x), files.Length);

		for (int i = 0; i < files.Length; i++)
			pq.Add(files[i]);

		// Keep track of the total cost
		int totalCost = 0;

		while (pq.Count > 1)
		{
			// Remove the two smallest file sizes from the 
			// the heap and keep a track of their sizes
			int smallestFileSize = pq.Dequeue();
			int secondSmallestFileSize = pq.Dequeue();

			// Merge them into a new file
			int mergedFileSize = smallestFileSize + secondSmallestFileSize;

			// Add the cost of the merge to the running count
			totalCost += mergedFileSize;

			// Push the new file on the heap ready for the next
			// round of merging
			pq.Add(mergedFileSize);
		}

		return totalCost;
	}
}

/// <summary>
/// PriorityQueue implemented using a heap-ordered binary tree. 
/// </summary>
public class PriorityQueue<T>
{
	private T[] _storage;
	private int _lastUsedIndex = 0;
	private Comparison<T> _comparer;

	public PriorityQueue(Comparison<T> comparison, int initialCapacity)
	{
		if (initialCapacity < 0)
			throw new ArgumentException($"Initial capacity cannot be less than zero");

		_storage = new T[initialCapacity + 1];
		_comparer = comparison;
	}

	public int Count => _lastUsedIndex;

	public void Add(T item)
	{
		if (_lastUsedIndex == _storage.Length - 1)
		{
			Resize(_storage.Length * 2);
		}

		// Store the new element at the result of incrementing the
		// last stored index of the storage array.
		_storage[++_lastUsedIndex] = item;

		// Now we need to reheapify by swimming up until the 
		// binary heap order is restored.
		Swim(_lastUsedIndex);
	}

	private void Swim(int idx)
	{
		while (idx > 1 && _comparer(_storage[idx / 2], _storage[idx]) < 0)
		{
			Swap(ref _storage[idx / 2], ref _storage[idx]);
			idx = idx / 2;
		}

	}

	private void Sink(int k)
	{
		while (2 * k <= Count)
		{
			int j = 2 * k;
			if (j < Count && _comparer(_storage[j],_storage[j+1]) < 0) j++;
			if (_comparer(_storage[k],_storage[j]) >=0) break;
			Swap(ref _storage[k], ref _storage[j]);
			k=j;
			
		}
	}

	private bool HasChildNode(int elementIdx) => Count >= elementIdx * 2;

	private bool IsRootNode(int elementIdx) => elementIdx == 1;

	private bool ElementIsHigherPriorityThanParent(int elementIdx) => _comparer(_storage[elementIdx], _storage[elementIdx / 2]) > 0;

	private bool ElementIsLowerPriorityThanChild(int elementIdx, int childIdx) => _comparer(_storage[elementIdx], _storage[childIdx]) < 0;

	private void Swap(ref T el1, ref T el2)
	{
		var temp = el1;
		el1 = el2;
		el2 = temp;
	}

	public T Dequeue()
	{
		T max = _storage[1];
		Swap(ref _storage[1], ref _storage[_lastUsedIndex]);
		_storage[_lastUsedIndex] = default(T);
		_lastUsedIndex--;
		Sink(1);
		return max;
	}

	public T GetHighestPriorityItem() => _storage[1];

	private void Resize(long newSize)
	{
		T[] newStorage = new T[newSize];
		Array.Copy(_storage, newStorage, _lastUsedIndex + 1);
		_storage = newStorage;
	}
}





