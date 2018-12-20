<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

// What is the output of this code

async Task  Main()
{
	try{
		LongRunningTask().Wait();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.GetType().Name);
	}
	
	try
	{
		await LongRunningTask();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.GetType().Name);
	}
}

Task LongRunningTask()
{
	return Task.Run( () =>
	{
		throw new Exception("Something went wrong");	
	});
}
