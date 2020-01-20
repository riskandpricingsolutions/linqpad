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

// Question: Write code to create a three node visual tree of circles. 
// The code should emphasize the order nodes in the tree are rendered

[STAThread]
public void Main()
{
	var window = new DepthFirstRendering();
	window.Show();
	Dispatcher.Run();
}


public class DepthFirstRendering : Window
{
	public DepthFirstRendering()
	{
		Width = Height = 150;
		WindowStyle = WindowStyle.None;
		ResizeMode = ResizeMode.NoResize;
		MouseLeftButtonDown += (sender,args) => DragMove();
		AllowsTransparency = true;


		this.AddVisualChild(_children);
		// 1. Big Circle 
		_children.Add(CreateCircle(new Point(40,40), Brushes.Red,40));
		
		
		VisualCollectionVisual onePointTwo = new VisualCollectionVisual();
		_children.Add(onePointTwo);
		
		_children.Add(CreateCircle(new Point(40,20),Brushes.Green,20));
	
		onePointTwo.Add(CreateCircle(new Point(80,40),Brushes.LightBlue,40));
	}
	
	public DrawingVisual CreateCircle(Point location, Brush brush, int radius)
	{
		DrawingVisual dv = new DrawingVisual();
		using (var dc = dv.RenderOpen())
		{
			dc.DrawEllipse(brush,new Pen(brush,3),location,radius,radius);
		}
		return dv;
	}

	protected override int VisualChildrenCount => _children.Count;
	protected override Visual GetVisualChild(int index) => _children._visualCollection[index];
	private VisualCollectionVisual _children = new VisualCollectionVisual();
}

public class VisualCollectionVisual : Visual
{
	public VisualCollectionVisual()
	{
		_visualCollection = new VisualCollection(this);
	}

	public int Count => _visualCollection.Count;

	public void Add(Visual visual)
	{
		_visualCollection.Add(visual);
	}

	protected override Visual GetVisualChild(int index) => _visualCollection[index];
	protected override int VisualChildrenCount => _visualCollection.Count;

	public readonly VisualCollection _visualCollection;
}