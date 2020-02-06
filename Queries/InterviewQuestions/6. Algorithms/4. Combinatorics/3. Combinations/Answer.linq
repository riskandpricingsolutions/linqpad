<Query Kind="Program" />

void Main()
{
	GeneratePermutations(new int[] {1,2,3,4,5},new int[3],0,0, a=>PrintCombination(a));
}


public void GeneratePermutations(int[] set, 
							int[] combination,
							int combinationIdx,
							int firstSetIdx,
							Action<int[]> visit)
{
	if (combinationIdx == combination.Length)
	{
		visit(combination);
		return;
	}

	for (int setIdx = firstSetIdx; setIdx < set.Length ; setIdx++)
	{
		combination[combinationIdx] = set[setIdx];
		
		GeneratePermutations(set, combination,combinationIdx + 1, setIdx + 1
			,visit);
	}
}

public static void PrintCombination(int[] combination)
{
	for (int j = 0; j < combination.Length; j++)
		Console.Write(combination[j] + " ");
	Console.WriteLine("");
	return;
}


//1 2 3
//1 2 4
//1 2 5
//1 3 4
//1 3 5
//1 4 5
//2 3 4
//2 3 5
//2 4 5
//3 4 5