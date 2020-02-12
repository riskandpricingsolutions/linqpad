<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(7,MinCoins(new int[] { 1,15, 35},55));
	MyExtensions.AreEqual(2,MinCoins(new int[] { 25,10, 5},30));
	MyExtensions.AreEqual(2,MinCoins(new int[] { 9,6,5,1},11));
	
}

public int MinCoins(int[] coins, int amount)
{
	if (amount == 0) return 0;
	
	int minNumber = int.MaxValue;
	
	for (int i = 0; i < coins.Length; i++)
	{
		if (amount - coins[i] >= 0) 
		{
			int minCoins = MinCoins(coins,amount-coins[i]);
			if (minCoins < minNumber)
				minNumber = minCoins;
		}
	}
	
	return minNumber+1;
}
