<Query Kind="Program" />

void Main()
{
	// Question: Implement a Mutex using an AutoResetEvent. Your code
	// should support thread affinity and reentry
	

	
}

public class MyMutex
{
	private AutoResetEvent _are = new AutoResetEvent(true);
	private int _reentrycount;
	private int _threadId = 0;
	
	public void Enter()
	{
		int tId = Thread.CurrentThread.ManagedThreadId;
		
		if (tId == _threadId)
		{
			_reentrycount++;
			return;
		}
		
		_are.WaitOne();
		
		// The current thread now owns the lock
		_reentrycount = 1;
		_threadId =  tId;
	}
	
	public void Exit()
	{
		int tId = Thread.CurrentThread.ManagedThreadId;
		if (_threadId != tId)  throw new InvalidOperationException();
		
		if (--_reentrycount == 0)
		{
			_threadId = 0;
			_are.Set();
		}
		
	}
}