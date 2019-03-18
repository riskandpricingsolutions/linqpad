<Query Kind="Program" />

void Main()
{
	int[] x = {3,4,5};
	int[] y = {3,4,5};
	((IStructuralEquatable)x)
		.Equals(y,EqualityComparer<int>.Default);
}

// Define other methods and classes here
