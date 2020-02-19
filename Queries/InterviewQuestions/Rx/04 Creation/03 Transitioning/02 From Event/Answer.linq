<Query Kind="Program">
  <NuGetReference>System.Reactive</NuGetReference>
  <Namespace>log4net</Namespace>
  <Namespace>log4net.Core</Namespace>
  <Namespace>static System.Console</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
</Query>

static ILog logger = LogManager.GetLogger(nameof(Main));

void Main()
{
	MyExtensions.SetupLog4Net();

	EventSource s = new EventSource();

	// Question: Transition from an EventHandler event
	Observable.FromEventPattern(o => s.MyEventHandlerEvent+=o,o=>s.MyEventHandlerEvent-=o)
		.Subscribe(o => WriteLine($"OnNext({o.EventArgs})"),()=>WriteLine("OnCompleted()"));		
	s.DeliverEventHandlerEvent();

	// Question: Transition from EventHandler<T> event
	Observable.FromEventPattern<MyEventArgs>(o => s.MyEventHandlerEvent2 += o, o => s.MyEventHandlerEvent2 -= o)
	.Subscribe(o => WriteLine($"OnNext({o.EventArgs.MyValue})"),() => WriteLine("OnCompleted()"));
	s.DeliverEventHandlerEvent2("Hello");
}

public class MyEventArgs : EventArgs
{
	public string MyValue { get; set;}
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