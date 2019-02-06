<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

// Generic class
public class GenericClass<T> { }

// Generic interface
public interface IGenericInterface<T> { }

// Generic struct
public struct GenericStruct<T> { }

// Generic delegate
public delegate TOut GenericDelegate<TIn,TOut>(TIn param);

public class ClassWithGenericMethod
{
	// Generic method
	public void Swap<T>(T a, T b) { }
}