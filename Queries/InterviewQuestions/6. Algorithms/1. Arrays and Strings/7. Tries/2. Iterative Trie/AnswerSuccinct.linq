<Query Kind="Program" />

void Main()
{
	string s = "she sell shells spa";
	string[] a = s.Split(' ');

	Trie<int> st = new Trie<int>();
	for (int i = 0; i < a.Length; i++)
		st.Put(a[i], i + 1);
	
	st.TryGet("shells", out int value);
	MyExtensions.AreEqual(3,value);
}


// Question: Implement an Iterative Trie
public class Trie<TV>
{
	public Trie(int radix = 256)
	{
		_radix = radix;
		_root = new UserQuery.Node<TV>(_radix);
	}

	public void Put(String key, TV value)
	{
		Node<TV> currentNode = _root;

		for (int digitIdx = 0; digitIdx < key.Length; digitIdx++)
		{
			int currentDigit = key[digitIdx];

			if (currentNode.ChildNodes[currentDigit] == null)
				currentNode.ChildNodes[currentDigit] = new Node<TV>(_radix);
				
			currentNode = currentNode.ChildNodes[currentDigit];
		}

		currentNode.Value = value;
	}

	public bool TryGet(String key, out TV value)
	{
		Node<TV> currentNode = _root;
		for (int digitIdx = 0; digitIdx < key.Length; digitIdx++)
		{			
			if (currentNode == null) 
			{
				value = default(TV);
				return false;
			}

			currentNode = currentNode.ChildNodes[key[digitIdx]];
		}
		value = currentNode.Value;
		return true;
	}

	private static int _radix;
	private Node<TV> _root ;
}

public class Node<TV>
{
	public Node(int radix) => _childNodes = new UserQuery.Node<TV>[radix];
	public TV Value { get; set; }
	public Node<TV>[] ChildNodes => _childNodes;	
	private Node<TV>[] _childNodes;
}

public class StackFrame<TV>
{
	public Node<TV> Node { get; set; }
	public int c { get; set; }
};