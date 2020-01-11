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
	// Initially the ARE is signalled,
	private AutoResetEvent _event = new AutoResetEvent(true);
	
	// The first thread calling WaitOne will be released
	// and the ASE will automatically be Reset to non signalled 
	// state. Subsequent threads calling Enter will block until the
	// first thread calls Leave and hence Set
	public void Enter() => _event.WaitOne();

	// Calling Set signals the ASE. If there are any blocked threads
	// one will be released and the ASE will Reset to non signalled.
	public void Leave() => _event.Set();
}