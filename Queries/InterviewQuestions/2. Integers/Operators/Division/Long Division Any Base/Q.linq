<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<(string,string)>(("4","1"),IntegerLongDivision("9",2));
}

// Question : Implement the below to perform integer long division in any base.
public (string quotient, string remainder) IntegerLongDivision(string dividend, int divisor,
	int b = 10) => throw new NotImplementedException();
