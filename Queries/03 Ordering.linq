<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var names = new List<String> (new[] { "Wren", "Bill", "Bob", "Will" });

// Query Syntax
IEnumerable<string> s1 =
	from 	n in names
	orderby n.Length,n
	select  n.ToUpper();

// Fluent Syntax
IEnumerable<string> s2 = 
	names
	.OrderBy(n => n.Length)
	.ThenBy(n => n)
	.Select(n => n.ToUpper());


IEnumerable<string> s3 =
	from n in names
	orderby n.Length descending, n descending
	select n.ToUpper();
	
WriteLine(((IStructuralEquatable)s2.ToArray()).Equals(s1.ToArray(), EqualityComparer<string>.Default));