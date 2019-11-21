<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: Start a task in three ways
	Task.Run(()=> Console.WriteLine("Task.Run"));
	
	Task.Factory.StartNew (()=> Console.WriteLine("Task.Factory.StartNew"));
	
	Task t = new Task(()=> Console.WriteLine("new Task()"));
	t.Start();
}