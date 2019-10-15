<Query Kind="Program" />

void Main()
{	
	MyExtensions.AreEqual(0,LogBrute(1));
	MyExtensions.AreEqual(1,LogBrute(2));
	MyExtensions.AreEqual(1,LogBrute(3));
	MyExtensions.AreEqual(2,LogBrute(4));
	MyExtensions.AreEqual(2,LogBrute(5));

	MyExtensions.AreEqual(0, LogOpt(1));
	MyExtensions.AreEqual(1, LogOpt(2));
	MyExtensions.AreEqual(1, LogOpt(3));
	MyExtensions.AreEqual(2, LogOpt(4));
	MyExtensions.AreEqual(2, LogOpt(5));

}

// Question: Write brute force algorithm to calculate 
// --------floor(log(x)) to base 2
public byte LogBrute(byte x) => throw new NotImplementedException();

// Question: optimised algorithm to calculate 
// --------floor(log(x)) to base 2
public int LogOpt(int x) => throw new NotImplementedException();


// Define other methods and classes here