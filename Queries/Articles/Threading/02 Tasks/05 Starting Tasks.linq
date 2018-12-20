<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

MyExtensions.SetupLog4Net();

v

var t1 = Task.Factory.StartNew(() => log.Info("TaskFactory.StartNext"));

var t2 = Task.Run(() => log.Info("Task.Run"));

var t3 = new Task(() => log.Info("new Task()"));
t3.Start();