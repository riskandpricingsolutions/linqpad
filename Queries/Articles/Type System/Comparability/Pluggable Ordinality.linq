<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Point[] a = new Point[]
	{
		new Point() {X=3,Y=1},
		new Point() {X=1,Y=1},
		new Point() {X=5,Y=1}
	};
	
	Array.Sort(a,new PointComparer());
	WriteLine(a);
}

public class Point
{
	public int X;
	public int Y;
}

public class PointComparer : Comparer<Point>
{
	public override int Compare(Point x, Point y)
	{
		if (object.Equals(x,y)) return 0;
		
		return x.X.CompareTo(y.X);
	}
}



// Define other methods and classes here