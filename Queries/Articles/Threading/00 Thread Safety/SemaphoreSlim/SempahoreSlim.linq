<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
  <Namespace>log4net</Namespace>
</Query>

var s = new System.Threading.SemaphoreSlim(0, 2);

for (int i = 0; i < 4; i++)
{
	int j = i;
	new Thread(() =>
   {
	   WriteLine($"{j} Acquiring Sempahore");
	   s.Wait();
	   WriteLine($"{j} In Critical Section");
	   Thread.Sleep(3000);
	   WriteLine($"{j} Releasing SemaphoreSlim");
	   s.Release();
   }).Start();
}

WriteLine("Main releasing semaphore twice");
s.Release(2); 