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


public class MixedModeWaitLock : IDisposable
{
	// Initially the ASE is non signalled
	private AutoResetEvent _event = new AutoResetEvent(false);
	private int _blockedCount = 0;

	public void Enter()
	{
		// Start with the user mode construct. If this is the
		// first thread to call Enter just return. 
		if (Interlocked.Increment(ref _blockedCount) == 1)
			return;

		// The second and later threads will block on the non-signalled
		// ASE. 
		_event.WaitOne();
			
	}

	public void Leave() 
	{
		// If no threads blocking just return
		if (Interlocked.Decrement(ref _blockedCount) == 0) return;
		
		// Otherwise release one of the blocked threads
		_event.Set();
	}

	public void Dispose()
	{
		_event.Dispose();
	}
}