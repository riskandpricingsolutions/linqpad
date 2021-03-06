<Query Kind="Program" />

#load ".\IArrayList"

void Main()
{
	IArrayList<int> list = new ArrayList<int>(2);
	list.Add(4);
	list.Add(5);
	list.Add(6);

	MyExtensions.AreEqual(4, list[0]);
	MyExtensions.AreEqual(5, list[1]);
	MyExtensions.AreEqual(6, list[2]);
	MyExtensions.AreEqual(3, list.Count);
	list.RemoveAt(2);
	MyExtensions.AreEqual(2, list.Count);
}

// Question: Write an ArrayList
public class ArrayList<T> : IArrayList<T>
{
	public ArrayList(long initialCapacity)
	{
		_storage = new T[initialCapacity];
	}

	/// <summary>
	/// Adding an element to the end of the list is amortized constant
	/// time meaning on the whole it is constant time, with the odd
	/// operation taking longer
	/// </summary>
	/// <param name="element"></param>
	public void Add(T element)
	{
		// Because arrays are zero based, the first time 
		// the the next free element equals the length of 
		// the storage we are off the end and need to increase the
		// size.
		if (_storage.Length == nextFreeElementIndex)
			Resize(nextFreeElementIndex * 2);

		_storage[nextFreeElementIndex++] = element;
	}

	/// <summary>
	/// Remove at the given index
	/// </summary>
	/// <param name="index"></param>
	public void RemoveAt(int index)
	{
		if (index < 0 || index > nextFreeElementIndex - 1)
			throw new ArgumentOutOfRangeException();

		Array.Copy(_storage, index + 1, _storage, index, nextFreeElementIndex - (index + 1));
		
		// If T is a reference type set it to null to prevent loitering
		_storage[nextFreeElementIndex] = default(T);
		
		nextFreeElementIndex--;
	}

	/// <summary>
	/// O(M) where M is the number of elements being added
	/// </summary>
	/// <param name="elements">The elements to be added</param>
	public void AddRange(IEnumerable<T> elements)
	{
		if (elements == null) return;
		foreach (var element in elements) Add(element);
	}

	/// <summary>
	/// Insert an element somewhere in the middle of the array.
	/// O(N). As we need to do an array copy. Is this really O(N)?
	/// How is the array copy implemented.
	/// </summary>
	/// <param name="index"></param>
	/// <param name="element"></param>
	public void Insert(int index, T element)
	{
		if (_storage.Length == nextFreeElementIndex)
			Resize(nextFreeElementIndex * 2);

		Array.Copy(_storage, index, _storage, index + 1, nextFreeElementIndex - index);
		nextFreeElementIndex++;
	}

	/// <summary>
	/// Setting/Getting by index is an O(1) operation
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public T this[int index]
	{
		get
		{
			if (index < 0 || index > nextFreeElementIndex - 1)
				throw new ArgumentOutOfRangeException();
			return _storage[index];
		}
		set
		{
			if (index < 0 || index > nextFreeElementIndex - 1)
				throw new ArgumentOutOfRangeException();
			_storage[index] = value;
		}
	}

	public override string ToString()
	{
		StringBuilder b = new StringBuilder("[");
		for (int i = 0; i < nextFreeElementIndex; i++)
		{
			if (i == nextFreeElementIndex - 1)
				b.Append(_storage[i]);
			else
				b.Append($"{_storage[i].ToString()},");
		}

		b.Append("]");

		return b.ToString();
	}

	private void Resize(long newSize)
	{
		T[] newStorage = new T[newSize];
		Array.Copy(_storage, newStorage, nextFreeElementIndex);
		_storage = newStorage;
	}

	private T[] _storage;
	private int nextFreeElementIndex = 0;

	public long Count => nextFreeElementIndex;
}