<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	Producer producer = new Producer();

	// Register First consumer
	producer.ValueChanged += x => WriteLine($"First {x}");
	
	// 1. Second consumer blows away first
	producer.ValueChanged = x => WriteLine($"Second {x}");
	
	//2. Consumer forcer producer to raise events
	producer.ValueChanged.Invoke(6.7);
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