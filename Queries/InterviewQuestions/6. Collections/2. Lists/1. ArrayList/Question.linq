<Query Kind="Program" />

#load ".\IArrayList"

void Main()
{
	IArrayList<int> list = new ArrayList<int>(2);
	list.Add(4);
    list.Add(5);
    list.Add(6);

	MyExtensions.AreEqual(4, list[0]);
	MyExtensions.AreEqual(5, list[0]);
	MyExtensions.AreEqual(6, list[0]);
	MyExtensions.AreEqual(3, list.Count);
	list.RemoveAt(2);
	MyExtensions.AreEqual(2, list.Count);
}

// Question: Write an ArrayList
public class ArrayList<T> : IArrayList<T>
{
	
	public ArrayList(int initialSize)
	{
		
	}

	public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public long Count => throw new NotImplementedException();

	public void Add(T element) => throw new NotImplementedException();

	public void AddRange(IEnumerable<T> elements) => throw new NotImplementedException();

	public void Insert(int index, T element) => throw new NotImplementedException();

	public void RemoveAt(int index) => throw new NotImplementedException();
}