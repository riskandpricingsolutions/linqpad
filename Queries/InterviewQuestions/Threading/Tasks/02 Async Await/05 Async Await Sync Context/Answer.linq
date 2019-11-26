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
	
	// Question: Use asyn await to update the button to be 
	// red and have spot price as text using async await	
	Window w = new Window();
	w.SizeToContent = SizeToContent.WidthAndHeight;
	
	Button b = new Button();
	b.Content = "Click Me";
	w.Content = b;
	b.Click += async (x,y) =>
	{
		double spot  = await GetSpotPrice();
		b.Background = Brushes.Red;
	};
	
	w.Show();
	Dispatcher.Run();
}

public Task<double> GetSpotPrice()
{
	return Task.Run(() =>
	{
		LogManager.GetLogger(nameof(Main)).Info($"Task Running \n");
		return 110.0;
	});
}