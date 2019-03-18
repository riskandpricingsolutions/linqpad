<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	var e = new SimpleEnumerator();

	while (e.MoveNext())
		WriteLine(e.Current);
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