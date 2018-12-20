<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Media</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

[STAThread]
public static void Main()
{
	Window w = new Window();
	w.Loaded += WOnLoaded;
	w.Show();
	Dispatcher.Run();
}

private static void WOnLoaded(object s, RoutedEventArgs e)
{
	int Id() => Thread.CurrentThread.ManagedThreadId;

	Console.WriteLine($@"Handler {Id()}");

	var rateTask = new Task<double>(() =>
	{
		Thread.Sleep(1000);
		Console.WriteLine($@"Task1 {Id()}");
		return 0.1;
	});

	var fwdTask = rateTask.ContinueWith(task =>
	{
		Thread.Sleep(1000);
		Console.WriteLine($@"Task2 {Id()}");
		return 100 * Math.Exp(task.Result);
	}, TaskScheduler.Default);

	fwdTask.ContinueWith(task =>
	{
		Console.WriteLine($@"Task3 {Id()}");
		double result = task.Result;
		Console.WriteLine($@"Task3 Result = {result} {Id()}");
	}, TaskContinuationOptions.ExecuteSynchronously);

	rateTask.Start(TaskScheduler.Default);

}