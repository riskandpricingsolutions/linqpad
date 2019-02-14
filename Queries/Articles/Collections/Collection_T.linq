<Query Kind="Program" />

void Main()
{
	
	IList<int> del = new List<int>();
	SpecialIntList list = new SpecialIntList(del);
	
	
}

public class SpecialIntList : System.Collections.ObjectModel.Collection<int>
{
	public SpecialIntList(IList<int> del) : base(del) {}

	
	protected override void InsertItem(int index, int item)
	{
		// Do some extra logic ...
		
		// Then call the base 
		base.InsertItem(index, item);
	}

	protected override void RemoveItem(int index)
	{
		// Pug in any extra logic then do the base
		base.RemoveItem(index);
	}
}

// Define other methods and classes here
