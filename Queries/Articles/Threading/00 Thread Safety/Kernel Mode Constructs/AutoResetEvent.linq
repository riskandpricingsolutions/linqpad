<Query Kind="Statements">
  <Namespace>log4net</Namespace>
</Query>

ILog logger = LogManager.GetLogger("Main");


MyExtensions.SetupLog4Net();
AutoResetEvent e = new AutoResetEvent(initialState: false);

Action work = () =>
{
	// Simulate some work this thread is doing
	Thread.Sleep(1000);
	logger.Info($"Calling WaitOne");

	// Now wait for notification from another thread
	// that we can complete
	e.WaitOne();

	// Simulate some more work 
	logger.Info("Running");
	Thread.Sleep(5000);
};

new Thread(()=> work()).Start();
new Thread(()=> work()).Start();

// Main thread does some work
Thread.Sleep(5000);
logger.Info("Calling Set to Signal ARE");

// Main thread notifies one background thread
e.Set();

// Main thread does some work
Thread.Sleep(5000);
Thread.Sleep(2000);

// Main thread notifies one background thread
logger.Info("Calling Set to Signal ARE");
e.Set();

