<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

MyExtensions.SetupLog4Net();
ILog log = LogManager.GetLogger("Chaining Tasks");

var rateTask = new Task<double>(() =>
{
	Thread.Sleep(1000);
	log.Info($"rateTask");
	return 0.1;
});

var fwdTask = rateTask.ContinueWith(task =>
{
	Thread.Sleep(1000);
	log.Info($"fwdTask");
	return 100 * Math.Exp(task.Result);
});

rateTask.Start();