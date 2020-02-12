<Query Kind="Program" />

void Main()
{
	MyExtensions.AreEqual(7,MinCoins(new int[] { 1,15, 35},55));
	MyExtensions.AreEqual(2,MinCoins(new int[] { 25,10, 5},30));
	MyExtensions.AreEqual(2,MinCoins(new int[] { 9,6,5,1},11));
	
}

// m is size of coins array  
// (number of different coins) 
static int MinCoins(int[] coinValues,
					int totalAmount)
{
	int m = coinValues.Length;
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
	for (int i = 1; i <= totalAmount; i++)
	{
		// Go through all coins 
		// smaller than i 
		for (int j = 0; j < m; j++)
		
			if (coinValues[j] <= i)
			{
				int coinValue = coinValues[j];
				
				// Table[i-coinValue] will hold the minimum number
				// of coins needed to represent i-coinValuel
				int sub_res = table[i - coinValue];
				
				if (sub_res != int.MaxValue &&
					sub_res + 1 < table[i])
					table[i] = sub_res + 1;
			}
	}
	return table[totalAmount];
}