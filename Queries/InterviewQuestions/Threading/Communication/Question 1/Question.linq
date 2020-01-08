<Query Kind="Program" />

void Main()
{
	// Question: Fix the below code so that it is impossible to write 0 to the console
}

public int value;
public bool isRead = false;

public void Write()
{
	value = 100;
	isRead = true;
}

public void Read()
{
	if (isRead)
		Console.WriteLine(value);
}
