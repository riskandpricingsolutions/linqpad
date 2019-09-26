<Query Kind="Statements">
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


Window w = new Window();
var c = new ChartArea();
c.AddLineSeries(-5, 5, 10, d => d * d * d, "Cubic", new Pen(Brushes.Blue, 1.0));
c.AddLineSeries(-5, 5, 10, d => d * d, "Quadratic", new Pen(Brushes.DarkRed, 1.0), AxisType.RightY);
w.Content = c;
w.Show();
