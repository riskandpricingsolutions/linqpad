<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(7,MinCoins(new int[] { 1,15, 35},55));
	MyExtensions.AreEqual(2,MinCoins(new int[] { 25,10, 5},30));
	MyExtensions.AreEqual(2,MinCoins(new int[] { 9,6,5,1},11));
	
}

// m is size of coins array  
// (number of different coins) 
static int MinCoins(int[] coins,
					int totalAmount)
{
	int numCoins = coins.Length;
	
	// Initialize the table
	int[] table = new int[totalAmount+1];
	table[0] = 0;
	for (int i = 1; i < table.Length; i++) table[i] = int.MaxValue;
	
	for (int amount = 1; amount <= totalAmount; amount++)
	{
		for (int coinIdx = 0; coinIdx < coins.Length; coinIdx++ )
		{
			int coin = coins[coinIdx];
			
			if ( coin <= amount)
			{
				int numForAmountLessCoin = table[amount-coin];
				
				if (numForAmountLessCoin + 1 < table[amount])
					table[amount] = numForAmountLessCoin + 1;
			}
		}
		
	}

	return table[totalAmount];
}