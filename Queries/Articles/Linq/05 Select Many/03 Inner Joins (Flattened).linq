<Query Kind="Statements" />

var inseq1 = new[] { (1, "one"), (2, "two"), };
var inseq2 = new[] { (1, "Ensimmäinen"), (1, "Ett") };

IEnumerable<(int, string)> sOuter = new[] { (1, "one"), (2, "two"), };
IEnumerable<(int, string)> sInner = new[] { (1, "Ensimmäinen"), (1, "Ett") };

var sOut = sOuter.SelectMany(outerEl =>
	sInner
		.Where(innerEl => outerEl.Item1 == innerEl.Item1)
		.Select(inner => (outerEl, inner)));

sOut.Dump();