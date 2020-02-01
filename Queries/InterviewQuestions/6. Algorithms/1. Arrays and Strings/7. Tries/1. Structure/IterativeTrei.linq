<Query Kind="Program" />

void Main()
{
	//string s = "se she";
	string s = "she sell shells spa";
	//string s = "she";
	string[] a = s.Split(' ');

	Trie<int> st = new Trie<int>();
	for (int i = 0; i < a.Length; i++)
	{
		st.Put(a[i], i + 1);
	}

//	int res = st.Get("sells");
//	int res2 = st.Get("niss");

	Console.WriteLine("keys(\"\"):");
	st.InOrder();
//	foreach (String key in st.Keys())
//	{
//		int v = st.Get(key);
//		Console.WriteLine(key + " " + ((v == 0) ? "" : v.ToString()));
//	}
	Console.WriteLine();

}


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

			// Is there an edge representing the currentDigit?
			// Such as edge would be implied by a entry in the
			// current nodes ChildNodes at index currentDigit
			if (currentNode.ChildNodes[currentDigit] == null)
			{
				// If no such edge exists we create it by 
				// constructing a new vertex and inserting it 
				// into the ChildNodes collection
				// at index currentDigit
				currentNode.ChildNodes[currentDigit] = 
					new Node<TV>(_radix);
			}
			
			// Iterate to the next node 
			currentNode = currentNode.ChildNodes[currentDigit];
		}

		// mark last node as leaf by setting a value on it
		currentNode.Value = value;
	}

	public TV Get(String key)
	{
		Node<TV> currentNode = _root;
		for (int digitIdx = 0; digitIdx < key.Length; digitIdx++)
		{
			// Search miss				
			if (currentNode == null) return default(TV);

			currentNode = currentNode.ChildNodes[key[digitIdx]];
		}
		return currentNode.Value;
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



	public void InOrder()
	{
		
		Stack<StackFrame> stack = new Stack<StackFrame>();

		StackFrame current = new StackFrame();
		current.node = _root;
		current.c = 0;
		
		stack.Push(current);
		
		while(!(stack.Count==0))
		{
			current = stack.Peek();
			stack.Pop();

			for (int c = current.c; c < _radix; c++)
			{
				if (current.node.ChildNodes[c] !=null)
				{
					char ch = (char)c;
					current.c = c+1;
					stack.Push(current);
					Console.WriteLine(ch);
					
					
					StackFrame snap = new StackFrame();
					snap.node = current.node.ChildNodes[c];
					snap.c = 0;
					stack.Push(snap);
					break;
				}

			}
		}
	}




	public IEnumerable<string> KeysWithPrefix(string prefix)
	{
		Queue<String> results = new Queue<String>();
		Node<TV> x = _root;
		Collect(x, new StringBuilder(prefix), results);
		return results;
	}

	public IEnumerable<string> Keys() => KeysWithPrefix("");

	private static int _radix;
	private Node<TV> _root;

	private struct StackFrame
	{
		public Node<TV> node;
		public int c;
	};
}

public class Node<TV>
{
	private Node<TV>[] _childNodes;

	public Node(int radix) => _childNodes = new UserQuery.Node<TV>[radix];

	public TV Value { get; set; }

	public Node<TV>[] ChildNodes => _childNodes;
}