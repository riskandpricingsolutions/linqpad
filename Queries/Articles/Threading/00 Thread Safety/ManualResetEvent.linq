<Query Kind="Statements" />

ManualResetEvent e = new ManualResetEvent(false);

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
//e.Reset();
//Console.WriteLine("Signalled");