<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static ILog log = LogManager.GetLogger("Sub Tasks");

public static void Main()
{
	MyExtensions.SetupLog4Net();
	
	Task<int> Increment(int x)
	{
		return Task.Run(() =>
	    {
			log.Info(nameof(Increment));
			return ++x
	    });
	}

	
	var result = Increment(0)
	.ContinueWith(f => Increment(f.Result))
	.Unwrap().ContinueWith(f => Increment(f.Result))
	.Unwrap().ContinueWith(f => Increment(f.Result))
	.Unwrap().ContinueWith(f => Increment(f.Result));

	result.ContinueWith(r => log.Info(r.Result));
}