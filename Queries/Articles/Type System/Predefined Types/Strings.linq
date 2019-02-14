<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// A String is a immutable sequence of unicode characters.
	String finishWord = "Äiti";

	// Equality is value like even though string are reference types
	String one = "Hello";
	String two = "Hello";
	WriteLine(one == two);

	// Inside double quotes we can use escape sequences
	String twoLines = "one \n two";
	WriteLine(twoLines);

	// For this reason a backslashs need to be itself escaped
	String escapedBackSlash = "\\\\";
	WriteLine(escapedBackSlash);

	// A verbatic string does not need to be esacaped
	String verbatimOne = @"\\";
	WriteLine(verbatimOne);

	// We can use double quotes in verbatim strings by 
	// entering them twice
	String verbatimTwo = @"<root attribute=""b""/>";
	WriteLine(verbatimTwo);

	// Verbatim strings can span lines
	String verbatimThree = @"
	<root attribute=""b"">
	  <sub>
	</root>";
	WriteLine(verbatimThree);

	// C# 6.0 String interpolation
	WriteLine($"{3 * 4}");

	// Curly braces in interpolated string. Enter each brace twice
	WriteLine($"{{{3 * 4}}}");

	// Interpolated verbatim string
	WriteLine($@"\\{3 * 4}");

	String a = Console.ReadLine();
	String b = Console.ReadLine();
}
