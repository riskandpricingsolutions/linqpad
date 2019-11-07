<Query Kind="Program" />

void Main()
{
	var input = new List<int> { 1, 2, 3, 4, 5, 6};
	

	// Question: Put comments against all the following operators explaining the results and why
	
	input.First().Dump();

	try { new int[0].First();} catch (Exception ex) {Console.WriteLine(ex.Message);};
	
	input.First(i => i %2==0).Dump();
	
	try { input.First(i => i %10==0);} catch (Exception ex) {Console.WriteLine(ex.Message);};

	new int[0].FirstOrDefault().Dump();

	input.FirstOrDefault().Dump();
	

	input.FirstOrDefault(x=> x%7==0).Dump();
}