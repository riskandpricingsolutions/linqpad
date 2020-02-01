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
	st.DepthFirstTraversal();
	//	foreach (String key in st.Keys())
	//	{
	//		int v = st.Get(key);
	//		Console.WriteLine(key + " " + ((v == 0) ? "" : v.ToString()));
	//	}
	Console.WriteLine();

}


// Question: Implement an Iterative Trie

public class Trie<TV>
{
	/// <summary>
	///  Construct an instance of the Trie with the given radix
	/// </summary>
	/// <param name="radix">The radix</param>
	public Trie(int radix = 256)
	{
		_radix = radix;
		_root = new UserQuery.Node<TV>(_radix);
	}

	/// <summary>
	///  Add the value to the Trie with the given key
	/// </summary>
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

	/// <summary>
	///  Lookup the value associated with the given key
	/// </summary>
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

	public void DepthFirstTraversal()
	{
		// Setup a stack
		Stack<StackFrame> stack = new Stack<StackFrame>();
		
		// Collect the results
		Queue<string> results = new Queue<string>();

		// Setup the initial stack frame as the root node 
		// and push it onto the stack
		StackFrame current = new StackFrame() {Node = _root, c=0};
		stack.Push(current);

		while (!(stack.Count == 0))
		{
			// Pop the top of the stack and start working on it
			current = stack.Pop();
			
			// If the is the first time we have seen this node
			// and the value is set we add it to the queue
			if (current.c == 0 and current.)

			// We might be part of the way though the children of 
			// this node. Hence we start iterating from the index
			// stored in the current stack frame.
			for (int c = current.c; c < _radix; c++)
			{
				if (current.Node.ChildNodes[c] != null)
				{
					char ch = (char)c;
					// We have found a child node representing 
					// character ch. We will push this on the stack
					// but first we need to push the current node 
					// as we have not completed working on it
					current.c = c + 1;
					stack.Push(current);
					Console.WriteLine(ch);

					// Now create a stack frame for the child node
					// and push that onto the stack
					StackFrame snap = new StackFrame() { Node = current.Node.ChildNodes[c], c = 0};
					stack.Push(snap);
					
					// Break out the loop as we need to process the child node next
					break;
				}

			}
		}
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

//	public IEnumerable<string> KeysWithPrefix(string prefix)
//	{
//		Queue<String> results = new Queue<String>();
//		Node<TV> x = Get(_root, prefix, 0);
//		Collect(x, new StringBuilder(prefix), results);
//		return results;
//	}


	private class StackFrame
	{
		public Node<TV> Node { get; set;}
		public int c {get;set;}
	};

	//public IEnumerable<string> Keys() => KeysWithPrefix("");
	private static int _radix;
	private Node<TV> _root ;
}

public class Node<TV>
{
	private Node<TV>[] _childNodes;

	public Node(int radix) => _childNodes = new UserQuery.Node<TV>[radix];

	public TV Value { get; set; }

	public Node<TV>[] ChildNodes => _childNodes;
}