<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	var e = new SimpleEnumerable();

	foreach (var element in e)
		WriteLine(e);
}

// Enumerables produce enumerators 
// It is enumerables that are consumed by foreach statements
public class SimpleEnumerable : IEnumerable<int>
{
	public IEnumerator<int> GetEnumerator()
	{
		return new SimpleEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

// An enumerator is a simple forward only cursor
public class SimpleEnumerator : IEnumerator<int>
{	
	public int Current => i;

	object IEnumerator.Current => i;

	public void Dispose() {}

	public bool MoveNext() => i++ < 4;

	public void Reset() =>  i = -1;
	
	private int i = -1;
}