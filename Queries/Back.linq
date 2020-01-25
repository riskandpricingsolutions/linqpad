<Query Kind="Program" />



//public static int MAXCANDIDATES = 2;
//public static int NMAX =3;

public  void Main()
{
	backtrack(new bool[2], -1, 2);
}

void process_solution(bool[] a, int k, int n)
{
	int i;              /* counter */

	Console.Write("{");
	for (i = 0; i <= k; i++)
		if (a[i])Console.Write($" {i+1}", i);

	Console.Write(" }");
	Console.WriteLine();
}

bool is_a_solution(bool[] a, int k, int n)
{
	return (k == (n-1));
}

void make_move(int[] a, int k, int n)
{
}

void unmake_move(int[] a, int k, int n)
{
}



/*	What are possible elements of the next slot in the permutation?  */

bool[] construct_candidates(bool[] a, int k, int n)
{
	bool[] c = new bool[2];
	c[0] = true;
	c[1] = false;
	return c;
}




void backtrack(bool[] candidateSolution, int k, int input)
{
	if (is_a_solution(candidateSolution, k, input))
		process_solution(candidateSolution, k, input);
	else
	{
		k++;
		bool[] nextElementSet = construct_candidates(candidateSolution, k, input );
		for (int i = 0; i < nextElementSet.Length; i++)
		{
			candidateSolution[k] = nextElementSet[i];

			backtrack(candidateSolution, k, input);
		}
	}
}
