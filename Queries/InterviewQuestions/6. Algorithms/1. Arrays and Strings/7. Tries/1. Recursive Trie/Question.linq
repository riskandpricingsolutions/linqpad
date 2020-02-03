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
	private Node<TV> _root = new Node<TV>(256);

	public void Put(string key, TV value) => throw new NotImplementedException();

	public TV Get(string k) => throw new NotImplementedException();
}

public class Node<TV>
{
	private Node<TV>[] _childNodes;

	public Node(int radix) => _childNodes = new UserQuery.Node<TV>[26];
	public TV Value { get; set; }

	public Node<TV>[] ChildNodes => _childNodes;
}