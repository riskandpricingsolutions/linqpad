<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var names = new List<String> (new[] { "Kenny", "Wilson"});

// Query Syntax
IEnumerable<string> s1 =
	from 	n in names
	where 	n.StartsWith("W")
	orderby n
	select  n.ToUpper();

// Fluent Syntax
IEnumerable<string> s2 = 
	names
	.Where(n => n.StartsWith("W"))
	.OrderBy(n => n)
	.Select(n => n.ToUpper());
	
WriteLine(((IStructuralEquatable)s2.ToArray()).Equals(s1.ToArray(), EqualityComparer<string>.Default));