<Query Kind="Program" />

void Main()
{
	string s = "Wonderful WorthIt";
	//string s = "she";
	string[] a = s.Split(' ');

	Trie<int> st = new Trie<int>();
	for (int i = 0; i < a.Length; i++)
	{
		st[a[i]] =  i + 1;
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
	private Node<TV> _root;
	private int _radix;


	public Trie(int radix = 256) => _radix = radix;
	
	public TV this[string key]
	{
		get
		{
			Node<TV> node = Get(_root,key,0);
			return (node == null) ? default(TV) : node.Value;
		}
		set => _root = Put(_root, key, value,0);
	}



	private Node<TV> Put(Node<TV> x, string k, TV val, int d)
	{
		if (x == null) x = new Node<TV>(_radix);

		// This is the end of a word so set the
		// value associated with the key
		if (d == k.Length)
		{
			x.Value = val;
			return x;
		}

		// This is not the end of the word so move
		// to the next character get the next node
		// and put it in the right place 
		char c = k[d];
		x.Children[c] = Put(x.Children[c], k, val, d + 1);
		return x;
	}

	private Node<TV> Get(Node<TV> x, String key, int d)
	{
		if (x == null) return null;
		
		// We are at the end of the key word
		if (d == key.Length) return x;
		
		// Otherwise move down to the next character
		return Get(x.Children[key[d]], key, d + 1);
	}

	private void Collect(Node<TV> x, StringBuilder prefix, Queue<string> results)
	{
		if (x==null) return;
		if (!Object.Equals(x.Value, default(TV))) results.Enqueue(prefix.ToString());

		for (int c = 0; c < _radix; c++)
		{
			prefix.Append((char)c);
			Collect(x.Children[c], prefix, results);
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

	public IEnumerable<string> Keys() =>  KeysWithPrefix("");
}

public class Node<TV>
{
	private Node<TV>[] _childNodes;

	public Node(int radix) =>_childNodes = new UserQuery.Node<TV>[radix];

	public TV Value { get; set; }

	public Node<TV>[] Children => _childNodes;
}