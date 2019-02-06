<Query Kind="Program" />

void Main()
{
	PassbyRef()
}

public void PassbyRef()
{
	uint a = 4;
	uint b = 5;
	C(ref a, out b);
}

private void C(ref uint u, out uint u1)
{
	u1 = 10;
}
