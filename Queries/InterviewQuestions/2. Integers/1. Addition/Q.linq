<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(8,Add(5,3));
	MyExtensions.AreEqual<int>(4,Add(5,-1));
}

// Question: Wrtie code to perform signed integer addition
public int Add(int a, int b) => throw new NotImplementedException();