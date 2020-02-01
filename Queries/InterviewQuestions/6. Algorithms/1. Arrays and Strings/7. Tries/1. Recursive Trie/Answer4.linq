<Query Kind="Program" />

void Main()
{
	string s = "She";
	//string s = "she";
	string[] a = s.Split(' ');

	Trie<int> st = new Trie<int>();
	for (int i = 0; i < a.Length; i++)
	{
		st[a[i]] = i + 1;
	}

	Console.WriteLine("keys(\"\"):");
	foreach (String key in st.Keys())
	{
		int v = st[key];
		Console.WriteLine(key + " " + ((v == 0) ? "" : v.ToString()));
	}
	Console.WriteLine();

}


public class Trie<TV>
{
	private static int _radix;
	private Node<TV> _root = new UserQuery.Node<TV>(_radix);

	public Trie(int radix = 256) => _radix = radix;

	public TV this[string key]
	{
		get
		{
			Node<TV> node = Get(_root, key, 0);
			return (node == null) ? default(TV) : node.Value;
		}
		set => Put(key, value);
	}
	
	
	private void Put(String key, TV value)
	{
		Node<TV> current = _root;

		for (int digitIdx = 0; digitIdx < key.Length; digitIdx++)
		{
			int currentDigit = key[digitIdx];

			// Is there an edge representing the currentDigit?
			// Such as edge would be implied by a entry in the
			// current nodes ChildNodes at index currentDigit
			if (current.ChildNodes[currentDigit] == null)
			{
				// If no such edge exists we create it by 
				// constructing a new vertex and inserting it 
				// into the ChildNodes collection
				// at index currentDigit
				current.ChildNodes[currentDigit] = 
					new Node<TV>(_radix);
			}
			
			// Iterate to the next node 
			current = current.ChildNodes[currentDigit];
		}

		// mark last node as leaf by setting a value on it
		current.Value = value;
	}
	
//	public void Put(String key, TV value)
//	{
//		PutRecursive(_root,key,value,0);
//		
//	}

	private void PutRecursive(Node<TV> currentNode, String key, TV value, int digitIdx)
	{
		if (digitIdx == key.Length)
		{
			// The current node is the (n+1)th node where n is the 
			// number of digits in the key. (indexing is zero based)
			// There are  are n+1 nodes on the path from root to end 
			// of a key. Consider the key "she" 
			// 
			//   s    h	   e
			// 0--->1--->2--->3
			// 
			// We just return now
			currentNode.Value = value;
			return;
		}

		// we are not a leaf yet
		int digit = key[digitIdx];
		Node<TV> childNode = currentNode.ChildNodes[digit];

		if (childNode == null)
		{
			childNode = new UserQuery.Node<TV>(_radix);
			currentNode.ChildNodes[digit] = childNode;
		}
		PutRecursive(childNode, key, value, digitIdx+1);
	}

	private Node<TV> Get(Node<TV> x, String key, int d)
	{
		if (x == null) return null;

		// We are at the end of the key word
		if (d == key.Length) return x;

		// Otherwise move down to the next character
		return Get(x.ChildNodes[key[d]], key, d + 1);
	}

	private void Collect(Node<TV> x, StringBuilder prefix, Queue<string> results)
	{
		if (x == null) return;
		if (!Object.Equals(x.Value, default(TV))) results.Enqueue(prefix.ToString());

		for (int c = 0; c < _radix; c++)
		{
			prefix.Append((char)c);
			Collect(x.ChildNodes[c], prefix, results);
			prefix.Remove(prefix.Length - 1, 1);
		}
	}

	public IEnumerable<string> KeysWithPrefix(string prefix)
	{
		Queue<String> results = new Queue<String>();
		Node<TV> x = Get(_root, prefix, 0);
		Collect(x, new StringBuilder(prefix), results);
		return results;
	}

	public IEnumerable<string> Keys() => KeysWithPrefix("");
}

public class Node<TV>
{
	private Node<TV>[] _childNodes;

	public Node(int radix) => _childNodes = new UserQuery.Node<TV>[radix];

	public TV Value { get; set; }

	public Node<TV>[] ChildNodes => _childNodes;
}
