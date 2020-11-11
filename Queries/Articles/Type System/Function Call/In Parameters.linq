<Query Kind="Program" />

void Main()
{
	InParams();
}

public void InParams()
{
	var a  = new ClassType() {A=1};
	var b = new Struct() {A=1};;
	C(in a, in b);
	a.Dump();
	b.Dump();
}

public class ClassType {
	public int A { get; set; }
}

public class Struct
{
	public int A { get; set; }
}

private void C(in ClassType x, in Struct y)
{
	// No error
	x.A = 2;
	
	//
	y.A = 4;
}
