<Query Kind="Program" />

void Main()
{
	string s = "she sells sea shells on the sea shore";
	string[] a = s.Split(' ');

	Trie<int?> st = new Trie<int?>();
	
	// Test Put
	for (int i = 0; i < a.Length; i++)
		st.Put(a[i], i + 1);
	
	// Test Get
	MyExtensions.AreEqual(1, st.Get("she"));
	MyExtensions.AreEqual(8, st.Get("shore"));
	MyExtensions.AreEqual(null, st.Get(""));



}

// Question: Implement an Recursive Trie
public class Trie<TV>
{

	public void Put(string k, TV v)
	{
		Put(_root,k,v,0);
		
		void Put(Node<TV> currentNode, String key, TV value, int digitIdx)
		{
			if (digitIdx == key.Length)
			{
				currentNode.Value = value;
				return;
			}

			int digit = key[digitIdx];
			Node<TV> childNode = currentNode.ChildNodes[digit];
			
			if (childNode == null)
			{
				childNode = new UserQuery.Node<TV>(_radix);
				currentNode.ChildNodes[digit] = childNode;
			}
			
			Put(childNode, key, value, digitIdx + 1);
		}
	}
	
	public TV Get(string k)
	{
		Node<TV> node = Get(_root,k,0);
		if (node != null) return node.Value;
		return default(TV);
	}
	
	private Node<TV> Get(Node<TV> x, String key, int d)
	{
		if (x == null) return null;
		if (d == key.Length) return x;
		return Get(x.ChildNodes[key[d]], key, d + 1);
	}
	
	public IEnumerable<string> GetKeysWithPrefix(string prefix)
	{
		// Get the node corresponding to last character of the 
		// prefix
		Node<TV> prefixNode = Get(_root,prefix,0);
		Queue<string> queue = new Queue<string>();
		
		// Collect all strings that are descendands of the 
		// prefix node
		Collect(prefixNode,new StringBuilder(prefix),queue);
		return queue;
	}
	
	private void Collect(Node<TV> node, StringBuilder prefix, Queue<string>q)
	{
		if (node==null) return;
		
		if (!Equals(node,default(TV)))
			q.Enqueue(prefix.ToString());
			
		for (int i = 0; i < 26; i++)
		{
			prefix.Append((char)('a'+i));
			Collect(node.ChildNodes[i],prefix,q);
			prefix.Remove(prefix.Length-1,1);
		}
	}
	private Node<TV> _root;
}

public class Node<TV>
{
	private Node<TV>[] _childNodes;

	public Node(int radix) => _childNodes = new UserQuery.Node<TV>[radix];

	public TV Value { get; set; }

	public Node<TV>[] ChildNodes => _childNodes;
}