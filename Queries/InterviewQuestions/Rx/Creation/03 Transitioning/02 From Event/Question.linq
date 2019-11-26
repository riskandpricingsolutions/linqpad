<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	EventSource s = new EventSource();

	// Question: Transition from an EventHandler event

	// Question: Transition from EventHandler<T> event
}

public class MyEventArgs : EventArgs
{
	public string MyValue { get; set; }
	public MyEventArgs(string value)
	{
		MyValue = value;
	}
}

public class EventSource
{
	public event EventHandler MyEventHandlerEvent;

	public event EventHandler<MyEventArgs> MyEventHandlerEvent2;

	public void DeliverEventHandlerEvent()
	{
		MyEventHandlerEvent(this, new EventArgs());
	}

	public void DeliverEventHandlerEvent2(string value)
	{
		MyEventHandlerEvent2(this, new MyEventArgs(value));
	}
}