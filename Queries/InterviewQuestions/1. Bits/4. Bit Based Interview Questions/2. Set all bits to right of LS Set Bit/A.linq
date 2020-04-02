<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual<int>(7, SetToRight(4));
}

// Write code to set all bits to right of least significant set bit
public int SetToRight(int n) => (n -1) | n;