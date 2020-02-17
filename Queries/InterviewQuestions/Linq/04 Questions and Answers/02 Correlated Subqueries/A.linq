<Query Kind="Statements" />


var sIn = new[] { "Hello World", "Moi Vaimoni", "Miten menee"};
	
var f = sIn.Select(i => i.Split());
f.Dump();
	
var q =from n in sIn select n.Split();
q.Dump();
	
