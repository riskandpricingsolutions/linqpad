<Query Kind="Program" />

void Main()
{

}


public abstract class Parser
{
	private HashSet<CallPoint> visitedCallPoints = new HashSet<UserQuery.CallPoint>();
	public void Parse(string mainFile)
	{
		Method root = GetMainMethod(mainFile);
		BuildSubGraph(root);
	}

	public void BuildSubGraph(Method parentMethod)
	{
		parentMethod.CallPoints = GetCallPoints(parentMethod);
		foreach (var callPoint in parentMethod.CallPoints)
		{
			if (!visitedCallPoints.Contains(callPoint))
			{
				visitedCallPoints.Add(callPoint);
				Method[] matchingMethods = ResolveMethods(callPoint);
				callPoint.ResolvedMethods = matchingMethods;

				foreach (var matchingMethod in callPoint.ResolvedMethods)
				{
					BuildSubGraph(matchingMethod);
				}
			}
		}
	}
	
	public IEnumerable<Type> GetUncaughtExceptions(Method m)
	{
		var uncaughtExceptions = new HashSet<Type>();
		
		if ( m.CallPoints == null) return uncaughtExceptions;
		
		foreach (var callPoint in m.CallPoints)
		{
			var methods = callPoint.ResolvedMethods;
			var caught = callPoint.CaughtExceptions;
			
			foreach( Method resolvedMethod in callPoint.ResolvedMethods)
			{
				var caleeExceptions = GetUncaughtExceptions(resolvedMethod);
				foreach(Type ex in caught)
				{
					if (caught.Contains(ex))
						uncaughtExceptions.Add(ex);
				}		
			}
		}
		
		return uncaughtExceptions;
	}

	public abstract Method GetMainMethod(string mainFile) ;
	
	public abstract CallPoint[] GetCallPoints(Method callingMethod);
	
	public abstract Method[] ResolveMethods(CallPoint callPoint);
}


public class Method
{
	public CallPoint[] CallPoints { get; set; }
	public Type[] ThrowExceptions {get;set;}
}

public class CallPoint
{
	public Type[] CaughtExceptions { get; set; }
	public Method[] ResolvedMethods { get; set; }
}

public class MainClass
{
	public void Main()
	{
		ClassA a = new ClassA();
		a.CalssAOne();
	}
}



class ClassB
{
	public void MethodBOne() => throw new ArgumentException();

	public void MethodBTwo2() => throw new InvalidOperationException();
}

class ClassA 
{
	ClassB b = new ClassB();
	
	
	public void CalssAOne()
	{
		try
		{
			b.MethodBTwo2();
		}
		catch (InvalidOperationException a) {}
		
		b.MethodBOne();	
	}
}
