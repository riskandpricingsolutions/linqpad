<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var names = new List<String> (new[] { "Kenny", "Wilson"});

// Query Syntax
IEnumerable<char> q1 =
	from 	n in names
	from 	c in n
	select  c;

// Fluent Syntax
IEnumerable<char> f1 = 
	names.SelectMany(n => n);
	
	
WriteLine(((IStructuralEquatable)q1.ToArray()).Equals(f1.ToArray(), EqualityComparer<char>.Default));