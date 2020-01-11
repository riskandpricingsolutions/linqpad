<Query Kind="Program" />

void Main()
{
	// Question: Add Spinning support to the below MixedModeWaitLock from the previous section
	
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


public class SpinningWaitLock : IDisposable
{
	private AutoResetEvent _are = new AutoResetEvent(false);
	private int _blockedCount = 0;
	
	private readonly int MaxSpinCount = 2000;
	
	public void Enter()
	{
		SpinWait spinWait = new SpinWait();
		
		for (int i = 0; i < MaxSpinCount; i++)
		{
			// If the value in _blockedCount is zero, set it to one. There
			// was no contention so we got the lock
			if (Interlocked.CompareExchange(ref _blockedCount,1,0)==0) return;
			
			// There was contention so we spin a little
			spinWait.SpinOnce();

		}
		
		// We have spun the maximum number of times so now we try one more time before
		// blocking
		if (Interlocked.Increment(ref _blockedCount) > 1)
		{
			_are.WaitOne();
		}

	}
	
	public void Leave()
	{
		// If no threads blocking just return
		if (Interlocked.Decrement(ref _blockedCount) == 0) return;

		// Otherwise release one of the blocked threads
		_are.Set();
	}

	public void Dispose()
	{
		_are.Dispose();
	}
}

