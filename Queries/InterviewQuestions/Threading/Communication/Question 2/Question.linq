<Query Kind="Program" />

void Main()
{
	// Question: Write your own SpinLock that can be used to make this code correct
	
	new Thread(() => UpdateValue()).Start();
	

	int temp = count;
	Thread.Sleep(100);
	temp = temp + 10;
	count = temp;
	Thread.Sleep(100);
	Console.WriteLine(count);
	
}

public int count = 0;

public void UpdateValue()
{
	int temp = count;
	Thread.Sleep(100);
	temp = temp + 10;
	count = temp;
}


public class MySpinLock
{
	private int taken = 0;
	
	public void Enter()
	{
		throw new NotSupportedException();
	}
	
	public void Leave()
	{
		throw new NotSupportedException();
	}
}