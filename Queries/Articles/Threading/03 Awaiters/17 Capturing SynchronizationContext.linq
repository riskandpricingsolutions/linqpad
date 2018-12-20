<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

[STAThread]
public static void Main()
{
	MyExtensions.SetupLog4Net();
	logger.Info("Main() started");
	Window w = new Window();
	w.Loaded += WOnLoaded;
	w.Show();
	Dispatcher.Run();
}

private static void WOnLoaded(object s, RoutedEventArgs e)
{
	Task<double> task = GetSpotPrice();

	TaskAwaiter<double> awaiter = task.GetAwaiter();

	awaiter.OnCompleted(() => logger.Info(awaiter.GetResult()));
}

public static Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		logger.Info("Task running");
		return 110.0;
	});
}