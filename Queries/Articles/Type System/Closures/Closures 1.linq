<Query Kind="Program" />

void Main()
{
	Action[] actions = new Action[3];
	
	for(int i = 0; i < 3; i++)
	{
		actions[i] = () => Console.Write(i);
	}
	
	foreach (var action in actions)
	{
		action();
	}
}

// Define other methods and classes here
