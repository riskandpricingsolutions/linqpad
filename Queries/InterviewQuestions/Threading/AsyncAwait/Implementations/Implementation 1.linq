<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	AnAwaiterMethod();
}

public async void AnAsyncMethod()
{
	Console.WriteLine("Starting an async method");
	Task t = Task.Run( () => Console.WriteLine("Task Running"));
	await t;
	Console.WriteLine("Task completed");
}

public void AnAwaiterMethod()
{
	Console.WriteLine("Starting an awaiter method");
	Task t = Task.Run(() => Console.WriteLine("Task Running"));

	t.GetAwaiter().OnCompleted(() =>
   {
	   Console.WriteLine("Task completed");
   });
	
}


// Define other methods and classes here
