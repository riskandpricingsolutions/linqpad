<Query Kind="Program" />

void Main()
{
	Solution.ReplaceWords(new List<string> {'cat',});	
}

public class Solution
{
	public static string ReplaceWords(IList<string> dict, string sentence)
	{

		Trie st = new Trie();

		foreach (string root in dict)
			st.Insert(root);

		string[] words = sentence.Split(' ');

		foreach (var word in words)
			sentence.Replace(word, st.GetRoot(word));

		return sentence;
	}
}

public class Trie
{

	/** Initialize your data structure here. */
	public Trie()
	{
	}

	public string GetRoot(Node parentNode, string word, int dId)
	{
		if (parentNode == null || dId == word.Length) return null;

		if (parentNode.IsWord) return word.Substring(0, dId);

		return GetRoot(parentNode.Children[word[dId] - 'a'], word, dId + 1);
	}

	public string GetRoot(string word) => GetRoot(_root, word, 0);

	/** Inserts a word into the trie. */
	public void Insert(string word)
	{
		_root = AddWord(_root, word, 0);
	}

	private Node AddWord(Node parentNode, string word, int dIdx)
	{
		// If the parent node is null it means there is no
		// character corresponding to character word[dIdx-1]
		// so we create it
		if (parentNode == null)
			parentNode = new Node();

		// The parent node corresponds to the character
		// word[dIdx] = word[word.Length-1] which is the
		// last character in the word. Just set the node
		// as a word and return. This is the terminating case
		if (word.Length == dIdx)
		{
			parentNode.IsWord = true;
			return parentNode;
		}

		// The recursive step. 
		char nextChar = word[dIdx];
		Node childNode = AddWord(parentNode.Children[nextChar - 'a'], word, dIdx + 1);
		parentNode.Children[nextChar - 'a'] = childNode;
		return parentNode;
	}


	/** Returns if the word is in the trie. */
	public bool Search(string word)
	{
		Node node = Search(_root, word, 0);
		return node != null && node.IsWord;
	}

	private Node Search(Node parentNode, string word, int dId)
	{
		if (parentNode == null) return null;

		if (word.Length == dId) return parentNode;

		return Search(parentNode.Children[word[dId] - 'a'], word, dId + 1);
	}

	/** Returns if there is any word in the trie that starts with the given prefix. */
	public bool StartsWith(string prefix)
	{
		Node node = Search(_root, prefix, 0);
		return node != null;
	}

	public class Node
	{
		public Node[] Children = new Node[256];
		public bool IsWord = false;
	}

	private Node _root = new Node();
}
