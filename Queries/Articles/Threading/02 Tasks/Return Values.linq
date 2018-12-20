<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Task<double> t = new Task<double>(() => F(4.0) );
	t.Start();
	double result = t.Result;
}


public double F(double x)
{
	return x * x;
}
// Define other methods and classes here
