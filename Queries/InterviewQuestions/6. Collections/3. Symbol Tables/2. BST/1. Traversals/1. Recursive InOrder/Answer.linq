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
		["C"] = "C"
	};

	MyExtensions.AreEqual(true, new string[] { "A", "B", "C", "D", "E" }.SequenceEqual(InOrderTraversal(bst.Root)));

	Console.WriteLine();
	ITreePrinter treePrinter = new BinarySearchTreePrinter();
	treePrinter.PrintTree(bst);
}

// Question: Write a recurisve InOrder traversal
public IEnumerable<TK> InOrderTraversal<TK,TV>(TreeNode<TK,TV> root)
	where TK : IComparable<TK>
{
	Queue<TK> keys = new Queue<TK>();
	
	void RecursiveTraverse<TKey,TVal>(TreeNode<TKey,TVal> node, Queue<TKey> q)
		where TKey : IComparable<TKey>
	{
		if (node == null) return;
		
		RecursiveTraverse(node.Left,q);
		q.Enqueue(node.Key);
		RecursiveTraverse(node.Right,q);
	}
	
	RecursiveTraverse(root,keys);
	return keys;
}
