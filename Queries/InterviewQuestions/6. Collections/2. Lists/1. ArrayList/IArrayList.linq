<Query Kind="Program" />

public interface IArrayList<T>
{
	void Add(T element);

	void RemoveAt(int index);

	void AddRange(IEnumerable<T> elements);

	void Insert(int index, T element);

	T this[int index] { get; set; }
	
	long Count {get;}
}

