<Query Kind="Program" />

void Main()
{
	SingleOrDefault();
}

public void Single()
{

		// If the sequence contains a single element return it
		new[] { 1 }.Single().Dump();

		// If the sequence contains no elements throw an exception
		try { (new int[0]).Single(); } catch (Exception ex) { Console.WriteLine(ex.Message); };

		// If the sequence contains more than one element throw an exception
		try { new[] { 1, 2 }.Single(); } catch (Exception ex) { Console.WriteLine(ex.Message); };

		// If the sequence contains a single element matching the predicate return it
		new[] { 1, 2 }.Single(x => x % 2 == 0).Dump();

		// If the sequence contains no elements matching the predicate throw an exception
		try { new[] { 1, 2 }.Single(x => x % 3 == 0); } catch (Exception ex) { Console.WriteLine(ex.Message); };

		// If the sequence contains multiple elements matching the predicate throw an exception
		try { new[] { 1, 2, 3, 4 }.Single(x => x % 2 == 0); } catch (Exception ex) { Console.WriteLine(ex.Message); };
}

public void SingleOrDefault()
{

	// If the sequence contains a single element return it
	new[] { 1 }.SingleOrDefault().Dump();

	// If the sequence contains no values returns default(int)
	new int[0].SingleOrDefault().Dump();

	// If the sequence contains more than one element throw an exception
	try { new[] { 1, 2 }.SingleOrDefault(); } catch (Exception ex) { Console.WriteLine(ex.Message); };

	// If the sequence contains a single element matching the predicate return it
	new[] { 1, 2 }.SingleOrDefault(x => x % 2 == 0).Dump();

	// If the sequence contains no element matching the predicate return default(int)
	new[] { 1, 2 }.SingleOrDefault(x => x % 3 == 0).Dump();

	// If the sequence contains multiple element matching the predicate throw exception
	try { new[] { 1, 2, 3, 4 }.SingleOrDefault(x => x % 2 == 0); } catch (Exception ex) { Console.WriteLine(ex.Message); };

}

// Define other methods and classes here
