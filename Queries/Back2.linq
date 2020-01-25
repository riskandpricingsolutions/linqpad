<Query Kind="Program" />



//public static int MAXCANDIDATES = 2;
//public static int NMAX =3;

public void Main()
{
	int[] set = { 2, 9, 5 };

	BackTrack(new bool[set.Length],new bool[] {true,false},0, (s,k)=> s.Length == k, (sv,k) => 
	{
		var sb = new StringBuilder("{");
		for (int i = 0; i < sv.Length; i++)
		{
			if (sv[i]) sb.Append(set[i] + " ");
		}
		sb.Append("}");
		Console.WriteLine(sb.ToString());
	});
}



void BackTrack<TElement>(
	TElement[] solutionVector, 
	TElement[] elementSet, 
	int k,
	Func<TElement[],int,bool> isSolution,
	Action<TElement[],int> processSolution)
{
	if (isSolution(solutionVector, k))
		processSolution(solutionVector, k);
	

	if ()

		for (int i = 0; i < elementSet.Length; i++)
		{
			solutionVector[k] = elementSet[i];

			BackTrack(solutionVector,elementSet, k+1,isSolution,processSolution);
		}
	}
}
