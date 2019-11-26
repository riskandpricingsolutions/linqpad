<Query Kind="Statements" />

IEnumerable<(int, string)> sIn = new[] { (1, "one"), (2, "two"), (3, "three") };

<<<<<<< HEAD
// Projecting in fluent syntax
IEnumerable<int> sOut = sIn.Select(i => i.Item1);

// Projecting in query syntax
var sOut2 =
	from i in sIn
	select i.Item1;

sOut.Dump();
sOut2.Dump();
=======
IEnumerable<int> sfOut = sIn.Select(i => i.Item1);

IEnumerable<int> sQOut = 
		from i in sIn 
		select i.Item1;

sfOut.Dump();
sQOut.Dump();
>>>>>>> ef99fbdca054f5fa881f03d470bfbdf92abbc820
