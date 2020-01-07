<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var l = new Object();

lock(l)
{
	WriteLine("Inside the critical section");
}

bool gotLock = false;
try
{
	Monitor.TryEnter(l, ref gotLock);
	WriteLine("Inside the critical section");
}
finally
{
	if (gotLock) Monitor.Exit(l);
}
