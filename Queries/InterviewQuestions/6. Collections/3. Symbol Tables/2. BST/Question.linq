<Query Kind="Program" />

void Main()
{
	// Question: Write the below Binary Search Tree
	
	// Question: Implement the index setter so this code works
	var bst = new BinarySearchTreeRecursive<string, int>
	{
		["D"] = 4,
		["B"] = 2,
		["E"] = 5,
		["A"] = 1,
		["C"] = 3
	};
	
	// Question: Implement the index getter so this code works
	MyExtensions.AreEqual(1, bst["A"]);
	
	
	
	Func<int[], int[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)b).Equals(c, EqualityComparer<int>.Default);
	
	// Test PostOrderTraversal
	var seq = bst.PostOrderTraversal().Select(node => node.Key).ToArray();
	MyExtensions.AreEqual(true, new string[] { "A", "C", "B", "E", "D" }.SequenceEqual(seq));

	// Test PreOrderTraversal
	seq = bst.PreOrderTraversal().Select(node => node.Key).ToArray();
	MyExtensions.AreEqual(true, new string[] { "D", "B", "A", "C", "E" }.SequenceEqual(seq));

	// Test InOrderTraversal
	seq = bst.InOrderTraversal().Select(node => node.Key).ToArray();
	MyExtensions.AreEqual(true, new string[] { "A", "B", "C", "D", "E"}.SequenceEqual(seq));
}

public class BinarySearchTreeRecursive<TK, TV> : ISymbolTable<TK, TV> where TK : IComparable<TK>
{
	private TreeNode<TK, TV> _root;

	private static TreeNode<TK, TV> PutRecursive(TreeNode<TK, TV> node, TK key, TV value) 
	{
		if (node == null) return new TreeNode<TK,TV>(key,value);
		
		int cmp = key.CompareTo(node.Key);
		
		if (cmp == 0) 
		{
			node.Value = value;
			return node;
		}
		
		if (cmp < 0) node.Left = PutRecursive(node.Left,key,value);
		else node.Right = PutRecursive(node.Right,key,value);
		
		return node;
	}

	private static TV GetRecursive(TreeNode<TK, TV> node, TK key) 
	{
		if (node == null) throw new ArgumentException();
		
		int cmp = key.CompareTo(node.Key);
		
		if (cmp == 0) return node.Value;
		if (cmp < 0) return GetRecursive(node.Left,key);
		return GetRecursive(node.Right,key);
	}

	public TV this[TK key]
	{
		set => _root = PutRecursive(_root, key, value);
		get => GetRecursive(_root, key);
	}

	public IEnumerable<KeyValuePair<TK, TV>> PostOrderTraversal()
	{
		Queue<KeyValuePair<TK, TV>> queue = new Queue<System.Collections.Generic.KeyValuePair<TK, TV>>();
		
		void PostOrderRecursive(TreeNode<TK, TV> node)
		{
			if (node.Left != null) PostOrderRecursive(node.Left);
			if (node.Right != null) PostOrderRecursive(node.Right);
			queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
		}
	
		PostOrderRecursive(_root);
		return queue;
	}

	public IEnumerable<KeyValuePair<TK, TV>> PreOrderTraversal() 
	{
		Queue<KeyValuePair<TK, TV>> queue = new Queue<System.Collections.Generic.KeyValuePair<TK, TV>>();
				
		void PreOrderTraversal(TreeNode<TK,TV> node)
		{
			queue.Enqueue(new KeyValuePair<TK,TV>(node.Key,node.Value));
			if (node.Left != null) PreOrderTraversal(node.Left);
			if (node.Right != null) PreOrderTraversal(node.Right);
		}
		
		PreOrderTraversal(_root);
		return queue;
	}
	
	public IEnumerable<KeyValuePair<TK, TV>> InOrderTraversal()
	{
		Queue<KeyValuePair<TK, TV>> queue = new Queue<System.Collections.Generic.KeyValuePair<TK, TV>>();

		void PreOrderTraversal(TreeNode<TK, TV> node)
		{
			if (node.Left != null) PreOrderTraversal(node.Left);
			queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
			if (node.Right != null) PreOrderTraversal(node.Right);
		}

		PreOrderTraversal(_root);
		return queue;
	}
}

// Define other methods and classes here
public interface ISymbolTable<TK, TV>
{
	TV this[TK key] { get; set; }

}

[DebuggerDisplay("Key={Key},Value={Value},Size={Size}")]
public class TreeNode<TK, TV> where TK : IComparable<TK>
{
	//public int Size => (Left?.Size ?? 0) + (Right?.Size ?? 0) + 1;

	public int Size { get; set; }
	public TK Key { get; set; }
	public TV Value { get; set; }
	public TreeNode<TK, TV> Left { get; set; }
	public TreeNode<TK, TV> Right { get; set; }

	public TreeNode(TK key, TV value)
	{
		Key = key;
		Value = value;
		Size = 1;
	}

	public override string ToString() => $"{Key}:{Value}, Size={Size}";
}

