<Query Kind="Program" />

void Main()
{
	Action a = GetAction();
	a();
	a();
}

public static Action GetAction()
{	
	int i = 5;
	return () => Console.WriteLine(++i);
}

// Define other methods and classes here