<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

Mutex e = new Mutex();

new Thread(() =>
{
	e.WaitOne(); // Block on obtaining Mutex

	// Critical Section

	e.ReleaseMutex(); // Release Mutex
}).Start();


var t1 = new Thread(() =>
{
	WriteLine($"t1 Calling WaitOne");
	e.WaitOne();
	WriteLine($"t1 In Critical Section");
	e.ReleaseMutex();
	WriteLine($"t1 Released mutex");
});

var t2 = new Thread(() =>
{
	WriteLine($"t2 Calling WaitOne");
	e.WaitOne();
	WriteLine($"t2 In Critical Section");
	e.ReleaseMutex();
	WriteLine($"t2 Released mutex");
});




e.WaitOne();
t1.Start();
t2.Start();
Thread.Sleep(5000);
e.ReleaseMutex();
