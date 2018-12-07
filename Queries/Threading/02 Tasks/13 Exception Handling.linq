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
  <Namespace>Logging</Namespace>
</Query>

public static void Main()
{
	TaskExceptionTest();
}

public static Task GetExceptionTask()
{
	return Task.Run(() =>
	{
		MyLogger.Log("exception raised");
		throw new ArgumentException();
	});
}

public static void TaskExceptionTest()
{
	try
	{
		var exceptionTask = GetExceptionTask();
		exceptionTask.Wait();
	}
	catch (Exception e)
	{
		MyLogger.Log($"Exception {e.GetType()}");
		MyLogger.Log($"Inner exception {e.InnerException.GetType()}");
	}
}
