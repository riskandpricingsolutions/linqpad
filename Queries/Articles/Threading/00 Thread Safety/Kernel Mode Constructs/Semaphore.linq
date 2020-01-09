<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

Semaphore e = new Semaphore(0,3);

for (int i = 0; i < 10; i++)
{
	int j = i;
	new Thread(() =>
	{
		e.WaitOne();
		Thread.Sleep(1000);
		e.Release();		
	}).Start();
}

e.Release(3);

