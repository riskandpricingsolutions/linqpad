<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

// Classes and structs can have nested classes, structs, 
// interfaces, delegates and enums
public class OuterMost
{
	private double x = 4.0;

	// Default visibility is private so not accessible outside
	enum Location { None, Left };

	// Make the innter struct visibile to the outside 
	public struct InnerStruct {};
}