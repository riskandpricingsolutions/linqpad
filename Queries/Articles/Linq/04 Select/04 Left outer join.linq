<Query Kind="Statements" />

var inseq1 = new[] { (1, "one"), (2, "two"),  };
var inseq2 = new[] { (1, "ensimmainen"),(1, "ett") };

var f1 = inseq1.Select(i =>
{
	return new {
		
		Left = i,
		Rigth = inseq2
					.Where(j => i.Item1 == j.Item1)
	};
	
});

f1.Dump();