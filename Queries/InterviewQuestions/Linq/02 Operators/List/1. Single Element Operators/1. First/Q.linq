<Query Kind="Program" />

void Main()
{
	var input = new List<int> { 1, 2, 3, 4, 5, 6};
	

	// Question: Put comments against all the following operators explaining the results and why
	

	// 1 The first element of the non empty input sequence
	input.First().Dump();


	// Throws an exception if sequence is empty
	try { new int[0].First();} catch (Exception ex) {Console.WriteLine(ex.Message);};
	

	// Returns the first even number 2
	input.First(i => i %2==0).Dump();
	
	
	try { input.First(i => i %10==0);} catch (Exception ex) {Console.WriteLine(ex.Message);};

	// Return the default(int) if the sequence is empty
	new int[0].FirstOrDefault().Dump();

	// Returns the first element 1
	input.FirstOrDefault().Dump();
	

	// return default[int] as no element that is a power of 7
	input.FirstOrDefault(x=> x%7==0).Dump();
}