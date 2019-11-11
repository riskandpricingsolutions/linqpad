<Query Kind="Program" />

void Main()
{
	// Question: Show how the following fluent query maps to query
	var names = new[] { "Wren", "Bill", "Bob", "Will" };
	var f = names.Select(n => n.Length);
	
	var q = from n in names select n.Length;
}