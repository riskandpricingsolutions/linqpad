<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(0,PositionOfSetDigit(1));
	MyExtensions.AreEqual(1,PositionOfSetDigit(2));
	MyExtensions.AreEqual(2,PositionOfSetDigit(4));
	MyExtensions.AreEqual(3,PositionOfSetDigit(8));
}

// Question: Write a function to return the position
// --------  of the single 1 bit in a given integer
public int PositionOfSetDigit(int x) =>
	(int)(Math.Log(x) / Math.Log(2));

// Question: Improve the previous method by adding logic 
// --------  to check if the input indeed only has a single 
//           set digit
public int PositionOfSetDigit2(int x)
{
	if ((x & x - 1) != 0) 
		throw new ArgumentException($"{x} has more than a single 1 in its binary representaion" );
	
	return (int)(Math.Log(x) / Math.Log(2));
}