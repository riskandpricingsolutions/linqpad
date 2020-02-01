<Query Kind="Program" />

void Main()
{
	void RunRansom(string magString, string noteString)
	{
		string[] mag1 = magString.Split(' ');
		string[] note1 = noteString.Split(' ');
		RansomeNote(mag1, note1);
	}

	//RunRansom("give me one grand today night", "give one grand today");
		RunRansom("two times three is not four", "two times two is four");
}

// Question: Given an array of integers and an integer k, you need to find the total 
//  number of continuous subarrays whose sum equals to k.
public static void RansomeNote(string[] magazine, string[] note) 
{
	var index = new Dictionary<string,int>();

	// Build the index
	for (int i = 0; i < magazine.Length; i++)
	{
		if (!index.ContainsKey(magazine[i])) index[magazine[i]] = 1;
		else index[magazine[i]]++;
	}
	

	foreach (var element in note)
	{
		int count = 0;
		if (!index.TryGetValue(element, out count) || count==0)
		{
			Console.WriteLine("No");
			return;
		}

		index[element] = count-1;
	}

	Console.WriteLine("Yes");
}