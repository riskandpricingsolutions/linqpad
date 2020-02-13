<Query Kind="Program" />

void Main()
{
	var coins = new int[] { 1,15, 35};
	var s1 = MinCoins(coins,55);
	for (int i = 0; i < coins.Length; i++)
	{
		Console.Write($"{s1[i]}x{coins[i]}, ");
	}
}

// m is size of coins array  
// (number of different coins) 
static int[] MinCoins(int[] coins,
					int totalAmount)
{
	// Maintain a separate two dimensional array to
	// track the actual coins that make up the solution and not just 
	// the number of coins.
	int[][] actualCoins = new int[totalAmount+1][];
	for (int i = 0; i <= totalAmount; i++) actualCoins[i] = new int[coins.Length];
	
	
	int numCoins = coins.Length;
	// table[i] will be storing  
	// the minimum number of coins 
	// required for i value. So  
	// table[V] will have result 
	int[] table = new int[totalAmount + 1];

	// Base case (If given 
	// value V is 0) 
	table[0] = 0;

	// Initialize all table 
	// values as Infinite 
	for (int i = 1; i <= totalAmount; i++)
		table[i] = int.MaxValue;

	
	// Compute minimum coins  
	// required for all 
	// values from 1 to V 
	for (int amount = 1; amount <= totalAmount; amount++)
	{
		// We have to find the minimum number of coins with
		// which we can represent amount
		for (int coinIdx = 0; coinIdx < numCoins; coinIdx++)
		{
			int coin = coins[coinIdx];
			
			// The current coin is only considered if it is less
			// that or equal to the amount we need to achieve
			if (coin <= amount)
			{
				for (int t = 0; t < coins.Length; t++)
					actualCoins[amount][t] = actualCoins[amount-coin][t];
				actualCoins[amount][coinIdx] = actualCoins[amount][coinIdx]+1;
			
				// What is the minimum number of coins needed to
				// represent amount-coin? Since this amount is 
				// by definition less than amount it must already
				// be in the table. We just look it up
				int numCoinsForAmountLessCoin = table[amount - coin];
				
				// Only update this entry if they was no better strategy 
				
				if (numCoinsForAmountLessCoin + 1 < table[amount])
					table[amount] = numCoinsForAmountLessCoin + 1;
			}
		}
	}
	return actualCoins[totalAmount];
}