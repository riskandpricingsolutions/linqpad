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
	TaskScheduler s1 = TaskScheduler.Default;

	TaskScheduler s2 = TaskScheduler.Current;

	TaskScheduler s3 = TaskScheduler.FromCurrentSynchronizationContext();
}
