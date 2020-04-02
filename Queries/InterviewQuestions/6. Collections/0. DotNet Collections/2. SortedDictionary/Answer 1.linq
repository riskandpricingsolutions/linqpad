<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

void Main()
{
	var st = new SortedDictionary<string, Product>()
	{
		{"Product3",new Product() {Id=3,Name="Product3"}},
		{"Product4",new Product() {Id=4,Name="Product4"}},
	};	
	
	// Lookup by key	
	WriteLine(st["Product3"]);
	
	// Lookup by index

}

public class ProductCollection : KeyedCollection<int, Product>
{
	protected override int GetKeyForItem(Product item) => item.Id;
}

public class Product
{
	public int Id { get; set; }

	public string Name { get; set; }

	public override string ToString() => $"{Id}, {Name}";
}
 