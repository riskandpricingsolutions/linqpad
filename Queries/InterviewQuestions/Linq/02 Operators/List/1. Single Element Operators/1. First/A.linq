<Query Kind="Program" />

void Main()
{
	var input = new List<int> { 1, 2, 3, 4, 5, 6};
	

	// Put comments against all the following operators explaining the results and why
	
	// Return the first element, in this case 1
	input.First().Dump();

	// Calling first on empty list throws an exception
	try { new int[0].First();} catch (Exception ex) {Console.WriteLine(ex.Message);};
	
	// Returns the first even number, in this case 2
	input.First(i => i %2==0).Dump();
	
	// No element matches the predicate so throws an exception
	try { input.First(i => i %10==0);} catch (Exception ex) {Console.WriteLine(ex.Message);};


	// Returns default(int) as sequence is empty
	new int[0].FirstOrDefault().Dump();
	
	// returns first element of the list which is 1
	input.FirstOrDefault().Dump();
	
	// Returns default(int) as nothing matches the predicate
	input.FirstOrDefault(x=> x%7==0).Dump();
}


