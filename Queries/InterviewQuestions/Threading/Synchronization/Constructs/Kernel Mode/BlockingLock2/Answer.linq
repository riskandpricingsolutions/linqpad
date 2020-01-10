<Query Kind="Program" />

void Main()
{
	// Question: Write your own BlockLock using an event
	
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
BlockingLock l = new BlockingLock();

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


public class BlockingLock
{
	private AutoResetEvent _event = new AutoResetEvent(true);
	
	public void Enter() => _event.WaitOne();
	
	public void Leave() => _event.Set();
}