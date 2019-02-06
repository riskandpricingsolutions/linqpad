<Query Kind="Program" />



void Main()
{
	Thread t1 = new Thread(this.ThreadBodyA);
	Thread t2 = new Thread(this.ThreadBodyB);

	t1.Start();
	t2.Start("Test Message");

}


public void ThreadBodyA() { }
public void ThreadBodyB(object message) { }

// Define other methods and classes here
