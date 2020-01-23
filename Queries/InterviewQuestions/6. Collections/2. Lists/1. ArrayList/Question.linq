<Query Kind="Program" />

void Main()
{
	IArrayList<int> _list = new ArrayList<int>(2);
	_list.Add(4);
    _list.Add(5);
     _list.Add(6);
}

// Question: Write an ArrayList

public interface IArrayList<T>
{
	// Add an element to the end of the list
	void Add(T element);

	// Remove the element at the given index.
	void RemoveAt(int index);

	/// <summary>
	/// Add a range of elements to the end of the list
	/// </summary>
	/// <param name="elements"></param>
	void AddRange(IEnumerable<T> elements);

	void Insert(int index, T element);

	// Index based access
	T this[int index] { get; set; }
}

public class ArrayList<T> : IArrayList<T>
{
	public ArrayList(int initialSize)
	{
		
	}
}