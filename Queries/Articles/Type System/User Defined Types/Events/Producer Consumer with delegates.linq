<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Producer producer = new Producer();

	// Register First consumer
	producer.ValueChanged += x => WriteLine($"First {x}");
	
	// Register Second consumer
	producer.ValueChanged += x => WriteLine($"Second {x}");
	
	// Producer does something
	producer.Fire();
}


public  delegate void ValueChangedEventHandler(double newValue);

public class Producer 
{
	public ValueChangedEventHandler ValueChanged;
	
	protected void OnValueChanged(double newValue)
	{
		ValueChanged?.Invoke(newValue);
	}
	
	public void Fire() => OnValueChanged(3.4);
}