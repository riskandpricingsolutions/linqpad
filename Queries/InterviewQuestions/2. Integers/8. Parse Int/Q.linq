<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<(string,string)>(("014","5"),IntegerLongDivision("145",10));
}

// Question : Implement the below to parse an integer string
public int ParseInteger(string s) => throw new NotImplementedException();

