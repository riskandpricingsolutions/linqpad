<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// A char is a 2 byte unicode value
	// The exclamation mark has the hex 
	// value 0x0021 or decimal 33
	var c = '!';
	
	
	
	char ö = 'ö';
	
	
	
	// Escape sequences begin with a backslash
	char escape1 = '\n';
	
	char escape2 = '\u03Aa';
	
	// Backslashes need to be prefixed with a backslash
	char backslash = '\\';
	
	// A String is a immutable sequence of unicode characters.
	string finishWord = "Äiti";

	
	
	// Equality is value like even though string are reference types
	string one = "Hello";
	string two = "Hello";
	WriteLine(one == two);
	
	// Inside double quotes we can use escape sequences
	string twoLines = "one \n two";
	WriteLine(twoLines);
	
	// For this reason a backslash need to be itself escapes
	string escapedBackSlash = "\\\\";
	WriteLine(escapedBackSlash);
	
	// A verbatic string does not need to be esacaped
	string verbatimOne = @"\\";
	WriteLine(verbatimOne);
	
	// We can use double quotes in verbatim strings by 
	// entering them twice
	string verbatimTwo = @"<root attribute=""b""/>";
	WriteLine(verbatimTwo);
	
	// Verbatim strings can span lines
	string verbatimThree = 
@"<root attribute=""b"">
  <sub>
</root>";
	WriteLine(verbatimThree);

	// C# 6.0 String interpolation
	WriteLine($"{3*4}");
	
	// Curly braces in interpolated string. Enter each brace twice
	WriteLine($"{{{3*4}}}");

	// Interpolated verbatim string
	WriteLine($@"\\{3 * 4}");
	
	string a =Console.ReadLine();
	string b =Console.ReadLine();
}



// Define other methods and classes here
