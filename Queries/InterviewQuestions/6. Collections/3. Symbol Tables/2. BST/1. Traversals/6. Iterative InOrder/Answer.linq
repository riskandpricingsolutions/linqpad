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
	ITreePrinter treePrinter = new BinarySearchTreePrinter();
		treePrinter.PrintTree(bst);
	var r = InOrderTraversal(bst.Root);
	
	MyExtensions.AreEqual(true, new string[] { "A", "B", "C", "D", "E" }.SequenceEqual(InOrderTraversal(bst.Root)));

	Console.WriteLine();
	treePrinter.PrintTree(bst);
}

// Question: Write a iterative InOrder traversal
public IEnumerable<TK> InOrderTraversal<TK,TV>(TreeNode<TK,TV> root)
	where TK : IComparable<TK>
{
	if (root == null) yield break;

	Stack<TreeNode<TK, TV>> s = new Stack<TreeNode<TK, TV>>();
	TreeNode<TK, TV> curr = root;

	    while (curr != null || s.Count > 0) 
        { 
  
            /* Reach the left most Node of the  
            curr Node */
            while (curr != null) 
            { 
                /* place pointer to a tree node on  
                   the stack before traversing  
                  the node's left subtree */
                s.Push(curr); 
                curr = curr.Left; 
            } 
  
            /* Current must be NULL at this point */
            curr = s.Pop(); 
  
           yield return curr.Key;

		/* we have visited the node and its  
		   left subtree.  Now, it's right  
		   subtree's turn */
		curr = curr.Right;
	}
}