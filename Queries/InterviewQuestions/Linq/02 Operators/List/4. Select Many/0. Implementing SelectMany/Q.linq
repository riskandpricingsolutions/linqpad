<Query Kind="Program" />

void Main()
{
	// Question: Implement Select
	var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee" };

	var res = inseq1.SelectMany<String, String>(el => el.Split()).Dump();



}

public static class MyLinq
{

}