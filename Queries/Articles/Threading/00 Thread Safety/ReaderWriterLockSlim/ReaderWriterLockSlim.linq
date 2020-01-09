<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
  <Namespace>log4net</Namespace>
</Query>

var s = new ReaderWriterLockSlim();

for (int i = 0; i < 2; i++)
{
	int j = i;
	new Thread(() =>
   {
	   Thread.Sleep(200);
	   s.EnterReadLock();
	   Thread.Sleep(10000);
	   s.ExitReadLock();
   }).Start();
}

Thread.Sleep(100);	
s.EnterWriteLock();
WriteLine($"Main Has Write Lock");
Thread.Sleep(5000);
s.ExitWriteLock();