<Query Kind="Program" />

void Main()
{
	// Question: Add Spinning support to the below MixedModeWaitLock
	
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
SpinningWaitLock l = new SpinningWaitLock();

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


public class SpinningWaitLock
{
	
	public void Enter() => throw new NotImplementedException();

	public void Leave() => throw new NotImplementedException();
}

