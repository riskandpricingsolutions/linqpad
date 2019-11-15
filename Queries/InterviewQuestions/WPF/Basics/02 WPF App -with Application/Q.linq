<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

// Question: Write the simplest possible WPF Main method. Use Application

[STAThread]
public static void Main()
{
	Window window = new Window();
	window.Show();
	Dispatcher.Run();
	
}