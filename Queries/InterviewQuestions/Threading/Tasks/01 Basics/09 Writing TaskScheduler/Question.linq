<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
	// Question: Implement a TaskScheduler that immediately 
	//           executes code on current thread. Demonstrate
	//           its use.
}