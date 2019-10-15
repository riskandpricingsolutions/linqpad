<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(2,Subtract(5,3));
	MyExtensions.AreEqual<int>(6,Subtract(5,-1));
}

// Implement subtact without the - key
public int Subtract(int a, int b) => a + ~b +1;