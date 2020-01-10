<Query Kind="Program" />

void Main()
{
	// Question: Fix the below code so that it is impossible to write 0 to the console
}

public int value;
public bool isRead = false;

volatile int x;

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
