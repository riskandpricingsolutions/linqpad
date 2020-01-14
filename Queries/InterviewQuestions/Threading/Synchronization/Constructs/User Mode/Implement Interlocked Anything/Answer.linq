<Query Kind="Program" />

void Main()
{
	// Question: Write your own code that can do thread safe Interlocking operation
}



public T Multiply<T>(ref T field, T arg, Func<T,T,T> f) where T : class
{
	while (true)
	{
		// The value in the field before we do the 
		// exchange
		T fieldVal1 = field;
		
		// AttemptedProduct
		T result = f(fieldVal1,arg);
		
		// We only update field if the value in the field is
		// equal to snapShot1. In this case the value of
		// product was calculated from the current value of
		// field
		T fieldVal2 = 
			Interlocked.CompareExchange(ref field, result, fieldVal1);
		
		// We can now compare the value in snapshot2 to see if 
		// we actually did the update. If we did the update return it
		if (fieldVal1 == fieldVal2) return result;

		// Otherwise we need to spin around again
		Thread.Yield();
	}
}