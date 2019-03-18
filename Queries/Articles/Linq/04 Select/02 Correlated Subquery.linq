<Query Kind="Statements" />

// Select - Basic Projection
//----------------------------------------------------------------------

var inseq1 = new[] { "Hello World", "Moi Vaimoni", "Miten menee"};

//var q1 = inseq1.Select(i => i.Split().Select(i => ));

var q1 =
	from i in inseq1
	select new 
	{ 
		Words =  
			from j in i.Split()
			select j
	};

var f1 = inseq1
		.Select(i => new 
		{
			Words = i.Split()
					 .Select(j => j)
		});


q1.Dump();
f1.Dump();