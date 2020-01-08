<Query Kind="Program" />

void Main()
{
	
}

public int value;
public bool isRead = false;

public void Write()
{
	value = 100;
	Thread.MemoryBarrier();
	isRead = true;
}

public void Read()
{
	if (isRead)
	{
		Thread.MemoryBarrier();
		Console.WriteLine(value);
	}		
}
