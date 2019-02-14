<Query Kind="Program" />

void Main()
{
	
}


public class PointComparer : EqualityComparer<Point>
{
	public override bool Equals(Point x, Point y)
	{
		return x.X == y.X && x.Y == y.Y;
	}

	public override int GetHashCode(Point obj)
	{
		return obj.X ^ obj.Y;
	}
}

public class Point
{
	public int X;
	public int Y;
}

// Define other methods and classes here
