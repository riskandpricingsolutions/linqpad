<Query Kind="Program" />

void Main()
{
	Option option = new Option();	
}

public interface IPriceable {}

public class Option :  IPriceable
{
	private static double _as = 2.0;
	private double _strike;
	private DateTime _expiry;
	
	public void Price() {}
	public void Reset() {}
}

// Define other methods and classes here
