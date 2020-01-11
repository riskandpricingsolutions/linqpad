<Query Kind="Program" />

void Main()
{
	// Question: Write your own very simple Mutex using a mix of 
	// user mode and kernel mode to improve performance
	
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
MixedModeWaitLock l = new MixedModeWaitLock();

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


public class MixedModeWaitLock
{

	public void Enter() => throw new NotImplementedException();

	public void Leave() => throw new NotImplementedException();
}