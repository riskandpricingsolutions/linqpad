<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>System.Windows.Media</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

void Main()
{
	MyExtensions.SetupLog4Net();
	
	// Question: Write code to create a window and button. When the 
	// button is clicked it will use a task to simulatr a long running task
	// and then when it completes change the button background to red
}

public Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		LogManager.GetLogger(nameof(Main)).Info($"Task Running \n");
		return 110.0;
	});
}