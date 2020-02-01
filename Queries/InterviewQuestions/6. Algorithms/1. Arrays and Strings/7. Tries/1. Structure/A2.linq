<Query Kind="Program" />

void Main()
{
	//string s = "she sells sea shells on the sea shore";
	string s = "she sell shells spa";
	string[] a = s.Split(' ');
	
	TrieST<int> st = new TrieST<int>();
	for (int i = 0; i < a.Length; i++)
	{
		st.Put(a[i],i+1);
	}
	


	// print results
	if (st.size() < 100)
	{
		Console.WriteLine("keys(\"\"):");
		st.keys();
//		foreach (String key in st.keys())
//		{
//			int v;
//			if (st.TryGet(key, out v));
//			{
//				Console.WriteLine(key + " " + ((v==0) ? "" : v.ToString()));
//			}	
//		}
//		Console.WriteLine();
	}

//	Console.WriteLine("longestPrefixOf(\"shellsort\"):");
//	Console.WriteLine(st.LongestPrefixOf("shellsort"));
//	Console.WriteLine();
//
//	Console.WriteLine("longestPrefixOf(\"quicksort\"):");
//	Console.WriteLine(st.LongestPrefixOf("quicksort"));
//	Console.WriteLine();
//
//	Console.WriteLine("keysWithPrefix(\"shor\"):");
//	foreach (String str in st.keysWithPrefix("shor"))
//		Console.WriteLine(str);
//	Console.WriteLine();
//
//	Console.WriteLine("keysThatMatch(\".he.l.\"):");
//	foreach (string str in st.keysThatMatch(".he.l."))
//		Console.WriteLine(str);
}

// Define other methods and classes here
public class TrieST<TV>
{
	private static int R = 256;        // extended ASCII

	private class Node<TV>
	{
		public TV val;
		public Node<TV>[] next = new Node<TV>[R];
	}

	private Node<TV> root;      // root of trie
	private int n;          // number of keys in trie

	public TrieST()
	{
	}


	public bool TryGet(String key, out TV value)
	{
		if (key == null) throw new ArgumentException("argument to get() is null");
		Node<TV> x = Get(root, key, 0);
		if (x == null)
		{
			value = default(TV);
			return false;
		}

		value = x.val;
		return true;
	}


	public bool Contains(String key)
	{
		if (key == null) throw new ArgumentException("argument to contains() is null");
		return TryGet(key, out TV val);
	}

	private Node<TV> Get(Node<TV> x, String key, int d)
	{
		if (x == null) return null;
		if (d == key.Length) return x;
		char c = key[d];
		return Get(x.next[c], key, d + 1);
	}

	public void Put(String key, TV val)
	{
		if (key == null) throw new ArgumentException("first argument to put() is null");
		if (val == null) delete(key);
		else root = Put(root, key, val, 0);
	}

	private Node<TV> Put(Node<TV> x, String key, TV val, int d)
	{
		if (x == null) x = new Node<TV>();
		if (d == key.Length)
		{
			if (x.val == null) n++;
			x.val = val;
			return x;
		}
		char c = key[d];
		int i = (int)c;
		x.next[c] = Put(x.next[c], key, val, d + 1);
		return x;
	}


	public int size() => n;

	public bool isEmpty() => size() == 0;


	public IEnumerable<string> keys()
	{
		return keysWithPrefix("");
	}


	public IEnumerable<string> keysWithPrefix(string prefix)
	{
		Queue<String> results = new Queue<String>();
		Node<TV> x = Get(root, prefix, 0);
		Collect(x, new StringBuilder(prefix), results);
		return results;
	}

	private void Collect(Node<TV> x, StringBuilder prefix, Queue<String> results)
	{
		if (x == null) return;
		if (x.val != null) results.Enqueue(prefix.ToString());
		for (int c = 0; c < R; c++)
		{
			prefix.Append((char)c);
			if (x.next[c] != null)
			{
				char ch = (char)c;
				Console.WriteLine((char)c);
				Collect(x.next[c], prefix, results);
			}
			
			
			prefix.Remove(prefix.Length - 1, 1);
		}
	}

	private void Collect2(Node<TV> x, StringBuilder prefix, Queue<String> results)
	{
		Stack<Node<TV>> stack = new Stack<UserQuery.TrieST<TV>.Node<TV>>();
		stack.Push(x);

		while (!(stack.Count == 0))
		{
			// Do something
			Node<TV> my_object = stack.Pop();

			// Push other objects on the stack.
			for (int c = R - 1; c >= 0; c--)
			{
				if (x.next[c] != null)
				{
					char ch = (char)c;
					Console.WriteLine((char)c);
					stack.Push(x.next[c]);
				}
			}
		}

	}


	public IEnumerable<String> keysThatMatch(String pattern)
	{
		Queue<String> results = new Queue<String>();
		Collect(root, new StringBuilder(), pattern, results);
		return results;
	}

	private void Collect(Node<TV> x, StringBuilder prefix, String pattern, Queue<String> results)
	{
		if (x == null) return;
		int d = prefix.Length;
		if (d == pattern.Length && x.val != null)
			results.Enqueue(prefix.ToString());
		if (d == pattern.Length)
			return;
		char c = pattern[d];
		if (c == '.')
		{
			for (int ch = 0; ch < R; ch++)
			{
				prefix.Append((char)ch);
				Collect(x.next[ch], prefix, pattern, results);
				prefix.Remove(prefix.Length - 1, 1);
			}
		}
		else
		{
			prefix.Append(c);
			Console.WriteLine(c);
			Collect(x.next[c], prefix, pattern, results);
			prefix.Remove(prefix.Length - 1, 1);
		}
	}

	public String LongestPrefixOf(String query)
	{
		if (query == null) throw new ArgumentException("argument to longestPrefixOf() is null");
		int length = LongestPrefixOf(root, query, 0, -1);
		if (length == -1) return null;
		else return query.Substring(0, length);
	}


	private int LongestPrefixOf(Node<TV> x, String query, int d, int length)
	{
		if (x == null) return length;
		if (x.val != null) length = d;
		if (d == query.Length) return length;
		char c = query[d];
		return LongestPrefixOf(x.next[c], query, d + 1, length);
	}


	public void delete(String key)
	{
		if (key == null) throw new ArgumentException("argument to delete() is null");
		root = delete(root, key, 0);
	}

	private Node<TV> delete(Node<TV> x, String key, int d)
	{
		if (x == null) return null;
		if (d == key.Length)
		{
			if (x.val != null) n--;
			x.val = default(TV);
		}
		else
		{
			char c = key[d];
			x.next[c] = delete(x.next[c], key, d + 1);
		}

		// remove subtrie rooted at x if it is completely empty
		if (x.val != null) return x;
		for (int c = 0; c < R; c++)
			if (x.next[c] != null)
				return x;
		return null;
	}
}