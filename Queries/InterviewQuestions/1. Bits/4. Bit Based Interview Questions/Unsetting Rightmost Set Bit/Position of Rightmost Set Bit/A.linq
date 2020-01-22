<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(2, PositionOfSetDigit2(12));
	MyExtensions.AreEqual(0, PositionOfSetDigit2(7));
}


public int PositionOfSetDigit2(int x)
{
	if (x==0) throw new ArgumentException("zero not valid input");
	
	int rightMostDigit = (x & (x-1)) ^ x;

	return (int)(Math.Log(rightMostDigit) / Math.Log(2));
}
