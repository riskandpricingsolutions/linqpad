<Query Kind="Program">
  <Reference>M:\Libraries\DotNetAssemblies\Rps\DataStructures\RiskAndPricingSolutions.Algorithms.DataStructures.dll</Reference>
  <Namespace>RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST</Namespace>
  <Namespace>RiskAndPricingSolutions.Algorithms.DataStructures.SymbolTable.BST.Printing</Namespace>
</Query>

void Main()
{
	var bst = new BinarySearchSearchTreeRecursive<string, string>
	{
		["D"] = "D",
		["B"] = "B",
		["E"] = "E",
		["A"] = "A",
		["C"] = "C",
		["F"] = "F"
	};

	//MyExtensions.AreEqual(true, new string[] { "A", "B", "C", "D", "E" }.SequenceEqual(InOrderTraversal(bst.Root)));
	
	var counts = GetCounts(bst.Root);
	Console.WriteLine();
	ITreePrinter treePrinter = new BinarySearchTreePrinter();
	treePrinter.PrintTree(bst);
}

// Question: Write a recurisve function to calculate level counts
public SortedDictionary<int,int> GetCounts<TK,TV>(TreeNode<TK,TV> root)
	where TK : IComparable<TK>
{
	SortedDictionary<int,int> counts = new SortedDictionary<int, int>();
	
	void CalcCounts<TKey,TVal>(TreeNode<TKey,TVal> node, SortedDictionary<int,int> cts, int level)
		where TKey : IComparable<TKey>
	{
		if (node == null) return;
		
		int levelCount;
		if (!counts.TryGetValue(level,out levelCount))
			counts[level] = 1;
		else
			counts[level] = counts[level]+1;

		CalcCounts(node.Left,cts,level+1);
		CalcCounts(node.Right,cts,level+1);
	}
	
	CalcCounts(root,counts,1);
	return counts;
}