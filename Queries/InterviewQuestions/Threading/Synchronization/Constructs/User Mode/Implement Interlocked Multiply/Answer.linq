<Query Kind="Program">
  <Namespace>static System.Threading.Interlocked</Namespace>
</Query>

void Main()
{
	// Question: Write your own code that can do thread safe multiply

	double x = 10;
	
	Multiply(ref x, 3.0);
	
	Console.WriteLine(x);
	
}



public double Multiply(ref double field, double y)
{
	while (true)
	{
		// The value in the field before we do the 
		// exchange
		double fieldVal1 = field;
		
		// AttemptedProduct
		double product = fieldVal1 * y;
		
		// We only update field if the value in the field is
		// equal to snapShot1. In this case the value of
		// product was calculated from the current value of
		// field
		double fieldVal2 = 
			CompareExchange(ref field, product, fieldVal1);
		
		// We can now compare the value in snapshot2 to see if 
		// we actually did the update. If we did the update return it
		if (fieldVal1 == fieldVal2) return product;

		// Otherwise we need to spin around again
		Thread.Yield();
	}
}