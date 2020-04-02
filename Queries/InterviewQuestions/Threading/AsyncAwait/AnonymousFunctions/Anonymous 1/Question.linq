<Query Kind="Program">
  <Namespace>log4net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Question:	What is the output of the following code and why

static ILog logger = LogManager.GetLogger(typeof(UserQuery));

void Main()
{
	MyExtensions.SetupLog4Net("[%thread]  %message%newline");
	logger.Info("");

	Func<double, Task<double>> asyncSquare = async x =>
	{
		logger.Info($"Starting {x}");
		await Task.Delay((int)(x*1000));
		logger.Info($"Completed {x}");
		return Math.Pow(x,2);
	};
	
	Task<double> one = asyncSquare(4);
	Task<double> two = asyncSquare(2);

	logger.Info($"One result {one.Result}");
	logger.Info($"Two result {two.Result}");
}

// Define other methods and classes here