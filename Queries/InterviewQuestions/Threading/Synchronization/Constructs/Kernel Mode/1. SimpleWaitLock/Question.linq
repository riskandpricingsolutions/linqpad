<Query Kind="Program" />

void Main()
{
	// Question: Write your own very simple Mutex using an AutoResetEvent 
	// internally.
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
SimpleWaitLock l = new SimpleWaitLock();

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


public class SimpleWaitLock
{
	public void Enter() => throw new NotImplementedException();

	public void Leave() => throw new NotImplementedException();
}