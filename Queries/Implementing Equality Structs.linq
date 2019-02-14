<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{

	string a = new string('*',4);
	string b = new string('*',4);
	string c = a;
	
	WriteLine(Object.ReferenceEquals(a,b)); // false
	WriteLine(a==b); // true
	WriteLine(a.Equals(b)); // true
	
}


public struct Point: IEquatable<Point>
{
	public int X;
	public int Y;

	// 1. Implement type safe equals defined in IEquatable
	public bool Equals(Point other) => X == other.X && Y == other.Y;

	// 2. Override Equals to perform null and type check before
	// calling IEquatable method
	public override bool Equals(object obj)
	{
		if (!(obj is Point)) return false;
		
		return Equals((Point)obj);
	}
	
	// 3. Implement operators
	public static bool operator==(Point a, Point b) => a.Equals(b);
	public static bool operator!=(Point a, Point b) => !a.Equals(b);

	// 4. override hash code
	public override int GetHashCode()
	{
		return X * 31 + Y;
	}
}