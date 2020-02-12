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

	MyExtensions.AreEqual(true, new string[] { "D", "B", "A", "C", "E" }.SequenceEqual(PreOrderTraversal(bst.Root)));

	Console.WriteLine();
	ITreePrinter treePrinter = new BinarySearchTreePrinter();
	treePrinter.PrintTree(bst);
}

// Question: Write a iterative InOrder traversal
public IEnumerable<TK> PreOrderTraversal<TK,TV>(TreeNode<TK,TV> root)
	where TK : IComparable<TK>
{
	if (root == null) yield break;
	
	Stack<TreeNode<TK,TV>> s = new Stack<TreeNode<TK,TV>>();
	s.Push(root);
	
	while (s.Count > 0)
	{
		var node = s.Pop();
		yield return node.Key;
		if(node.Right != null) s.Push(node.Right); 
		if(node.Left != null) s.Push(node.Left); 
	}
}