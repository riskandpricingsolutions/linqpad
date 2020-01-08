<Query Kind="Program" />

void Main()
{
	
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
