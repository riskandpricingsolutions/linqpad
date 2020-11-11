<Query Kind="Program" />

void Main()
{
	var big = new ABigStruct {
		
		A = 5,
		B = 6
	};
	
	DoIt(in big);
}	

public class ABigStruct {
	public int A { get; set; }
	public int B { get; set; }
}

public void DoIt(in ABigStruct a)
{
	a.Dump();
}
