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
  <Namespace>System</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

[STAThread]
public static void Main()
{
	MyExtensions.SetupLog4Net();
	Window w = new Window();
	w.Loaded += WOnLoaded;
	w.Show();
	Dispatcher.Run();
}

private static async void WOnLoaded(object s, RoutedEventArgs e)
{
	Window w = s as Window;
	w.Background = new SolidColorBrush(Colors.Green);

	// 1. We log out to show we have entered the Main method and
	// highlight the thread we are running on
	LogManager.GetLogger(nameof(Main)).Info($"Main entered \n");

	try
	{
		Task<double> t = LongRunningTask();
		double result = await t;
	}
	catch (Exception ex)
	{
		// 3. The internals of async/await mechanism has captured the
		//    synchronization context and posted the exception back onto it. As 
		//    before it has unwrapped the exception
		LogManager.GetLogger(nameof(Main)).Info($"Caught exception of type {ex.GetType().Name} \n {MyExtensions.GetStackTraceString(1)} \n");
	}
}



static Task<double> LongRunningTask()
{
	return Task<double>.Run(() =>
	{
		// 2. Raise the exception on a background thread
		LogManager.GetLogger(nameof(LongRunningTask)).Info
		($"Raising exception \n {MyExtensions.GetStackTraceString(1)} \n");
		throw new Exception("Raised on background");
		return 100.0;
	});
}