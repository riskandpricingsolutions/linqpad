<Query Kind="Program" />

double PriceProducts(IEnumerable<Product> products)
{
	double total = 0.0;
	
	foreach (var product in products)
	{
		if (product is Option)
			total += ((Option)product).PriceOption();
		if (product is VarSwap)
			total += ((VarSwap)product).PriceVarswap();
	}
	
	return total;
}

public class Product {}

public class Option : Product {
	public double PriceOption() =>  5.0;
}

public class VarSwap : Product
{
	public double PriceVarswap() => 5.0;
}

// Define other methods and classes here