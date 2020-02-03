<Query Kind="Program" />

void Main()
{
	var r = Solution.ReplaceWords(new List<string>() {"cat","bat","rat"},"the cattle was rattled by the battery");	
}

public class Solution
{
	public static string ReplaceWords(IList<string> dict, string sentence)
	{
		Trie trie = new Trie();

		// Add the roots to the trie
		foreach (string root in dict) trie.Insert(root);

		// Get the words in the sentence
		string[] words = sentence.Split(' ');
		
		
		StringBuilder result = new StringBuilder();
		for (int i = 0; i < words.Length; i++)
		{
			var root = trie.GetRoot(words[i]);
			result.Append(root ?? words[i]);
			if (i != words.Length-1) result.Append(" ");
		}
		
		return result.ToString();
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
		public Node[] Children = new Node[26];
		public bool IsWord = false;
	}

	private Node _root = new Node();
}