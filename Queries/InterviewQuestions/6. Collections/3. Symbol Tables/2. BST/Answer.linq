<Query Kind="Program" />

void Main()
{
	// Question: Write the below Binary Search Tree
	
	// Initialize the BST
	var bst = new BinarySearchTreeRecursive<string, int>
	{
		["D"] = 4,
		["B"] = 2,
		["E"] = 5,
		["A"] = 1,
		["C"] = 3
	};
	
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

	//BFS
	var seq2 = bst.BreadthFirstTraversal().Select(node => node).ToArray();
	MyExtensions.AreEqual(true, new string[] { "D", "B", "E", "A", "C" }.SequenceEqual(seq2));
}

public class BinarySearchTreeRecursive<TK, TV> : ISymbolTable<TK, TV> where TK : IComparable<TK>
{
	private TreeNode<TK, TV> _root;
	
	private static TreeNode<TK, TV> PutRecursive(TreeNode<TK, TV> node, TK key, TV value)
	{
		// We have moved left or right down the tree and reached a 
		// null/leaf node. The searchKey is therefor not in the table. We
		// create a new node for the searchKey/value and return it.
		if (node == null) return new TreeNode<TK, TV>(key, value);

		// Compare the new searchKey to the searchKey in the current node
		int cmp = key.CompareTo(node.Key);

		if (cmp == 0)
		{
			// We have a match. Replace the value in this node with the 
			//new value and return it
			node.Value = value;
			return node;
		}

		// The searchKey to be inserted does not match the current node and the current 
		// node is not a null/leaf so we need to recurse. If the searchKey to be inserted
		// is greater than the current searchKey we set the right node of this node to be the
		// result of recursively calling this function on this nodes right link.
		//
		// Note: We always replace the left or right node. As with this implementation we 
		// always only creates new nodes at leaves we could test and only do this when the 
		// left/right pointers are null. But this code is as efficient and takes less code. The
		// logic to set the left/right is simpler than the logic to test and set.
		if (cmp < 0) node.Left = PutRecursive(node.Left, key, value);
		if (cmp > 0) node.Right = PutRecursive(node.Right, key, value);
		node.Size = (node.Left?.Size ?? 0) + (node.Right?.Size ?? 0) + 1;

		return node;
	}

	private static TV GetRecursive(TreeNode<TK, TV> node, TK key)
	{
		if (node == null)
			throw new KeyNotFoundException($"{key} not found");

		var compareTo = key.CompareTo(node.Key);

		// We have a hit. Return this nodes value
		if (compareTo == 0) return node.Value;

		// We move left or right depending on whether the searchKey is greater than or
		// equal to the searchKey at this node.l
		return (compareTo > 0) ? GetRecursive(node.Right, key) : GetRecursive(node.Left, key);
	}


	/// <summary>
	/// Get/Set value by searchKey
	/// </summary>
	/// <param name="key">The searchKey</param>
	/// <returns>The value</returns>
	public TV this[TK key]
	{
		set => _root = PutRecursive(_root, key, value);
		get => GetRecursive(_root, key);
	}

	public IEnumerable<TK> BreadthFirstTraversal()
	{
		Queue<TreeNode<TK, TV>> queue = new Queue<UserQuery.TreeNode<TK, TV>>();
		Queue<TK> values = new Queue<TK>();

		queue.Enqueue(_root);

		while (queue.Count > 0)
		{
			var node = queue.Dequeue();
			values.Enqueue(node.Key);

			if (node.Left != null) queue.Enqueue(node.Left);
			if (node.Left != null) queue.Enqueue(node.Right);
		}

		return values;
	}

	public IEnumerable<KeyValuePair<TK, TV>> PostOrderTraversal()
	{
		void PostOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
		{
			if (node.Left != null) PostOrderRecursive(node.Left, queue);
			if (node.Right != null) PostOrderRecursive(node.Right, queue);
			queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
		}

		Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
		PostOrderRecursive(_root, q);
		return q;
	}

	public IEnumerable<KeyValuePair<TK, TV>> PreOrderTraversal()
	{
		void PreOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
		{
			queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
			if (node.Left != null) PreOrderRecursive(node.Left, queue);
			if (node.Right != null) PreOrderRecursive(node.Right, queue);
		}

		Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
		PreOrderRecursive(_root, q);
		return q;
	}

	public IEnumerable<KeyValuePair<TK, TV>> InOrderTraversal()
	{
		void InOrderRecursive(TreeNode<TK, TV> node, Queue<KeyValuePair<TK, TV>> queue)
		{
			if (node.Left != null) InOrderRecursive(node.Left, queue);
			queue.Enqueue(new KeyValuePair<TK, TV>(node.Key, node.Value));
			if (node.Right != null) InOrderRecursive(node.Right, queue);
		}

		Queue<KeyValuePair<TK, TV>> q = new Queue<KeyValuePair<TK, TV>>();
		InOrderRecursive(_root, q);
		return q;
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