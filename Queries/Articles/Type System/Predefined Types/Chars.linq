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
}	




// Define other methods and classes here