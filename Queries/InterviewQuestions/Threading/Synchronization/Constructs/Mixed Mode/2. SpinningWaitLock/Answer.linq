<Query Kind="Program" />

void Main()
{
	// Question: Add Reentry and Thread affinity to the SpinningWaitLock
	// from the previous question
	
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
MyMonitor l = new MyMonitor();

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

public class MyMonitor : IDisposable
{
	// Initially the ASE is non signalled
	private AutoResetEvent _event = new AutoResetEvent(false);
	private int _blockedCount = 0;
	private int _owningThreadId = 0;
	private int _reentryCount = 0;

	public void Enter()
	{
		int threadId = Thread.CurrentThread.ManagedThreadId;

		// Reentrant call to enter to just incremwent count and retunr
		if (threadId == _owningThreadId)
		{
			_reentryCount++;
			return;
		}
		
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
		if (Thread.CurrentThread.ManagedThreadId != _owningThreadId) throw new SynchronizationLockException();
		
		if (--_reentryCount > 0) return;

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