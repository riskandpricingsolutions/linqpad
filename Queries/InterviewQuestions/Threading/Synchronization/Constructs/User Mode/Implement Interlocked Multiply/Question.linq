<Query Kind="Program" />

void Main()
{
	// Question: Write your own code that can do thread safe multiply

	double x = 10;
	
	Multiply(ref x, 3.0);
	
	Console.WriteLine(x);
	
}



public double Multiply(ref double field, double y) => throw new NotImplementedException();