<Query Kind="Program" />

void Main()
{
	var memo = new Dictionary<int,int>();
	MyExtensions.AreEqual(7,MinCoins(new int[] { 1,15, 35},55,memo));
//	MyExtensions.AreEqual(2,MinCoins(new int[] { 25,10, 5},30,memo));
//	MyExtensions.AreEqual(2,MinCoins(new int[] { 9,6,5,1},11,memo));
}

int numCalls;

// Question. Solve the minimum coins using Memoization
public int MinCoins(int[] coins, int amount, IDictionary<int,int> memo)
{
	// Terminating case that causes
	// recursion to bottom out.
	if (amount == 0) return 0;
	
	int minCoins = int.MaxValue;
	// Assume we have a one penny coin so we also have a solution
	for (int i = 0; i < coins.Length; i++)
	{
		int newAmount = amount - coins[i];
		
		if (newAmount >=0)
		{
			int requiredCoins;
			if (!memo.TryGetValue(newAmount,out requiredCoins))
			{
				memo[newAmount] =  MinCoins(coins, newAmount,memo);
			}
			
			minCoins = Math.Min(minCoins,requiredCoins);
		}			
	}
	
	return minCoins +1;
}