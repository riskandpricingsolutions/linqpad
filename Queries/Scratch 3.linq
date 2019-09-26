<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static void Main()
{
        char[]objectSet = {'A','B','C','D','E',}; 
        int r = 3; 
        int n = objectSet.Length; 
        printCombination(objectSet, n, r); 

}

// The main function that prints 
// all combinations of size r 
// in arr[] of size n. This  
// function mainly uses combinationUtil() 
static void printCombination<T>(T[] objectSet,
							 int n, int r)
{

	T[] combination = new T[r];


	combinationUtil(
		objectSet:objectSet,
		combination: combination,
		firstObjectIdx: 0,
		lastObjectIdx: n-1,
		combinationIdx:0,
		r:r);
}


static void combinationUtil<T>(T[] objectSet, T[] combination,
							int firstObjectIdx, int lastObjectIdx,
							int combinationIdx, int r)
{
	// Current combination is  
	// ready to be printed,  
	// print it 
	if (combinationIdx == r)
	{
		for (int j = 0; j < r; j++)
			Console.Write(combination[j] + " ");
		Console.WriteLine("");
		return;
	}

	for (int objectIdx = firstObjectIdx; objectIdx <= lastObjectIdx ; objectIdx++)
	{
		combination[combinationIdx] = objectSet[objectIdx];
		
		combinationUtil(			
			objectSet:objectSet,
			combination: combination,
			firstObjectIdx:objectIdx + 1,
			lastObjectIdx:lastObjectIdx,
			combinationIdx:combinationIdx + 1, 
			r:r);
	}
}