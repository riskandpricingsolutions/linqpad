<Query Kind="Program" />


private object _myLock = new Object();

void Main()
{
	Monitor.Enter(_myLock);
	try
	{
		// Do some work
	}
	finally 
	{
		Monitor.Exit(_myLock);
	}
}

// Define other methods and classes here
