<Query Kind="Program" />

void Main()
{
	// Question: Write your own SpinLock that can be used to make this code correct
	
	new Thread(() => UpdateValue()).Start();
	
	
	l.Enter();
	int temp = count;
	Thread.Sleep(100);
	temp = temp + 10;
	count = temp;
	l.Leave();
	Thread.Sleep(100);
	Console.WriteLine(count);
	
}
MySpinLock l = new MySpinLock();

public int count = 0;

public void UpdateValue()
{
	l.Enter();
	int temp = count;
	Thread.Sleep(100);
	temp = temp + 10;
	count = temp;
	l.Leave();
}


public class MySpinLock
{
	private int taken;
	
	public void Enter()
	{
		while (true)
		{
			if (Interlocked.Exchange(ref taken, 1) == 0) return;
			
			// Yield the current thread in an attempt to lessen the 
			// impact of spinning and allow the thread that holds the 
			// lock to finish what it is doing
			Thread.Yield();
		}
	}
	
	public void Leave() => Volatile.Write(ref taken,0);
}