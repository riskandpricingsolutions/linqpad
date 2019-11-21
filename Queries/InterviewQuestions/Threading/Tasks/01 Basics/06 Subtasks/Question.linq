<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// Question: Given the variable forward extract its integer result

	Task<double> GetSpot() => Task.Run(() => 100.0);
	Task<double> GetForward(double spot) => Task.Run(() => spot * Math.Exp(0.1));

	Task<Task<double>> forward = GetSpot()
		.ContinueWith(x => GetForward(x.Result));
}
