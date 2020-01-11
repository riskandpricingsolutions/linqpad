<Query Kind="Program" />

void Main()
{
	// Question: Add support for rentry and thread affinity

	new Thread(() => UpdateValue()).Start();


	l.Enter();
	int temp = count;
	Thread.Sleep(100);
	temp = temp + 10;
	count = temp;
	l.Exit();
	Thread.Sleep(100);
	Console.WriteLine(count);

}
ReentrantLock l = new ReentrantLock();

public int count = 0;

public void UpdateValue()
{
	l.Enter();
	int temp = count;
	Thread.Sleep(100);
	temp = temp + 10;
	count = temp;
	l.Exit();
}


public class ReentrantLock
{
	private AutoResetEvent _event = new AutoResetEvent(true);
	private int _reentryCount = 0;
	private int _owningThread = 0;

	public void Enter()
	{
		int callingThread = Thread.CurrentThread.ManagedThreadId;

		if (callingThread == _owningThread)
		{
			_reentryCount++;
			return;
		}

		// Calling thread not the owning thread.
		// If the ARE is signalled this will return immediately
		// and fall through to the below. If the ARE is 
		// non signalled then we will block here until the 
		// owning thread calls exit
		_event.WaitOne();

		// Now we are the owing thread
		_owningThread = callingThread;
		_reentryCount = 1;
	}

	public void Exit()
	{
		if (Thread.CurrentThread.ManagedThreadId != _owningThread)
			throw new InvalidOperationException();

		if (--_reentryCount == 0)
		{
			_owningThread = 0;
			_event.Set();
		}
	}
}