<Query Kind="Program" />

void Main()
{
	var dict = new Dictionary<string,string> {
	
		{"Hello", "World"}
	};
	
	if (dict.TryGetValue("Hello", out string value))
		Console.WriteLine(value);
}

// You can define other methods, fields, classes and namespaces here
