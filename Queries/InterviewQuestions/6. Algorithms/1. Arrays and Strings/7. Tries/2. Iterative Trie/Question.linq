<Query Kind="Program" />

void Main()
{
	string s = "she sell shells spa";
	string[] a = s.Split(' ');

	Trie<int> st = new Trie<int>();
	for (int i = 0; i < a.Length; i++)
		st.Put(a[i], i + 1);
	
//	st.TryGet("shells", out int value);
//	MyExtensions.AreEqual(3,value);
}


// Question: Implement an Iterative Trie
public class Trie<TV>
{
	private Node<TV> _root = new UserQuery.Node<TV>(256);
	
	public void Put(string key, TV value)
	{
		Node<TV> current = _root;
		
		for (int i = 0; i < key.Length; i++)
		{
			if (current.ChildNodes[key[i]] == null)
				current.ChildNodes[key[i]] = new Node<TV>(256);
				
			current = current.ChildNodes[key[i]];
		}
		
		current.Value = value;
	}
	
	public bool TryGet(string key, out TV value)
	{
		Node<TV> current = _root;
		
		for (int i = 0; i < key.Length; i++)
		{
			if (current.ChildNodes[key[i]] ==null)
			{
				value = default(TV);
				return false;
			}

	}
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