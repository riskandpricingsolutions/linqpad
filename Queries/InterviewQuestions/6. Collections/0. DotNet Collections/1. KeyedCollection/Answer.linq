<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
</Query>

void Main()
{
	var keyedCollection = new ProductCollection()
	{
		new Product() {Id=3,Name="Product3"},
		new Product() {Id=4,Name="Product4"},
	};	
	
	// Lookup by key	
	WriteLine(keyedCollection[3].ToString());
	
	// Lookup by index
	WriteLine(keyedCollection.ElementAt(1).ToString());
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
 