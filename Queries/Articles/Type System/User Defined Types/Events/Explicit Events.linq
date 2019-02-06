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
	private EventHandler<ValueChangedEventArgs> _delegate;
	
	public event EventHandler<ValueChangedEventArgs> ValueChanged
	{
		add {_delegate += value;}
		remove {_delegate -= value;}
	}

	// 3. Add a method called OnValueChanged that raised the event
	protected void OnValueChanged(ValueChangedEventArgs args)
	{
		_delegate?.Invoke(this,args);
	}
	
	public void Fire(double newValue)
	{
		OnValueChanged(new ValueChangedEventArgs(newValue));
	}
}