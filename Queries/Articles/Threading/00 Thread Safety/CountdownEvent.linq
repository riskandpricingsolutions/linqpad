<Query Kind="Statements" />

CountdownEvent e = new CountdownEvent(2);

new Thread(() =>
{
	e.Wait();
	Console.WriteLine("t1 in");
}).Start();

new Thread(() =>
{
	e.Wait();
	Console.WriteLine("t2 in");
}).Start();

Thread.Sleep(1000);
e.Signal();
Console.WriteLine("Signalled");
e.Signal();
Console.WriteLine("Signalled");