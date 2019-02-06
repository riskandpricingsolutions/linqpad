<Query Kind="Program" />

void Main()
{
	Point p = new Point(1.0,2.0);
	
	var (a,b) = p;
}

public class Point
{
	private double x;
	private double y;
	
	public Point(double x, double y)
	{
		this.x = x;
		this.y = y;
	}
	
	public void Deconstruct(out double x, out double y)
	{
		x = this.x;
		y = this.y;
	}
}

// Define other methods and classes here
