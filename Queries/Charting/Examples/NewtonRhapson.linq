<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference Relative="..\..\..\libs\Charting\RiskAndPricingSolutions.Charting.Controls.dll">&lt;LocalApplicationData&gt;\MyLINQPad\linqpad\libs\Charting\RiskAndPricingSolutions.Charting.Controls.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>RiskAndPricingSolutions.Charting.Controls.Extensions</Namespace>
  <Namespace>RiskAndPricingSolutions.Charting.Controls.View.VisualAxis</Namespace>
  <Namespace>RiskAndPricingSolutions.Charting.Controls.View.VisualChartArea</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

void Main()
{
	Window w = new Window();
	var c = new ChartArea();
	
	// 0 = f(x0) + f'(x0)(x1-x0)
	// x1-x0 = - 
	// x1 = x0 - f(x0) / f'(x0) 
	Solve(2.0,1.5,x=>x*x-2,x=>2*x);
	
//	c.AddLineSeries(-5, 5, 100, d => d * d, "Quadratic", new Pen(Brushes.DarkRed, 1.0), AxisType.LeftY,false);
//	w.Content = c;
//	w.Show(); 
}

public double Solve(double target, double initialGuess, Func<double,double> f, Func<double,double> f1x)
{
	double error = 0.0001;
	double x = initialGuess;
	
	double y = f(x)-target;
	while ( Math.Abs(y - target) > error)
	{
		x = x - ( y / f1x(x));
		y = f(x)-	target;
	}
	
	return x;
}

// Define other methods and classes here
