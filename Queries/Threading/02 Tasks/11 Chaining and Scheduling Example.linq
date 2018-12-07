<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.Core.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.Interfaces.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.Linq.dll</Reference>
  <Reference>C:\Users\rps\Code\onedrive\csharp-samples\Frameworks\Rx\libs\System.Reactive.PlatformServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
  <Namespace>System.Windows.Media</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
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
	}, TaskScheduler.FromCurrentSynchronizationContext()); 

	rateTask.Start(TaskScheduler.Default); 

}