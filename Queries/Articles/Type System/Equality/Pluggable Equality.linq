<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	IDictionary<Point,string> a1 = new Dictionary<UserQuery.Point, string>();
	a1[new Point() {X=1,Y=1}] = "hello";	
	WriteLine(a1.ContainsKey(new Point() {X=1,Y=1})); // False

	var pc = new PointComparer()
	var a2 = new Dictionary<UserQuery.Point, string>(pc);
	a2[new Point() { X = 1, Y = 1 }] = "hello";
	WriteLine(a2.ContainsKey(new Point() { X = 1, Y = 1 })); // true
}


public class PointComparer : EqualityComparer<Point>
{
	public override bool Equals(Point x, Point y) 
		=> x.X == y.X && x.Y == y.Y;

	public override int GetHashCode(Point obj) 
		=> obj.X ^ obj.Y;
}

public class Point 
{
	public int X;
	public int Y;
}

// Define other methods and classes here