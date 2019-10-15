<Query Kind="Program" />

void Main()
{
	//var res = maxXor(new[] { 0, 1, 2 }, new[] {3,7,2});
	Main2(null);
}

static void Main2(string[] args)
{
	//TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);


	FileStream f = new FileStream(@"C:\Users\rps\OneDrive\Code\hackerrank\maxxor\input04.txt", FileMode.Open);

	TextReader r = new StreamReader(f);


	int n = Convert.ToInt32(r.ReadLine());

	int[] arr = Array.ConvertAll(r.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
	;
	int m = Convert.ToInt32(r.ReadLine());

	int[] queries = new int[m];

	for (int i = 0; i < m; i++)
	{
		int queriesItem = Convert.ToInt32(r.ReadLine());
		queries[i] = queriesItem;
	}

	int[] result = maxXor(arr, queries);


	int[] expected = File.ReadAllText(@"C:\Users\rps\OneDrive\Code\hackerrank\maxxor\output04.txt")
	.Split().Where(f1=> !string.IsNullOrEmpty(f1)).Select(fi =>
	{
	try
	{
		return int.Parse(fi);
		}
		catch (Exception e)
		{
			
		}
		
		return -1;
	}).ToArray();
	
	for (int i = 0; i < expected.Length; i++)
	{
		if (expected[i] != result[i])
		{
			string b = "";
		}
	}
	

//	textWriter.WriteLine(string.Join("\n", result));
//
//	textWriter.Flush();
//	textWriter.Close();
}

static int[] maxXor(int[] arr, int[] queries)
{		
	int[] result = new int[queries.Length];
	Tri t = new Tri();

	for (int i = 0; i < arr.Length; i++)
	{
		t.Add(arr[i]);
	}

	for (int i = 0; i < queries.Length; i++)
		result[i] = t.CalcMaxXor(queries[i]);

	return result;
}

public class Tri
{
	private TriNode root = new TriNode();
	private static readonly int NumBits = sizeof(int) * 8;
	public class TriNode
	{
		public TriNode[] Children = new TriNode[2];
		public int? value;
	}
	
	public void Add(int x)
	{		
		TriNode curr = root;
		for (int i = 0; i < NumBits; i++)
		{
			int bit = (x >> (NumBits-1-i))&1;
			
			if (curr.Children[bit] == null )
				curr.Children[bit] = new TriNode();
				
			curr = curr.Children[bit];
		}
	}	
	
	public int CalcMaxXor(int x)
	{
		int result = 0;
		TriNode curr = root;
		for (int i = 0; i < NumBits; i++)
		{
			int inputBit = x >> ((NumBits - 1 - i)) & 1;

			if (inputBit == 0)
			{
				if (curr.Children[1] == null)
				{
					curr = curr.Children[0];
				}
				else
				{
					result |= 1 << (NumBits - 1 - i);
					curr = curr.Children[1];
				}
			}
			else
			{
				if (curr.Children[0] == null)
				{
					curr = curr.Children[1];
				}
				else
				{
					result |= 1 << (NumBits - 1 - i);
					curr = curr.Children[0];
				}
			}
		}
		return result;
	}
}