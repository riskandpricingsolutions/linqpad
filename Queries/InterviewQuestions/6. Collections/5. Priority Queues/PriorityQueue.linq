<Query Kind="Program" />

void Main()
{
	//+var pq = new PriorityQueue<char>( (x,y) => x.CompareTo(y), 0);
	
	//pq.Add('P');
	//pq.Add('Q');
	//pq.Add('E');
	//var deleted =pq.Dequeue();
	//pq.Add('X');
	//pq.Add('A');
	//pq.Add('M');
	//deleted =pq.Dequeue();
	//pq.Add('P');
	//pq.Add('L');
	//pq.Add('E');
	//deleted =pq.Dequeue();
	
	var pq = new PriorityQueue<int>( (x,y) => y.CompareTo(x), 0);
	var inputs = new int[] { 20,30,10,5,30};
	for (int i = 0; i < inputs.Length; i++)
	{
		pq.Add(inputs[i]);	
	}
	
	var a = pq.Dequeue();
	var b = pq.Dequeue();
}

/// <summary>
/// A PriorityQueue using a heap ordered binary tree. Clients
/// specify whether it is a a Max or Min PQ by providing
/// a relevant Comparison<T> delegate. 
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
		while (!IsRootNode(idx) && ElementIsHigherPriorityThanParent(idx))
		{
			var parentNodeIndex = idx / 2;

			Swap(ref _storage[idx], ref _storage[parentNodeIndex]);

			idx = idx / 2;
		}
	}

	private void Sink(int idx)
	{
		while (HasChildNode(idx))
		{
			// Determine the index of the child node which has highest(lowest) priority
			var leftChildIdx = 2 * idx;
			var rightChildIdx = (2 * idx) + 1;
			
			var childIdx = leftChildIdx;
			
			// If we have a right child index
			if (rightChildIdx < Count)
			{
				var leftCHild = _storage[leftChildIdx];
				var rightChild = _storage[rightChildIdx];
				int comparisonResult = _comparer(leftCHild,rightChild);
				
				if (comparisonResult >= 0)
					childIdx = leftChildIdx;
			}

			// If the node at idx is not of lower priority that the highest priority child we 
			// can stop here. 
			if (!ElementIsLowerPriorityThanChild(idx, childIdx))
				break;

			Swap(ref _storage[idx], ref _storage[childIdx]);

			idx = childIdx;
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

