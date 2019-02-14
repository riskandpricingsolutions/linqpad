<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	IEnumerable<int> Fib(int n)
	{
		for (int i =0,current=0,next=1; i < n; i++)
		{
			yield return current;
			int nextnext = next + current;
			current = next;
			next = nextnext;
		}
	}
	
	foreach (var element in Fib(6))
		WriteLine(element);
}


// Define other methods and classes here
