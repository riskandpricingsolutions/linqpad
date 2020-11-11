<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	// Create tuple
	var tuple = (name: "Kenny", age:45);
	WriteLine(tuple);
	
	// Deconstruct tuple
	var (nm, ag) = tuple;
	WriteLine(nm);
	
	WriteLine(GetPerson().age);
}


static (int age, string name) GetPerson() => (45,"kenny");