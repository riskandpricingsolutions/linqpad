<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>log4net</Namespace>
</Query>

static void Main()
{
	foreach (int[] c in FindCombinations(2, 3))
	{
		for (int i = 0; i < c.Length; i++)
		{
			
			Console.Write(c[i] + " ");
		}
		Console.WriteLine();
	}
}

public static IEnumerable<int[]> FindCombosRec(int[] buffer, int done, int begin, int end)
{
	for (int i = begin; i < end; i++)
	{
		buffer[done] = i;

		if (done == buffer.Length - 1)
			yield return buffer;
		else
			foreach (int[] child in FindCombosRec(buffer, done + 1, i + 1, end))
				yield return child;
	}
}

public static IEnumerable<int[]> FindCombinations(int m, int n)
{
	return FindCombosRec(new int[m], 0, 0, n);
}

