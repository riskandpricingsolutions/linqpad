<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();
	var l = new Object();
	
	new Thread( () => 
	{
		Thread.Sleep(500);
		logger.Info("Acquiring lock");
		lock (l)
		{
			logger.Info("Executing Critical Section");
			Thread.Sleep(1000);
			logger.Info("Leaving Critical Section");
		}
	}).Start();
	
	logger.Info("Acquiring lock");
	lock (l)
	{
		logger.Info("Executing Critical Section");
		Thread.Sleep(5000);
		logger.Info("Leaving Critical Section");
	}
}

// Define other methods and classes here
