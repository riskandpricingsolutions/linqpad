<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(7,MinCoins(new int[] { 1,15, 35},55));
//	MyExtensions.AreEqual(2,MinCoins(new int[] { 25,10, 5},30));
//	MyExtensions.AreEqual(2,MinCoins(new int[] { 9,6,5,1},11));
}

int callCount;

// Question. Solve the minimum coins probablem using a greedy algorithm.
public int MinCoins(int[] coins, int amount)
{
	callCount++;
	
	// Terminating case that causes
	// recursion to bottom out.
	if (amount == 0) return 0;

	int minCoins = int.MaxValue;

	// Assume we have a one penny coin so we also have a solution
	for (int i = 0; i < coins.Length; i++)
	{
		int newAmount = amount - coins[i];
		if (newAmount >= 0)
		{
			minCoins =
				Math.Min(minCoins, MinCoins(coins, newAmount));
		}

	}

	return minCoins + 1;
}
