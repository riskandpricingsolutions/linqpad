<Query Kind="Program" />

void Main()
{
	// Question: Implement Select
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee" };

	inseq1.Select(i => i.First()).Dump();

	inseq1.Select((i, el) => i).Dump();

}

public static class MyLinq
{

}

