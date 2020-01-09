<Query Kind="Statements" />

AutoResetEvent e = new AutoResetEvent(initialState:true);

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

Console.Read();
e.Set();
