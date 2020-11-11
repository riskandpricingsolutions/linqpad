<Query Kind="Program" />

void Main()
{
	int[] a = new[] {1,2,3};
	DoSomeThing(a.AsSpan(1,2));
	a.Dump();
}

void DoSomeThing(Span<int> s)
{
	s[0] = 5;
}
