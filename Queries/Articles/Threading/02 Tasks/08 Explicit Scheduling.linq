<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

MyExtensions.SetupLog4Net();
ILog log = LogManager.GetLogger("Explicit Scheduling");

TaskScheduler scheduler = TaskScheduler.Default;
Task t3 = new Task(() => log.Info("new Task()"));
t3.Start(scheduler);