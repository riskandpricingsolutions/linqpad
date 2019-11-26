<Query Kind="Program" />

void Main()
{
	using (MyDisposable m = new MyDisposable())
	{
		Console.WriteLine("Using MyDisposable");
	}
	
	MyDisposable n = new MyDisposable();
	try
	{
		Console.WriteLine("Using another");
	}
	finally 
	{
		n.Dispose();
	}
}


public class MyDisposable : IDisposable
{
	public void Dispose()
	{
		Console.WriteLine("Dispose");
	}
}

// Define other methods and classes here
