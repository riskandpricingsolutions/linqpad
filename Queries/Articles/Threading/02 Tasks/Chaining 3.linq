<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

ILog logger = LogManager.GetLogger("Main");

void Main()
{
	MyExtensions.SetupLog4Net();

	Task<Task<int>> outerTask = new Task<Task<int>>(() =>
	{
		
		Task<int> innerTask = new Task<int>(new Func<int>(() => 5));
		innerTask.Start();

		Task<int> cont = innerTask.ContinueWith(new Func<Task<int>, int>((ant) =>
		{
			return ant.Result * 2;
		}));

		return cont;
	});
	
	outerTask.Start();
	
	outerTask.Unwrap().ContinueWith(t => logger.Info(t.Result));
	
	
}