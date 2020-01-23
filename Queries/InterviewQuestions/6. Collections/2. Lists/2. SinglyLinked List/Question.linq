<Query Kind="Program" />

void Main()
{
	ILinkedList<int> _list = new SinglyLinkedList<int>();
	_list.AddFirst(4);
    _list.AddFirst(5);
     _list.AddFirst(6);
}

// Question: Write a SinglyLinkedList

public interface ILinkedList<T> : IEnumerable<T>
{
	void AddFirst(T data);

	void AddLast(T data);

	void RemoveFirst();

	void RemoveLast();

	int Count { get; }

	bool Contains(T value);

	bool Remove(T value);
}

public class SinglyLinkedList<T> : ILinkedList<T>
{

}