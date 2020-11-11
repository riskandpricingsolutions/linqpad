<Query Kind="Program" />

void Main()
{
	var (nm, street) = new Address();
	Console.WriteLine(nm);
}

class Address
{
	public void Deconstruct(out int number, out string street )
	{
		number = 45;
		street = "North Road";
	}
}