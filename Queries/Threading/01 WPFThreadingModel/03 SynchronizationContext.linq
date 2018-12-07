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
	Window w = s as Window;
	w.Background = new SolidColorBrush(Colors.Green);

	SynchronizationContext synchronizationContext = SynchronizationContext.Current;

	Task.Run(() =>
	{
		Thread.Sleep(2000);
		synchronizationContext.Post(state => w.Background = Brushes.NavajoWhite, null);
	});
}
