<Query Kind="Program" />

void Main()
{
	ReferenceypeOnStack()
}

public void ReferenceypeOnStack()
{
	MyType x = new MyType();
	MyType y = new MyType();
}

class MyType
{
	private uint _val = 1;
}
