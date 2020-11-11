<Query Kind="Program">
  <Namespace>static System.Console</Namespace>
</Query>

void Main()
{
	WriteLine(Mean(4,2));
}

public double Mean(params int[] vals) 
	=> vals.Average();
