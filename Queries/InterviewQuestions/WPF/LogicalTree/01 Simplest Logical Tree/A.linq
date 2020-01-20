<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Shapes</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

// Question: Write code to create a single window with two rectangle children; one blue and one red

[STAThread]
public static void Main()
{
	Window window = new Window() {Height=200, Width=200};
	
	var panel = new StackPanel() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment=VerticalAlignment.Center};
	
	var r = new Rectangle() { Width=50, Height=50, Fill=Brushes.Red};
	var b = new Rectangle() { Width=50, Height=50, Fill=Brushes.Blue};
	
	panel.Children.Add(r);
	panel.Children.Add(b);
	
	window.Content = panel;
	
	window.Show();
	Dispatcher.Run();

}