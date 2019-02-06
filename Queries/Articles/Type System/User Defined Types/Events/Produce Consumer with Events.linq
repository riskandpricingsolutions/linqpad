<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Producer producer = new Producer();
	producer.ValueChanged += (x,y) => WriteLine(y.NewValue);

	producer.Fire(4.5);
}

// 1. Create a subclass of EventArgs with a public 
//    readonly field for the new value
public class ValueChangedEventArgs : EventArgs
{
	public readonly double NewValue;
	
	public ValueChangedEventArgs(double newValue)
	{
		NewValue = newValue;
	}
}

public class Producer 
{
	// 2. Add an event using the generic EventHandler delegate
	//    type
	public event EventHandler<ValueChangedEventArgs> ValueChanged;
	
	// 3. Add a method called OnValueChanged that raised the event
	protected void OnValueChanged(ValueChangedEventArgs args)
	{
		ValueChanged?.Invoke(this,args);
	}
	
	public void Fire(double newValue)
	{
		OnValueChanged(new ValueChangedEventArgs(newValue));
	}
}