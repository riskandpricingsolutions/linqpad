<Query Kind="Statements" />

AutoResetEvent e = new AutoResetEvent(false);

new Thread(() =>
{
	e.WaitOne();
	Console.WriteLine("t1 in");
}).Start();

new Thread(() =>
{
	e.WaitOne();
	Console.WriteLine("t2 in");
}).Start();

Thread.Sleep(1000);
e.Set();
Console.WriteLine("Signalled");

Thread.Sleep(1000);
e.Set();
Console.WriteLine("Signalled Again");
//e.Reset();
//Console.WriteLine("Signalled");