<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	var myAddress = (23,"Worple Road");
	
	var a1 = (23,"Worple Road");
	var a2 = a1;
	a2.Item1 = 46;
	WriteLine(a1); // (23, "Worple Road");

	(int, string) GetAddress() => (23, "Worple Road");
	(int, string) address = GetAddress();
	WriteLine(address);
	
	// Generics and tuple types
	IList<(int,string)> l = new List<(int, string)>()
	{
		(23,"Worple Road"),
		(46,"Worple Road")
	};
	
	// Naming tuple elements
	var a3 = (Number:1,Road:"Worple Road");
	WriteLine( a3.Number); // 1
	
	(int Number, string Road) a4 = (Number:1,Road:"Worple Road");
	(int Number, string Road) a5 = (2,"Worple Road");
	
	// Deconstructing a tuple
	(int Number, string Road) a6 = (2,"Worple Road");
	(int num, string rd) = a5;
	WriteLine(rd);
	
	// Tuples use value equality on both operator and method
	(int Number, string Road) a7 = (2,"Worple Road");
	(int Number, string Road) a8 = (2,"Worple Road");
	WriteLine(Object.ReferenceEquals(a7,a8)); // false 
	WriteLine(a7 == a8); // true
	WriteLine(a7.Equals(a8)); // true 
}



// Define other methods and classes here