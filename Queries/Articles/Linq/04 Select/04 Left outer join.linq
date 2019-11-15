<Query Kind="Statements" />


IEnumerable<(int, string)> sOuter = new[] { (1, "one"), (2, "two"), };
IEnumerable<(int, string)> sInner = new[] { (1, "Ensimmäinen"), (1, "Ett") };


IEnumerable<((int, string) Left, IEnumerable<(int, string)> Right)> sOut
	= sOuter.Select(outerEl =>
	{
		return (Left: outerEl, 
				Right: sInner.Where(innerEl => outerEl.Item1 == innerEl.Item1));
	});



sOut.Dump();