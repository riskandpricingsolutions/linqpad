<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Threading</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Shapes</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

// Question: Write code to create a single node visual tree that has 
// no rendering instructions and just shows as a black box

public class SingleNodeVisualTree : Window
{
	public SingleNodeVisualTree()
	{
		Width = Height = 200;
		WindowStyle = WindowStyle.None;
	}
	
	protected override int VisualChildrenCount => 0;
}