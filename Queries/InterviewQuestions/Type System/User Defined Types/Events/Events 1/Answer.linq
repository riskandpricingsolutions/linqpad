<Query Kind="Program">
  <Namespace>log4net</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Question:	Implement an event called PriceChanged in the class Asset
//				such that the following code in Main compiles. Use the .NET
//				standard event pattern but write you own delegate and logic to 
//              back the += and -=. Do not use let the compiler do it for you.
//				You will also need to create PriceChangedEventArgs

void Main()
{
	Asset a = new Asset();
	a.PriceChanged += (source, args) => WriteLine($"Event raised {args.NewPrice}");
	a.Fire();
}

// 1. Define a subclass of EventArgs and add old and new prices
public class PriceChangedEventArgs : EventArgs
{
	public readonly double OldPrice;
	public readonly double NewPrice;
	
	public PriceChangedEventArgs(double oldPrice, double newPrice)
	{
		NewPrice = newPrice;
		OldPrice = oldPrice;
	}
}

public class Asset
{
	// 2. Create a private delegate of the type EventHandler
	private EventHandler<PriceChangedEventArgs> _delegate;
	
	// 3. Implement the event by creating add and remove
	public event EventHandler<PriceChangedEventArgs> PriceChanged
	{
		add {_delegate += value;}
		remove {_delegate -= value;}
	}
	
	// 4. Add a protected OnPriceChanged method to raise the event
	protected void OnPriceChanged(PriceChangedEventArgs args)
		=> _delegate?.Invoke(this, args);

	public void Fire() 
	{
		OnPriceChanged(new PriceChangedEventArgs(4.0,5.0));
	}
}

