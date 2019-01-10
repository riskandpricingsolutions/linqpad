<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog log = LogManager.GetLogger("Sub Tasks");

public static void Main()
{
	MyExtensions.SetupLog4Net();
	
	Task<double> GetSpot() => Task.Run(() => 100.0);
	
	Task<double> GetForward(double spot) => Task.Run(() =>spot * Math.Exp(0.1));
	
	// Having a Task<Task<double>> is inconvenient
	Task<Task<double>> forward = GetSpot()
		.ContinueWith(x => GetForward(x.Result));	
		
	// We can solve this using the Unwrap extension method.
	// This method creates a proxy Task that only completes
	// when both the outer and inner Tasks are ready	
	forward
		.Unwrap()
		.ContinueWith(f => log.Info(f.Result));
}

