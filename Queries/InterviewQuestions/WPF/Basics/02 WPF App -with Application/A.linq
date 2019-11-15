<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Windows</Namespace>
</Query>

// Question: Write the simplest possible WPF Main method. Use Application


[STAThread]
public static void Main(String[] args)
{	
	Application app = new Application();
	Window w = new Window();
	app.Run(w);
}	