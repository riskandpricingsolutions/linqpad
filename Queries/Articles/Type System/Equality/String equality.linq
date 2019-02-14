<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{

	string a = new string('*',4);
	string b = new string('*',4);
	string c = a;
	
	WriteLine(Object.ReferenceEquals(a,b)); // false
	WriteLine(a==b); // true
	WriteLine(a.Equals(b)); // true
	
}

