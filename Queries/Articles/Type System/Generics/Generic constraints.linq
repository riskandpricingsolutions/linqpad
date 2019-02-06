<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

public interface IInterface {}
public class MyClass {}

// 1. Base class constraint. T must be decendent of MyClass
public class BaseClassConstraint<T> where T : MyClass {}

// 2. Interface constraint. T must implement IInterface
public class InterfaceConstraint<T> where T : IInterface {}

// 3. Reference type constraint
public class ReferenceConstraint<T> where T : class {}

// 4. Value type constraint
public class ValueConstraint<T> where T : struct { }

// 5. Parameterless constructor constraint
public class ConstructorConstraint<T> where T : new() { }


public class Naked<T> 
{
	// 6. Naked constraint. One generic param must implement
	//    another
	public void NakedMethod<U>(U input) where U : T
	{
		
	}
}
