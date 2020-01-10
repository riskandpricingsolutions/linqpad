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
	private int _rentryCount = 0;
	private int _owningThread = 0;

	public void Enter()
	{
		int callingThread = Thread.CurrentThread.ManagedThreadId;
		
		if (callingThread == _owningThread)
		{
			_rentryCount++;
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
		 _rentryCount = 1;
	}

	public void Exit()
	{
		if (Thread.CurrentThread.ManagedThreadId != _owningThread) 
			throw new InvalidOperationException();
		
		if (--_rentryCount == 0)
		{
			_owningThread =0;
			_event.Set();
		}
	}
}