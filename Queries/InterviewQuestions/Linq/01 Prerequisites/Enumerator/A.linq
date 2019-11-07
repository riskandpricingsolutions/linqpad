<Query Kind="Program" />

void Main()
{
	IEnumerator<int> enumerator = new MyEnumerator();
	
	var results1 = new List<int>();
	while (enumerator.MoveNext())
		results1.Add(enumerator.Current);
	MyExtensions.AreEqual(0,results1.First());
	MyExtensions.AreEqual(3,results1.Last());
	
	enumerator.Reset();
	results1.Clear();
	while (enumerator.MoveNext())
		results1.Add(enumerator.Current);
	MyExtensions.AreEqual(0, results1.First());
	MyExtensions.AreEqual(3, results1.Last());
}

// Question: Implement a typed enumerators such that it
//           produces a sequence of integers from 0 to 3
public class MyEnumerator : IEnumerator<int>
{
	private int _current = -1;
	
	public int Current => _current;

	object IEnumerator.Current => _current;

	public void Dispose() {}

	public bool MoveNext() => ++_current < 4;

	public void Reset() => _current=-1;
}