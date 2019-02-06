<Query Kind="Program" />

void Main()
{
	SomeClass2 s = new SomeClass2(); 
}


public delegate void strdel(string str);

public class SomeClass
{
	public event strdel MyEvent;

}

public class SomeClass2
{
	private strdel MyEvent;

	public void add_MyEvent(strdel del) =>
		MyEvent = (strdel)Delegate.Combine(MyEvent, del);

	public void remove_MyEvent(strdel del) =>
		MyEvent = (strdel)Delegate.Remove(MyEvent, del);

	public void Fire()
	{
		strdel delA = new strdel(this.MyEvent);
		Delegate[] dels = delA.GetInvocationList();

		foreach (strdel del in dels)
		{
			try
			{
				del("Test");
			}
			catch (Exception ex) { }
		}
	}
}

// Define other methods and classes here