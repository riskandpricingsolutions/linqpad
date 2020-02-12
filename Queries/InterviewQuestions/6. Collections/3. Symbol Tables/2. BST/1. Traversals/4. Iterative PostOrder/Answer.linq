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

	var res = PostOrderTraversal(bst.Root);

	MyExtensions.AreEqual(true, new string[] { "A", "C", "B", "E", "D" }.SequenceEqual(PostOrderTraversal(bst.Root)));

	Console.WriteLine();
	ITreePrinter treePrinter = new BinarySearchTreePrinter();
	treePrinter.PrintTree(bst);
}

// Question: Write a iterative InOrder traversal
public IEnumerable<TK> PostOrderTraversal<TK,TV>(TreeNode<TK,TV> root)
	where TK : IComparable<TK>
{
	if (root == null) yield break;
	
	Stack<TreeNode<TK,TV>> s = new Stack<TreeNode<TK,TV>>();
	TreeNode<TK,TV> prev = null;
	s.Push(root);
	
	while (s.Count > 0)
	{
		var node = s.Peek();
		
		// We are moving down the tree 
		if (prev == null || prev.Left == node || prev.Right == node)
		{
			// If its a root node just visist it and trows it off the stack
			if (node.Left == null && node.Right == null) 
			{
				yield return node.Key;
				prev = node;
				s.Pop();
			}
				
			else 
			{
				if (node.Right != null) s.Push(node.Right);
				if (node.Left != null) s.Push(node.Left);
				prev = node;
			}	
		}
		// Moving back up
		else
		{
			yield return node.Key;
			prev = node;
			s.Pop();
		}
	}
}