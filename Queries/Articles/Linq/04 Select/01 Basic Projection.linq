<Query Kind="Statements" />

IEnumerable<(int, string)> sIn = new[] { (1, "one"), (2, "two"), (3, "three") };

IEnumerable<int> sfOut = sIn.Select(i => i.Item1);

IEnumerable<int> sQOut = 
		from i in sIn 
		select i.Item1;

sfOut.Dump();
sQOut.Dump();
