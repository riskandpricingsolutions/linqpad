<Query Kind="Statements" />

// Question: Makes the folllwing code thread safe
for (int i = 0; i < 10; i++)
{
	new Thread(() => Console.Write(i)).Start();
}
Console.WriteLine();

// Answer:
