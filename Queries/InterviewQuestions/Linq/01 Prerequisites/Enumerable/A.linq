<Query Kind="Program" />

void Main()
{
	 IEnumerable<int> enumerator = new MyEnumerable();
	
	var results1 = new List<int>();
	foreach (var element in enumerator)
		results1.Add(element);

	MyExtensions.AreEqual(0,results1.First());
	MyExtensions.AreEqual(3,results1.Last());

	foreach (var element in enumerator
	
	)
	
	results1.Add(element);
	MyExtensions.AreEqual(0, results1.First());
	MyExtensions.AreEqual(3, results1.Last());
}

// Question: Implement a typed enumerable such that it
//           produces a sequence of integers from 0 to 3
public class MyEnumerable : IEnumerable<int>
{
	public IEnumerator<int> GetEnumerator() => new MyEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

public class MyEnumerator : IEnumerator<int>
{
	private int _current = -1;

	public int Current => _current;

	object IEnumerator.Current => _current;

	public void Dispose() { }

	public bool MoveNext() => ++_current < 4;

	public void Reset() => _current = -1;
}