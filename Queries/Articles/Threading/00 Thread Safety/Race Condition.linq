<Query Kind="Program" />

void Main()
{
	
}

public class Account
{
	private double _balance = 0.0;
	
	public void MakeDeposit(double newAmount)
	{
		double balance = _balance;
		balance += newAmount;
		_balance =balance;
	}
}
