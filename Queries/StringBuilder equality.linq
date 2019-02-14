<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{

	StringBuilder a =  new StringBuilder("Hello");
	StringBuilder b =  new StringBuilder("Hello");
	
	WriteLine(Object.ReferenceEquals(a,b)); // false
	WriteLine(a==b); // false
	WriteLine(a.Equals(b)); // true
}