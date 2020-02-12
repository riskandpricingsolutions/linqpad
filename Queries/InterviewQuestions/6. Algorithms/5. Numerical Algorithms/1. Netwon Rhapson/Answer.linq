<Query Kind="Program" />

void Main()
{
	double r= Solve( x=> x*x, x=> 2*x,1.0, 2.0);
}

// Question: Implement Newton Rhapson

public double Solve(Func<double,double>f, Func<double,double> fd, 
	double initialGuess, double c)
{
	Func<double,double> g = r => f(r)-c;
	double x = initialGuess;
	
	double y = g(x);
	double error = 0.0000001;
	
	while (Math.Abs(y) > error)
	{
		x = x - (y/fd(x));
		y = g(x);
	}
	
	return x;
}
