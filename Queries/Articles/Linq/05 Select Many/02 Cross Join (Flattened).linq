<Query Kind="Statements" />

IEnumerable<(int, string)> sOuter = new[] { (1, "one"), (2, "two"), };
IEnumerable<(int, string)> sInner = new[] { (1, "Ensimmäinen"), (1, "Ett") };

IEnumerable<((int, string), (int, string))> sOut = sOuter
	.SelectMany(elOut => sInner.Select(elIn => (Left:elOut, Right:elIn)));

sOut.Dump();