<Query Kind="Statements" />

ManualResetEvent e = new ManualResetEvent(initialState:true);

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
Console.WriteLine("Signalled");
//e.Reset();
//Console.WriteLine("Signalled");