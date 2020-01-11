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
	public void Enter() => throw new NotImplementedException();

	public void Exit() => throw new NotImplementedException();
}