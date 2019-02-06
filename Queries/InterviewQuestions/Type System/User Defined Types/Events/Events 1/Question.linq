<Query Kind="Program">
  <Namespace>log4net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Question:	Implement an event called PriceChanged in the class Asset
//				such that the following code in Main compiles. Use the .NET
//				standard event pattern but write you own delegate and logic to 
//              back the += and -=. Do not use let the compiler do it for you.
//				You will also need to create PriceChangedEventArgs

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	Asset a = new Asset();
	a.PriceChanged += (source, args) => logger.Info($"Event raised {args.NewPrice}")
	a.Fire();
}

public class PriceChangedEventArgs
{
	
}

public class Asset
{

}

// Define other methods and classes here