<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
</Query>

var names = new List<String> (new[] { "Wren", "Bill", "Bob", "Will" });

// Query Syntax
IEnumerable<int> result = from 	n in names select  n.Length


// Fluent Syntax
IEnumerable<int> s2 = names.Select(n => n.Length);

	
WriteLine(((IStructuralEquatable)s2.ToArray()).Equals(result.ToArray(), EqualityComparer<string>.Default));