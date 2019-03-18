<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{	
	WriteLine(GetFibonacci(6));
}

IEnumerator<int> GetFibonacci(int numEntries)
{
	for (int i = 0, current = 0, next = 1, nextnext = 1; i < numEntries; i++)
	{
		yield return current;

		nextnext = current + next;
		current = next;
		next = nextnext;
	}
}