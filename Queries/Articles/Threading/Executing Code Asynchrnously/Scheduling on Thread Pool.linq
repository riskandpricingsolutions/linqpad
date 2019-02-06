<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	ThreadPool.QueueUserWorkItem(Console.WriteLine, "Hello World");
	
	Task.Run(() => Console.WriteLine("Hello World"));
}


// Define other methods and classes here