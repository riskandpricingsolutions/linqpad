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

	MyExtensions.AreEqual(true, new string[] { "A", "C", "B", "E", "D" }.SequenceEqual(PostOrderTraversal(bst.Root)));

	Console.WriteLine();
	ITreePrinter treePrinter = new BinarySearchTreePrinter();
	treePrinter.PrintTree(bst);
}

// Question: Write a recurisve PostOrder traversal
public IEnumerable<TK> PostOrderTraversal<TK,TV>(TreeNode<TK,TV> root)
	where TK : IComparable<TK>
{
	Queue<TK> keys = new Queue<TK>();
	
	void RecursiveTraverse<TKey,TVal>(TreeNode<TKey,TVal> node, Queue<TKey> q)
		where TKey : IComparable<TKey>
	{
		if (node == null) return;
		
		RecursiveTraverse(node.Left,q);
		RecursiveTraverse(node.Right,q);
		q.Enqueue(node.Key);
	}
	
	RecursiveTraverse(root,keys);
	return keys;
}