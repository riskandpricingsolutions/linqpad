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

	Func<string[], string[], bool> compareResults = (b, c)
		=> ((IStructuralEquatable)(b)).Equals(c, EqualityComparer<string>.Default);

	// GetAllKey
	var allKeys = st.GetKeysWithPrefix("").ToArray();
	MyExtensions.AreEqual(true, compareResults(new string[] { "on", "sea", "sells", "she", "shells", "shore", "the" }, allKeys));
	
	// Get with prefix
	var prefixKeys = st.GetKeysWithPrefix("sh").ToArray();
	MyExtensions.AreEqual(true, compareResults(new string[] { "she", "shells", "shore" }, prefixKeys));

	// 
	var matchKeys = st.KeysThatMatch(".h.").ToArray();
	MyExtensions.AreEqual(true, compareResults(new string[] { "she", "the" }, prefixKeys));
}

public class Trie<TV>
{
	public void Put(string k, TV v) => _root = Put(_root,k,v,0);
	
	private Node<TV> Put(Node<TV> parent, string key, TV value, int digId)
	{
		// If the parent node is null it means there is no node
		// representing the charcter key[digId-1]
		if (parent == null)
			parent = new Node<TV>(26);
			
		// If the digId is equal to the length of the key it means
		// the parent node represents the last charater of the key -
		// the character at key[digId-1] = key[key.Length-1]
		// In this case we just set the value and return. This is the
		// terminating case of the recursion
		if (digId == key.Length)
		{
			parent.Value = value;
			return parent;
		}
		
		// Get the node corresponding to the child at index key[digId] and set it
		// on the child array
		parent.ChildNodes[key[digId]-'a'] = Put(parent.ChildNodes[key[digId]-'a'],key,value,digId+1);
		return parent;
	}
	
	public TV Get(string key)
	{
		Node<TV> node = Get(_root,key,0);	
		if (node == null) return default(TV);
		return node.Value;
	}
	
	public Node<TV> Get(Node<TV> parent, string key, int digId)
	{
		// If the parent is null there is no node for the character
		// key[digId-1] and hence we have a search miss. Return null
		if (parent == null) return null;
		
		// The non-null parent node corresponds to the character
		// key[key.Length-1] so we have every character of the key
		// in the Trie. Just return the parent node
		if (digId == key.Length) return parent;
		
		// The recursive case. Move to the child node 
		// representing digId.
		return Get(parent.ChildNodes[key[digId]-'a'],key,digId+1);
	}

	public IEnumerable<string> GetKeysWithPrefix(string prefix)
	{
		// Get the node corresponding to last character of the 
		// prefix
		Node<TV> prefixNode = Get(_root, prefix, 0);
		Queue<string> queue = new Queue<string>();

		// Collect all strings that are descendands of the 
		// prefix node
		Collect(prefixNode, new StringBuilder(prefix), queue);
		return queue;
	}

	private void Collect(Node<TV> node, StringBuilder prefix, Queue<string> q)
	{
		if (node == null) return;

		if (!Equals(node.Value, default(TV)))
			q.Enqueue(prefix.ToString());

		for (int i = 0; i < 26; i++)
		{
			prefix.Append((char)('a' + i));
			Collect(node.ChildNodes[i], prefix, q);
			prefix.Remove(prefix.Length - 1, 1);
		}
	}
	
	public IEnumerable<string> KeysThatMatch(string pattern)
	{
		Queue<string> q = new Queue<string>();
		Collect(_root,"",pattern,q);
		return q;
	}

	public void Collect(Node<TV> node, string prefix, string pattern, Queue<string> matchedWords)
	{
		if (node == null) return;

		int prefixLength = prefix.Length;
		int patternLength = pattern.Length;

		if (prefixLength == patternLength)
		{
			// The prefix matches the pattern and is a valid word
			// so add it to the q
			if (!Object.Equals(node.Value, default(TV)))
				matchedWords.Enqueue(prefix);

			// No point going further as longer strings 
			// cannot match the pattern
			return;
		}

		char nextPatternChar = pattern[prefixLength];
		for (int i = 0; i < 26; i++)
		{
			char nextPossiblePrefixChar = (char)('a' + i);
			
			if (nextPatternChar == '.' || nextPatternChar == nextPossiblePrefixChar)
			{
				var childNode = node.ChildNodes[i];
				Collect(childNode, prefix + nextPatternChar, pattern, matchedWords);
			}
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