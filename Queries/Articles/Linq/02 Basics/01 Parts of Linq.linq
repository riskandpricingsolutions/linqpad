<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// 1. A sequence is any collection implementing IEnumerable<T>
	IEnumerable<int> sequence = new int[] {0,1,2,3,4};
	
	// 2. An element is a single constituent of the sequence
	foreach (var element in sequence)
		WriteLine(element);
	
	// 4. Queries combine query operators
	IEnumerable<int> output = sequence
		.Where(s => s%2 ==0)
		.Select(s => s*s);
}