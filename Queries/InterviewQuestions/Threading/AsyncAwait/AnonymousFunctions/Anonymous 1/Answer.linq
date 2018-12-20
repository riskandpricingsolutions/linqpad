<Query Kind="Program">
  <Namespace>log4net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Question:	What is the output of the following code and why
//
// Answer:		
//	[Main Query Thread]
//	[Main Query Thread] Starting 4
//	[Main Query Thread] Starting 2
//	[12] Completed 2
//	[6] Completed 4
//	[Main Query Thread] One result 16
//	[Main Query Thread] Two result 4
//
// Because we block on results even though the second result is available earlier
// it is not processed as a log until after the longer running one completes
static ILog logger = LogManager.GetLogger(nameof(Main));

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