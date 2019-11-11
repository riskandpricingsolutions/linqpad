<Query Kind="Program" />

void Main()
{
	// Question: Use SelectMany to flatten the following sequence
	var parit = new[] { ("Kenny", new[] { 1, 2, 3 }),
		("Joe", new[] { 4, 5, 6 }) };

	var seq2 =
		parit
		.SelectMany(s => s.Item2);
		
	seq2.Dump();
}

