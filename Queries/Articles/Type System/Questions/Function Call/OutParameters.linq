<Query Kind="Program" />

void Main()
{
	int a = 4;
	ProvideOut2(out a);
}

public void ProvideOut2(out int x)
{
	x = 3;
}

public void ProvideOut(out int x)
{
	//Console.WriteLine(x);
	x = 3;
}

