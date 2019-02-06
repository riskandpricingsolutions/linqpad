<Query Kind="Program" />

void Main()
{
	Action[] actions = new Action[2];
	
	int outer = 0;
	for (int j = 0; j<2;j++)
	{
		int inner = 0;
		actions[j] = () => Console.WriteLine($"{outer++},{inner++}");
	}
	
	actions[0]();
	actions[0]();
	actions[0]();
	
	actions[1]();
	actions[1]();
}

// Define other methods and classes here