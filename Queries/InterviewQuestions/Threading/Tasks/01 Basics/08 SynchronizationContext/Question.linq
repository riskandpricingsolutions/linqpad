<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Media</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
</Query>

void Main()
{
	Button b = new Button();
	b.Content = "Click Me";

	Window w = new Window();
	w.SizeToContent = SizeToContent.WidthAndHeight;
	w.Content = b;

	// Question: Add a handler to B that when clicked starts a 
	//           task on a background thread and after while 
	//           executes another task that sets the button 
	//           background to Red.
	
}