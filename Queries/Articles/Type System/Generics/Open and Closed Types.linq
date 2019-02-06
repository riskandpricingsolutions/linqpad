<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	List<int> listOfInt = new List<int>();
	listOfInt.Add(4);
	listOfInt.Add(10);
	
	WriteLine(listOfInt.Get(1));
}

public class List<T>
{
	public void Add(T element) { _storage[_nextFreeSlot++] = element; }
	public T Get(int idx) { return _storage[idx]; }

	private readonly T[] _storage = new T[10];
	private int _nextFreeSlot = 0;
}
